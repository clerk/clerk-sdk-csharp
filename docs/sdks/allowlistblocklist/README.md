# AllowListBlockList
(*AllowListBlockList*)

## Overview

### Available Operations

* [ListBlocklistIdentifiers](#listblocklistidentifiers) - List all identifiers on the block-list

## ListBlocklistIdentifiers

Get a list of all identifiers which are not allowed to access an instance

### Example Usage

```csharp
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas;
using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.AllowListBlockList.ListBlocklistIdentifiersAsync();

// handle response
```

### Response

**[ListBlocklistIdentifiersResponse](../../Models/Requests/ListBlocklistIdentifiersResponse.md)**

### Errors

| Error Type                                                                    | Status Code                                                                   | Content Type                                                                  |
| ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- | ----------------------------------------------------------------------------- |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.ClerkErrors  | 401, 402                                                                      | application/json                                                              |
| OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Errors.APIException | 4XX, 5XX                                                                      | \*/\*                                                                         |