
start on Lesson #122  

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
( it's the "DA4" repository )

https://github.com/wes1193/DA4/commits/main

https://github.com/wes1193/DatingApp

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
Json to TypeScript converter - utility

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


 to move changes from ef to the database,
 use "dotnet ef migrations add ExtendedUserEnity "
 or use "dotnet ef migrations remove"

 to commit the migration to the database
 use "dotnet ef database update"

 to DELETE the database, in order to start over
 dotnet ef database drop

 then once the reseed logic is in place, should be able to do
 DOTNET WATCH RUN,  and it will recreate

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

ngx-spinner
http://www.npmjs.com/package/ngx-spinner

cd to here: C:\temp\DatingApp\client
then run this "npm i ngx-spinner@12.0.0"


from 
PS C:\temp\DatingApp\client>   ng add ngx-spinner
when I did this it said it installed, but there was a dependency issue

so, tried this
npm install ngx-spinner --force


his video got an error and he had to installnpm install @angular/cdk
but it got an error for member

 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

