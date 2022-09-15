-- SQLite
update Users
set email = KnownAs || '@wesco.com';

SELECT Id, UserName,  Email, Phone, City, 
    Country, Created, DateOfBirth, Gender, 
    Interests, KnownAs, LastActive, LookingFor 
    ,PasswordHash, PasswordSalt
FROM Users;

/*
    update Users
    set email = 'wes@wesco.com'
    where id = 11;
*/