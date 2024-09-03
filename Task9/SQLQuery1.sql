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


CREATE TABLE UserRoles (
UserID INT,
Role NVARCHAR(50),
CONSTRAINT PK_UserRoles PRIMARY KEY (UserID, Role),
CONSTRAINT FK_UserRole_User FOREIGN KEY (UserID) REFERENCES Users(UserID)
);


select * from Users;
select * from UserRoles;


alter table Users 
alter column PasswordSalt VARBINARY(max)