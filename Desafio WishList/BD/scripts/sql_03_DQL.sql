USE M_WISHLIST

--Seleciona as informa��es dos usu�rios
SELECT * FROM USUARIO
GO

--Seleciona os desejos
SELECT * FROM DESEJOS
GO

--Seleciona todos os desejos de todos os usu�rios
SELECT U.username "Usu�rio", D.descricao "Desejo", D.dataCadastro "Cadastro do desejo" FROM DESEJOS D
LEFT JOIN USUARIO U ON D.idUsuario = U.idUsuario
GO

--Seleciona todas as informa��es de um usu�rio espec�fico
SELECT U.username "Usu�rio", U.email "Email", U.senha "Senha", D.descricao "Desejo", D.dataCadastro "Cadastro do desejo" FROM DESEJOS D
LEFT JOIN USUARIO U ON D.idUsuario = U.idUsuario 
WHERE D.idUsuario = 2
GO

--Seleciona apenas os desejos de um usu�rio espec�fico
SELECT U.username "Usu�rio", D.descricao "Desejo", D.dataCadastro "Cadastro do desejo" FROM DESEJOS D
LEFT JOIN USUARIO U ON D.idUsuario = U.idUsuario 
WHERE D.idUsuario = 3
GO


--Seleciona apenas as informa��es pessoais de um usu�rio espec�fico
SELECT username "Nome de Usu�rio", email "Email", senha "Senha" FROM USUARIO
WHERE idUsuario = 1
GO
