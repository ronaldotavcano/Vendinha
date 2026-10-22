# Vendinha

Este projeto foi feito e desenvolvido pelo aluno Ronaldo T Cano.

## Banco de Dados

Utilizando o PostgreSQL junto com o DBeaver, criei o banco e a conexão através dos comandos abaixo.

### 0) Primeiro acesso: instalando e configurando o Postgres

**Ubuntu:**

```bash
sudo apt install postgresql postgresql-contrib 
sudo systemctl enable --now postgresql 
systemctl status postgresql 
```

### 1) Acessar o terminal do Postgres

Tentei criar pelo DBeaver, mas tive algumas dificuldades, então usei o terminal:

```bash
sudo -u postgres psql
```

### 2) Criar o usuário

```sql
CREATE USER meu_usuario WITH PASSWORD 'minha_senha';
```

### 3) Criar o banco de dados

```sql
CREATE DATABASE vendinha OWNER meu_usuario;
```

### 4) Verificar se o banco foi criado

```sql
\l
```

### 5) Conectar pelo DBeaver

1. Criar uma nova conexão do tipo **PostgreSQL**.
2. Host: `localhost` / Porta: `5432` (padrão).
3. Database: `vendinha`.
4. Usuário e senha: os criados no passo 2.
5. Clicar em **Testar conexão**.

Com o banco criado e conectado, você pode acompanhar o script de criação das tabelas no arquivo
script.md
