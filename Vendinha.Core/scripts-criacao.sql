# Scripts do Banco de Dados

create table clientes (
	cpf VARCHAR(11) primary key,
	nome VARCHAR(80) not null,
	email VARCHAR(40) not null,
	data_nascimento TIMESTAMP not NULL
);

CREATE TABLE dividas (
    id SERIAL primary key,
    cliente_cpf VARCHAR(11) not null,
    valor NUMERIC(10, 2) not null, 
    divida_paga BOOLEAN not null default false,
    data_criacao TIMESTAMP not null,
    data_pagamento TIMESTAMP,
    CONSTRAINT fk_dividas_clientes FOREIGN KEY (cliente_cpf) REFERENCES clientes(cpf)
);
