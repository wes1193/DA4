/* to add columns
run  dotnet ef database drop
add the column ALTER TABLE 

 then once the reseed logic is in place, should be able to do

 DOTNET WATCH RUN,  and it will recreate

*/

-- SQLite

--create a new user from existing one
insert into users ( UserName, KnownAs, Gender, Email,   Phone, City, Country, Created, DateOfBirth,  Interests, LastActive, LookingFor, Description, Introduction , PasswordHash, PasswordSalt)
 SELECT  'susan', 'sue', 'female', knownAs || '@wes.com',   Phone, City, Country, Created, DateOfBirth,  Interests,  LastActive, LookingFor, Description, Introduction ,PasswordHash, PasswordSalt
    FROM Users where id = 11
    ;

    delete from users where id  = 28


 SELECT  id, UserName, PasswordHash, PasswordSalt, Email, Phone, City, Country, Created, DateOfBirth, Gender, Interests, KnownAs, LastActive, LookingFor, Description, Introduction
    FROM Users;

    update 
    Users 
    set username = 'Rebecca',
    KnownAs = 'becky' ,
    email = 'becky@wes.com'
    where id = 27;



/*SELECT Id, UserName,  Description, Email, Phone
, City, Country, Created, DateOfBirth, Gender, Interests, KnownAs, LastActive
, LookingFor
FROM Users;
-- SQLite
ALTER TABLE Users 
ADD COLUMN Description Text;

update Users
set phone = '727-456-7080'
, city = 'Jax'
, country = 'USA'
, gender  = 'male'
, KnownAs = 'Wes'
where ID in (3);

SELECT 
Id, UserName
, Email, Phone, City, Country
, Created, DateOfBirth, Gender
, Interests, KnownAs, LastActive, LookingFor
, PasswordHash, PasswordSalt
FROM Users
where ID in (11,3);

ALTER TABLE Users 
ADD COLUMN Description Text;

ALTER TABLE Users
ADD Introduction TEXT;

SELECT Id, Url, IsMain, PublicId, AppUserId
FROM Photos;

ALTER TABLE Users 
ADD COLUMN Introduction Text;



update Users
set 
Description = 'Desc: ' || Description
, Introduction = 'Intro: ' || Introduction

SELECT 
    id
    ,UserName
    ,email
    ,Phone
    ,SUBSTR(PasswordHash,1,12) AS [Pswd]
    ,SUBSTR(PasswordSalt,1,12) AS [Salt]
 FROM Users;
 update Users
set username  = 'lisa'
where id = 15 ;

update Users
set 
email  = username || '@wesco.com'

update Users
set 
phone  = '907 845-7812'
*/


    update 
    Users 
    set username = 'Rebecca',
    KnownAs = 'becky' ,
    email = 'becky@wes.com'
    where id = 27;

SELECT Id, UserName
, substr(Description,1,20) as "DESC" 
, substr(Introduction,1,20) as "Intro"
,Email, Phone, City, Country, Created,
 DateOfBirth,
 Gender, Interests, KnownAs, LastActive, 
 LookingFor, PasswordHash, PasswordSalt
FROM Users;

-- SQLite
SELECT SourceUserId, LikedUserId
FROM Likes;

SELECT "t"."Id", "t"."City", "t"."Country", "t"."Created", "t"."DateOfBirth", "t"."Description", "t"."Email", "t"."Gender", "t"."Interests", "t"."Introduction", "t"."KnownAs", "t"."LastActive", "t"."LookingFor", "t"."PasswordHash", "t"."PasswordSalt", 
"t"."Phone", "t"."UserName", "p"."Id", "p"."AppUserId", "p"."IsMain", "p"."PublicId", "p"."Url"
      FROM (
          SELECT "u"."Id", "u"."City", "u"."Country", "u"."Created", "u"."DateOfBirth", "u"."Description", "u"."Email", "u"."Gender", "u"."Interests", "u"."Introduction", "u"."KnownAs", "u"."LastActive", "u"."LookingFor", "u"."PasswordHash", "u"."PasswordSalt", "u"."Phone", "u"."UserName"
          FROM "Users" AS "u"
          WHERE "u"."UserName" = 'cruz'
          LIMIT 2
      ) AS "t"
      LEFT JOIN "Photos" AS "p" ON "t"."Id" = "p"."AppUserId"
      ORDER BY "t"."Id";