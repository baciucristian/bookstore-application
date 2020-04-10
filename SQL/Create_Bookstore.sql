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
	idFurnizor int primary key -- Cheie primară ce identifică furnizorul
	,denumireFurnizor nvarchar(100) UNIQUE -- Denumirea furnizorului
    ,tipFurnizor nvarchar(100) -- Tipul furnizorului (editura, depozit, persoana particulara)
    ,adresaFurnizor nvarchar(100) -- Adresa furnizorului
    ,telefonFurnizor nvarchar(100) -- Telefon de contact al furnizorului
)
create table Autori
(
    idAutor int primary key -- Cheie primară ce identifică autorul
    ,numeAutor nvarchar(100) -- Numele și prenumele autorului
    ,dataAutor nvarchar(100) -- Data nașterii autorului
    ,genAutor nvarchar(1) -- Genul (M sau F)
)
create table Carti
( 
	idCarte int primary key -- Cheie primară ce identifică cartea
	,idFurnizor int foreign key (idFurnizor) references Furnizori -- Face legatura cu tabelul Furnizori
	,denumireCarte nvarchar(100) UNIQUE -- Denumirea cartii
    ,idAutor int foreign key (idAutor) references Autori -- Face legatura cu tabelul Autori
    ,anCarte nvarchar(100) -- Anul editarii cartii
    ,pretCarte int -- Pretul cartii
    
)
create table Users
( 
    idUser int IDENTITY(1,1) primary key -- Cheie primară ce identifică utilizatorul
    ,username nvarchar(50) -- Username-ul utilizatorului
    ,password nvarchar(50) -- Password-ul utilizatorului
)
GO
--Inserarea datelor
INSERT INTO Furnizori (idFurnizor, denumireFurnizor, tipFurnizor, adresaFurnizor, telefonFurnizor) VALUES 
	(1, 'Editura Arc', 'Editura', 'str. M. Eminescu 23', '067123376')
    ,(2, 'Editura Cartier', 'Editura', 'str. Sarmisezetusa 87/B', '067233479')
    ,(3, 'Jian Catalin', 'Persoana', 'str. Bucuriei 1', '043829874')
GO
INSERT INTO Autori (idAutor, numeAutor, dataAutor, genAutor) VALUES
    (1, 'Ion Creangă', '01.03.1837', 'M')
    ,(2, 'Mihai Eminescu', '15.01.1850', 'M')
GO
INSERT INTO Carti (idCarte, idFurnizor, denumireCarte, idAutor, anCarte, pretCarte) VALUES
    (1, 3, 'Amintiri din copilărie', 1, '1892', 52)
    ,(2, 1, 'Luceafărul', 2,'1883', 86)
GO
INSERT INTO Users (username, password) VALUES 
    ('admin', 'admin')
	,('baciuness', 'portugal')