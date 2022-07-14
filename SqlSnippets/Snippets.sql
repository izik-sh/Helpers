-- ********************
-- *** Sql Snippets ***
-- ********************

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
    WHERE [...]

END
---------------------------------------------------------------------------------------------------------------------------------------------------------