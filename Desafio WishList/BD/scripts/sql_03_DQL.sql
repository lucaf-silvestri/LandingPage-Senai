USE M_WISHLIST

--Seleciona as informações dos usuários
SELECT * FROM USUARIO
GO

--Seleciona os desejos
SELECT * FROM DESEJOS
GO

--Seleciona todos os desejos de todos os usuários
SELECT U.username "Usuário", D.descricao "Desejo", D.dataCadastro "Cadastro do desejo" FROM DESEJOS D
LEFT JOIN USUARIO U ON D.idUsuario = U.idUsuario
GO

--Seleciona todas as informações de um usuário específico
SELECT U.username "Usuário", U.email "Email", U.senha "Senha", D.descricao "Desejo", D.dataCadastro "Cadastro do desejo" FROM DESEJOS D
LEFT JOIN USUARIO U ON D.idUsuario = U.idUsuario 
WHERE D.idUsuario = 2
GO

--Seleciona apenas os desejos de um usuário específico
SELECT U.username "Usuário", D.descricao "Desejo", D.dataCadastro "Cadastro do desejo" FROM DESEJOS D
LEFT JOIN USUARIO U ON D.idUsuario = U.idUsuario 
WHERE D.idUsuario = 3
GO


--Seleciona apenas as informações pessoais de um usuário específico
SELECT username "Nome de Usuário", email "Email", senha "Senha" FROM USUARIO
WHERE idUsuario = 1
GO
