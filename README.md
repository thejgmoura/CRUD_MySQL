Este repositório contém uma aplicação CRUD (create, read, update, delete) para gerenciamento de cadastros, utilizando MySQL e C# com Windows Forms.

## Funcionalidades

- Cadastrar novos contatos com nome, telefone e e-mail.
- Buscar contatos através do nome.
- Atualizar os dados de um contato existente.
- Excluir contatos.
- Exibição de contatos em uma interface gráfica.

## Requisitos

- Visual Studio ou outra IDE compatível com C# e Windows Forms.
- Banco de dados MySQL configurado.
- Biblioteca MySql.Data instalada para comunicação com o MySQL.

## Configuração do banco de dados

- Crie um banco de dados MySQL.
- Crie uma tabela chamada com essa estrutura:

```sql
CREATE TABLE new_table (
	id INT AUTO_INCREMENT PRIMARY KEY,
	nome VARCHAR(100) NOT NULL,
	telefone VARCHAR(15) NOT NULL,
	email VARCHAR(100) NOT NULL
);
```

## Instruções de uso

- Clone este repositório para o seu computador.
- Abra o projeto no Visual Studio.
- Execute o projeto.
- Utilize os botões para adicionar, atualizar, excluir ou buscar contatos.
