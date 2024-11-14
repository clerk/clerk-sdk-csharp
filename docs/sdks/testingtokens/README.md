# TestingTokens
(*TestingTokens*)

## Overview

### Available Operations

* [Create](#create) - Retrieve a new testing token

## Create

Retrieve a new testing token. Only available for development instances.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.TestingTokens.CreateAsync();

// handle response
```

### Response

**[CreateTestingTokenResponse](../../Models/Operations/CreateTestingTokenResponse.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| Clerk.BackendAPI.Models.Errors.SDKError | 4XX, 5XX                                | \*/\*                                   |