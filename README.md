 - Antes de executar a API, é necessário:
1) Criar a base de dados conforme o script SQL abaixo:

```sql	
	CREATE DATABASE MyFlixDB
	GO
	
	USE MyFlixDB
	
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

```
3) Executar o comando "update-database" no Package Manager Console, apontando para o projeto "MyFlix.DAO" (isso ira incluir as tabelas Identity usadas pra autenticação do usuário)

4) Verique se a string de conexão do servidor local SQL está configurada corretamente. As configurações de ambiente de string de conexão ficam no arquivo appSettings (Projeto 'MyFlix.API') 
