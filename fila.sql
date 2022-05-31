create database fila;
use fila;

create table paciente(
  codigo_paciente int not null primary key,
  nome_paciente varchar(90) not null,
  idade_paciente varchar(3) not null,
  cpf_paciente varchar(14) not null,
  convenio_paciente varchar(13),
  prioridade_paciente int not null
);

select * from paciente;