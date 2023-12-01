create database proyectoFinal;
use proyectoFinal;
/*Tablas sin Foreign key*/
 create table sensor_temperatura(
 id_temperatura int auto_increment primary key,
 temperatura varchar(4) 
 );
 create table sensor_gas(
 id_gas int  auto_increment primary key ,
 gas varchar(50) 
 );
 create table sensor_movimiento(
 id_movimiento int  auto_increment primary key ,
 movimiento varchar(4) 
 );
/*Tablas con foreign*/
create table carro (
id_carro int unique primary key AUTO_INCREMENT,
nombre varchar(250),
id_movimiento int,
id_temperatura int,
id_gas int,
foreign key (id_gas) references sensor_gas(id_gas),
foreign key (id_temperatura) references sensor_temperatura(id_temperatura),
foreign key (id_movimiento) references sensor_movimiento(id_movimiento)
);
create table usuario (
id int unique primary key AUTO_INCREMENT ,
correo varchar(200) unique,
password varchar(500),
id_carro int,
foreign key (id_carro) references carro(id_carro)
);	