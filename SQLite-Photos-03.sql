-- SQLite
/*

-- SQLite

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

insert into Photos
(Url
, IsMain
, PublicId
, AppUserId)
values (
'https://randomuser.me/api/portraits/men/79.jpg'
,1
, NULL
, 11
);

-- delete from photos where id = 12;

update Photos
set url = 'https://randomuser.me/api/portraits/women/49.jpg'
where id = 4;
*/
SELECT 
Id, Url, IsMain
, PublicId
, AppUserId
FROM Photos;

