
# Makers Solutions - ASP.NET API

> A RESTful API for implementing simple CRUD operations over *Customers* and *Invoices* entities.

## 🛠️Technologies
`ASP.NET 8` / `Entity Framework` / `SQL Server`

## 👥Entities

Customer: *{ Id, Name, Lastname, Address, Phone, IsDeleted }*

Invoices: *{ Id, InvoiceDate, CreatedBy, Concept, Total, CustomerId, IsDeleted }*

## 🚧👷🏼‍♂️Installation and Setup Instructions

1. Clone this repository with `git clone` command.
2. Create the database in SQL Server.
3. Add the *Connection String* in the `appsettings.json` file within `MakersSolutions.API` project.
