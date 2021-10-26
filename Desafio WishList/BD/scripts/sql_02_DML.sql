USE M_WISHLIST
GO

INSERT INTO USUARIO(username, email, senha)
VALUES
	('Angelo', 'angelo@gmail.com', 'angelo@123'),
	('Marcos', 'marcos@outlook.com', 'marcos@123'),
	('Miria', 'miria@gmail.com', 'miria@123')

GO

INSERT INTO DESEJOS(idUsuario, descricao, dataCadastro)
VALUES
	(1, 'Nintendo Switch', '26/10/2021'),
	(2, 'Casa própria', '26/10/2021'),
	(2, 'Playstation 5', '27/10/2021'),
	(3, 'Chocolate', '26/10/2021'),
	(3, 'Banana', '27/10/2021')
GO

