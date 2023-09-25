[![.NET](https://github.com/francoeder/CustomerManagement/actions/workflows/ci-dotnet.yml/badge.svg?branch=main)](https://github.com/francoeder/CustomerManagement/actions/workflows/ci-dotnet.yml)

# What is that?

A .NET 7.0 Web API boilerplate project that implements the Clean Architecture pattern.

This project contains a basic CRUD of a Customer entity.

Technologies used:
- FluentValidation
- Automapper;
- Entity Framework Core;
- SQL Server;
- xUnit, Moq & AutoFixture;

<br>

# Project Structure
```
.
├── docker
└── src
    ├── CustomerManagement.Api
    ├── CustomerManagement.Api.Tests
    ├── CustomerManagement.Application
    ├── CustomerManagement.Application.Tests
    ├── CustomerManagement.Domain
    ├── CustomerManagement.Infra.Data
    └── CustomerManagement.Infra.Ioc
```

<br>

# Running API via Docker

To run the API via Docker we must run docker-compose pointing to the files in the ./docker folder (`docker-compose.yml` and `docker-compose.internal.yml`).

The command below does the dirty work.

```
docker-compose \
    -f docker/docker-compose.yml \
    -f docker/docker-compose.internal.yml \
    up -d
```

After that, just access the following address to see the Swagger page:

- http://localhost:5000/swagger

<br>

# Development

To run the project, you need to provide a valid connection string.

There are two options that can be followed here: Local Installation of SQL Server or SQL Server on Docker.
<br><br>

## 1. Local Installation of SQL Server
This option requires SQL Server to be installed locally on your machine.

Once SQL Server is installed, simply run the project with the environment variable `ASPNETCORE_ENVIRONMENT` = `Development`.
<br><br>


## 2. SQL Server on Docker
This option only requires Docker to be installed on your machine.

Once Docker is installed, simply run the command below to upload the SQL Server database:

```
docker-compose -f docker/docker-compose.yml up -d
```

After that, just run the project with the environment variable `ASPNETCORE_ENVIRONMENT` = `Internal`.
<br><br>

# Unit Tests

This project considers some unit tests for example purposes only.

Criteria such as test coverage and static source code analysis are not being considered.

To run the unit tests, simply run the command below in the project root:

```
dotnet test
```
<br>

# Migrations

This project is already configured to run migrations at the time the project is launched.
<br><br>


# Next Steps

I will probably continue with this project, there are a lot of things that can be improved.
If you want to follow what lies ahead, visit the project page at the link below.


### 👷🏻‍♂️🛠️ [CustomerManagement - Web API boilerplate Project](https://github.com/users/francoeder/projects/1/views/1)