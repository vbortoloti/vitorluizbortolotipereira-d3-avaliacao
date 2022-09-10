USE db_27;
GO

CREATE TABLE Users(
	Id					VARCHAR(255) NOT NULL UNIQUE,
	[Name]			    VARCHAR(255) NOT NULL,
	Email				VARCHAR(255) NOT NULL UNIQUE,
	[Password]			VARCHAR(255) NOT NULL
);
GO

INSERT INTO Users (Id, [Name], Email, [Password])
VALUES				 ('1', 'Admin', 'admin@email.com', 'admin123');
GO



SELECT * FROM Users
WHERE Email='admin@email.com';