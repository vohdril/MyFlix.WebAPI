 - Antes de executar a API, é necessário:
1) Criar a base de dados conforme o script SQL abaixo:

	
	CREATE DATABASE MyFlixDB
	GO
	
	USE MyFlixDB
	GO
	
	CREATE TABLE Filme
		(
			Id INT  IDENTITY(1,1) PRIMARY KEY,
			TITULO VARCHAR  (255),
			GENERO VARCHAR  (255),
			ANO_LANCAMENTO DATETIME NOT NULL DEFAULT GETDATE(),                     
			NOTA INT NOT NULL DEFAULT 1, 
			Poster VARCHAR (MAX),
			STATUS_ASSISTIDO BIT NOT NULL DEFAULT 0,
			DATA_CADASTRO DATETIME NOT NULL DEFAULT GETDATE()
   		)	 

3) Executar o comando "update-database" no Package Manager Console, apontando para o projeto "MyFlix.DAO" (isso ira incluir as tabelas Identity usadas pra autenticação do usuário)
