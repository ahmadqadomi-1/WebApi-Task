use APITASK2;
GO
CREATE TABLE Categories (
    CategoryID int identity(1,1) primary key,
    CategoryName varchar(225),
    CategoryImage varchar(225)
);
INSERT INTO Categories (CategoryName, CategoryImage)
VALUES 
('Electronics', 'https://i1.sndcdn.com/artworks-000480252444-q5nocl-t500x500.jpg'),
('Clothing', 'https://i1.sndcdn.com/artworks-000386097702-iqikhu-t240x240.jpg'),
('Home Appliances', 'https://mir-s3-cdn-cf.behance.net/projects/404/2f673799249051.5eee8d8cd521f.png'),
('Books', 'https://i1.sndcdn.com/artworks-000407211156-ylwh3a-t500x500.jpg'),
('Toys', 'https://i1.sndcdn.com/artworks-ID5A1rQliUT33oEJ-7ItCAw-t240x240.jpg');


CREATE TABLE Products (
    ProductID int identity(1,1) primary key,
    ProductName varchar(225), 
    Description varchar(225),
    Price varchar(225),
    CategoryID int,
    ProductImage varchar(MAX),
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);
INSERT INTO Products (ProductName, Description, Price, CategoryID, ProductImage)
VALUES 
('Smartphone', 'Latest model with advanced features', '599.99', 1, 'smartphone_image.jpg'),
('Smartphone', 'Latest model with advanced features', '99.99', 1, 'smartphone_image.jpg'),
('Smartphone', 'Latest model with advanced features', '299.99', 1, 'smartphone_image.jpg'),
('T-shirt', 'Cotton round-neck t-shirt', '19.99', 2, 'tshirt_image.jpg'),
('Microwave', '700W microwave oven with grill', '89.99', 3, 'microwave_image.jpg'),
('Fiction Novel', 'Bestselling fiction novel by popular author', '14.99', 4, 'fiction_novel_image.jpg'),
('Action Figure', 'Superhero action figure for kids', '29.99', 5, 'action_figure_image.jpg');


CREATE TABLE Users (
UserID int identity(1,1) primary key,
Username Varchar (255),
Password Varchar (255),
Email Varchar (255),
ProductID int,
CategoryID int,
 FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID),
  FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);
INSERT INTO Users (Username, Password, Email, ProductID, CategoryID) 
VALUES 
('john_doe', 'password123', 'john.doe@example.com', 1, 1),
('jane_smith', 'securePass!45', 'jane.smith@example.com', 2, 2),
('mike_brown', 'Pass@2023', 'mike.brown@example.com', 3, 3),
('susan_jones', 'Pa55w0rd!', 'susan.jones@example.com', 4, 4),
('tom_white', 'White1234', 'tom.white@example.com', 5, 5);

CREATE TABLE Orders (
OrderID int identity(1,1) primary key,
OrderName Varchar (255),
UserID int,
OrderDate Date,
  FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
INSERT INTO Orders (OrderName, UserID, OrderDate) 
VALUES 
('Order 001', 1, '2024-08-01'),
('Order 002', 2, '2024-08-02'),
('Order 003', 3, '2024-08-03'),
('Order 004', 4, '2024-08-04'),
('Order 005', 5, '2024-08-05');


CREATE TABLE Order_Table (
Order_Table int identity(1,1) primary key,
OrderID int,
UserID int,
FOREIGN KEY (UserID) REFERENCES Users(UserID),
FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);
INSERT INTO Order_Table (OrderID, UserID) 
VALUES 
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5);


select * from Categories;
select * from Orders;
select * from Users;
select * from Order_Table;