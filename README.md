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

1 - Crie um banco de dados MySQL.
2 - Crie uma tabela chamada com essa estrutura:

```sql
CREATE TABLE new_table (
	id INT AUTO_INCREMENT PRIMARY KEY,
	nome VARCHAR(100) NOT NULL,
	telefone VARCHAR(15) NOT NULL,
	email VARCHAR(100) NOT NULL
);
```

## Instruções de uso

1 - Clone este repositório para o seu computador.
2 - Abra o projeto no Visual Studio.
3 - Execute o projeto.
4 - Utilize os botões para adicionar, atualizar, excluir ou buscar contatos.

Se houver dúvidas ou sugestões, fique à vontade para abrir uma issue!
