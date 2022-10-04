-- SQLite
SELECT Id, UserName
, Introduction
, PasswordHash, PasswordSalt, Email, Phone, City
, Country, Created, DateOfBirth, Gender
, Interests, KnownAs, LastActive, LookingFor
FROM Users;

alter TABLE Users
add Introduction varchar(200);

update Users
set Introduction
= 'Intro: ' || Interests

