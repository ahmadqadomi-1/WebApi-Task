USE APITASK4;
GO

------------------------------------------------------Break------------------------------------------------------!
CREATE TABLE Categories (
    CategoryID INT IDENTITY(1,1) PRIMARY KEY,
    CategoryName VARCHAR(225),
    CategoryImage VARCHAR(MAX)
);
INSERT INTO Categories (CategoryName, CategoryImage)
VALUES 
('Electronics', 'electronics_image.jpg'),
('Clothing', 'clothing_image.jpg'),
('Home Appliances', 'home_appliances_image.jpg'),
('Books', 'books_image.jpg'),
('Toys', 'toys_image.jpg');

------------------------------------------------------Break------------------------------------------------------!
CREATE TABLE Products (
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX),
    Price DECIMAL(10, 2) NOT NULL,
    CategoryID INT,
    ProductImage NVARCHAR(MAX), 
    CONSTRAINT FK_CategoryID FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);
INSERT INTO Products (ProductName, Description, Price, CategoryID, ProductImage)
VALUES 
('Smartphone', 'Latest model with advanced features', 599.99, 1, 'smartphone_image.jpg'),
('T-shirt', 'Cotton round-neck t-shirt', 19.99, 2, 'tshirt_image.jpg'),
('Microwave', '700W microwave oven with grill', 89.99, 3, 'microwave_image.jpg'),
('Fiction Novel', 'Bestselling fiction novel by popular author', 14.99, 4, 'fiction_novel_image.jpg'),
('Action Figure', 'Superhero action figure for kids', 29.99, 5, 'action_figure_image.jpg');

------------------------------------------------------Break------------------------------------------------------!
CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    Username VARCHAR(255),
    Password VARCHAR(255),
    Email VARCHAR(255),
    ProductID INT,
    CategoryID INT,
    CONSTRAINT FK_CategoryID_User FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID),
    CONSTRAINT FK_ProductID_User FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
INSERT INTO Users (Username, Password, Email, ProductID, CategoryID) 
VALUES 
('john_doe', 'password123', 'john.doe@example.com', 1, 1),
('jane_smith', 'securePass!45', 'jane.smith@example.com', 2, 2),
('mike_brown', 'Pass@2023', 'mike.brown@example.com', 3, 3),
('susan_jones', 'Pa55w0rd!', 'susan.jones@example.com', 4, 4),
('tom_white', 'White1234', 'tom.white@example.com', 5, 5);

------------------------------------------------------Break------------------------------------------------------!
CREATE TABLE Carts (
    CartID INT IDENTITY(1,1) PRIMARY KEY,
    UserID INT UNIQUE,
    CONSTRAINT FK_UserCart FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
INSERT INTO Carts (UserID)
VALUES 
(1),  
(2),  
(3),  
(4),  
(5);  
------------------------------------------------------Break------------------------------------------------------!
CREATE TABLE CartItems (
    CartItemID INT IDENTITY(1,1) PRIMARY KEY,
    CartID INT,
    ProductID INT,
    Quantity INT NOT NULL,
    CONSTRAINT FK_Cart FOREIGN KEY (CartID) REFERENCES Carts(CartID),
    CONSTRAINT FK_Product FOREIGN KEY (ProductID) REFERENCES Products(ProductID),
    UNIQUE (CartID, ProductID)
);
INSERT INTO CartItems (CartID, ProductID, Quantity)
VALUES 
(1, 1, 1),  
(1, 2, 2),  
(2, 3, 1),  
(3, 4, 3),  
(4, 5, 1);  
------------------------------------------------------Break------------------------------------------------------!
SELECT * FROM Categories;
SELECT * FROM Products;
SELECT * FROM Users;
SELECT * FROM Carts;
SELECT * FROM CartItems;
