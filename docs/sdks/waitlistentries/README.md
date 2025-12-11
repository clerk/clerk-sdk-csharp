# WaitlistEntries

## Overview

### Available Operations

* [List](#list) - List all waitlist entries
* [Create](#create) - Create a waitlist entry
* [Delete](#delete) - Delete a pending waitlist entry
* [Invite](#invite) - Invite a waitlist entry
* [Reject](#reject) - Reject a waitlist entry

## List

Retrieve a list of waitlist entries for the instance.
Entries are ordered by creation date in descending order by default.
Supports filtering by email address or status and pagination with limit and offset parameters.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="ListWaitlistEntries" method="get" path="/waitlist_entries" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

ListWaitlistEntriesRequest req = new ListWaitlistEntriesRequest() {
    Limit = 20,
    Offset = 10,
};

var res = await sdk.WaitlistEntries.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `request`                                                                           | [ListWaitlistEntriesRequest](../../Models/Operations/ListWaitlistEntriesRequest.md) | :heavy_check_mark:                                                                  | The request object to use for the request.                                          |

### Response

**[ListWaitlistEntriesResponse](../../Models/Operations/ListWaitlistEntriesResponse.md)**

### Errors

| Error Type                              | Status Code                             | Content Type                            |
| --------------------------------------- | --------------------------------------- | --------------------------------------- |
| Clerk.BackendAPI.Models.Errors.SDKError | 4XX, 5XX                                | \*/\*                                   |

## Create

Creates a new waitlist entry for the given email address.
If the email address is already on the waitlist, no new entry will be created and the existing waitlist entry will be returned.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateWaitlistEntry" method="post" path="/waitlist_entries" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateWaitlistEntryRequestBody? req = null;

var res = await sdk.WaitlistEntries.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                   | Type                                                                                        | Required                                                                                    | Description                                                                                 |
| ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- |
| `request`                                                                                   | [CreateWaitlistEntryRequestBody](../../Models/Operations/CreateWaitlistEntryRequestBody.md) | :heavy_check_mark:                                                                          | The request object to use for the request.                                                  |

### Response

**[CreateWaitlistEntryResponse](../../Models/Operations/CreateWaitlistEntryResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 422                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Delete

Delete a pending waitlist entry.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="DeleteWaitlistEntry" method="delete" path="/waitlist_entries/{waitlist_entry_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.WaitlistEntries.DeleteAsync(waitlistEntryId: "<id>");

// handle response
```

### Parameters

| Parameter                              | Type                                   | Required                               | Description                            |
| -------------------------------------- | -------------------------------------- | -------------------------------------- | -------------------------------------- |
| `WaitlistEntryId`                      | *string*                               | :heavy_check_mark:                     | The ID of the waitlist entry to delete |

### Response

**[DeleteWaitlistEntryResponse](../../Models/Operations/DeleteWaitlistEntryResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 404, 409, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Invite

Send an invite to the email address in a waitlist entry.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="InviteWaitlistEntry" method="post" path="/waitlist_entries/{waitlist_entry_id}/invite" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.WaitlistEntries.InviteAsync(waitlistEntryId: "<id>");

// handle response
```

### Parameters

| Parameter                                                                                   | Type                                                                                        | Required                                                                                    | Description                                                                                 |
| ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- |
| `WaitlistEntryId`                                                                           | *string*                                                                                    | :heavy_check_mark:                                                                          | The ID of the waitlist entry to invite                                                      |
| `RequestBody`                                                                               | [InviteWaitlistEntryRequestBody](../../Models/Operations/InviteWaitlistEntryRequestBody.md) | :heavy_minus_sign:                                                                          | N/A                                                                                         |

### Response

**[InviteWaitlistEntryResponse](../../Models/Operations/InviteWaitlistEntryResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 404, 409, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Reject

Reject a waitlist entry.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="RejectWaitlistEntry" method="post" path="/waitlist_entries/{waitlist_entry_id}/reject" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.WaitlistEntries.RejectAsync(waitlistEntryId: "<id>");

// handle response
```

### Parameters

| Parameter                              | Type                                   | Required                               | Description                            |
| -------------------------------------- | -------------------------------------- | -------------------------------------- | -------------------------------------- |
| `WaitlistEntryId`                      | *string*                               | :heavy_check_mark:                     | The ID of the waitlist entry to reject |

### Response

**[RejectWaitlistEntryResponse](../../Models/Operations/RejectWaitlistEntryResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 404, 409, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |