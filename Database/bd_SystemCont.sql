#System Cont - Advocacia
create database bd_advocacia;
use bd_advocacia;

create table Cliente(
id_cli integer primary key auto_increment,
nome_cli varchar (300),
telefone_cli varchar (300),
rg_cli varchar (100),
cpf_cli varchar (200),
nacionalidade_cli varchar (100),
renda_cli varchar (100),
email_cli varchar (100),
local_cli varchar (100)
);

create table Perfil(
id_per int primary key auto_increment,
descricao_per varchar(300),
data_egresso date
);

create table Reuniao(
id_reu int primary key auto_increment,
status_reu varchar(300),
data_reu date,
horario_inicio_reu time,
horario_termino_reu time,
resumo_reu varchar(500)
);

create table Endereco(
id_end int primary key auto_increment,
pais_end varchar(300),
estado_end varchar(300),
cidade_end varchar(300),
bairro_end varchar(300),
rua_end varchar(300),
numero_end varchar(300),
id_cli_fk int,
foreign key (id_cli_fk) references Cliente (id_cli)
);

create table Funcionario(
id_fun int primary key auto_increment,
nome_fun varchar(300),
email_fun varchar(300),
login_fun varchar(300),
senha_fun varchar(300),
cpf_fun varchar(300),
rg_fun varchar(300),
numero_inscricao varchar(300),
id_per_fk int,
foreign key (id_per_fk) references Perfil (id_per)
);

create table Caixa(
id_cai int primary key auto_increment,
saldo_atual_cai double,
horario_atual time,
data_atual date,
id_fun_fk int,
foreign key (id_fun_fk) references Funcionario (id_fun)
);

create table Processo(
id_pro int primary key auto_increment,
tipo_pro varchar(300),
status_pro varchar(300),
id_cli_fk int,
foreign key (id_cli_fk) references Cliente (id_cli)
);

create table Tarefa(
id_tar int primary key auto_increment,
data_inicio_tar date,
data_termino_tar date,
id_fun_fk int,
foreign key (id_fun_fk) references Funcionario (id_fun),
id_pro_fk int,
foreign key (id_pro_fk) references Processo (id_pro)
);

create table Honorario(
id_hon int primary key auto_increment,
valor_hon double,
descricao_hon varchar(300),
id_pro_fk int,
foreign key (id_pro_fk) references Processo (id_pro)
);

create table Despesa(
id_des integer not null primary key auto_increment,
descricao_des varchar(300),
valor_des double,
data_despesa_des date
);

create table Pagamento(
id_pag int primary key auto_increment,
valor_pag double,
descricao_pag varchar(300),
data_pagamento_pag date,
horario_pagamento_pag time,
id_cai_fk int,
foreign key (id_cai_fk) references Caixa (id_cai),
id_des_fk int,
foreign key (id_des_fk) references Despesa (id_des)
);

create table Recebimento(
id_rec int primary key auto_increment,
descricao_rec varchar(300),
valor_rec double,
data_recebimento_rec date,
id_cai_fk int not null,
foreign key (id_cai_fk) references Caixa (id_cai)
);

create table Responsavel(
id_res int primary key auto_increment,
nome_res varchar(300),
id_fun_fk int,
foreign key (id_fun_fk) references Funcionario (id_fun),
id_pro_fk int,
foreign key (id_pro_fk) references Processo (id_pro)
);

create table Funcionario_Honorario(
id_fuho int primary key auto_increment,
valor_fuho double,
porcentagem_fuho double,
id_fun_fk int,
foreign key (id_fun_fk) references Funcionario (id_fun),
id_hon_fk int,
foreign key (id_hon_fk) references Honorario (id_hon)
);

create table Reuniao_Funcionario(
id_refu int primary key auto_increment,
quantidade_refu int,
id_fun_fk int,
foreign key (id_fun_fk) references Funcionario (id_fun),
id_reu_fk int,
foreign key (id_reu_fk) references Reuniao (id_reu)
);

