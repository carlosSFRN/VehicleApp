# VehicleApp

API REST para gerenciamento de veículos com autenticação JWT, desenvolvida em .NET 8 seguindo princípios de Clean Architecture e CQRS.

## 🚀 Tecnologias

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core (InMemory)
- JWT Authentication com Roles (Admin/User)
- MediatR (CQRS)
- FluentValidation
- BCrypt.Net
- Swagger/OpenAPI

## 📁 Arquitetura

Projeto organizado em camadas seguindo Clean Architecture:

```
VehicleApp/
├── Vehicle.API/              # Camada de apresentação (Controllers, Middleware)
├── Vehicle.Application/      # Lógica de aplicação (Commands, Queries, Handlers)
├── Vehicle.Domain/           # Entidades e regras de negócio
└── Vehicle.Infrastructure/   # Acesso a dados (Repositories, DbContext)
```

## ⚙️ Configuração e Execução

### Pré-requisitos
- .NET 8 SDK

### Executar a aplicação

```bash
# Clone o repositório
git clone <url-do-repositorio>

# Navegue até a pasta do projeto
cd VehicleApp/src/Vehicle.API

# Execute o projeto
dotnet run
```

A API estará disponível em:
- HTTPS: `https://localhost:5001`
- HTTP: `http://localhost:5000`
- Swagger: `https://localhost:5001/swagger`

### Testar com Postman

Na pasta `postman/` há uma collection pronta para importar no Postman. A collection já está configurada para adicionar automaticamente o token JWT nas requisições após o login.

### Credenciais padrão

Um usuário administrador é criado automaticamente:
- **Login:** `admin`
- **Senha:** `123456`
- **Role:** `Admin`

## 📚 Endpoints

### Autenticação

#### Login
```http
POST /api/auth/login
Content-Type: application/json

{
  "login": "admin",
  "senha": "123456"
}
```

**Resposta (200 OK):**
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

### Veículos

> 🔒 Todos os endpoints de veículos requerem autenticação via Bearer Token

> 👤 Endpoints de criação, atualização e exclusão requerem Role **Admin**

#### Criar Veículo (Admin)
```http
POST /api/vehicles
Authorization: Bearer {token}
Content-Type: application/json

{
  "marca": "Toyota",
  "modelo": "Corolla",
  "ano": 2024,
  "placa": "ABC1234",
  "cor": "Prata"
}
```

#### Listar Veículos
```http
GET /api/vehicles?pageNumber=1&pageSize=10
Authorization: Bearer {token}
```

#### Buscar Veículo por ID
```http
GET /api/vehicles/{id}
Authorization: Bearer {token}
```

#### Atualizar Veículo (Admin)
```http
PUT /api/vehicles/{id}
Authorization: Bearer {token}
Content-Type: application/json

{
  "marca": "Toyota",
  "modelo": "Corolla XEI",
  "ano": 2024,
  "placa": "ABC1234",
  "cor": "Preto"
}
```

#### Deletar Veículo (Admin)
```http
DELETE /api/vehicles/{id}
Authorization: Bearer {token}
```

## 📋 Códigos de Resposta HTTP

| Código | Descrição |
|--------|----------|
| 200 | Requisição bem-sucedida |
| 201 | Recurso criado com sucesso |
| 204 | Requisição bem-sucedida sem conteúdo |
| 400 | Erro de validação nos dados enviados |
| 401 | Não autenticado ou token inválido |
| 403 | Acesso negado (sem permissão) |
| 404 | Recurso não encontrado |
| 500 | Erro interno do servidor |

## 🔐 Autenticação e Autorização

A API utiliza JWT (JSON Web Token) para autenticação com suporte a Roles. Após o login, inclua o token no header de todas as requisições:

```
Authorization: Bearer {seu-token-aqui}
```

### Roles e Permissões

| Role | Permissões |
|------|------------|
| **Admin** | Criar, atualizar, deletar e visualizar veículos |
| **User** | Apenas visualizar veículos (GET) |

O token JWT contém as seguintes claims:
- `NameIdentifier`: ID do usuário
- `Name`: Login do usuário
- `Role`: Papel do usuário (Admin ou User)

## 🛠️ Padrões Utilizados

- **CQRS**: Separação de comandos e consultas usando MediatR
- **Repository Pattern**: Abstração da camada de dados
- **Dependency Injection**: Inversão de controle nativa do .NET
- **Validation**: Validação de entrada com FluentValidation
- **Clean Architecture**: Separação clara de responsabilidades

## 📝 Observações

- O banco de dados é InMemory, os dados são perdidos ao reiniciar a aplicação
- Senhas são criptografadas com BCrypt
- Token JWT expira em 8 horas
- Paginação padrão: 10 itens por página
- Novos usuários criados recebem Role "User" por padrão