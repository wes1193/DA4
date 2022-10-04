/* to add columns
run  dotnet ef database drop
add the column ALTER TABLE 

 then once the reseed logic is in place, should be able to do

 DOTNET WATCH RUN,  and it will recreate

*/



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




SELECT Id, UserName
, substr(Description,1,20) as "DESC" 
, substr(Introduction,1,20) as "Intro"
,Email, Phone, City, Country, Created,
 DateOfBirth,
 Gender, Interests, KnownAs, LastActive, 
 LookingFor, PasswordHash, PasswordSalt
FROM Users
