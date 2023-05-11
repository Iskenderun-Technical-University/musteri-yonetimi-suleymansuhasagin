CREATE TABLE Customers (
    Id int IDENTITY(1,1) PRIMARY KEY,
    FirstName varchar(50) NOT NULL,
    LastName varchar(50) NOT NULL,
    Email varchar(50) NOT NULL,
    Phone varchar(20) NOT NULL,
    City varchar(50) NOT NULL,
    Country varchar(50) NOT NULL
);

using (SqlConnection connection = new SqlConnection("Data Source=myserver;Initial Catalog=mydatabase;Integrated Security=True"))

INSERT INTO Customers (FirstName, LastName, Email, Phone, City, Country) 
VALUES ('John', 'Doe', 'johndoe@example.com', '555-555-5555', 'Anytown', 'USA');

SELECT * FROM Customers;