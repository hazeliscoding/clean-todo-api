# Clean Architecture with ASP.NET Core, Dapper, and MySQL
A simple Todo App API used as an example of a Clean Architecture approach in an ASP.NET Core, leveraging Dapper as the ORM and MySQL as the database.

## 🚀 Features
* **Clean Architecture**: Clear separation of concerns with four main layers: API, Application, Domain, and Infrastructure.
* **Dapper ORM**: Flexible and fast micro ORM.
* **MySQL**: Robust open-source relational database.
* **CQRS with MediatR**: Command Query Responsibility Segregation to clearly differentiate read and write actions.
* **Docker-Compose**: Easily containerize the application for consistent development and deployment experiences.

## 📚 Project Structure
* **API Layer**: Entry point of the application. Contains the ASP.NET Core Web API setup, controllers, and DI configuration.
* **Application Layer**: Houses the application's business logic, DTOs, interfaces, and application-specific services. Contains MediatR commands and queries.
* **Domain Layer**: Core layer of the project. Contains all the domain entities, value objects, domain events, and domain services.
* **Infrastructure Layer**: Deals with the external concerns, data access, and other integrations. Contains the Dapper ORM configurations and repository implementations.

## 🐋 Docker-Compose
This project includes a `docker-compose.yml file` to help you containerize your application. This simplifies setup, especially for contributors who want to run the project without manually configuring external dependencies like MySQL.

### Running with Docker
Ensure you have Docker and Docker-Compose installed. Then:

```
docker-compose up --build
```

This will build the required images and start the containers. Once running, you can access the API typically at `http://localhost:<port>`.

## 🌱 Getting Started
1. Clone this repository:
```
git clone https://github.com/nekomatadev/clean-architecture-demo.git
```  
2. Navigate to the project directory:
```
cd path-to-project-directory
```
3. Use Docker-Compose to run the application:
```
docker-compose up --build
```

## 📜 License
[MIT](https://choosealicense.com/licenses/mit/)

