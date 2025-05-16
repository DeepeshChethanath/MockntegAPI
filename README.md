# MockntegAPI
dotnet 8 | Web API | vertical slice architecture | CQRS | Mediatr 

# Functionality
> Retrive product by name and pagination
> Create product with validation
> Delete product by Id
> Implemented CQRS using Mediatr
> Uses HttpClientFactory with Singleton-configured baseURL

# Technology Used
- dotnet 8
- ASP.net Core Web API
- Mediatr
- Swagger

# Running the Application
1. Clone the repository
2. Build the application in VS2022
3. Run the application
4. Open Swagger at: http://localhost:{port}/swagger

# Security Enhancement of API that can be done(my observations)
1. The request and response can be encrypted as payload using any encryption logic like AES or SHA256 Algorithm.
2. The partners who are consuming the API can be authorised on the basis of partner, partner key and salt key provided to them. Action filter will be a good solution in code implementation.
3. Serilog or NLog can be used for logging sensitive information.
4. Exception can be handled using error handling middleware globally.
5. Rate limiting can be implemented by using expiring JWT tokens.

# Key Features
* record based models
* Supports dynamic json data
* CQRS pattern with Mediatr
