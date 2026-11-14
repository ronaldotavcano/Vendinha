# Vendinha - Sistema de Gestão de Clientes e Dívidas

Sistema desktop desenvolvido para o gerenciamento de clientes e controle de dívidas, construído com foco na separação de responsabilidades em **Arquitetura de 3 Camadas** (Apresentação, Negócio e Dados).

**Aluno:** Ronaldo T. Cano  
**RA:** 2051371

---

## Funcionalidades e Regras de Negócio

* **Cadastro de Clientes:** Validação de campos obrigatórios, verificação matemática de dígitos verificadores do CPF e bloqueio de duplicidade de CPF ou e-mail no banco de dados.

* **Listagem e Busca Paginada:** Exibição de clientes ordenada pelos maiores devedores (10 registros por página), com filtro de busca por nome ou CPF e cálculo dinâmico do total geral de dívidas em aberto no rodapé.

* **Lançamento de Dívidas:** Associação de dívidas por CPF, permitindo apenas uma dívida em aberto por vez para cada cliente.

* **Pagamento de Dívidas:** Baixa rápida diretamente pela listagem de clientes, registrando a data e hora do pagamento e mantendo o histórico financeiro no banco.

* **Exclusão Segura de Clientes:** Remoção de clientes permitida apenas quando não há dívidas pendentes em seu CPF.

---

## Tecnologias Utilizadas

* **Linguagem:** C# (.NET)
* **Interface Gráfica (Frontend):** Windows Forms (`Vendinha.Desktop`)
* **Acesso a Dados (ORM):** Entity Framework Core + LINQ
* **Banco de Dados:** PostgreSQL 

---

## Arquitetura do Projeto

O sistema está dividido em duas soluções principais que refletem a arquitetura em camadas:

### 1. `Vendinha.Desktop` (Camada de Apresentação)
Responsável pela interação com o usuário por meio de formulários e janelas do Windows Forms. Exibe os dados formatados, captura as entradas e encaminha as solicitações para a camada de negócio.

### 2. `Vendinha.Core` / `Vendinha` (Camadas de Negócio e Dados)
Concentra a estrutura de persistência e as regras do sistema:
* **`Contexts/`**: Contém o `VendinhaDbContext`, responsável por gerenciar a sessão com o banco de dados PostgreSQL e mapear as classes para as tabelas.
* **`Models/`**: Contém as entidades `Cliente.cs` e `Divida.cs`, estruturando os dados e suas anotações de validação.
* **`Services/`**: Centro das regras de negócio da aplicação. Contém as classes `ClienteService.cs` e `DividaService.cs`, que validam objetos com `ValidationContext`, aplicam travas de segurança e coordenam a gravação dos dados.

---

## Como Executar o Projeto

### 1. Obter o código-fonte
Clone este repositório ou baixe e extraia o arquivo `.zip` em sua máquina:
```bash
git clone <url-do-seu-repositorio>
```

### 2. Configurar o Banco de Dados

- Certifique-se de ter o PostgreSQL instalado e em execução.

- Crie um banco de dados chamado vendinha.

A- bra a sua ferramenta de banco de dados, conecte-se ao banco vendinha e execute o script contido no arquivo scripts-criacao.sql para criar as tabelas e popular os registros iniciais.

### 3. Configurar a String de Conexão
Abra as classes ClienteService.cs e DividaService.cs (localizadas na pasta Services). Na linha 22 de ambos os arquivos, ajuste o usuário (User Id) e a senha (Password) da constante ConnectionString conforme as credenciais do seu PostgreSQL local:

```C#
private const string ConnectionString = "Server=localhost; Port=5432; Database=vendinha; User Id=postgres; Password=sua_senha;";
```

### 4. Compilar e Executar

Abra o terminal na pasta raiz do projeto e execute os comandos abaixo para limpar e compilar as dependências:

```bash
dotnet clean
dotnet build
dotnet run --project Vendinha.Desktop
```
