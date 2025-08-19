# Jwks
(*Jwks*)

## Overview

### Available Operations

* [GetJWKS](#getjwks) - Retrieve the JSON Web Key Set of the instance

## GetJWKS

Retrieve the JSON Web Key Set of the instance

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetJWKS" method="get" path="/jwks" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Jwks.GetJWKSAsync();

// handle response
```

### Response

**[GetJWKSResponse](../../Models/Operations/GetJWKSResponse.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| Clerk.BackendAPI.Models.Errors.SDKError | 4XX, 5XX                                | \*/\*                                   |