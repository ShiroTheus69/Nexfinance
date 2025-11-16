CREATE TABLE usuario (
	id SERIAL PRIMARY KEY,
	nome VARCHAR(100) NOT NULL,
	cpf Varchar(11) NOT NULL,
	email VARCHAR(100) UNIQUE NOT NULL,
	senha_hash VARCHAR(200) NOT NULL,
	idade INT,
	dt_criacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE categoria (
	id SERIAL PRIMARY KEY,
	nome VARCHAR(100) NOT NULL,
	tipo VARCHAR(10) NOT NULL CHECK (tipo IN('ENTRADA', 'SAIDA')),
	descricao TEXT
);

CREATE TABLE conta(
	id SERIAL PRIMARY KEY,
	nome VARCHAR(100) NOT NULL,
	tipo VARCHAR(100) NOT null,
	fk_usuario_id INT not null references usuario(id)
);


CREATE TABLE lancamento (
    id SERIAL PRIMARY KEY,
    usuario_id INT NOT NULL REFERENCES usuario(id),
    categoria_id INT NOT NULL REFERENCES categoria(id),
    conta_id INT NOT NULL REFERENCES conta(id),
    tipo VARCHAR(10) NOT NULL CHECK (tipo IN ('ENTRADA','SAIDA')), 
    valor DECIMAL(12,2) NOT NULL,
    data DATE NOT NULL,
    descricao TEXT,
    data_criacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE transferencia (
    id SERIAL PRIMARY KEY,
    usuario_id INT NOT NULL REFERENCES usuario(id),
    conta_origem_id INT NOT NULL REFERENCES conta(id),
    conta_destino_id INT NOT NULL REFERENCES conta(id),
    valor DECIMAL(12,2) NOT NULL,
    data DATE NOT NULL,
    descricao TEXT,
    data_criacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
