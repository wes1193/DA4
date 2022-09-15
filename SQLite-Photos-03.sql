-- SQLite
/*
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

