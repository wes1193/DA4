-- SQLite
update Users
set email = UserName || '@will.com'
where email is null;

update Users
set Phone =  '8004569873'
where Phone is null;

SELECT 
    id
    ,UserName
    ,email
    ,Phone
    ,SUBSTR(PasswordHash,1,12) AS [Pswd]
    ,SUBSTR(PasswordSalt,1,12) AS [Salt]
 FROM Users;