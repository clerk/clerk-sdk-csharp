# BlocklistIdentifiers
(*BlocklistIdentifiers*)

## Overview

### Available Operations

* [Create](#create) - Add identifier to the block-list

## Create

Create an identifier that is blocked from accessing an instance

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Operations;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateBlocklistIdentifierRequestBody req = new CreateBlocklistIdentifierRequestBody() {
    Identifier = "<value>",
};

var res = await sdk.BlocklistIdentifiers.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                               | Type                                                                                                    | Required                                                                                                | Description                                                                                             |
| ------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------- |
| `request`                                                                                               | [CreateBlocklistIdentifierRequestBody](../../Models/Operations/CreateBlocklistIdentifierRequestBody.md) | :heavy_check_mark:                                                                                      | The request object to use for the request.                                                              |

### Response

**[CreateBlocklistIdentifierResponse](../../Models/Operations/CreateBlocklistIdentifierResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 402, 422                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |