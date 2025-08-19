# AwsCredentials
(*AwsCredentials*)

## Overview

### Available Operations

* [Delete](#delete) - Delete an AWS Credential
* [Update](#update) - Update an AWS Credential

## Delete

Delete the AWS Credential with the given ID

### Example Usage

<!-- UsageSnippet language="csharp" operationID="DeleteAWSCredential" method="delete" path="/aws_credentials/{id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.AwsCredentials.DeleteAsync(id: "<id>");

// handle response
```

### Parameters

| Parameter                              | Type                                   | Required                               | Description                            |
| -------------------------------------- | -------------------------------------- | -------------------------------------- | -------------------------------------- |
| `Id`                                   | *string*                               | :heavy_check_mark:                     | The ID of the AWS Credential to delete |

### Response

**[DeleteAWSCredentialResponse](../../Models/Operations/DeleteAWSCredentialResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Update

Updates an AWS credential.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="UpdateAWSCredential" method="patch" path="/aws_credentials/{id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.AwsCredentials.UpdateAsync(id: "<id>");

// handle response
```

### Parameters

| Parameter                                                                                   | Type                                                                                        | Required                                                                                    | Description                                                                                 |
| ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- |
| `Id`                                                                                        | *string*                                                                                    | :heavy_check_mark:                                                                          | The ID of the AWS Credential to update                                                      |
| `RequestBody`                                                                               | [UpdateAWSCredentialRequestBody](../../Models/Operations/UpdateAWSCredentialRequestBody.md) | :heavy_minus_sign:                                                                          | N/A                                                                                         |

### Response

**[UpdateAWSCredentialResponse](../../Models/Operations/UpdateAWSCredentialResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |