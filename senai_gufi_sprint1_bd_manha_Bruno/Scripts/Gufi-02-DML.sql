--DML

-- INSERIR DADOS

INSERT INTO TipoUsuario VALUES (
	'Admnistrador'
);
INSERT INTO TipoUsuario VALUES (
	'Comum'
);


INSERT INTO TipoEvento VALUES (
	'C#'
);
INSERT INTO TipoEvento VALUES (
	'React'
);
INSERT INTO TipoEvento VALUES (
	'SQL'
);


INSERT INTO Instituicao VALUES (
	'11111111111111','Escola SENAI de Inform�tica','Rua Alameda Bar�o de Limeira,538'
);

INSERT INTO Usuario VALUES (
	'Admnistrador','adm@adm.com','adm123','06/02/2020','N�o Informado',1
);
INSERT INTO Usuario VALUES (
	'Carol','carol@email.com','carol123','06/02/2020','Feminino',2
);
INSERT INTO Usuario VALUES (
	'Saulo','saulo@email.com','saulo123','06/02/2020','Masculino',2
);


INSERT INTO Evento VALUES (
	'Orienta��o a objetos','07/02/2020 01:40:49','Conceitos sobre os pilares da programa��o orientada a objetos','True',1,1
);
INSERT INTO Evento VALUES (
	'Ciclo de vida','08/02/2020 01:42:49','Como utilizar os ciclos de vida com a biblioteca ReactJs','False',1,2
);
INSERT INTO Evento VALUES (
	'Introdu��o a SQL','09/02/2020 01:44:49','Comandos b�sicos utilizando SQL Server','True',1,3
);


INSERT INTO Presenca VALUES (
	2,2,'Confirmada'
);
INSERT INTO Presenca VALUES (
	2,3,'N�o Confirmada'
);
INSERT INTO Presenca VALUES (
	3,1,'Confirmada'
);