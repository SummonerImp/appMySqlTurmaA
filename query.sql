DROP DATABASE IF EXISTS dbturmaa;
CREATE DATABASE dbTurmaA;
use dbturmaa;

create table categoria(
idCategoria int(5) primary key auto_increment,
nome varchar(50) not null,
descricao varchar(50) not null);

create table produto(
idProduto int(50) primary key auto_increment,
nome varchar(50) not null,
precoUnitario decimal(10,2) not null,
idCategoria int(5) not null);

create table detalhevenda(
idDetalhe int(11),
numFatura int(11),
subTotal double not null,
quantidade int(11) not null,
idVenda int(11) not null,
idProduto int(5) not null,
primary key(idDetalhe, numFatura));

create table fatura(
numFatura int(11) primary key,
data date not null,
taxa double not null,
total double not null,
desconto decimal(10,2),
numPag int(11) not null);

create table modopag(
numPag int(11) primary key,
nome varchar(25) not null,
outrosDetalhes varchar(50));

create table venda(
idVenda int(11) primary key,
total double not null,
data date not null,
desconto decimal(10,2),
taxa decimal(10,2) not null,
idCliente int(11) not null,
idVendedor varchar(5) not null);

create table cliente(
idCliente int(11) primary key auto_increment,
nome varchar(30) not null,
endereco varchar(50) not null,
telefone varchar(30) not null,
cpf varchar(11) not null unique);

create table vendedor(
idVendedor varchar(5) primary key,
nome varchar(30) not null,
cpf varchar(11) not null,
telefone varchar(20) not null);

ALTER TABLE produto ADD CONSTRAINT fk_idCategoria
FOREIGN KEY (idCategoria) REFERENCES categoria(idCategoria);

ALTER TABLE detalhevenda ADD CONSTRAINT fk_idVenda
FOREIGN KEY (idVenda) REFERENCES venda(idVenda);

ALTER TABLE detalhevenda ADD CONSTRAINT fk_idProduto
FOREIGN KEY (idProduto) REFERENCES produto(idProduto);

ALTER TABLE fatura ADD CONSTRAINT fk_numPag
FOREIGN KEY (numPag) REFERENCES modopag(numPag);

ALTER TABLE venda ADD CONSTRAINT fk_idCliente
FOREIGN KEY (idCliente) REFERENCES cliente(idCliente);

ALTER TABLE venda ADD CONSTRAINT fk_idVendedor
FOREIGN KEY (idVendedor) REFERENCES vendedor(idVendedor);

ALTER TABLE detalhevenda ADD CONSTRAINT fk_numFatura
FOREIGN KEY (numFatura) REFERENCES fatura(numFatura);

insert into cliente(nome, endereco, telefone, cpf) values('caio','abbes','171171171', '00012312311');
select * from cliente;

describe cliente;
select * from categoria