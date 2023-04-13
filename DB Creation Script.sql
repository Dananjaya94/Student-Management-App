CREATE DATABASE StudentDB;

CREATE TABLE Student(
	
	id int IDENTITY(1,1) PRIMARY KEY,
    FirstName varchar(255),
    LastName varchar(255),
	Address varchar(255),
    City varchar(255)
);

insert into Student
values('Sahan','Gunasekara','Maliban Junction','Rathmalana');

insert into Student
values('Rakith','Wicks','Maliban Junction','Rathmalana');

insert into Student
values('Dilshan','Praboda','Maliban Junction','Rathmalana');

insert into Student
values('Buddhika','Devapura','Maliban Junction','Rathmalana');

insert into Student
values('Prageeth','Lakshan','Maliban Junction','Rathmalana');