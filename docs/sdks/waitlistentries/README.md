# WaitlistEntries
(*WaitlistEntries*)

## Overview

### Available Operations

* [ListWaitlistEntries](#listwaitlistentries) - List all waitlist entries
* [CreateWaitlistEntry](#createwaitlistentry) - Create a waitlist entry

## ListWaitlistEntries

Retrieve a list of waitlist entries for the instance.
Entries are ordered by creation date in descending order by default.
Supports filtering by email address or status and pagination with limit and offset parameters.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

ListWaitlistEntriesRequest req = new ListWaitlistEntriesRequest() {};

var res = await sdk.WaitlistEntries.ListWaitlistEntriesAsync(req);

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

## CreateWaitlistEntry

Creates a new waitlist entry for the given email address.
If the email address is already on the waitlist, no new entry will be created and the existing waitlist entry will be returned.

### Example Usage

```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateWaitlistEntryRequestBody req = new CreateWaitlistEntryRequestBody() {
    EmailAddress = "Demond_Willms@hotmail.com",
};

var res = await sdk.WaitlistEntries.CreateWaitlistEntryAsync(req);

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