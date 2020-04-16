SET DATEFORMAT dmy
use master
go
if exists (select * from sys.databases where name='Library')
	begin
		alter database Library set single_user 
			with rollback immediate
		drop database Library
	end
go
create database Library
go
alter authorization on database::Library to sa
go
use Library
go
create table Furnizori
(
	idFurnizor int IDENTITY(1,1) primary key -- Cheie primară ce identifică furnizorul
	,denumireFurnizor nvarchar(100) UNIQUE -- Denumirea furnizorului
    ,tipFurnizor nvarchar(100) -- Tipul furnizorului (editura, depozit, persoana particulara)
    ,adresaFurnizor nvarchar(100) -- Adresa furnizorului
    ,telefonFurnizor nvarchar(100) -- Telefon de contact al furnizorului
)
create table Autori
(
    idAutor int IDENTITY(1,1) primary key -- Cheie primară ce identifică autorul
    ,numeAutor nvarchar(100) -- Numele și prenumele autorului
    ,dataAutor nvarchar(100) -- Data nașterii autorului
    ,genAutor nvarchar(1) -- Genul (M sau F)
)
create table Carti
( 
	idCarte int IDENTITY(1,1) primary key -- Cheie primară ce identifică cartea
	,idFurnizor int foreign key (idFurnizor) references Furnizori -- Face legatura cu tabelul Furnizori
	,denumireCarte nvarchar(100) UNIQUE -- Denumirea cartii
    ,idAutor int foreign key (idAutor) references Autori -- Face legatura cu tabelul Autori
    ,anCarte nvarchar(100) -- Anul editarii cartii
	,limbaCarte nvarchar(100) -- Limba cartii
    ,pretCarte int -- Pretul cartii
	,nrExemplare int -- Numarul de exemplare
)
create table Users
( 
    idUser int IDENTITY(1,1) primary key -- Cheie primară ce identifică utilizatorul
    ,username nvarchar(50) -- Username-ul utilizatorului
    ,password nvarchar(50) -- Password-ul utilizatorului
)
GO
--Inserarea datelor
INSERT INTO Furnizori (denumireFurnizor, tipFurnizor, adresaFurnizor, telefonFurnizor) VALUES 
	('Editura Arc', 'Editura', 'str. M. Eminescu 23', '067123376')
    ,('Editura Cartier', 'Editura', 'str. Sarmisezetusa 87/B', '067233479')
    ,('Jian Catalin', 'Persoana', 'str. Bucuriei 1', '063829874')
	,(N'Negară Maxim', 'Persoana', 'str. Grigore Vieru 54', '067124492')
	,('Editura Litera', 'Editura', 'str. M. Eminescu 90', '067298349')
GO
INSERT INTO Autori (numeAutor, dataAutor, genAutor) VALUES
    (N'Ion Creangă', '01.03.1837', 'M')
    ,('Mihai Eminescu', '15.01.1850', 'M')
	,('Miron Costin', '30.03.1633', 'M')
	,('Veronica Micle', '22.04.1850', 'F')
	,('Ion Pillat', '31.03.1891', 'M')
	,(N'Luís de Camões', '01.12.1524', 'M')
GO
INSERT INTO Carti (idFurnizor, denumireCarte, idAutor, anCarte, limbaCarte, pretCarte, nrExemplare) VALUES
    (3, N'Amintiri din copilărie', 1, '1892', N'Română', 52, 0)
    ,(1, N'Luceafărul', 2,'1883', N'Română', 86, 6)
	,(4, N'Letopisețul Țării Moldovei', 3, 1661, N'Română', 138, 3)
	,(5, N'Viața Lumii', 3, 1672, N'Română', 102, 14)
	,(2, N'Plimbarea de mai în Iaşi', 4, 1872, N'Română', 83, 20)
	,(2, 'Capra cu trei iezi', 1, 1875, N'Română', 52, 32)
	,(1, N'La mormântul lui Aron Pumnul', 2, 1886, N'Română', 130, 10)
	,(1, 'Lusiadele', 6, 1572, N'Portugheză', 240, 14)
GO
INSERT INTO Users (username, password) VALUES 
    ('admin', 'admin')
	,('baciuness', 'portugal')