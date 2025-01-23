# AllowBlockList
(*AllowBlockList*)

## Overview

### Available Operations

* [DeleteIdentifier](#deleteidentifier) - Delete identifier from block-list

## DeleteIdentifier

Delete an identifier from the instance block-list

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.AllowBlockList.DeleteIdentifierAsync(identifierId: "identifier123");

// handle response
```

### Parameters

| Parameter                                              | Type                                                   | Required                                               | Description                                            | Example                                                |
| ------------------------------------------------------ | ------------------------------------------------------ | ------------------------------------------------------ | ------------------------------------------------------ | ------------------------------------------------------ |
| `IdentifierId`                                         | *string*                                               | :heavy_check_mark:                                     | The ID of the identifier to delete from the block-list | identifier123                                          |

### Response

**[DeleteBlocklistIdentifierResponse](../../Models/Operations/DeleteBlocklistIdentifierResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 402, 404                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |