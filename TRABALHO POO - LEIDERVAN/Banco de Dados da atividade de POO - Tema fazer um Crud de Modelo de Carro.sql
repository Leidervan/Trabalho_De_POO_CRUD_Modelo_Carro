create database Modelo;
use Modelo;

create table Modelo(
Id_Modelo INT PRIMARY KEY AUTO_INCREMENT,
nome_Modelo VARCHAR(30) NOT NULL,
tipo_Modelo VARCHAR(25) NOT NULL,
cor_Modelo VARCHAR(15) NOT NULL,
ano_Modelo DATETIME NOT NULL
);

select * from Modelo;
