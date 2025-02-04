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

## Roteiro para testes

Os testes da API podem ser realizados pelo Swagger.
A ordem recomendada para utilizar a API é:
- Autenticar e gerar um token: [POST] /api/Authentication
- Inserir o token no cabeçalho Authorize (não é preciso digitar o "Bearer")
- Inserir um cliente: [POST] /api/Customer
- Listar os clientes: [GET] /api/Customer
- Alterar um cliente: [PUT] /api/Customer
- Inserir um histórico de contato: [POST] /api/ContactHistory
- Listar o histórico de contatos: [GET] /api/ContactHistory
- Inserir uma venda: [POST] /api/Sale
- Listar uma venda: [GET] /api/Sale
- Verificar o relatório da operação: [GET] /api/Dashboard

---

# **Endpoints**


## [POST] /api/Authentication

Concede acesso à API. Gera um token JWT que deve ser anexado ao header Authorization para acesso aos outros endpoints.

### Dados de requisição
| Campo | Descrição | Tipo |
|---|---|---|
| username | Usuário para autenticação. | `string` |
| password | Senha. | `string` |

### Exemplo de requisição:

```json
{
    "username" : "Manager",
    "password" : "1234"
}
```

### Retorno esperado:

status code: 200

```json
{
  "message": "Token gerado com sucesso.",
  "token": "{jwtToken}"
}
```


## [GET] /api/Customer

Lista os clientes cadastrados.

### Sem corpo de requisição

### Retorno esperado:

status code: 200

```json
[
  {
    "id": 1,
    "name": "Carlos",
    "age": 25,
    "phone": "519984455",
    "email": "email@email.com",
    "createdAt": "2025-01-31T23:41:29.79",
    "updatedAt": null
  },
  {
    "id": 2,
    "name": "Joana",
    "age": 42,
    "phone": "519984455",
    "email": "email@email.com",
    "createdAt": "2025-01-31T23:44:01.447",
    "updatedAt": null
  }
]
```


## [POST] /api/Customer

Registra um novo cliente.

### Dados de requisição
| Campo | Descrição | Tipo | Validação |
|---|---|---|---|
| name | Nome do cliente. | `string` | obrigatório, máximo 100 caracteres |
| age | Idade do cliente. | `integer` | obrigatório, entre 0 e 200 |
| phone | Telefone do cliente. | `string` | obrigatório, telefone válido |
| email | E-mail do cliente. | `string` | email válido |

### Exemplo de requisição:

```json
{
  "name": "Marcos",
  "age": 33,
  "phone": "1156987545",
  "email": "example@email.com"
}
```

### Retorno esperado:

status code: 200

```json
{
  "message": "Cliente inserido com sucesso."
}
```

## [PUT] /api/Customer

Atualiza os dados de um cliente.

### Dados de requisição
| Campo | Descrição | Tipo | Validação |
|---|---|---|---|
| id | ID do cliente. | `integer` | obrigatório |
| name | Nome do cliente. | `string` | obrigatório, máximo 100 caracteres |
| age | Idade do cliente. | `integer` | obrigatório, entre 0 e 200 |
| phone | Telefone do cliente. | `string` | obrigatório, telefone válido |
| email | E-mail do cliente. | `string` | email válido |

### Exemplo de requisição:

```json
{
  "id": 2,
  "name": "Marcos",
  "age": 33,
  "phone": "1156987545",
  "email": "example@email.com"
}
```

### Retorno esperado:

status code: 200

```json
{
  "message": "Cliente atualizado com sucesso."
}
```


## [GET] /api/ContactHistory

Lista o histórico de contatos e os dados dos clientes contatados.

### Sem corpo de requisição

### Retorno esperado:

status code: 200

```json
[
  {
    "id": 1,
    "customerId": 1,
    "type": 1,
    "typeDescription": "Pré-Venda Realizada",
    "contactDate": "2025-02-01T15:52:20.24",
    "notes": "",
    "customer": {
      "id": 1,
      "name": "Carlos",
      "age": 25,
      "phone": "519984455",
      "email": "email@email.com",
      "createdAt": "2025-01-31T23:41:29.79",
      "updatedAt": null
    }
  },
  {
    "id": 2,
    "customerId": 2,
    "type": 2,
    "typeDescription": "Interesse Futuro",
    "contactDate": "2025-02-01T15:52:53",
    "notes": "",
    "customer": {
      "id": 2,
      "name": "Joana",
      "age": 42,
      "phone": "519984455",
      "email": "email@email.com",
      "createdAt": "2025-01-31T23:44:01.447",
      "updatedAt": null
    }
  }
]
```


## [POST] /api/ContactHistory

Insere o registro de um contato com um cliente.
Os tipos de contato são:
- 1: Pré-Venda Realizada
- 2: Interesse Futuro
- 3: Sem Interesse
- 4: Não Atendeu
- 5: Telefone Errado

### Dados de requisição
| Campo | Descrição | Tipo | Validação |
|---|---|---|---|
| customerId | ID do cliente. | `string` | obrigatório |
| type | Tipo de contato. | `integer` | obrigatório, entre 1 e 5 |
| notes | Observações sobre o contato. | `string` | |

### Exemplo de requisição:

```json
{
    "customerId" : 1,
    "type" : 2,
    "notes" : "Retornar ao cliente pela manhã."
}
```

### Retorno esperado:

status code: 200

```json
{
  "message": "Histórico de contato inserido com sucesso."
}
```


## GET /api/Sale

Lista as vendas realizadas com detalhes do cliente e produto adquirido.

### Sem corpo de requisição

### Retorno esperado:

status code: 200

```json
[
  {
    "id": 1,
    "customerId": 1,
    "productId": 1,
    "quantity": 3,
    "unitPrice": 19.9,
    "totalPrice": 59.7,
    "saleDate": "2025-02-01T19:52:17.67",
    "customer": {
      "id": 1,
      "name": "Carlos",
      "age": 25,
      "phone": "519984455",
      "email": "email@email.com",
      "createdAt": "2025-01-31T23:41:29.79",
      "updatedAt": null
    },
    "product": {
      "id": 1,
      "name": "Plano Essencial",
      "price": 19.9
    }
  }
]
```


## [POST] /api/Sale

Registra a venda de um ou mais produtos para um cliente.
Os tipos de produto são:
- 1: Plano Essencial 19,90
- 2: Plano Profissional 49,90
- 3: Plano Elite 69,90

### Dados de requisição
| Campo | Descrição | Tipo | Validação |
|---|---|---|---|
| customerId | ID do cliente. | `string` | obrigatório |
| productId | ID do produto. | `integer` | obrigatório |
| quantity | Quantidade de itens. | `string` | obrigatório |

### Exemplo de requisição:

```json
{
  "customerId": 2,
  "productId": 3,
  "quantity": 1
}
```

### Retorno esperado:

status code: 200

```json
{
  "message": "Venda registrada com sucesso."
}
```


## [GET] /api/Dashboard

Relatório de desempenho da operação de vendas.

### Sem corpo de requisição

### Dados de resposta
| Campo | Descrição | Tipo |
|---|---|---|
| totalContacts | Total de contatos realizados. | `integer` |
| totalProductiveContacts | Total de contatos produtivos (Pré-Venda Realizada ou Interesse Futuro). | `integer` |
| totalSalesCount | Total de vendas realizadas. | `integer` |
| totalSalesValue | Valor total das vendas. | `number` |
| averageTicket | Ticket Médio (Valor total das vendas / Total de vendas realizadas). | `number` |
| conversionRate | Taxa de conversão ((Total de vendas / Contatos produtivos) * 100). | `number` |

### Retorno esperado:

status code: 200

```json
{
  "totalContacts": 25,
  "totalProductiveContacts": 7,
  "totalSalesCount": 10,
  "totalSalesValue": 858.1,
  "averageTicket": 85.81,
  "conversionRate": 142.857142857
}
```




