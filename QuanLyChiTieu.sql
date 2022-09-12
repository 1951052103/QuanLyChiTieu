CREATE DATABASE QuanLyChiTieu;

USE QuanLyChiTieu;

CREATE TABLE Users (
    Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Username varchar(15) NOT NULL UNIQUE,
	Pass varchar(255) NOT NULL,
    FirstName varchar(255) NOT NULL,
	LastName varchar(255) DEFAULT NULL,
	Active bit DEFAULT 1
);

INSERT INTO Users (Username, Pass, FirstName)
VALUES ('user', '$2a$10$IMc.iLFc2GlER.1nZT2or.IKqqnSB76N6Y5YRMHtYABYWrnPnExIK', 'user'),
('admin', '$2a$10$IMc.iLFc2GlER.1nZT2or.IKqqnSB76N6Y5YRMHtYABYWrnPnExIK', 'admin');

CREATE TABLE Groups (
	Id int NOT NULL IDENTITY(1,1) PRIMARY KEY ,
    GroupName varchar(255) NOT NULL,
    Active bit DEFAULT 1
);

INSERT INTO Groups (GroupName)
VALUES ('Group 1'), ('Group 2');

CREATE TABLE Groups_Users (
	Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    GroupId int DEFAULT NULL,
	UserId int DEFAULT NULL,
    IsGroupLeader bit DEFAULT 0,
    JoinDate date DEFAULT GETDATE(),
    Active bit DEFAULT 1,
	FOREIGN KEY (GroupId) REFERENCES Groups(Id) ON DELETE SET NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE SET NULL
);

INSERT INTO Groups_Users (GroupId, UserId, IsGroupLeader)
VALUES (1, 1, 0), (1, 2, 1);

CREATE TABLE IncomeAndExpense (
    Id int NOT NULL IDENTITY(1,1) PRIMARY KEY ,
	UserId int DEFAULT NULL,
	GroupId int DEFAULT NULL,
    Amount decimal(12,2) DEFAULT 0,
    Reason varchar(255) DEFAULT NULL,
	Detail text DEFAULT NULL,
	Date date DEFAULT GETDATE(),
	IsIncome bit DEFAULT 1,
	Approved bit DEFAULT 1,
    Confirmed bit DEFAULT 1,
	Active bit DEFAULT 1,
    FOREIGN KEY (GroupId) REFERENCES Groups(Id) ON DELETE SET NULL,
    FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE SET NULL
);

INSERT INTO IncomeAndExpense (UserId, GroupId, Amount, Reason, IsIncome)
VALUES (1, NULL, 1000000, 'salary', 1),
(1, NULL, 1000000, 'salary', 1),
(1, NULL, 1000000, 'salary', 1),
(1, NULL, 1000000, 'salary', 1),
(1, NULL, 1000000, 'spending', 0),
(1, NULL, 1000000, 'spending', 0),
(1, NULL, 1000000, 'spending', 0);