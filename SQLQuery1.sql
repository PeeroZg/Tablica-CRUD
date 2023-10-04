
CREATE TABLE Osobe
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    Ime NVARCHAR(255),
    Prezime NVARCHAR(255),
    Telefon NVARCHAR(20),
    Email NVARCHAR(255),
    Spol NVARCHAR(10)
);


INSERT INTO Osobe (Ime, Prezime, DatumRodjenja, Telefon, Email, Spol)
VALUES
('Elon', 'Musk', '0911112323', 'elonmusk@tesla.com', 'M'),
('Bill', 'Gates', '0915552222', 'billgates@microsoft.com', 'M'),
('Conor', 'McGregor', '0987772223', 'conormcgregor@mma.com', 'M'),
('Arnold', 'Schwarzenegger', '0987654321', 'arnold@terminator.com', 'M'),
('Jim', 'Carrey', '0976543210', 'jim@comedian.com', 'M'),
('Brad', 'Pitt', '0912345678', 'bradpitt@hollywood.com', 'M'),
('Angelina', 'Jolie', '0923456789', 'angelina@actress.com', 'Ž'),
('Emma', 'Watson', '0934567890', 'emma@actress.com', 'Ž');
