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

---------------------------------------------------------------------------------------------------------------------------------------------------------
BEGIN -- Data compare

SELECT * FROM t_MD_BH_RULES
UNION 
SELECT * FROM t_MD_BH_RULES_COMPARE
EXCEPT 
SELECT * FROM t_MD_BH_RULES
INTERSECT
SELECT * FROM t_MD_BH_RULES_COMPARE;
END

---------------------------------------------------------------------------------------------------------------------------------------------------------
BEGIN -- Delete all stored procedure

declare @procName varchar(500)
declare cur cursor 

for select [name] from sys.objects where type = 'p'
open cur
fetch next from cur into @procName
while @@fetch_status = 0
begin
    exec('drop function [' + @procName + ']')
    fetch next from cur into @procName
end
close cur
deallocate cur
END

---------------------------------------------------------------------------------------------------------------------------------------------------------

BEGIN -- Delete all functions

Declare @sql NVARCHAR(MAX) = N'';

SELECT @sql = @sql + N' DROP FUNCTION ' 
                   + QUOTENAME(SCHEMA_NAME(schema_id)) 
                   + N'.' + QUOTENAME(name)
FROM sys.objects
WHERE type_desc LIKE '%FUNCTION%';

Exec sp_executesql @sql
END

---------------------------------------------------------------------------------------------------------------------------------------------------------

BEGIN -- Compare 2 tables schema

-- Replace 'your_table_1' and 'your_table_2' with your table names

-- Compare columns in Table 1 and Table 2
SELECT
    'Table1 vs Table2' AS ComparisonType,
    t1.name AS ColumnNameT1,
	 t2.name AS ColumnNameT2,
    t1.type AS DataType_Table1,
    t2.type AS DataType_Table2,
    t1.is_nullable AS IsNullable_Table1,
    t2.is_nullable AS IsNullable_Table2,
    t1.column_id AS ColumnID_Table1,
    t2.column_id AS ColumnID_Table2,
    CASE 
        WHEN t1.name IS NULL THEN 'Column is in Table 2 but not in Table 1'
        WHEN t2.name IS NULL THEN 'Column is in Table 1 but not in Table 2'
        WHEN t1.type <> t2.type THEN 'Data type mismatch'
        WHEN t1.is_nullable <> t2.is_nullable THEN 'Nullability mismatch'
        ELSE 'No difference'
    END AS DifferenceType
FROM
    -- Columns in Table 1
    (SELECT c.name, ty.name AS type, c.is_nullable, c.column_id
     FROM sys.columns c
     JOIN sys.types ty ON c.user_type_id = ty.user_type_id
     WHERE c.object_id = OBJECT_ID('t_MD_Currency')) t1
FULL OUTER JOIN
    -- Columns in Table 2
    (SELECT c.name, ty.name AS type, c.is_nullable, c.column_id
     FROM sys.columns c
     JOIN sys.types ty ON c.user_type_id = ty.user_type_id
     WHERE c.object_id = OBJECT_ID('t_MD_Currency_Test')) t2
ON t1.name = t2.name
ORDER BY ColumnNameT1;

END
*/