select 
p.parkingLotID,	p.providerID,	p.name, 
p.address,		p.districtId,	p.description,
p.urlPicture,	p.longitud,		p.latitude,
p.LocalPhone,	p.openTime,		p.closeTime,
p.priceHour,	p.status,
v.userID,		
u.lastName	userlastName,
d.name		districtName,
r.name		provinceName,
m.name		departmentName
from	 [dbo].[parkingLot]		p
inner join [dbo].[provider]		v on v.providerID	= p.providerID
inner join [dbo].[user]			u on u.userID		= v.userID
inner join [dbo].[disctrict]	d on d.districtId	= p.districtId
inner join [dbo].[province]		r on r.provinceId	= d.provinceId
inner join [dbo].[department]	m on m.departmentId = r.departmentId;



update [dbo].[parkingLot]
set [districtId]=1290
go

/*Cambiar el nombre de una columna*/
EXEC sp_rename '[dbo].[province].nombre', 'name', 'COLUMN';
GO

/*Inicio de cambio de campos*/
alter table [dbo].[reservation]
alter column [startParking] varchar(20);

alter table [dbo].[reservation]
alter column [finishParking] varchar(20);

select 
 right('00'+ltrim(rtrim(convert(varchar(10), DATEPART ( hour ,   convert(datetime, [startParking] ) )))),2) +':'+
 right('00'+ltrim(rtrim(convert(varchar(10), DATEPART ( minute , convert(datetime, [startParking] ) )))),2) 
,right('00'+ltrim(rtrim(convert(varchar(10), DATEPART ( hour ,   convert(datetime, [finishParking]) )))),2) +':'+
 right('00'+ltrim(rtrim(convert(varchar(10), DATEPART ( minute , convert(datetime, [finishParking]) )))),2) 
from [dbo].[reservation]

update [dbo].[reservation]
set
 [startParking] = right('00'+ltrim(rtrim(convert(varchar(10), DATEPART ( hour ,   convert(datetime, [startParking] ) )))),2) +':'+
				  right('00'+ltrim(rtrim(convert(varchar(10), DATEPART ( minute , convert(datetime, [startParking] ) )))),2) 
,[finishParking]= right('00'+ltrim(rtrim(convert(varchar(10), DATEPART ( hour ,   convert(datetime, [finishParking]) )))),2) +':'+
				  right('00'+ltrim(rtrim(convert(varchar(10), DATEPART ( minute , convert(datetime, [finishParking]) )))),2) 


alter table [dbo].[reservation]
alter column [startParking] varchar(5);

alter table [dbo].[reservation]
alter column [finishParking] varchar(5);

/*Fin de cambio de campos*/

select * from [dbo].[reservation]

select * from [dbo].[parkingLot]
select * from [dbo].[parkingSpace] pl where pl.parkingLotID=1

/*Tablas con Data*/
select * from [dbo].[user]
select * from [dbo].[department]
select * from [dbo].[province] p where p.departmentId=15
select * from [dbo].[disctrict]p where p.provinceId=127
select * from [dbo].[reservation] R WHERE R.UserID=3
/*Selects sin registros*/

/*
select * from [dbo].[reservation]
select * from [dbo].[parkingSpace] pl where pl.parkinglotid=15
select * from [dbo].[parkingLot] 
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
