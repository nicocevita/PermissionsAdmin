use AdminPermissions

CREATE TABLE PermissionTypes
(
Id INT PRIMARY KEY IDENTITY(1,1) ,
Description VARCHAR (50) NOT NULL
);

CREATE TABLE Permissions
(
Id INT PRIMARY KEY IDENTITY(1,1),
EmployeeFirstname varchar(50) NOT NULL ,
EmployeeLastname varchar(50) NOT NULL ,
PermissionType int NOT NULL ,
PermissionDate DATETIME NOT NULL,
CONSTRAINT FK_PermissionTypeID
FOREIGN KEY (PermissionType) REFERENCES PermissionTypes(id)
);

insert into PermissionTypes(Description) values ('vacation'),('sickness')
