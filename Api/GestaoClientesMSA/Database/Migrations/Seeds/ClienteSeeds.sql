-- Seeds para tabelas de Cliente e Telefone

--
INSERT INTO Cliente (Nome, Email, DataNascimento) VALUES ('Bernardo', 'bernardo@exemplo.com', '1994-10-05');

INSERT INTO Telefone (Numero, Tipo, ClienteId) VALUES ('21 995814400', 0, IDENT_CURRENT('Cliente'));
INSERT INTO Telefone (Numero, Tipo, ClienteId) VALUES ('21 32687679', 2, IDENT_CURRENT('Cliente'));

-- 

INSERT INTO Cliente (Nome, Email, DataNascimento) VALUES ('Daniela', 'daniela@exemplo.com', '1994-08-16');

INSERT INTO Telefone (Numero, Tipo, ClienteId) VALUES ('11 999998887', 0, IDENT_CURRENT('Cliente'));