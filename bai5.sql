create database administrative_management;
go

use administrative_management;

create table account(
email varchar(50) primary key,
password varchar(20) not null
)

insert into account values ('admin@it.com', '123456'), ('hai@it.com', '123456');

create table absence_letter(
employee_name varchar(50) not null,
department varchar(15),
totalDate int,
from_date varchar(10) not null,
to_date varchar(10) not null,
note varchar(200)
)

ALTER TABLE absence_letter ADD CONSTRAINT PK_absence_letter PRIMARY KEY (employee_name,from_date,to_date);