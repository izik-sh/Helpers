-- ********************
-- *** Sql Snippets ***
-- ********************
/*
---------------------------------------------------------------------------------------------------------------------------------------------------------
BEGIN -- Find text in objects
    SELECT DISTINCT
           o.name AS Object_Name,
           o.type_desc
    FROM sys.sql_modules m
           INNER JOIN
           sys.objects o
             ON m.object_id = o.object_id
    WHERE m.definition Like '%some text to find';
END
---------------------------------------------------------------------------------------------------------------------------------------------------------
BEGIN -- Get last update objects

    SELECT name, create_date, modify_date, type
    FROM sys.objects
    -- WHERE type in ('P','U','IF')
    ORDER BY modify_date DESC
    -- List of object types: https://docs.microsoft.com/en-us/sql/relational-databases/system-catalog-views/sys-objects-transact-sql?view=sql-server-ver16 --

END
---------------------------------------------------------------------------------------------------------------------------------------------------------
BEGIN -- Get activities params

    BEGIN -- Get last connections executues
       SELECT * FROM sys.dm_exec_connections
    END 

    BEGIN -- Example 1 
       SELECT  
       CONNECTIONPROPERTY('net_transport') AS net_transport,
       CONNECTIONPROPERTY('protocol_type') AS protocol_type,
       CONNECTIONPROPERTY('auth_scheme') AS auth_scheme,
       CONNECTIONPROPERTY('local_net_address') AS local_net_address,
       CONNECTIONPROPERTY('local_tcp_port') AS local_tcp_port,
       CONNECTIONPROPERTY('client_net_address') AS client_net_address,
       CURRENT_USER AS 'CURRENT_USER',
       SERVERPROPERTY ('property_name') AS 'propertyname',
       SERVERPROPERTY('MachineName') AS 'MachineName',
       HOST_NAME() as 'HOST_NAME'
    END

    BEGIN -- Example 2
           SELECT hostname,
                  net_library,
                  net_address,
                  client_net_address
        FROM sys.sysprocesses AS S
        INNER JOIN sys.dm_exec_connections AS decc ON S.spid = decc.session_id
        WHERE spid = @@SPID
    END
END
---------------------------------------------------------------------------------------------------------------------------------------------------------
BEGIN -- Backup / copy table to new table
    
    SELECT * INTO DESTINATION_TABLE_NAME
    FROM SOURCE_TABLE_NAME
    --WHERE [...]

END
---------------------------------------------------------------------------------------------------------------------------------------------------------
BEGIN -- Delete duplicated rows
    IF OBJECT_ID('tempdb..#DuplicateTest') is not null
    BEGIN
	    DROP TABLE #DuplicateTest
    END

    CREATE TABLE #DuplicateTest (ID INT, FirstName NVARCHAR(50),LastName NVARCHAR(50))

    DELETE FROM #DuplicateTest
    INSERT INTO #DuplicateTest VALUES(1, 'Bob','Smith') 
    INSERT INTO #DuplicateTest VALUES(2, 'Dave','Jones') 
    INSERT INTO #DuplicateTest VALUES(3, 'Karen','White') 
    INSERT INTO #DuplicateTest VALUES(1, 'Bob','Smith')
    INSERT INTO #DuplicateTest VALUES(7, 'Bob','Smith')	
    INSERT INTO #DuplicateTest VALUES(7, 'Bob','Smith')	
    INSERT INTO #DuplicateTest VALUES(7, 'Bob','Smith 2')
    INSERT INTO #DuplicateTest VALUES(8, 'Bob','Smith 2')	


    SELECT * FROM #DuplicateTest; 

    DELETE FROM a
    FROM #DuplicateTest a
    JOIN
    (
    SELECT MAX(%%lockres%%) pseudoID, FirstName, LastName
    FROM #DuplicateTest
    GROUP BY  FirstName, LastName
    ) b ON b.LastName = a.LastName AND b.FirstName = a.FirstName AND b.pseudoID <> a.%%lockres%%

    SELECT * FROM #DuplicateTest ORDER BY ID 
END
---------------------------------------------------------------------------------------------------------------------------------------------------------
BEGIN -- Dynamic PIVOT
DECLARE @cols AS NVARCHAR(MAX),
        @query  AS NVARCHAR(MAX)

select @cols = STUFF((SELECT distinct ',' + QUOTENAME(AssignmentName) 
                    from yourtable
            FOR XML PATH(''), TYPE
            ).value('.', 'NVARCHAR(MAX)') 
        ,1,1,'')

set @query = 'SELECT StudentName, ' + @cols + ' from 
             (
                select StudentName, AssignmentName, grade
                from yourtable
            ) x
            pivot 
            (
                min(grade)
                for assignmentname in (' + @cols + ')
            ) p '

execute(@query)
END
---------------------------------------------------------------------------------------------------------------------------------------------------------
BEGIN -- Count with join

SELECT COUNT(*) TotalCount, 
        category.category_id, 
        category.category_name 
FROM    [izik-sh_pDB].[dbo].d_catagories_to_song cts
        INNER JOIN [d_categories] category
          ON cts.category_id = category.category_id 
GROUP BY category.category_id, category.category_name
END



*/