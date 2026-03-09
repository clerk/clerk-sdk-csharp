# AgentTasks

## Overview

### Available Operations

* [Create](#create) - Create agent task
* [Revoke](#revoke) - Revoke agent task

## Create

Create an agent task on behalf of a user.
The response contains a URL that, when visited, creates a session for the user.
The agent_id is stable per agent_name within an instance. The task_id is unique per call.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateAgentTask" method="post" path="/agents/tasks" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateAgentTaskRequestBody? req = null;

var res = await sdk.AgentTasks.CreateAsync(req);

// handle response
```

### Parameters

| Parameter                                                                           | Type                                                                                | Required                                                                            | Description                                                                         |
| ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------- |
| `request`                                                                           | [CreateAgentTaskRequestBody](../../Models/Operations/CreateAgentTaskRequestBody.md) | :heavy_check_mark:                                                                  | The request object to use for the request.                                          |

### Response

**[CreateAgentTaskResponse](../../Models/Operations/CreateAgentTaskResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 404, 422                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## Revoke

Revokes a pending agent task.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="RevokeAgentTask" method="post" path="/agents/tasks/{agent_task_id}/revoke" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.AgentTasks.RevokeAsync(agentTaskId: "<id>");

// handle response
```

### Parameters

| Parameter                               | Type                                    | Required                                | Description                             |
| --------------------------------------- | --------------------------------------- | --------------------------------------- | --------------------------------------- |
| `AgentTaskId`                           | *string*                                | :heavy_check_mark:                      | The ID of the agent task to be revoked. |

### Response

**[RevokeAgentTaskResponse](../../Models/Operations/RevokeAgentTaskResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 404                                   | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |