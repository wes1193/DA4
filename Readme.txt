
to run the app
1) cd API - dotnet watch run
2) cd client - ng serve

to login to app, use
user name: wes, bob, etc
pswd : Pswd
    
start on Lesson #78

when in the API , CSharp code, use "CTRL+." control + period, to bring in include statements.


do Ctrl+Shft+P then Select
SqlLite: Open Databse

then right-click on users table
and New Query [Select]

SQL to read Users table
SELECT 
    id
    ,UserName
    ,email
    ,Phone
    ,SUBSTR(PasswordHash,1,12) AS [Pswd]
    ,SUBSTR(PasswordSalt,1,12) AS [Salt]
 FROM Users;