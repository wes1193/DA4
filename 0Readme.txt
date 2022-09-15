
start on Lesson #113 

- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
to run the app
1) cd API - dotnet watch run
2) cd client - ng serve

- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
to login to app, use
user name: wes, bob, etc
pswd : Pa$$w0rd
or for wes, use password

- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

Course source files:
Source Code - github
https://github.com/TryCatchLearn/DatingApp

working code for each section is here
https://github.com/TryCatchLearn/DatingApp/commits/master


My GitHub repo:
https://github.com/wes1193/DatingApp
it's the "DA4" repository

"# DA4" 
"# DA4" 

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
TypeScript
Json to TypeScript converter

cut json from PostScript call to GetUsers, pick one json result from the list
and go here. and paste it it
https://jsonformatter.org/json-to-typescript


- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
Data / Database

do Ctrl+Shft+P then Select
SqlLite: Open Database

then right-click on users table
and New Query [Select]

Sample Data provided for this course:
C:\temp\DatingApp\StudentAssets\UserSeedData.json

SQL:
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
BootStrap

https://valor-software.com/ngx-bootstrap/#/documentation#getting-started

BootStrap Tabs
https://valor-software.com/ngx-bootstrap/#/components/tabs?tab=overview


 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
CSS Styles
copy and paste from there
C:\temp\DatingApp\StudentAssets\snippets\member-tabs-css.txt

to
client\src\styles.css
C:\temp\DatingApp\client\src\styles.css

 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

 Security / Certificates
 C:\temp\DatingApp\StudentAssets\generateTrustedSSL
 
 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
images Gallery
https://www.npmjs.com/package/@kolkov/ngx-gallery

use this to install an older version
npm i @kolkov/ngx-gallery@1.2.4

npm install @kolkov/ngx-gallery 

go here for usage instructions ?
https://github.com/kolkov/ngx-gallery#readme

 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

