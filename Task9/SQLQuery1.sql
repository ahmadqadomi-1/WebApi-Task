USE Task9;
GO;
DROP TABLE IF EXISTS Users;
CREATE TABLE Users (
    UserID int identity(1,1) primary key,
    Username VARCHAR(60),
    PasswordHash VARBINARY(64),  
    PasswordSalt VARBINARY(32),  
    Email VARCHAR(255)
);
INSERT INTO Users (Username, PasswordHash, PasswordSalt, Email) 
VALUES 
('user1', 0xAA123456789, 0xAA123456789, 'user1@example.com'),
('user2', 0xAB123456789, 0xAB123456789, 'user2@example.com'),
('user3', 0xAC123456789, 0xAC123456789, 'user3@example.com'),
('user4', 0xAD123456789, 0xAD123456789, 'user4@example.com'),
('user5', 0xAE123456789, 0xAE123456789, 'user5@example.com');

CREATE TABLE UserRoles (
UserID INT,
Role NVARCHAR(50),
CONSTRAINT PK_UserRoles PRIMARY KEY (UserID, Role),
CONSTRAINT FK_UserRole_User FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
INSERT INTO UserRoles (UserID, Role)
VALUES
(1, 'Admin'),
(2, 'Client');

select * from Users;
select * from UserRoles;