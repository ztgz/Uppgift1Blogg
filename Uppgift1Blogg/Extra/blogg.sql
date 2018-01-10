use master;
go

create database Blogg;
go

use Blogg;
go

create table Category(
	ID int identity(1,1) primary key,
	Name varchar(50)
);

insert into Category(Name)
values('C#'),('JAVA'),('JavaScript'),('HTML');

create table BlogPost(
	ID int identity(1,1) primary key,
	Header varchar(50),
	Content varchar(2000),
	Date date,
	CategoryID int foreign key references Category(ID)
);

insert into BlogPost(Header, Content, Date, CategoryID)
values('C# intro', 'Det rekomenderas att du använder visual studio community när du
 börjar med C#', '2018-01-02' ,1);

