# Employee Management System - EMI

This project is an employee management system that implements a secure approach for authentication and authorization using JSON Web Tokens (JWT). The application is designed with a modular architecture that follows layered architecture principles, using design patterns like Repository and Dependency Injection (DI).

## Main Features

- **Authentication and Authorization with JWT**: Users can log in securely, receiving a JWT token that allows them to access protected resources. The main roles include:
  - **Admin**: Full access.
  - **User**: Limited access to read operations.
  
- **RESTful Controllers**: The controllers handle CRUD operations related to employees and users, making it easier to interact with the client.

- **Global Exception Handling Middleware**: Centralizes error handling and provides consistent and readable responses.

- **Request Logging Middleware**: Logs all incoming requests and outgoing responses, improving tracking and monitoring.

- **Repository Pattern**: Abstracts data access, allowing for better separation of responsibilities and easier unit testing.

- **Dependency Injection (DI)**: Sets up all dependencies in a central way, promoting modularity and making testing easier.

## Architecture

The project follows a layered architecture, organized as follows:

- **Application Layer (App Service)**: Manages HTTP requests, authentication and authorization, controllers, and middlewares.
- **Application Layer (Application)**: Contains business logic and data transfers (DTOs).
- **Domain Layer (Domain)**: Defines entities and main business rules.
- **Repository Layer (Repository)**: Manages database access using Entity Framework Core and the repository pattern.
- **Transversal Layer (Transversal)**: Includes common components like enumerations, exceptions, and entity mappings.

## Database
**SQL Server:** This project uses SQL Server as the database management system. Make sure it is installed and configured correctly.

**Instructions to Run the Database Script**
1. Open SQL Server Management Studio.
2. Connect to your local server.
3. Right-click on "Databases" and select "New Database" to create a new database.
4. Run the SQL file called "EMI DB" from the "New Query" option, selecting the newly created database.

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- JWT (JSON Web Tokens)
- Dependency Injection
- Repository Pattern

## Workflow

-The client sends an HTTP request.
-The controller processes the request.
-The Application Layer handles data mappings and transformations.
-Business logic is applied in the Domain Layer.
-If needed, the repository layer interacts with the database.
-The controller returns a response to the client.

## Installation

1. Clone the repository:
   git clone https://github.com/sidnyzh/EMI-technical-test.git
2. Open the project in your preferred IDE "EMI.sln"
3. Configure the Connection String:
   
- Open the appsettings.json file in the project.
- Locate the ConnectionStrings section and configure the connection string for your SQL Server database. 
4. un the Application

## Technical Test Instructions

In the technical test document, there were several questions:

### Section 1: C# Programming

**Question:** Add a method to this class that calculates a yearly bonus based on the salary and current position. The bonus is 10% of the salary for regular employees and 20% for managers.

- This method can be found in the application layer in the `EmployeeDomain` file as a private method.

### Section 2: ASP.NET Core

**Question:** Describe how you would implement authentication and authorization in this API.

**Authentication**

1. **Authentication Service Configuration:** First, I configured the authentication services in the application in the main configuration file (Startup.cs or Program.cs). I used JWT (JSON Web Tokens) to handle user authentication. This allows generating tokens that are used to identify users in each request. In this configuration, I define how to validate the tokens, ensuring that the issuer, audience, and signature key are correct.
  
2. **Login Method:** I implemented a method in the user controller that allows users to log in. This method receives the credentials (username and password) and, if they are valid, generates a JWT token. Once the user logs in, they receive a token that must be included in the headers of requests to access protected resources.

3. **Resource Protection:** To protect API resources, the `[Authorize]` attribute is applied to controllers or action methods. This ensures that only authenticated users can access those resources.

In the application service configuration, I defined an authorization policy called "RolePolicy." This is done in the main configuration file (Program.cs), where I use the `AddAuthorization` method to add the policy:

- This policy states that to access certain resources, the user must meet the requirements defined in `AuthorizeRoleRequirement`.

4. **RoleHandler Creation:** I implemented an authorization handler called `RoleHandler` that evaluates whether the user has the necessary roles to access resources. In this handler, I check the user's roles as follows:
   - If the user has the Admin role, access is granted without restrictions.
   - If the user has the User role, access is allowed only if they are making a GET request. This ensures that regular users can only view information and cannot perform actions that modify data.

5. **Applying the Policy in Controllers:** Finally, in my controllers or action methods, I use the authorization policy to restrict access. This is done by applying the `[Authorize(Policy = "RolePolicy")]` attribute, which allows the defined authorization logic to execute automatically when someone tries to access those resources.

**Question:** Explain the concept of middleware in ASP.NET Core. Write a simple custom middleware that logs the details of each incoming HTTP request.

- In ASP.NET Core, middleware is a key concept used to handle HTTP requests and responses. Middleware components are pieces of code executed in sequence as an HTTP request flows through the application, and they play a role in processing that request. The request flows through the middleware pipeline, and each component can inspect, modify, or even short-circuit the request to return a response directly.

### Section 3: Authentication and Authorization

**Question:** Provide an example of how to protect the endpoints in the employees controller using these roles.

To secure the endpoints in the employees controller, we implement an authorization policy using the [Authorize(Policy = "RolePolicy")] attribute. This policy is applied at the top of the controller, ensuring that all endpoints require authorization based on user roles.

User Credentials
There are two sets of user credentials that demonstrate role-based access:

-Admin 
-User

Email: syzapataho@gmail.com
Password: 1234
Role: Admin
Access Level: This user has full access and can perform any operation on the endpoints, including creating, updating, deleting, and retrieving employee information.
Regular User

Email: jz@gmail.com
Password: 1234
Role: User
Access Level: This user is limited to viewing data and can only access GET APIs, including the login endpoint. They are not authorized to perform any operations that modify data.
Implementation Details
By placing the [Authorize(Policy = "RolePolicy")] attribute at the controller level, we enforce that:

Any request to the endpoints within this controller will first check the user's role against the defined policy.
Admin users will have unrestricted access, while regular users will be restricted to read-only actions.

### Section 5: Performance and Optimization

1. **Question:**  What are some common performance issues in .NET applications, and how can you address them?

Excessive Boxing and Unboxing: This can lead to performance overhead. Boxing occurs when value types are converted to reference types and vice versa. To avoid this, it's best to minimize unnecessary use of value types and utilize nullable types instead.

String Concatenation: Using string for operations involving multiple concatenations can be inefficient. Instead, it's better to use StringBuilder, which is more suitable for efficiently building strings.

Excessive Database Calls: Making too many calls to the database can severely impact performance. It’s advisable to batch queries and employ optimization techniques, such as eager loading or lazy loading, to reduce unnecessary database trips.

Resource Management: Not properly releasing resources, such as database connections or file handles, can affect long-term performance. Using using blocks to manage resources is a good practice.

Large Data Sets in Memory: Keeping large data sets in memory can cause performance issues. It’s recommended to use pagination and limits to manage data efficiently.

Inefficient Algorithms: Using suboptimal algorithms can affect the application’s response time, especially due to unnecessary loops. Reviewing and optimizing algorithms is essential.

Lack of Asynchronous Programming: Not utilizing asynchronous programming for time-consuming operations can block threads and make the application feel slow. Using async and await for time-intensive operations, such as database calls, prevents blocking the execution thread.

Suboptimal Libraries: Some libraries may not be optimal and could cause performance problems. It's important to review dependencies and their impact on performance.

Rate Limiting: This technique controls the number of requests a user can make to the API within a given timeframe. It prevents server overload and ensures equitable resource usage among all users. Implementing middleware for rate limiting can help achieve this.

AutoMapper: While AutoMapper simplifies the process of mapping objects, it can be more costly in terms of performance compared to manual mapping due to its use of reflection, initialization overhead, and object handling. To mitigate this, it's important to avoid unnecessary calculations within AutoMapper.
 
2. **Question:** Describe how you would profile and optimize a slow-running query in a ASP.NET Core application.

To profile and optimize a slow-running query, I would take the following steps:

Monitoring and Logging: I would use monitoring and logging tools to identify problematic queries. Custom logs can help track execution times and highlight the slowest queries.

Analyze Execution Plan: I would analyze the query using SQL Server Management Studio (SSMS) to review the execution plan. This plan provides insights into how tables are processed, which indexes are used, and any operations that might impact performance.

Review Query Structure: I would examine the structure and logic of the query. Complex queries may benefit from simplification, so I would look for opportunities to streamline them. Additionally, I would ensure that indexes are used effectively and explore whether any JOIN conditions could be optimized.
