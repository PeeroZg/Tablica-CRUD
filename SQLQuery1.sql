
CREATE TABLE Osobe
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Ime NVARCHAR(255),
    Prezime NVARCHAR(255),
    DatumRodjenja DATE,
    Telefon NVARCHAR(20),
    Email NVARCHAR(255),
    Spol NVARCHAR(10)
);


INSERT INTO Osobe (Ime, Prezime, DatumRodjenja, Telefon, Email, Spol)
VALUES
('Elon', 'Musk', '2010-05-05', '0911112323', 'elonmusk@tesla.com', 'M'),
('Bill', 'Gates', '1990-01-01', '0915552222', 'billgates@microsoft.com', 'M'),
('Conor', 'McGregor', '1991-08-04', '0987772223', 'conormcgregor@mma.com', 'M'),
('Arnold', 'Schwarzenegger', '1947-07-30', '0987654321', 'arnold@terminator.com', 'M'),
('Jim', 'Carrey', '1962-01-17', '0976543210', 'jim@comedian.com', 'M'),
('Brad', 'Pitt', '1963-12-18', '0912345678', 'bradpitt@hollywood.com', 'M'),
('Angelina', 'Jolie', '1975-06-04', '0923456789', 'angelina@actress.com', 'Ž'),
('Emma', 'Watson', '1990-04-15', '0934567890', 'emma@actress.com', 'Ž');
