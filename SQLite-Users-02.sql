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

