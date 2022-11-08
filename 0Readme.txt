
start on Lesson #170
- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
to run the app, open 2 terminal windows
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


  SELECT * FROM "sqlite_master" WHERE "name" = '__EFMigrationsHistory' 

      SELECT "MigrationId", "ProductVersion"
      FROM "__EFMigrationsHistory"
      ORDER BY "MigrationId";

 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
to DEBUG
look at lesson #38
make sure the API and client are running
set a breakpoint in c#
in the left NAv pane select the Debug Icon, 4th one down in the list
then click the little green arrow to run teh debugger
it will open a dropdown of processes to attach to
>>>> pick the one with API.exe in it
do the test



 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
BootStrap

https://valor-software.com/ngx-bootstrap/#/documentation#getting-started

BootStrap Tabs
https://valor-software.com/ngx-bootstrap/#/components/tabs?tab=overview

npm install bootstrap@5.2.1


see below for more info on bootstrap
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


go here to get randome pictures
https://randomuser.me/photos

"https://randomuser.me/api/portraits/men/22.jpg"


 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
NPM packages

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
Image Storage 

image storage - Cloudinary
Cloudinary.com
wes1193@comcast.net 
Wesfreda1!

cloud name: dr0dwrdwe
API key: 291912295439282
API Secret: 0btfYHUy65Z4knKmHPEVdhGq1uo
API Environment variable: CLOUDINARY_URL=cloudinary://291912295439282:0btfYHUy65Z4knKmHPEVdhGq1uo@dr0dwrdwe

help docs:
https://cloudinary.com/documentation

for dotnet
https://cloudinary.com/documentation/dotnet_integration

install
https://cloudinary.com/documentation/dotnet_integration#installation

c#
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

configuration
https://cloudinary.com/documentation/dotnet_integration#configuration

Account account = new Account(
    "my_cloud_name",
    "my_api_key",
    "my_api_secret");

Cloudinary cloudinary = new Cloudinary(account);
cloudinary.Api.Secure = true;

https://cloudinary.com/documentation/dotnet_image_and_video_upload

 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
Photo Upload library

ng2-file-upload
https://valor-software.com/ng2-file-upload/

to install , use/run 
npm install ng2-file-upload

or maybe
npm install ng2-file-upload@1.4.0


npm install ng2-file-upload --save



 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
    BootStrap - Additional info
    “bootstrap mb-3 meaning” Code Answer

    bootstrap class="mb-3"css 

    mt- = margin-top
    mb- = margin-bottom
    ml- = margin-left
    mr- = margin-right
    my- = it sets margin-left and margin-right at the same time on y axes
    mX- = it sets margin-bottom and margin-top at the same time on X axes
    Source: stackoverflow.com



 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
npm packages

for date times functionality:
https://npmjs.com/package/ngx-timeago   

npm install ngx-timeago

 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

    MISC:
    Comments out multiple lines
    Comment Code Block 
    Ctrl+K+C
    Ctrl+K+U 

    or ALT+Shift+A


 - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

