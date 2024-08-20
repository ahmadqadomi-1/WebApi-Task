use APITask;
GO
CREATE TABLE Categories (
    CategoryID int identity(1,1) primary key,
    CategoryName varchar(225),
    CategoryImage varchar(225)
);
INSERT INTO Categories (CategoryName, CategoryImage)
VALUES 
('Electronics', 'electronics_image.jpg'),
('Clothing', 'clothing_image.jpg'),
('Home Appliances', 'home_appliances_image.jpg'),
('Books', 'books_image.jpg'),
('Toys', 'toys_image.jpg');


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
('T-shirt', 'Cotton round-neck t-shirt', '19.99', 2, 'tshirt_image.jpg'),
('Microwave', '700W microwave oven with grill', '89.99', 3, 'microwave_image.jpg'),
('Fiction Novel', 'Bestselling fiction novel by popular author', '14.99', 4, 'fiction_novel_image.jpg'),
('Action Figure', 'Superhero action figure for kids', '29.99', 5, 'action_figure_image.jpg');
