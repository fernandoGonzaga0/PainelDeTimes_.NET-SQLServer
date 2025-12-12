CREATE TABLE Time (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Nome VARCHAR(200) NOT NULL
	);



CREATE TABLE Jogadores (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Nome VARCHAR(200) NOT NULL,
	Posicao VARCHAR(100) NOT NULL,
	Numero INT,
	TimeId INT, -- coluna de vínculo com a tabela Time

	CONSTRAINT FK_Jogadores_Time -- isso obriga que o valor inserido em Jogadores.TimeId exista previamente em Time.Id
		FOREIGN KEY (TimeId)     -- é a coluna na tabela Jogadores que guarda o Id do time.
		REFERENCES Time(Id)	     -- chave de proteção entre a relação Time ID
	);