# Scripts do Banco de Dados

```sql

create table clientes (
	cpf VARCHAR(12) primary key,
	nome VARCHAR(80) not null,
	email VARCHAR(40) not null,
	data_nascimente DATE not NULL
)

```