# Webhooks
(*Webhooks*)

## Overview

You can configure webhooks to be notified about various events that happen on your instance.
<https://clerk.com/docs/integration/webhooks>

### Available Operations

* [CreateSvixApp](#createsvixapp) - Create a Svix app
* [DeleteSvixApp](#deletesvixapp) - Delete a Svix app
* [GenerateSvixAuthURL](#generatesvixauthurl) - Create a Svix Dashboard URL

## CreateSvixApp

Create a Svix app and associate it with the current instance

### Example Usage

```csharp
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Webhooks.CreateSvixAppAsync();

// handle response
```

### Response

**[CreateSvixAppResponse](../../Models/Requests/CreateSvixAppResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.ClerkErrors  | 400                                                                           | application/json                                                              |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.APIException | 4XX, 5XX                                                                      | \*/\*                                                                         |

## DeleteSvixApp

Delete a Svix app and disassociate it from the current instance

### Example Usage

```csharp
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Webhooks.DeleteSvixAppAsync();

// handle response
```

### Response

**[DeleteSvixAppResponse](../../Models/Requests/DeleteSvixAppResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.ClerkErrors  | 400                                                                           | application/json                                                              |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.APIException | 4XX, 5XX                                                                      | \*/\*                                                                         |

## GenerateSvixAuthURL

Generate a new url for accessing the Svix's management dashboard for that particular instance

### Example Usage

```csharp
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Webhooks.GenerateSvixAuthURLAsync();

// handle response
```

### Response

**[GenerateSvixAuthURLResponse](../../Models/Requests/GenerateSvixAuthURLResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.ClerkErrors  | 400                                                                           | application/json                                                              |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.APIException | 4XX, 5XX                                                                      | \*/\*                                                                         |