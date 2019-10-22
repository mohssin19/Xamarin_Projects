use master 
go

drop database if exists IdeasDb
go

create database IdeasDb
go

use IdeasDb
go

create table thoughts(
thoughtId INT IDENTITY PRIMARY KEY NOT NULL,
thoughtIdea varchar(50) NULL,
)

insert into thoughts values ('SQL?');
insert into thoughts values ('HTML5?');
insert into thoughts values ('CSS?');
insert into thoughts values ('JAVASCRIPT?');