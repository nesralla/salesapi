# Developer Evaluation Project

`READ CAREFULLY`

## Instructions
**The test below will have up to 7 calendar days to be delivered from the date of receipt of this manual.**

- The code must be versioned in a public Github repository and a link must be sent for evaluation once completed
- Upload this template to your repository and start working from it
- Read the instructions carefully and make sure all requirements are being addressed
- The repository must provide instructions on how to configure, execute and test the project
- Documentation and overall organization will also be taken into consideration

## Use Case
**You are a developer on the DeveloperStore team. Now we need to implement the API prototypes.**

As we work with `DDD`, to reference entities from other domains, we use the `External Identities` pattern with denormalization of entity descriptions.

Therefore, you will write an API (complete CRUD) that handles sales records. The API needs to be able to inform:

* Sale number
* Date when the sale was made
* Customer
* Total sale amount
* Branch where the sale was made
* Products
* Quantities
* Unit prices
* Discounts
* Total amount for each item
* Cancelled/Not Cancelled

It's not mandatory, but it would be a differential to build code for publishing events of:
* SaleCreated
* SaleModified
* SaleCancelled
* ItemCancelled

If you write the code, **it's not required** to actually publish to any Message Broker. You can log a message in the application log or however you find most convenient.

### Business Rules

* Purchases above 4 identical items have a 10% discount
* Purchases between 10 and 20 identical items have a 20% discount
* It's not possible to sell above 20 identical items
* Purchases below 4 items cannot have a discount

These business rules define quantity-based discounting tiers and limitations:

1. Discount Tiers:
   - 4+ items: 10% discount
   - 10-20 items: 20% discount

2. Restrictions:
   - Maximum limit: 20 items per product
   - No discounts allowed for quantities below 4 items

Developer Evaluation API Documentation

📌 Overview

This API manages sales records following the DDD architecture and implements a complete CRUD.

🔧 Tech Stack

.NET 8 (ASP.NET Core Web API)

PostgreSQL (Database)

Redis (Caching)

Kafka (Event Streaming)

FluentValidation (Request validation)

MediatR (CQRS pattern)

Swagger (API Documentation)

Docker & Docker Compose (Containerized environment)

📂 Project Structure

backend/
 ├── src/
 │   ├── Ambev.DeveloperEvaluation.WebApi/ (API Layer)
 │   ├── Ambev.DeveloperEvaluation.Application/ (Application Layer - Use Cases)
 │   ├── Ambev.DeveloperEvaluation.Domain/ (Domain Layer - Entities & Repositories)
 │   ├── Ambev.DeveloperEvaluation.Infrastructure/ (ORM, Migrations, DB Access)
 │   ├── Ambev.DeveloperEvaluation.IoC/ (Dependency Injection)
 │   ├── Ambev.DeveloperEvaluation.Tests/ (Unit & Integration Tests)
 ├── docker-compose.yml (Infrastructure Services)
 ├── README.md (Documentation)

📜 API Endpoints

**Sales API (/api/sales)

Method

Endpoint

Description

POST

/api/sales

Create a new sale

GET

/api/sales/{id}

Retrieve sale details

PUT

/api/sales/{id}

Update an existing sale

DELETE

/api/sales/{id}

Delete a sale

POST

/api/sales/{id}/cancel

Cancel a sale

POST

/api/sales/{saleId}/items/{itemId}/cancel

Remove or cancel a sale item

🚀 Running the Project

1️⃣ Prerequisites

Ensure you have installed:

Docker & Docker Compose

.NET 8 SDK

2️⃣ Running Services

Start the database, Redis, and Kafka with:

docker-compose up -d

3️⃣ Running the API

dotnet run --project src/Ambev.DeveloperEvaluation.WebApi

4️⃣ Accessing Swagger

The API documentation is available at:

<http://localhost:5000/swagger>

📌 Environment Configuration (appsettings.json)

Key

Description

ConnectionStrings:Pcastgres

PostgreSQL database connection

Redis:Host

Redis cache server

Kafka:BootstrapServers

Kafka broker connection

📌 Running Tests

To execute unit tests, run:

dotnet test

📌 Now your API is fully documented! 🚀 If you have any questions or need enhancements, let me know! 😃
