/*Tablas con Data*/
select * from [dbo].[user]
select * from [dbo].[department]
select * from [dbo].[province]
select * from [dbo].[disctrict]

/*Selects sin registros*/
select * from [dbo].[parkingLot]
select * from [dbo].[reservation]
select * from [dbo].[parkingSpace]
/*
select * from [dbo].[provider]
select * from [dbo].[user]
select * from [dbo].[department]
select * from [dbo].[province]
select * from [dbo].[disctrict]
*/
update [dbo].[user] set status=1
 
drop table [dbo].[reservation]
drop table [dbo].[parkingSpace]
drop table [dbo].[parkingLot]
drop table [dbo].[provider]
drop table [dbo].[user]
drop table [dbo].[disctrict]
drop table [dbo].[province]
drop table [dbo].[department]

truncate table [dbo].[disctrict]
delete [dbo].[province]
delete  [dbo].[department]

DBCC CHECKIDENT ('dbo.province', RESEED,0)
DBCC CHECKIDENT ('dbo.department', RESEED,0)


SELECT * FROM dbo.disctrict d where d.name like '%surco%'
SELECT * FROM [dbo].[provider]
alter table [dbo].[parkingLot] 
drop column [department]


SELECT * FROM [dbo].[user] u where u.userID in (
SELECT p.userID FROM [dbo].[provider] p)
SELECT * FROM [dbo].[parkingLot]
