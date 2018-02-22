create database Vidalink;

Create Table UserProfile  
(  
    [UserId] int primary key identity(1, 1),  
    [UserName] varchar(50),  
    [Password] varchar(50),  
    [Active] bit not null default (0) 
); 

CREATE TABLE Task (
	[TaskId] int not null primary key identity(1,1),
	[UserId]	int NOT NULL foreign key(UserId) references UserProfile(UserId),
    [Title] varchar (180) not null,
	[Description] varchar (max) not null,
    [ExecDate] datetime     not null,
    [Active] bit not null default (0) 
);

Insert into UserProfile  
Select 'admin', '1234', 1

Insert into Task  
Select 1,'Primeira', 'Testando task', '2018-02-22T00:00:00',1 union all
Select 1,'Segunda', 'Testando task', '2018-02-19T00:00:00',1 union all
Select 1,'Terceira', 'Testando task', '2018-02-15T00:00:00',1 union all
Select 1,'Quarta', 'Testando task', '2018-02-03T00:00:00',1 union all
Select 1,'Quinta', 'Testando task', '2018-02-01T00:00:00',1 union all
Select 1,'Sexta', 'Testando task', '2018-01-06T00:00:00',1 union all
Select 1,'Setima', 'Testando task', '2018-01-17T00:00:00',1 union all
Select 1,'Oitava', 'Testando task', '2017-12-15T00:00:00',1 union all
Select 1,'Nona', 'Testando task', '2017-02-14T00:00:00',1 union all
Select 1,'Decima', 'Testando task', '2017-09-05T00:00:00',1