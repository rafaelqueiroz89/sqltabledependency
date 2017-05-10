# sqltabledependency
In this repository I am demonstrating how to properly get the SqlTableInjection running, a SQL script is also attached (you will need to run it in your SQL Server). 


In this repository I am demonstrating how to properly get the SqlTableInjection running, a SQL script is also attached (you will need to run it in your SQL Server).

Link to download: https://tabledependency.codeplex.com/

Audit, monitor and receive notifications on table change

SqlTableDependency is a high-level C# component to used to audit, monitor and receive notifications on SQL Server's record table change.

For any record table change, insert update or delete, a notification containing values for the record inserted, changed or deleted is received from SqlTableDependency. This notification contains the update values int the database table.

Compared to Microsoft ADO.NET SqlDependency class, this tracking change system has the advantage of avoid a database select to retrieve updated table record state, because this latest table status is delivered by the received notification.


TO DO: 

- INTERFACE IT ALL
- Summary =)
