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
renda_cli double,
email_cli varchar (100),
local_cli varchar (100)
);

create table Funcionario(
id_fun int primary key auto_increment,
nome_fun varchar(300),
email_fun varchar(300),
senha_fun varchar(300),
cpf_fun varchar(300),
rg_fun varchar(300),
numero_inscricao_fun varchar(300)
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
cep_end varchar(300),
id_cli_fk int,
foreign key (id_cli_fk) references Cliente (id_cli)
);

create table Perfil(
id_per int primary key auto_increment,
descricao_per varchar(300),
data_egresso date,
id_fun_fk int,
foreign key (id_fun_fk) references Funcionario (id_fun)
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
responsavel_pro varchar(300),
id_cli_fk int,
foreign key (id_cli_fk) references Cliente (id_cli),
id_fun_fk int,
foreign key (id_fun_fk) references Funcionario (id_fun)
);

create table Tarefa(
id_tar int primary key auto_increment,
data_inicio_tar date,
data_termino_tar date,
id_fun_fk int,
foreign key (id_fun_fk) references Funcionario (id_fun)
);

create table Honorario(
id_hon int primary key auto_increment,
valor_hon double,
descricao_hon varchar(300),
data_hon date,
id_pro_fk int,
foreign key (id_pro_fk) references Processo (id_pro)
);

create table Despesa(
id_des integer primary key auto_increment,
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
id_cai_fk int,
foreign key (id_cai_fk) references Caixa (id_cai),
id_hon_fk int,
foreign key (id_hon_fk) references Honorario (id_hon)
);

create table Funcionario_Honorario(
id_fuho int primary key auto_increment,
valor_fuho double,
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

#Procedimentos

Delimiter $$
create procedure InserirCliente (nome varchar(300), telefone varchar(300), rg varchar(100), cpf varchar(200), nacionalidade varchar(100), renda double, email varchar(100), localidade varchar(100))
begin
insert into Cliente values(null, nome, telefone, rg, cpf, nacionalidade, renda, email, localidade);
end;
$$ Delimiter ;

Delimiter $$
create procedure InserirFuncionario (nome varchar(300), email varchar(300), senha varchar(300), cpf varchar(300), rg varchar(300), numeroInscricao varchar(300))
begin
insert into Funcionario values(null, nome, email, senha, cpf, rg, numeroInscricao);
end;
$$ Delimiter ;

Delimiter $$
create procedure InserirPerfil (descricao varchar(300), dataEgresso date, idFuncionario int)
begin
insert into Perfil values(null, descricao, dataEgresso, idFuncionario);
end;
$$ Delimiter ;

Delimiter $$
create procedure InserirReuniao (statusReuniao varchar(300), dataReuniao date, horarioInicio time, horarioTermino time, resumo varchar(500))
begin
insert into Reuniao values(null, statusReuniao, dataReuniao, horarioInicio, horarioTermino, resumo);
end;
$$ Delimiter ;

Delimiter $$
create procedure InserirEndereco (pais varchar(300), estado varchar(300), cidade varchar(300), bairro varchar(300), rua varchar(300), numero varchar(300), idCliente int)
begin
insert into Reuniao values(null, pais, estado, cidade, bairro, rua, numero, idCliente);
end;
$$ Delimiter ;

Delimiter $$
create procedure InserirCaixa (saldoAtual double, horario time, dataAtual date, idFuncionario int)
begin
insert into Caixa values(null, saldoAtual, horario, dataAtual, idFuncionario);
end;
$$ Delimiter ;

Delimiter $$
create procedure InserirProcesso (tipo varchar(300), statusProcesso varchar(300), responsavel varchar(300), idCliente int, idFuncionario int)
begin
insert into Processo values(null, tipo, statusProcesso, responsavel, idCliente, idFuncionario);
end;
$$ Delimiter ;

Delimiter $$
create procedure InserirTarefa (dataInicio date, dataTermino date, idFuncionario int, idProcesso int)
begin
insert into Tarefa values(null, dataInicio, dataTermino, idFuncionario, idProcesso);
end;
$$ Delimiter ;

Delimiter $$
create procedure InserirHonorario (valor double, descricao varchar(300), idProcesso int)
begin
insert into Honorario values(null, valor, descricao, idProcesso);
end;
$$ Delimiter ;

Delimiter $$
create procedure InserirDespesa (nome varchar (300), descricao varchar(300), valor double, dataDespesa date)
begin
insert into Despesa values(null, nome, descricao, valor, dataDespesa);
end;
$$ Delimiter ;

Delimiter $$
create procedure InserirPagamento (valor double, descricao varchar(300), dataPagamento date, horarioPagamento time, idCaixa int, idDespesa int)
begin
insert into Pagamento values(null, valor, descricao, dataPagamento, horarioPagamento, idCaixa, idDespesa);
end;
$$ Delimiter ;

Delimiter $$
create procedure InserirRecebimento (descricao varchar(300), valor double, dataRecebimento date, idCaixa int, idHonorario int)
begin
insert into Recebimento values(null, descricao, valor, dataRecebimento, idCaixa, idHonorario);
end;
$$ Delimiter ;

Delimiter $$
create procedure InserirFuncionario_Honorario (valor double, porcentagem double, idFuncionario int, idHonorario int)
begin
insert into Funcionario_Honorario values(null, valor, porcentagem, idFuncionario, idHonorario);
end;
$$ Delimiter ;

Delimiter $$
create procedure InserirReuniao_Funcionario (quantidade int, idFuncionario int, idReuniao int)
begin
insert into Reuniao_Funcionario values(null, quantidade, idFuncionario, idReuniao);
end;
$$ Delimiter ;


#PROCEDIMENTOS - ATUALIZAR

Delimiter $$
create procedure AtualizarCliente (nome varchar(300), telefone varchar(300), rg varchar(100), cpf varchar(200), nacionalidade varchar(100), renda double, email varchar(100), localidade varchar(100))
begin
insert into Cliente values(null, nome, telefone, rg, cpf, nacionalidade, renda, email, localidade);
end;
$$ Delimiter ;



