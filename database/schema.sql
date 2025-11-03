-- Esquema do Banco de Dados NexFinance
-- PostgreSQL

CREATE TABLE usuario (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(150) UNIQUE NOT NULL,
    senha_hash VARCHAR(200) NOT NULL,
    data_criacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE categoria (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    tipo VARCHAR(10) NOT NULL CHECK (tipo IN ('ENTRADA','SAIDA')), -- define se a categoria é de receita ou despesa
    descricao TEXT
);

CREATE TABLE conta (
    id SERIAL PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    tipo VARCHAR(20) NOT NULL CHECK (tipo IN ('CARTEIRA','BANCO','CARTAO')),
    saldo_inicial DECIMAL(12,2) DEFAULT 0,
    data_criacao TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE lancamento (
    id SERIAL PRIMARY KEY,
    usuario_id INT NOT NULL REFERENCES usuario(id),
    categoria_id INT NOT NULL REFERENCES categoria(id),
    conta_id INT NOT NULL REFERENCES conta(id),
    tipo VARCHAR(10) NOT NULL CHECK (tipo IN ('ENTRADA','SAIDA')), -- redundância para facilitar relatórios
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
