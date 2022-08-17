-- SQLite
SELECT 
    id
    ,UserName
    ,email
    ,Phone
    ,SUBSTR(PasswordHash,1,12) AS [Pswd]
    ,SUBSTR(PasswordSalt,1,12) AS [Salt]
 FROM Users;