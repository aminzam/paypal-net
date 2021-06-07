# Paypal.net
Paypal.net is a wrapper library for Paypal subscription API.
## Usage
Configure PayPal's API endpoint plus API key and secret. You can find these settings by creating an application in Paypal's developer dashboard.
``` json
// appsettings.json
"Paypal": {
    "ApiBaseUrl": "https://api-m.sandbox.paypal.com/",
    "ClientId": "your-client-id-here",
    "Secret": "your-secret-here"
}
```
Register library types by calling `AddPaypalApi` on `IServiceCollection`.
 ``` c#
// Startup.cs
using Paypal.Net.Sdk.DependencyInjection;
// ...

public void ConfigureServices(IServiceCollection services) 
{
    // ...     
    services.AddPaypalApi();
}
```
Inject an instance of the proper API class whenever you need it.
``` c#
using Paypal.Net.Sdk.Api;
// ...

// Inject the catalog API class
public IndexModel(CatalogProductApi catalogProductApi) 
{
    _catalogProductApi = catalogProductApi;
}

// Use the catalog API object to get a list of products
public async Task OnGet() 
{
    Definitions.ProductListResponse products = await _catalogProductApi.ListProductsAsync();
}
```
## Why
Paypal's official SDK is not being maintained anymore ([Home · paypal/PayPal-NET-SDK Wiki (github.com)](https://github.com/paypal/PayPal-NET-SDK/wiki)). On top of that this SDK does not provide access to subscription API which allows merchants to create a recurring subscription for customers. This library is aiming to provide an un-opinionated wrapper for Paypal API that plays nicely with .net core dependency injection and configuration framework.
## Todo
 - Update type registration extensions to provide more flexibility for configuration using builder pattern.
 - Add a configuration class and inject in all classes instead of directly accessing IConfiguration.
 - Improve code coverage
 - Add an example asp.net project
 - Create a nuget package and publish
 - Improve unit testability by introducing interfaces for API classes
 - Update this readme with more examples and list of API classes
 - Add webhook examples