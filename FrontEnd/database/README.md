# Banco de Dados - NexFinance

## Descrição

Este diretório contém o esquema do banco de dados PostgreSQL utilizado no projeto NexFinance.

## Estrutura das Tabelas

### 1. usuario
Armazena informações dos usuários do sistema.

**Campos:**
- `id` (SERIAL PRIMARY KEY): Identificador único do usuário
- `nome` (VARCHAR(100)): Nome completo do usuário
- `email` (VARCHAR(150) UNIQUE): Email único para login
- `senha_hash` (VARCHAR(200)): Hash da senha (bcrypt/argon2)
- `data_criacao` (TIMESTAMP): Data de criação do registro

### 2. categoria
Define as categorias para classificação de receitas e despesas.

**Campos:**
- `id` (SERIAL PRIMARY KEY): Identificador único da categoria
- `nome` (VARCHAR(100)): Nome da categoria (ex: Alimentação, Transporte)
- `tipo` (VARCHAR(10)): Tipo da categoria ('ENTRADA' ou 'SAIDA')
- `descricao` (TEXT): Descrição opcional da categoria

**Exemplos de categorias:**
- ENTRADA: Salário, Freelance, Investimentos, Vendas
- SAIDA: Alimentação, Transporte, Moradia, Lazer, Saúde

### 3. conta
Representa as contas financeiras do usuário.

**Campos:**
- `id` (SERIAL PRIMARY KEY): Identificador único da conta
- `nome` (VARCHAR(100)): Nome da conta (ex: Banco Itaú, Carteira)
- `tipo` (VARCHAR(20)): Tipo da conta ('CARTEIRA', 'BANCO', 'CARTAO')
- `saldo_inicial` (DECIMAL(12,2)): Saldo inicial ao criar a conta
- `data_criacao` (TIMESTAMP): Data de criação do registro

### 4. lancamento
Registra todas as transações financeiras (receitas e despesas).

**Campos:**
- `id` (SERIAL PRIMARY KEY): Identificador único do lançamento
- `usuario_id` (INT FK): Referência ao usuário
- `categoria_id` (INT FK): Referência à categoria
- `conta_id` (INT FK): Referência à conta
- `tipo` (VARCHAR(10)): Tipo do lançamento ('ENTRADA' ou 'SAIDA')
- `valor` (DECIMAL(12,2)): Valor da transação
- `data` (DATE): Data da transação
- `descricao` (TEXT): Descrição opcional da transação
- `data_criacao` (TIMESTAMP): Data de criação do registro

### 5. transferencia
Registra transferências entre contas do mesmo usuário.

**Campos:**
- `id` (SERIAL PRIMARY KEY): Identificador único da transferência
- `usuario_id` (INT FK): Referência ao usuário
- `conta_origem_id` (INT FK): Conta de origem da transferência
- `conta_destino_id` (INT FK): Conta de destino da transferência
- `valor` (DECIMAL(12,2)): Valor transferido
- `data` (DATE): Data da transferência
- `descricao` (TEXT): Descrição opcional da transferência
- `data_criacao` (TIMESTAMP): Data de criação do registro

## Relacionamentos

```
usuario (1) -----> (N) lancamento
usuario (1) -----> (N) transferencia
categoria (1) -----> (N) lancamento
conta (1) -----> (N) lancamento
conta (1) -----> (N) transferencia (origem)
conta (1) -----> (N) transferencia (destino)
```

## Instalação

### 1. Instalar PostgreSQL
```bash
# Ubuntu/Debian
sudo apt-get install postgresql postgresql-contrib

# Windows: Baixar do site oficial
# https://www.postgresql.org/download/
```

### 2. Criar o banco de dados
```sql
CREATE DATABASE nexfinance;
```

### 3. Executar o schema
```bash
psql -U postgres -d nexfinance -f schema.sql
```

## Queries Úteis

### Saldo atual de uma conta
```sql
SELECT 
    c.nome,
    c.saldo_inicial + 
    COALESCE(SUM(CASE WHEN l.tipo = 'ENTRADA' THEN l.valor ELSE -l.valor END), 0) as saldo_atual
FROM conta c
LEFT JOIN lancamento l ON c.id = l.conta_id
WHERE c.id = ?
GROUP BY c.id, c.nome, c.saldo_inicial;
```

### Total de receitas e despesas do mês
```sql
SELECT 
    tipo,
    SUM(valor) as total
FROM lancamento
WHERE usuario_id = ?
    AND EXTRACT(MONTH FROM data) = EXTRACT(MONTH FROM CURRENT_DATE)
    AND EXTRACT(YEAR FROM data) = EXTRACT(YEAR FROM CURRENT_DATE)
GROUP BY tipo;
```

### Últimas transações
```sql
SELECT 
    l.data,
    l.tipo,
    l.valor,
    l.descricao,
    cat.nome as categoria,
    c.nome as conta
FROM lancamento l
JOIN categoria cat ON l.categoria_id = cat.id
JOIN conta c ON l.conta_id = c.id
WHERE l.usuario_id = ?
ORDER BY l.data DESC, l.data_criacao DESC
LIMIT 10;
```

## Considerações de Segurança

1. **Senhas**: Sempre armazenar hash (bcrypt, argon2) nunca texto plano
2. **Validação**: Implementar validações no backend antes de inserir dados
3. **Índices**: Criar índices em campos frequentemente consultados (usuario_id, data)
4. **Backup**: Implementar rotina de backup automático do banco
5. **Permissões**: Configurar usuário do banco com permissões mínimas necessárias

## Melhorias Futuras

- [ ] Adicionar tabela de `metas` financeiras
- [ ] Implementar `soft delete` com campo `deleted_at`
- [ ] Adicionar tabela de `anexos` para comprovantes
- [ ] Criar tabela de `orcamento` mensal por categoria
- [ ] Implementar auditoria com tabela de `logs`
