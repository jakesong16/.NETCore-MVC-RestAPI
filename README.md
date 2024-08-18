# CLI Commands REST API (ASP.NET Core MVC)
#### It is helpful to have an API that returns us CLI commands that we may often forget. This Commands API stores command line snippets along with a short description of what it does, as well as which platform it's for.
### The purpose of this project is to learn and practice concepts related to:
> - Building a REST API
> - .NET Core
> - MVC Architectural Pattern
> - C#

#### More specifically, I used the following:
> - Dependency injection
> - Repository design pattern
> - SQL Server Express & SSMS
> - Entity Framework Core O/RM (DBContext, Migration)
> - Data Transfer Objects (DTOs) & AutoMapper
> - RESTful API guidelines
> - HTTP (GET, POST, PUT, PATCH, DELETE, status codes)
> - Views (Razor, Shared Layout, ViewBag, RenderSection)
> - Testing API Endpoints (SwaggerUI & Postman)
> - Docker (Container, Image, Deploying on Docker Hub)

*Note: Please excuse the large amount of comments in my code, they are used as notes for later review.*

### Application Architecture:

![image](https://github.com/user-attachments/assets/603d1a56-1fe4-4819-b2dd-f6f2d17b8cf8)

### Website Look:

![image](https://github.com/user-attachments/assets/e19bc97f-6e4c-4188-a2cd-4c8d8cffdaf7)

### API Endpoints (CRUD):

![image](https://github.com/user-attachments/assets/e7085ed5-3a03-4489-b774-02fb17bcd52a)

## Sample endpoints using Postman:

### [HttpPost] Creates a new command, returns Location header with link to resource, as well as the '201 Created' status code.

![image](https://github.com/user-attachments/assets/b5bbbec1-75d3-4841-a661-5ed8eacc4e9c)

### [HttpPatch] Updates the value of the howTo attribute and returns the '204 No Content' status code.

![image](https://github.com/user-attachments/assets/e83b1309-0017-46b7-b796-2599ca72360a)


