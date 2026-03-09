# Healthcare Claim Processing & AI Risk Analysis Platform

## Overview

Backend healthcare claims processing platform built using **Clean Architecture** and **CQRS principles**.

The system allows healthcare providers to submit insurance claims for patients, while insurance administrators can review, approve, or reject claims.

The project demonstrates enterprise backend architecture concepts such as layered architecture, domain-driven design, and command/query separation.

---

## Architecture

The project follows **Clean Architecture** with clear separation of responsibilities between layers.

Client

↓

API (Controllers)

↓

Application (CQRS + MediatR)

↓

Domain (Entities & Business Rules)

↓

Infrastructure (EF Core Repositories)

↓

Database

### Layers

**API Layer**

- ASP.NET Core Web API
- Controllers
- Request/Response handling

**Application Layer**

- CQRS Commands and Queries
- MediatR handlers
- DTOs
- Repository interfaces
**Domain Layer**

- Core business entities
- Business rules and domain logic

**Infrastructure Layer**

- Entity Framework Core
- Database access
- Repository implementations

---

## CQRS Pattern

The system uses **Command Query Responsibility Segregation (CQRS)** to separate read and write operations.

### Commands (Write Operations)

Commands modify system state.

Examples:

- CreatePatientCommand
- CreateClaimCommand
- ApproveClaimCommand
- RejectClaimCommand

### Queries (Read Operations)

Queries retrieve data without modifying system state.

Examples:

- GetPagedPatientsQuery
- GetPatientByIdQuery
- GetPatientByPatientIdQuery
- GetPagedClaimsQuery

---
## Core Domain Entities

The system models the following healthcare domain entities:

- **Patient**
- **Provider**
- **InsurancePolicy**
- **Claim**


---

## Features

### Patient Management

- Create patients
- Retrieve patient by ID
- Retrieve patient by patient number
- Paginated patient listing

### Provider Management

- Register healthcare providers
- Provider lookup

### Claim Processing

- Submit healthcare claims
- Approve claims
- Reject claims
- Paginated claim listing

---
AI Risk Analysis (Planned)

The platform is designed to integrate with an AI-based risk analysis service that evaluates healthcare claims before approval.

The AI service will analyze claim data and generate a risk score to help insurance administrators identify potentially fraudulent or high-risk claims.

Planned design:

API

↓

Claim Submitted

↓

AI Risk Analysis Service (Python Microservice)

↓

Risk Score Returned

↓

Claim Review Decision

The AI component will be implemented as a separate microservice communicating with the backend API.

---

## Technology Stack

- ASP.NET Core Web API
- Entity Framework Core
- MediatR
- Clean Architecture
- CQRS Pattern
- SQL Server

---

## Future Enhancements

Planned improvements for the platform:

- JWT Authentication and Role-based authorization
- Claim document attachments
- AI-based claim risk analysis service
- Message queue based async claim processing
- Distributed system evolution

---

## How to Run

1. Clone the repository
2. Install latest .NET SDK
3. Open the solution
4. Configure the database connection in appsettings.json
5. Apply Entity Framework migrations
6. Run the API project
7. Access Swagger UI to test endpoints

---

## Project Status

🚧 Under active development

Current focus:

- Claim workflow completion
- Authentication module

---

## Author

Fathima Mahamood K K

Backend engineering portfolio project focused on **Clean Architecture and scalable backend system design**.


## Notes

This project is created for portfolio demonstration, backend engineering practice, and system design learning.

