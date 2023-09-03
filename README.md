# CQRS-API

An ASP.NET Core Web API implementing the CQRS pattern for a ```Person``` entity using entity framework.

Run solution after:\
Running ```docker compose up``` command to create an Azure SQL Edge database instance in a container (docker files included).\
Running ```dotnet ef --startup-project CQRSApi/ database update ```

Functionalities:

- Command to AddPerson.
- Command to RecordBirth.

- Query to GetPersonId.
- Query to GetAllPeople.

- Introduces basic logging to log when a command or query is handled.

Assumptions:
- dotnet 7 installed
- dotnet ef 7 and command-line tools installed
- Docker installed
