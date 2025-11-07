# NexFinance - Administração de Finanças

Sistema de controle financeiro pessoal desenvolvido como Trabalho de Conclusão de Curso (TCC) da UNIP.

## 📋 Sobre o Projeto

O **NexFinance** é uma aplicação web para gerenciamento de finanças pessoais, permitindo o controle de receitas, despesas, investimentos e geração de relatórios financeiros.

### Equipe de Desenvolvimento
- Giovanni Destito
- João Gabriel Esquinca
- Matheus da Silva Braga Neres
- Thiago Barbosa Candido
- Pedro Menezes Furigo

### Orientadora
Prof.ª Dr.ª Eliana Leão do Prado Battaglion

## 🚀 Tecnologias Utilizadas

### Frontend
- **Angular** (v20.x)
- **PO-UI** (Biblioteca de componentes da TOTVS)
- **TypeScript**
- **CSS**

### Backend (Planejado)
- **C#** (.NET)
- **PostgreSQL**

## 📦 Estrutura do Projeto

```
nexfinance/
├── src/
│   ├── app/
│   │   ├── models/          # Interfaces TypeScript (modelos de dados)
│   │   ├── pages/           # Componentes de páginas
│   │   │   ├── dashboard/
│   │   │   ├── receitas/
│   │   │   ├── despesas/
│   │   │   ├── investimentos/
│   │   │   └── relatorios/
│   │   ├── services/        # Serviços Angular (integração com API)
│   │   ├── app.config.ts    # Configurações da aplicação
│   │   ├── app.routes.ts    # Rotas da aplicação
│   │   └── app.ts           # Componente raiz
│   ├── styles.css           # Estilos globais
│   └── index.html           # Página HTML principal
├── database/
│   └── schema.sql           # Esquema do banco de dados PostgreSQL
└── package.json             # Dependências do projeto
```

## 🛠️ Instalação e Configuração

### Pré-requisitos
- Node.js (v18 ou superior)
- npm ou yarn
- Angular CLI

### Passos para Instalação

1. **Clone o repositório** (ou extraia os arquivos)
```bash
cd nexfinance
```

2. **Instale as dependências**
```bash
npm install
```

3. **Execute o projeto em modo de desenvolvimento**
```bash
npm start
```

4. **Acesse a aplicação**
```
http://localhost:4200
```

## 📊 Banco de Dados

O esquema do banco de dados PostgreSQL está disponível em `database/schema.sql`.

### Tabelas Principais:
- **usuario**: Dados dos usuários do sistema
- **categoria**: Categorias de receitas e despesas
- **conta**: Contas bancárias, carteiras e cartões
- **lancamento**: Registro de receitas e despesas
- **transferencia**: Transferências entre contas

## 🎨 Funcionalidades

### Implementadas (Projeto Base)
- ✅ Dashboard com visão geral das finanças
- ✅ Página de Receitas
- ✅ Página de Despesas
- ✅ Página de Investimentos
- ✅ Página de Relatórios
- ✅ Menu de navegação lateral (PO-UI)
- ✅ Layout responsivo
- ✅ Modelos TypeScript para integração com backend

### Planejadas (Desenvolvimento Futuro)
- ⏳ Autenticação de usuários
- ⏳ CRUD completo de receitas e despesas
- ⏳ Gestão de categorias personalizadas
- ⏳ Controle de múltiplas contas
- ⏳ Transferências entre contas
- ⏳ Gráficos e relatórios detalhados
- ⏳ Integração com backend C#
- ⏳ Exportação de relatórios (PDF/Excel)

## 🔧 Scripts Disponíveis

```bash
# Executar em modo de desenvolvimento
npm start

# Compilar para produção
npm run build

# Executar testes
npm test

# Verificar qualidade do código
npm run lint
```

## 📝 Estrutura de Dados (Models)

O projeto inclui interfaces TypeScript que correspondem ao esquema do banco de dados:

- `Usuario`: Dados do usuário
- `Categoria`: Categorias de transações
- `Conta`: Contas financeiras
- `Lancamento`: Receitas e despesas
- `Transferencia`: Transferências entre contas

## 🎯 Próximos Passos

1. Implementar serviços Angular para comunicação com API
2. Criar formulários para cadastro de receitas e despesas
3. Desenvolver backend em C# com Entity Framework
4. Implementar autenticação JWT
5. Adicionar gráficos com bibliotecas de visualização
6. Implementar testes unitários e de integração

## 📄 Licença

Este projeto é parte de um Trabalho de Conclusão de Curso (TCC) da Universidade Paulista - UNIP.

## 👥 Contato

Para dúvidas ou sugestões, entre em contato com a equipe de desenvolvimento através da instituição.

---

**Universidade Paulista - UNIP**  
**Curso de Ciência da Computação**  
**Ribeirão Preto - 2025**

# NexFinance - Administração de Finanças

Sistema de controle financeiro pessoal desenvolvido como Trabalho de Conclusão de Curso (TCC) da UNIP.

## 📋 Sobre o Projeto

O **NexFinance** é uma aplicação web para gerenciamento de finanças pessoais, permitindo o controle de receitas, despesas, investimentos e geração de relatórios financeiros.

### Equipe de Desenvolvimento
- Giovanni Destito
- João Gabriel Esquinca
- Matheus da Silva Braga Neres
- Thiago Barbosa Candido
- Pedro Menezes Furigo

### Orientadora
Prof.ª Dr.ª Eliana Leão do Prado Battaglion

## 🚀 Tecnologias Utilizadas

### Frontend
- **Angular** (v20.x)
- **PO-UI** (Biblioteca de componentes da TOTVS)
- **TypeScript**
- **CSS**

### Backend (Planejado)
- **C#** (.NET)
- **PostgreSQL**

## 📦 Estrutura do Projeto

```
nexfinance/
├── src/
│   ├── app/
│   │   ├── models/          # Interfaces TypeScript (modelos de dados)
│   │   ├── pages/           # Componentes de páginas
│   │   │   ├── dashboard/
│   │   │   ├── receitas/
│   │   │   ├── despesas/
│   │   │   ├── investimentos/
│   │   │   └── relatorios/
│   │   ├── services/        # Serviços Angular (integração com API)
│   │   ├── app.config.ts    # Configurações da aplicação
│   │   ├── app.routes.ts    # Rotas da aplicação
│   │   └── app.ts           # Componente raiz
│   ├── styles.css           # Estilos globais
│   └── index.html           # Página HTML principal
├── database/
│   └── schema.sql           # Esquema do banco de dados PostgreSQL
└── package.json             # Dependências do projeto
```

## 🛠️ Instalação e Configuração

### Pré-requisitos
- Node.js (v18 ou superior)
- npm ou yarn
- Angular CLI

### Passos para Instalação

1. **Clone o repositório** (ou extraia os arquivos)
```bash
cd nexfinance
```

2. **Instale as dependências**
```bash
npm install
```

3. **Execute o projeto em modo de desenvolvimento**
```bash
npm start
```

4. **Acesse a aplicação**
```
http://localhost:4200
```

## 📊 Banco de Dados

O esquema do banco de dados PostgreSQL está disponível em `database/schema.sql`.

### Tabelas Principais:
- **usuario**: Dados dos usuários do sistema
- **categoria**: Categorias de receitas e despesas
- **conta**: Contas bancárias, carteiras e cartões
- **lancamento**: Registro de receitas e despesas
- **transferencia**: Transferências entre contas

## 🎨 Funcionalidades

### Implementadas (Projeto Base)
- ✅ Dashboard com visão geral das finanças
- ✅ Página de Receitas
- ✅ Página de Despesas
- ✅ Página de Investimentos
- ✅ Página de Relatórios
- ✅ Menu de navegação lateral (PO-UI)
- ✅ Layout responsivo
- ✅ Modelos TypeScript para integração com backend

### Planejadas (Desenvolvimento Futuro)
- ⏳ Autenticação de usuários
- ⏳ CRUD completo de receitas e despesas
- ⏳ Gestão de categorias personalizadas
- ⏳ Controle de múltiplas contas
- ⏳ Transferências entre contas
- ⏳ Gráficos e relatórios detalhados
- ⏳ Integração com backend C#
- ⏳ Exportação de relatórios (PDF/Excel)

## 🔧 Scripts Disponíveis

```bash
# Executar em modo de desenvolvimento
npm start

# Compilar para produção
npm run build

# Executar testes
npm test

# Verificar qualidade do código
npm run lint
```

## 📝 Estrutura de Dados (Models)

O projeto inclui interfaces TypeScript que correspondem ao esquema do banco de dados:

- `Usuario`: Dados do usuário
- `Categoria`: Categorias de transações
- `Conta`: Contas financeiras
- `Lancamento`: Receitas e despesas
- `Transferencia`: Transferências entre contas

## 🎯 Próximos Passos

1. Implementar serviços Angular para comunicação com API
2. Criar formulários para cadastro de receitas e despesas
3. Desenvolver backend em C# com Entity Framework
4. Implementar autenticação JWT
5. Adicionar gráficos com bibliotecas de visualização
6. Implementar testes unitários e de integração

## 📄 Licença

Este projeto é parte de um Trabalho de Conclusão de Curso (TCC) da Universidade Paulista - UNIP.

## 👥 Contato

Para dúvidas ou sugestões, entre em contato com a equipe de desenvolvimento através da instituição.

---

**Universidade Paulista - UNIP**  
**Curso de Ciência da Computação**  
**Ribeirão Preto - 2025**
