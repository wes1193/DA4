
start on Lesson #99

- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
to run the app
1) cd API - dotnet watch run
2) cd client - ng serve

- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
to login to app, use
user name: wes, bob, etc
pswd : Pswd

- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

Course source files:
Source Code - github
https://github.com/TryCatchLearn/DatingApp

working code for each section is here
https://github.com/TryCatchLearn/DatingApp/commits/master


My GitHub repo:
https://github.com/wes1193/DatingApp
it's the "DA4" repository
- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
CTRL+.
when in the API , CSharp code, 
use "CTRL+." control + period, 
to bring in using / include statements.

- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
seed data PasswordHash
user.PasswordHash = hmac.ComputeHash(Encoding.UT8.GetBytes("Pa$$w0rd"));

- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
Automapper
do Ctrl+Shft+P then Select
NuGet Gallery
from there, search on "Automapper"  and select the one for 
Automapper.Extensions.Microsoft.DependencyInjection (by Jimmy Bogard)


- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
do Ctrl+Shft+P then Select
SqlLite: Open Database

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


 to move changes from ef to the database,
 use " dotnet ef migrations add ExtendedUserEnity "
 or use "dotnet ef migrations remove"

 to commit the migration to the database
 use "dotnet ef database update"

 to delete the database, in order to start over
 dotnet ef database drop

 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
to Debug
look at lesson #38

 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 


 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 


 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 