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
tema_reu varchar(500)
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
numero_pro varchar(300),
tipo_pro varchar(300),
status_pro varchar(300),
responsavel_pro varchar(300),
cliente_pro varchar(300),
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
numero_processo_hon varchar(300),
valor_hon double,
descricao_hon varchar(300),
data_hon date,
id_pro_fk int,
foreign key (id_pro_fk) references Processo (id_pro)
);

create table Despesa(
id_des integer primary key auto_increment,
nome_des varchar (300),
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
create procedure InserirReuniao (statusReuniao varchar(300), dataReuniao date, horarioInicio time, horarioTermino time, tema varchar(500))
begin
insert into Reuniao values(null, statusReuniao, dataReuniao, horarioInicio, horarioTermino, tema);
end;
$$ Delimiter ;

Delimiter $$
create procedure InserirEndereco (pais varchar(300), estado varchar(300), cidade varchar(300), bairro varchar(300), rua varchar(300), numero varchar(300), idCliente int)
begin
insert into Reuniao values(null, pais, estado, cidade, bairro, rua, numero, idCliente);
end;
$$ Delimiter ;

Delimiter $$
create procedure InserirCaixa (saldoAtual double, idFuncionario int)
begin
insert into Caixa values(null, saldoAtual, CURTIME(), CURDATE(), idFuncionario);
end;
$$ Delimiter ;

Delimiter $$
create procedure InserirProcesso (numeroProcesso varchar(300),tipo varchar(300), statusProcesso varchar(300), responsavel varchar(300), cliente varchar(300), idCliente int, idFuncionario int)
begin
insert into Processo values(null, numeroProcesso, tipo, statusProcesso, responsavel, cliente, idCliente, idFuncionario);
end;
$$ Delimiter ;

Delimiter $$
create procedure InserirTarefa (dataInicio date, dataTermino date, idFuncionario int, idProcesso int)
begin
insert into Tarefa values(null, dataInicio, dataTermino, idFuncionario, idProcesso);
end;
$$ Delimiter ;

Delimiter $$
create procedure InserirHonorario (numeroProcesso varchar (300), valor double, descricao varchar(300), dataHonorario date, idProcesso int)
begin
insert into Honorario values(null, numeroProcesso, valor, descricao, dataHonorario, idProcesso);
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

call InserirCliente("Renan da Rocha Santos", "(69) 9 9992-1143", "14585278", "781.919.764-12", "Brasileiro", 2000, "renanro919@gmail.com", "Presidente-Médici");
call InserirCliente("Priscila Catarina Evelyn da Mata", "(79) 3596-9501", "28.970.945-3", "640.264.215-03", "Brasileira", 3500, "priscilacatarinadamata@band.com.br", "Aracaju");
call InserirCliente("Lorena Elaine Lopes", "(95) 3512-5150", "19.190.522-7 ", "975.387.885-06", "Brasileira", 1700, "lorena_elaine_lopes@institutodainfancia.com.br", "Presidente-Médici");
call InserirCliente("Mariah Mirella Isadora Castro", "(51) 3998-4295", "20.248.601-1", "048.836.126-51", "Brasileira",  210,  "mariahmirellacastro@yahool.com", "Porto Alegre");
call InserirCliente("Henrique Edson Diogo das Neves", "(82) 2835-4121", "22.352.785-3", "003.753.621-42", "Brasileira", 1200, "henrique_dasneves@solucao.adm.br", "Maceió");

call InserirFuncionario("Rafael Felipe de Oliveira Aguiar", "rafaaguia@gmail.com", "123", "769.707.609-87", "11.661.639-8", "0123456789");
call InserirFuncionario("Isis Benedita Aurora das Neves", "risisbeneditadasneves@ppe.ufrj.br", "123", "432.330.703-90", "432.330.703-90", "34712955");
call InserirFuncionario("Elaine Isis Alves", "elaine_isis_alves@officetectecnologia.com.br", "123", "547.133.277-60", "16.889.373-3", "0123ABVDE");
call InserirFuncionario("Augusto Alexandre da Luz", "augusto.alexandre.daluz@ritmolog.com.br", "123", "688.282.740-00", "688.282.740-00", "ASDS456789");
call InserirFuncionario("Marina Vitória Bárbara Vieira", "marina_vieira@yahool.com", "123", "437.473.263-23", "11.375.689-6", "5642170");
call InserirFuncionario("c", "marina_vieira@yahool.com", "c", "437.473.263-23", "11.375.689-6", "5642170");

call InserirProcesso("4455511", "Criminal", "Em avaliação", "Rafael Felipe de Oliveira Aguiar", "Renan da Rocha Santos", 1, 1);
call InserirProcesso("33069", "Criminal", "Em aguaardo", "Isis Benedita Aurora das Neves", "Priscila Catarina Evelyn da Mata", 2, 1);
call InserirProcesso("555766", "Criminal", "Em avaliação", "Elaine Isis Alves", "Lorena Elaine Lopes", 3, 1);
call InserirProcesso("4552055", "Criminal", "Em aguaardo", "Augusto Alexandre da Luz", "Mariah Mirella Isadora Castro", 4, 1);
call InserirProcesso("5236748", "Criminal", "Em avaliação", "Marina Vitória Bárbara Vieira", "Henrique Edson Diogo das Neves", 5, 1);

call InserirHonorário("4455511", 300, "Processo de Regulamentação", '2022-04-24', 1);
call InserirHonorário("33069", 200, "Processo de Ação", '2022-05-24', 1);
call InserirHonorário("555766", 100, "Processo de Regulamentação", '2022-06-24', 1);
call InserirHonorário("4552055", 300, "Processo de Compra", '2022-07-24', 1);
call InserirHonorário("5236748", 230, "Processo de Venda", '2022-08-24', 1);
call InserirHonorário("504650", 100, "Processo de Aluguel", '2022-09-24', 1);
call InserirHonorário("745806", 300, "Processo de Danos Morais", '2022-10-24', 1);
call InserirHonorário("0248404", 1400, "Processo de Difamação", '2022-11-24', 1);
call InserirHonorário("688074recebimento", 250, "Processo de Regulamentação", '2022-12-24', 1);
call InserirHonorário("76090", 520, "Processo de Regulamentação", '2022-12-24', 1);

call InserirCaixa(0, 1);
call InserirCaixa(0, 2);
call InserirCaixa(0, 3);
call InserirCaixa(0, 4);

call InserirRecebimento("Recebimento Honorario", 520, '2022-01-24', 1, 1);
call InserirRecebimento("Recebimento Honorario", 340, '2022-02-24', 1, 1);
call InserirRecebimento("Recebimento Honorario", 1024, '2022-03-24', 1, 1);
call InserirRecebimento("Recebimento Honorario", 278, '2022-04-24', 1, 1);
call InserirRecebimento("Recebimento Honorario", 920, '2022-05-24', 1, 1);
call InserirRecebimento("Recebimento Honorario", 320, '2022-06-24', 1, 1);
call InserirRecebimento("Recebimento Honorario", 190, '2022-07-24', 1, 1);
call InserirRecebimento("Recebimento Honorario", 456, '2022-08-24', 1, 1);
call InserirRecebimento("Recebimento Honorario", 2200, '2022-09-24', 1, 1);
call InserirRecebimento("Recebimento Honorario", 960, '2022-10-24', 1, 1);
call InserirRecebimento("Recebimento Honorario", 452, '2022-11-24', 1, 1);
call InserirRecebimento("Recebimento Honorario", 650, '2022-12-24', 1, 1);

call InserirDespesa("Água", "Água", 250, '2022-04-21');
call InserirDespesa("Energia", "Energia", 650, '2022-05-21');
call InserirDespesa("Aluguel", "Aluguel", 400, '2022-06-21');
call InserirDespesa("Internet", "Internet", 250, '2022-07-21');

call InserirReuniao("Em aberto", '2022-11-25', '12:00:00', '13:00:00', "Exposição de Softwares");

#PROCEDIMENTOS - ATUALIZAR

Delimiter $$
create procedure AtualizarCliente (idCliente int, nome varchar(300), telefone varchar(300), rg varchar(100), cpf varchar(200), nacionalidade varchar(100), renda double, email varchar(100), localidade varchar(100))
begin
update Cliente set nome_cli = nome, telefone_cli = telefone, rg_cli = rg, cpf_cli = cpf, nacionalidade_cli = nacionalidade, renda_cli = renda, email_cli = email, local_cli = localidade where idCliente = id_cli;
end;
$$ Delimiter ;

Delimiter $$
create procedure AtualizarCaixa (idCaixa int, saldoAtual double, idFuncionario int)
begin
update Caixa set id_cai = idCaixa, saldo_atual_cai = saldoAtual, id_fun_fk = idFuncionario where idFuncionario = id_fun;
end;
$$ Delimiter ;

Delimiter $$
create procedure AtualizarDepesa (idDespesa int, nome varchar(300), descricao varchar(300), valor double, dataDesp date)
begin
update Caixa set id_des = idDespesa, nome_des = nome, descricao_des = descricao, valor_des = valor, data_despesa_des = dataDesp where idDespesa = id_des;
end;
$$ Delimiter ;




