CREATE DATABASE StudentDB;

CREATE TABLE Student(
	id int IDENTITY(1,1) PRIMARY KEY,
	FirstName varchar(255),
	LastName varchar(255),
	Address varchar(255),
	City varchar(255)
);

insert into Student
values('Eric','Brian','SA','CA');

insert into Student
values('Bill','Chen','Guanzhou','China');

insert into Student
values('Rick','Martin','Las Vegas','Texas');