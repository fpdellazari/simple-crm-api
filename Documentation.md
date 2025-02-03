# **SimpleCRM API**
### **Info**
- **Description**: A **SimpleCRM API** fornece funcionalidades básicas para um CRM. Ela permite o gerenciamento de **clientes**, **histórico de contatos**, **vendas** e **relatórios de desempenho**. A API foi desenvolvida utilizando **ASP.NET Core 8.0** e implementa autenticação via **JWT** (JSON Web Tokens) para segurança.

---
### **Endpoints**

### /api/Authentication

**POST**

**[ Request Body ]** 

- application/json:

    - $schema: AuthenticationModel

- text/json:

    - $schema: AuthenticationModel

- application/*+json:

    - $schema: AuthenticationModel

**Example Value**:

```json
{
    "username" : string,
    "password" : string
}
```

**[ Responses ]**

code: 200

description: Success

### /api/ContactHistory

**GET**

**[ Responses ]**

code: 200

description: Success

**POST**

**[ Request Body ]** 

- application/json:

    - $schema: ContactHistoryCreateRequest

- text/json:

    - $schema: ContactHistoryCreateRequest

- application/*+json:

    - $schema: ContactHistoryCreateRequest

**Example Value**:

```json
{
    "customerId" : integer,
    "type" : enum: [ 1, 2, 3, 4, 5 ],
    "notes" : string
}
```

**[ Responses ]**

code: 200

description: Success

- text/plain:

    - type: string

- application/json:

    - type: string

- text/json:

    - type: string

### /api/Customer

**GET**

**[ Responses ]**

code: 200

description: Success

**POST**

**[ Request Body ]** 

- application/json:

    - $schema: CustomerCreateRequest

- text/json:

    - $schema: CustomerCreateRequest

- application/*+json:

    - $schema: CustomerCreateRequest

**Example Value**:

```json
{
    "name" : string,
    "age" : integer,
    "phone" : string,
    "email" : string
}
```

**[ Responses ]**

code: 200

description: Success

- text/plain:

    - type: string

- application/json:

    - type: string

- text/json:

    - type: string

### /api/Dashboard

**GET**

**[ Responses ]**

code: 200

description: Success

### /api/Sale

**GET**

**[ Responses ]**

code: 200

description: Success

- text/plain:

    - type: array ( $schema: SaleModel )

- application/json:

    - type: array ( $schema: SaleModel )

- text/json:

    - type: array ( $schema: SaleModel )

**Example Value**:

```json
[
    {
        "id" : integer,
        "customerId" : integer,
        "productId" : integer,
        "quantity" : integer,
        "unitPrice" : number,
        "totalPrice" : number,
        "saleDate" : string,
        "customer" : {
            "id" : integer,
            "name" : string,
            "age" : integer,
            "phone" : string,
            "email" : string,
            "createdAt" : string,
            "updatedAt" : string
        },
        "product" : {
            "id" : integer,
            "name" : string,
            "price" : number
        }
    }
]
```

**POST**

**[ Request Body ]** 

- application/json:

    - $schema: SaleCreateRequest

- text/json:

    - $schema: SaleCreateRequest

- application/*+json:

    - $schema: SaleCreateRequest

**Example Value**:

```json
{
    "customerId" : integer,
    "productId" : integer,
    "quantity" : integer
}
```

**[ Responses ]**

code: 200

description: Success


---
### **Components**
### Schemas
**AuthenticationModel**

**username**:

- **string**

    - _required: true_

    - _nullable: false_

    - _minLength: 1_

**password**:

- **string**

    - _required: true_

    - _nullable: false_

    - _minLength: 1_





**ContactHistoryCreateRequest**

**customerId**:

- **integer**

    - _format: int32_

    - _required: true_

    - _nullable: false_

**type**:

- **ContactType**

    - _required: true_

    - _nullable: false_

**notes**:

- **string**

    - _required: false_

    - _nullable: true_





**ContactType**

enum: [ 1, 2, 3, 4, 5 ]





**CustomerCreateRequest**

**name**:

- **string**

    - _required: true_

    - _nullable: false_

    - _maxLength: 100_

    - _minLength: 0_

**age**:

- **integer**

    - _format: int32_

    - _required: true_

    - _nullable: false_

    - _maximum: 200_

    - _minimum: 16_

**phone**:

- **string**

    - _required: true_

    - _nullable: false_

    - _minLength: 1_

    - _pattern: ^\d{8,12}$_

**email**:

- **string**

    - _format: email_

    - _required: false_

    - _nullable: true_





**CustomerModel**

**id**:

- **integer**

    - _format: int32_

    - _required: false_

    - _nullable: false_

**name**:

- **string**

    - _required: false_

    - _nullable: true_

**age**:

- **integer**

    - _format: int32_

    - _required: false_

    - _nullable: false_

**phone**:

- **string**

    - _required: false_

    - _nullable: true_

**email**:

- **string**

    - _required: false_

    - _nullable: true_

**createdAt**:

- **string**

    - _format: date-time_

    - _required: false_

    - _nullable: false_

**updatedAt**:

- **string**

    - _format: date-time_

    - _required: false_

    - _nullable: true_





**ProductModel**

**id**:

- **integer**

    - _format: int32_

    - _required: false_

    - _nullable: false_

**name**:

- **string**

    - _required: false_

    - _nullable: true_

**price**:

- **number**

    - _format: double_

    - _required: false_

    - _nullable: false_





**SaleCreateRequest**

**customerId**:

- **integer**

    - _format: int32_

    - _required: true_

    - _nullable: false_

**productId**:

- **integer**

    - _format: int32_

    - _required: true_

    - _nullable: false_

    - _maximum: 3_

    - _minimum: 1_

**quantity**:

- **integer**

    - _format: int32_

    - _required: true_

    - _nullable: false_

    - _maximum: 2147483647_

    - _minimum: 1_





**SaleModel**

**id**:

- **integer**

    - _format: int32_

    - _required: false_

    - _nullable: false_

**customerId**:

- **integer**

    - _format: int32_

    - _required: false_

    - _nullable: false_

**productId**:

- **integer**

    - _format: int32_

    - _required: false_

    - _nullable: false_

**quantity**:

- **integer**

    - _format: int32_

    - _required: false_

    - _nullable: false_

**unitPrice**:

- **number**

    - _format: double_

    - _required: false_

    - _nullable: false_

**totalPrice**:

- **number**

    - _format: double_

    - _required: false_

    - _nullable: false_

**saleDate**:

- **string**

    - _format: date-time_

    - _required: false_

    - _nullable: false_

**customer**:

- **CustomerModel**

    - _required: false_

    - _nullable: false_

**product**:

- **ProductModel**

    - _required: false_

    - _nullable: false_






---
### Security Schemes
**Bearer**

- type: http

- description: Insira seu token JWT.

- scheme: Bearer

- bearerFormat: JWT


---
### Security
**Bearer**

[  ]
---
