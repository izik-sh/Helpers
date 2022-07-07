--- Snippets ---

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

BEGIN -- Get last update objects
---------------------------------------------------------------------------------------------------------------------------------------------------------
-- List of object types: https://docs.microsoft.com/en-us/sql/relational-databases/system-catalog-views/sys-objects-transact-sql?view=sql-server-ver16 --
---------------------------------------------------------------------------------------------------------------------------------------------------------

SELECT name, create_date, modify_date, type
FROM sys.objects
-- WHERE type in ('P','U','IF')
ORDER BY modify_date DESC
END