# JwtTemplates
(*JwtTemplates*)

## Overview

### Available Operations

* [List](#list) - List all templates
* [Create](#create) - Create a JWT template
* [Get](#get) - Retrieve a template
* [Update](#update) - Update a JWT template
* [Delete](#delete) - Delete a Template

## List

List all templates

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.JwtTemplates.ListAsync();

// handle response
```

### Response

**[ListJWTTemplatesResponse](../../Models/Operations/ListJWTTemplatesResponse.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| Clerk.BackendAPI.Models.Errors.SDKError | 4XX, 5XX                                | \*/\*                                   |

## Create

Create a new JWT template

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateJWTTemplateRequestBody req = new CreateJWTTemplateRequestBody() {};

var res = await sdk.JwtTemplates.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `request`                                                                               | [CreateJWTTemplateRequestBody](../../Models/Operations/CreateJWTTemplateRequestBody.md) | :heavy_check_mark:                                                                      | The request object to use for the request.                                              |

### Response

**[CreateJWTTemplateResponse](../../Models/Operations/CreateJWTTemplateResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 402, 422                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Get

Retrieve the details of a given JWT template

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.JwtTemplates.GetAsync(templateId: "<id>");

// handle response
```

### Parameters

| Parameter          | Type               | Required           | Description        |
| ------------------ | ------------------ | ------------------ | ------------------ |
| `TemplateId`       | *string*           | :heavy_check_mark: | JWT Template ID    |

### Response

**[GetJWTTemplateResponse](../../Models/Operations/GetJWTTemplateResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 404                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Update

Updates an existing JWT template

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.JwtTemplates.UpdateAsync(
    templateId: "<id>",
    requestBody: new UpdateJWTTemplateRequestBody() {}
);

// handle response
```

### Parameters

| Parameter                                                                               | Type                                                                                    | Required                                                                                | Description                                                                             |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `TemplateId`                                                                            | *string*                                                                                | :heavy_check_mark:                                                                      | The ID of the JWT template to update                                                    |
| `RequestBody`                                                                           | [UpdateJWTTemplateRequestBody](../../Models/Operations/UpdateJWTTemplateRequestBody.md) | :heavy_minus_sign:                                                                      | N/A                                                                                     |

### Response

**[UpdateJWTTemplateResponse](../../Models/Operations/UpdateJWTTemplateResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 402, 422                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Delete

Delete a Template

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.JwtTemplates.DeleteAsync(templateId: "<id>");

// handle response
```

### Parameters

| Parameter          | Type               | Required           | Description        |
| ------------------ | ------------------ | ------------------ | ------------------ |
| `TemplateId`       | *string*           | :heavy_check_mark: | JWT Template ID    |

### Response

**[DeleteJWTTemplateResponse](../../Models/Operations/DeleteJWTTemplateResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 403, 404                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |