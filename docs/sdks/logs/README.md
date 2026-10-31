# Logs

## Overview

### Available Operations

* [List](#list) - List all logs
* [GetSchema](#getschema) - Retrieve the payload schema of a log event type
* [ListGroupEvents](#listgroupevents) - List an event group's logs
* [Get](#get) - Retrieve a single log

## List

Returns a list of logs for the authenticated instance.

Use it to find specific events, such as one user's failed sign-ins or
every event in a trace. Narrow the search with filters and a time range
(`event_time_after` and `event_time_before`), and stop paginating once
you have what you need. Syncing or exporting logs through this endpoint
isn't allowed; use log drains, part of the Enterprise plan, instead.

Results are paginated with cursors. The `next_page_status` field in the
cursor object says whether more results exist:
- `"true"`: more results are available. Pass `starting_after` to get the
  next page.
- `"unknown"`: to keep latency predictable, the server read only part of
  the time range, reported as `searched_from` and `searched_to`. More
  matches may exist in the rest of the range; pass `starting_after` to
  keep searching.
- `"false"`: no more results exist within the requested range.

Results never go back further than the plan's log retention.
`retention_floor` in the cursor object is the oldest timestamp the plan
can return. `retention_limit_reached` is `true` when `next_page_status`
is `"false"` because the search ended at that floor, either because
`event_time_after` asked for older events or because it was omitted.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="ListLogs" method="get" path="/logs" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

ListLogsRequest req = new ListLogsRequest() {
    UserId = "user_2abcDEF",
    Identifier = "ana@example.com",
    TraceId = "1234567890abcdef1234567890abcdef",
    SessionId = "sess_2abcDEF",
    EventTimeAfter = 1705315800000,
    EventTimeBefore = 1705319400000,
};

var res = await sdk.Logs.ListAsync(req);

// handle response
```

### Parameters

| Parameter                                                     | Type                                                          | Required                                                      | Description                                                   |
| ------------------------------------------------------------- | ------------------------------------------------------------- | ------------------------------------------------------------- | ------------------------------------------------------------- |
| `request`                                                     | [ListLogsRequest](../../Models/Operations/ListLogsRequest.md) | :heavy_check_mark:                                            | The request object to use for the request.                    |

### Response

**[ListLogsResponse](../../Models/Operations/ListLogsResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 403, 422, 429                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## GetSchema

Returns the payload schema of a log event type: which fields its
payload carries, addressed by the dot-paths that the `payload_filter`
and `payload_fields` parameters of the list endpoint accept.

`type` accepts a concrete event type (`sign_in.completed`), a
trailing-`*` wildcard (`sign_in.*`), or a bare family name (`sign_in`,
normalized to `sign_in.*` when no concrete type matches — the
response's `event_type`
echoes the normalized form). For wildcard lookups the fields are the
intersection across every matching event type, and `matched_event_types`
lists what the intersection was computed over; per-type metadata
(description, severity, docs_group) is present only for concrete types.

The response is the same for every instance.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetLogSchema" method="get" path="/logs/schemas" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Logs.GetSchemaAsync(type: "sign_in.*");

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                 | Type                                                                                                                                                                                      | Required                                                                                                                                                                                  | Description                                                                                                                                                                               | Example                                                                                                                                                                                   |
| ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `Type`                                                                                                                                                                                    | *string*                                                                                                                                                                                  | :heavy_check_mark:                                                                                                                                                                        | The event type to describe: concrete (`sign_in.completed`),<br/>trailing-`*` wildcard (`sign_in.*`), or bare family name<br/>(`sign_in`). Unknown types return a 422. A bare `*` is not<br/>accepted. | sign_in.*                                                                                                                                                                                 |

### Response

**[GetLogSchemaResponse](../../Models/Operations/GetLogSchemaResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 403, 422, 429                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## ListGroupEvents

Returns the log entries of one event group past the ones a grouped
page of `GET /logs` includes, oldest first, for loading
more of a group. Accepts the same event filters as listing logs, so a
filtered page keeps loading only matching events.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="ListLogGroupEvents" method="get" path="/logs/groups/{group_id}/events" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Logs.ListGroupEventsAsync(
    groupId: "<id>",
    startedAt: 797022,
    limit: 10
);

// handle response
```

### Parameters

| Parameter                                                                                                                                       | Type                                                                                                                                            | Required                                                                                                                                        | Description                                                                                                                                     |
| ----------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------- |
| `GroupId`                                                                                                                                       | *string*                                                                                                                                        | :heavy_check_mark:                                                                                                                              | The ID of the event group, e.g. a sign-in ID.                                                                                                   |
| `StartedAt`                                                                                                                                     | *long*                                                                                                                                          | :heavy_check_mark:                                                                                                                              | When the group started (Unix timestamp in milliseconds), the<br/>`started_at` of the group item. It bounds the time range searched.             |
| `Limit`                                                                                                                                         | *long*                                                                                                                                          | :heavy_minus_sign:                                                                                                                              | Applies a limit to the number of results returned.                                                                                              |
| `StartingAfter`                                                                                                                                 | *string*                                                                                                                                        | :heavy_minus_sign:                                                                                                                              | The group's `events_cursor` from the grouped view, or the<br/>`starting_after` cursor this endpoint returned. Only forward<br/>pagination is supported. |

### Response

**[ListLogGroupEventsResponse](../../Models/Operations/ListLogGroupEventsResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 403, 422, 429                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Get

Returns a single log entry by its composite key ({event_time_ms}:{event_id}).
Unlike the list endpoint, this returns the full payload for the event.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetLog" method="get" path="/logs/{event_time_and_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Logs.GetAsync(eventTimeAndId: "1776207110588:019d8e31-a1bc-7e07-9347-0fd20b25c475");

// handle response
```

### Parameters

| Parameter                                                                                                                                                                                  | Type                                                                                                                                                                                       | Required                                                                                                                                                                                   | Description                                                                                                                                                                                | Example                                                                                                                                                                                    |
| ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| `EventTimeAndId`                                                                                                                                                                           | *string*                                                                                                                                                                                   | :heavy_check_mark:                                                                                                                                                                         | Composite identifier in the format `{event_time_ms}:{event_id}`, where<br/>`event_time_ms` is the event timestamp as a Unix timestamp in milliseconds<br/>and `event_id` is the UUID of the event. | 1776207110588:019d8e31-a1bc-7e07-9347-0fd20b25c475                                                                                                                                         |

### Response

**[GetLogResponse](../../Models/Operations/GetLogResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 401, 403, 404, 429                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |