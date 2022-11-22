-- SQLite
SELECT Id, UserName
, Introduction
, PasswordHash, PasswordSalt, Email, Phone, City
, Country, Created, DateOfBirth, Gender
, Interests, KnownAs, LastActive, LookingFor
FROM Users;

insert into users ( UserName, PasswordHash, PasswordSalt, Email, Phone, City, Country, Created, DateOfBirth, Gender, Interests, KnownAs, LastActive, LookingFor, Description, Introduction)
 SELECT  UserName, PasswordHash, PasswordSalt, Email, Phone, City, Country, Created, DateOfBirth, Gender, Interests, KnownAs, LastActive, LookingFor, Description, Introduction
    FROM Users where id = 11;

alter TABLE Users
add Introduction varchar(200);

update Users
set Introduction
= 'Intro: ' || Interests

