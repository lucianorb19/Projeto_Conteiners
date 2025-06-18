-- Script para inserir 200 clientes na tabela Clientes

DECLARE @Counter INT = 1;
DECLARE @Estados TABLE (Estado NVARCHAR(MAX));

-- Inserir estados brasileiros na tabela temporária
INSERT INTO @Estados (Estado)
VALUES 
    ('AC'), ('AL'), ('AP'), ('AM'), ('BA'), ('CE'), ('DF'), ('ES'), ('GO'), 
    ('MA'), ('MT'), ('MS'), ('MG'), ('PA'), ('PB'), ('PR'), ('PE'), ('PI'), 
    ('RJ'), ('RN'), ('RS'), ('RO'), ('RR'), ('SC'), ('SP'), ('SE'), ('TO');

-- Variáveis auxiliares para dados fictícios
DECLARE @Id UNIQUEIDENTIFIER;
DECLARE @Nome NVARCHAR(MAX);
DECLARE @Email NVARCHAR(MAX);
DECLARE @CPF NVARCHAR(MAX);
DECLARE @Celular NVARCHAR(MAX);
DECLARE @CEP NVARCHAR(MAX);
DECLARE @Rua NVARCHAR(MAX);
DECLARE @Numero NVARCHAR(MAX);
DECLARE @Complemento NVARCHAR(MAX);
DECLARE @Bairro NVARCHAR(MAX);
DECLARE @Municipio NVARCHAR(MAX);
DECLARE @Cidade NVARCHAR(MAX);
DECLARE @Estado NVARCHAR(MAX);

-- Listas de nomes femininos e masculinos
DECLARE @NomesFemininos TABLE (Nome NVARCHAR(MAX));
DECLARE @NomesMasculinos TABLE (Nome NVARCHAR(MAX));

INSERT INTO @NomesFemininos (Nome)
VALUES ('Ana'), ('Maria'), ('Júlia'), ('Sofia'), ('Laura'), ('Isabella'), ('Alice'), ('Beatriz'), ('Larissa'), ('Camila');

INSERT INTO @NomesMasculinos (Nome)
VALUES ('João'), ('Pedro'), ('Lucas'), ('Gabriel'), ('Miguel'), ('Matheus'), ('Rafael'), ('Gustavo'), ('Arthur'), ('Henrique');

-- Inserir 200 clientes
WHILE @Counter <= 200
BEGIN
    -- Gerar dados fictícios
    SET @Id = NEWID();
    
    -- Alternar entre nomes femininos e masculinos
    IF @Counter % 2 = 0
        SELECT TOP 1 @Nome = Nome FROM @NomesFemininos ORDER BY NEWID();
    ELSE
        SELECT TOP 1 @Nome = Nome FROM @NomesMasculinos ORDER BY NEWID();

    SET @Email = LOWER(@Nome) + CAST(@Counter AS NVARCHAR) + 
                 CASE 
                     WHEN @Counter % 3 = 1 THEN '@exemplo.org'
                     WHEN @Counter % 3 = 2 THEN '@email.org'
                     ELSE '@email.com.br'
                 END;

    SET @CPF = RIGHT('000' + CAST(10000000000 + (@Counter * 11) AS NVARCHAR), 11); -- CPF fictício válido
    SET @Celular = '(11) 9' + CAST(100000000 + @Counter AS NVARCHAR); 
    SET @CEP = '12345-' + RIGHT('000' + CAST(@Counter AS NVARCHAR), 3);
    SET @Rua = 'Rua Fictícia ' + CAST(@Counter AS NVARCHAR);
    SET @Numero = CAST(@Counter AS NVARCHAR);
    SET @Complemento = NULLIF('Apto ' + CAST((@Counter % 10) + 1 AS NVARCHAR), 'Apto 1');
    SET @Bairro = 'Bairro ' + CAST(@Counter AS NVARCHAR);
    SET @Municipio = 'Municipio ' + CAST(@Counter AS NVARCHAR);
    SET @Cidade = 'Cidade ' + CAST(@Counter AS NVARCHAR);

    -- Selecionar um estado aleatório
    SELECT TOP 1 @Estado = Estado FROM @Estados ORDER BY NEWID();

    -- Inserir na tabela Clientes
    INSERT INTO [dbo].[Clientes] (
        [Id], [Nome], [Email], [CPF], [Celular], [CEP], [Rua], [Numero], 
        [Complemento], [Bairro], [Municipio], [Cidade], [Estado]
    )
    VALUES (
        @Id, @Nome, @Email, @CPF, @Celular, @CEP, @Rua, @Numero, 
        @Complemento, @Bairro, @Municipio, @Cidade, @Estado
    );

    SET @Counter = @Counter + 1;
END