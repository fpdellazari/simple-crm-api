# SimpleCRM API

## Descrição

A **SimpleCRM API** fornece funcionalidades básicas para um CRM. Ela permite o gerenciamento de **clientes**, **histórico de contatos**, **vendas** e **relatórios de desempenho**. A API foi desenvolvida utilizando **ASP.NET Core 8.0** e implementa autenticação via **JWT** (JSON Web Tokens) para segurança.

A API é composta por uma série de endpoints RESTful, proporcionando operações CRUD (Create, Read e Update) sobre os recursos principais.

A arquitetura foi baseada no modelo **DDD**, seguindo boas práticas de desenvolvimento como os princípios **SOLID**, **Clean Code** e **Clean Architecture**. O objetivo foi criar algo simples mas que pode ser facilmente escalável e testável.
Também há um projeto de **testes unitários** com um primeiro teste do serviço de autenticação.


## Funcionalidades

- **Autenticação**: Sistema de login com geração de **JWT** para autenticação segura.
- **Gerenciamento de Clientes**: Criação, leitura e atualização de clientes.
- **Histórico de Contatos**: Adicionar e listar histórico de interação com os clientes.
- **Vendas**: Registro e acompanhamento de vendas realizadas.
- **Relatórios**: Geração de relatórios de desempenho de vendas e atividades.

## Tecnologias

- **ASP.NET Core 8.0**
- **Dapper ORM**
- **JWT Authentication**
- **Swagger** para documentação interativa
- **AutoMapper** para mapeamento de entidades

## Documentação Completa

Para mais detalhes, acesse a documentação completa da API:

[Documentação Completa](https://github.com/fpdellazari/simple-crm-api/blob/main/Documentation.md)


