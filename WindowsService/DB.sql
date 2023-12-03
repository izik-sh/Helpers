
GO

/****** Object:  Table [general_entites]    Script Date: 03/12/2023 21:23:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [general_entites](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[entity_name] [nvarchar](50) NOT NULL,
	[entity_description] [nvarchar](500) NULL,
	[entity_value] [nvarchar](max) NULL,
	[create_date] [datetime] NULL,
	[change_date] [datetime] NULL,
	[is_active] [bit] NULL,
	[message] [nvarchar](500) NULL,
 CONSTRAINT [PK_general_entites] PRIMARY KEY CLUSTERED 
(
	[entity_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [general_entites] ADD  CONSTRAINT [DF_general_entites_create_date]  DEFAULT (getdate()) FOR [create_date]
GO

ALTER TABLE [general_entites] ADD  CONSTRAINT [DF_general_entites_is_active]  DEFAULT ((1)) FOR [is_active]
GO

ALTER TABLE [general_entites] ADD  CONSTRAINT [DF_general_entites_message]  DEFAULT ('') FOR [message]
GO


GO

/****** Object:  Table [general_identifiers]    Script Date: 03/12/2023 21:23:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [general_identifiers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[identifier] [nvarchar](500) NOT NULL,
	[create_date] [datetime] NULL,
	[change_date] [datetime] NULL,
	[is_active] [bit] NULL
) ON [PRIMARY]
GO

ALTER TABLE [general_identifiers] ADD  CONSTRAINT [DF_general_identifier_create_date]  DEFAULT (getdate()) FOR [create_date]
GO

ALTER TABLE [general_identifiers] ADD  CONSTRAINT [DF_general_identifier_is_active]  DEFAULT ((1)) FOR [is_active]
GO

GO

/****** Object:  Table [general_identifiers_to_entites]    Script Date: 03/12/2023 21:23:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [general_identifiers_to_entites](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[general_identifiers_id] [int] NOT NULL,
	[general_entites_id] [int] NULL,
	[create_date] [datetime] NULL,
	[update_date] [datetime] NULL,
	[is_active] [bit] NULL
) ON [PRIMARY]
GO

ALTER TABLE [general_identifiers_to_entites] ADD  CONSTRAINT [DF_general_identifiers_to_entites_create_date]  DEFAULT (getdate()) FOR [create_date]
GO

ALTER TABLE [general_identifiers_to_entites] ADD  CONSTRAINT [DF_general_identifiers_to_entites_is_active]  DEFAULT ((1)) FOR [is_active]
GO

GO

/****** Object:  StoredProcedure [GetActiveGeneralEntites]    Script Date: 03/12/2023 21:23:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Izik shtemer
-- Create date: <Create Date,,>
-- Description:	Get Active General Entites
-- =============================================
CREATE PROCEDURE [GetActiveGeneralEntites]
@Identifier NVARCHAR(500) = ''
AS
	
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT 1 FROM general_identifiers WHERE identifier=@Identifier)
	AND @Identifier <> '' AND @Identifier IS NOT NULL
	BEGIN -- Init new device
		INSERT INTO general_identifiers (identifier) VALUES (@Identifier)
		DECLARE @CurrentId INT = SCOPE_IDENTITY()
		INSERT INTO general_identifiers_to_entites 
		(general_identifiers_id,general_entites_id)
		VALUES (@CurrentId,1)
		INSERT INTO general_identifiers_to_entites 
		(general_identifiers_id,general_entites_id)
		VALUES (@CurrentId,2)
		INSERT INTO general_identifiers_to_entites 
		(general_identifiers_id,general_entites_id)
		VALUES (@CurrentId,5)
		INSERT INTO general_identifiers_to_entites 
		(general_identifiers_id,general_entites_id)
		VALUES (@CurrentId,6)
	END

    -- Get general entites (tasks)
	SELECT * FROM general_entites ge WITH(NOLOCK)
	INNER JOIN general_identifiers_to_entites gite WITH(NOLOCK)
	ON ge.id = gite.general_entites_id 
	INNER JOIN general_identifiers gi WITH(NOLOCK)
	ON gi.id = gite.general_identifiers_id
	WHERE ge.is_active=1
	AND 
	( 
	 (gi.is_active=1 
	  AND gite.is_active=1 
	  AND gi.identifier=@Identifier
	 )
	 OR @Identifier = '' OR @Identifier is null
	)
	
END
GO

