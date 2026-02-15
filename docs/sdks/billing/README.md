# Billing

## Overview

### Available Operations

* [ListPlans](#listplans) - List all billing plans
* [ListPrices](#listprices) - List all billing prices
* [CreatePrice](#createprice) - Create a custom billing price
* [ListSubscriptionItems](#listsubscriptionitems) - List all subscription items
* [CancelSubscriptionItem](#cancelsubscriptionitem) - Cancel a subscription item
* [ExtendSubscriptionItemFreeTrial](#extendsubscriptionitemfreetrial) - Extend free trial for a subscription item
* [CreatePriceTransition](#createpricetransition) - Create a price transition for a subscription item
* [ListStatements](#liststatements) - List all billing statements
* [GetStatement](#getstatement) - Retrieve a billing statement
* [GetStatementPaymentAttempts](#getstatementpaymentattempts) - List payment attempts for a billing statement

## ListPlans

Returns a list of all billing plans for the instance. The plans are returned sorted by creation date,
with the newest plans appearing first. This includes both free and paid plans. Pagination is supported.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetCommercePlanList" method="get" path="/billing/plans" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Billing.ListPlansAsync(
    limit: 20,
    offset: 10
);

// handle response
```

### Parameters

| Parameter                                                                                                                                 | Type                                                                                                                                      | Required                                                                                                                                  | Description                                                                                                                               | Example                                                                                                                                   |
| ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- |
| `Paginated`                                                                                                                               | *bool*                                                                                                                                    | :heavy_minus_sign:                                                                                                                        | Whether to paginate the results.<br/>If true, the results will be paginated.<br/>If false, the results will not be paginated.             |                                                                                                                                           |
| `Limit`                                                                                                                                   | *long*                                                                                                                                    | :heavy_minus_sign:                                                                                                                        | Applies a limit to the number of results returned.<br/>Can be used for paginating the results together with `offset`.                     | 20                                                                                                                                        |
| `Offset`                                                                                                                                  | *long*                                                                                                                                    | :heavy_minus_sign:                                                                                                                        | Skip the first `offset` results when paginating.<br/>Needs to be an integer greater or equal to zero.<br/>To be used in conjunction with `limit`. | 10                                                                                                                                        |
| `PayerType`                                                                                                                               | [PayerType](../../Models/Operations/PayerType.md)                                                                                         | :heavy_minus_sign:                                                                                                                        | Filter plans by payer type                                                                                                                |                                                                                                                                           |

### Response

**[GetCommercePlanListResponse](../../Models/Operations/GetCommercePlanListResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 422                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## ListPrices

Returns a list of all prices for the instance. The prices are returned sorted by amount ascending,
then by creation date descending. This includes both default and custom prices. Pagination is supported.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetBillingPriceList" method="get" path="/billing/prices" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Billing.ListPricesAsync(
    limit: 20,
    offset: 10
);

// handle response
```

### Parameters

| Parameter                                                                                                                                 | Type                                                                                                                                      | Required                                                                                                                                  | Description                                                                                                                               | Example                                                                                                                                   |
| ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- |
| `Paginated`                                                                                                                               | *bool*                                                                                                                                    | :heavy_minus_sign:                                                                                                                        | Whether to paginate the results.<br/>If true, the results will be paginated.<br/>If false, the results will not be paginated.             |                                                                                                                                           |
| `Limit`                                                                                                                                   | *long*                                                                                                                                    | :heavy_minus_sign:                                                                                                                        | Applies a limit to the number of results returned.<br/>Can be used for paginating the results together with `offset`.                     | 20                                                                                                                                        |
| `Offset`                                                                                                                                  | *long*                                                                                                                                    | :heavy_minus_sign:                                                                                                                        | Skip the first `offset` results when paginating.<br/>Needs to be an integer greater or equal to zero.<br/>To be used in conjunction with `limit`. | 10                                                                                                                                        |
| `PlanId`                                                                                                                                  | *string*                                                                                                                                  | :heavy_minus_sign:                                                                                                                        | Filter prices by plan ID                                                                                                                  |                                                                                                                                           |

### Response

**[GetBillingPriceListResponse](../../Models/Operations/GetBillingPriceListResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## CreatePrice

Creates a custom price for a billing plan. Custom prices allow you to offer different pricing
to specific customers while maintaining the same plan structure.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateBillingPrice" method="post" path="/billing/prices" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

CreateBillingPriceRequest req = new CreateBillingPriceRequest() {
    PlanId = "<id>",
    Amount = 826545,
};

var res = await sdk.Billing.CreatePriceAsync(req);

// handle response
```

### Parameters

| Parameter                                                                         | Type                                                                              | Required                                                                          | Description                                                                       |
| --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- |
| `request`                                                                         | [CreateBillingPriceRequest](../../Models/Components/CreateBillingPriceRequest.md) | :heavy_check_mark:                                                                | The request object to use for the request.                                        |

### Response

**[CreateBillingPriceResponse](../../Models/Operations/CreateBillingPriceResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## ListSubscriptionItems

Returns a list of all subscription items for the instance. The subscription items are returned sorted by creation date,
with the newest appearing first. This includes subscriptions for both users and organizations. Pagination is supported.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetCommerceSubscriptionItemList" method="get" path="/billing/subscription_items" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using Clerk.BackendAPI.Models.Operations;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

GetCommerceSubscriptionItemListRequest req = new GetCommerceSubscriptionItemListRequest() {
    Limit = 20,
    Offset = 10,
};

var res = await sdk.Billing.ListSubscriptionItemsAsync(req);

// handle response
```

### Parameters

| Parameter                                                                                                   | Type                                                                                                        | Required                                                                                                    | Description                                                                                                 |
| ----------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------- |
| `request`                                                                                                   | [GetCommerceSubscriptionItemListRequest](../../Models/Operations/GetCommerceSubscriptionItemListRequest.md) | :heavy_check_mark:                                                                                          | The request object to use for the request.                                                                  |

### Response

**[GetCommerceSubscriptionItemListResponse](../../Models/Operations/GetCommerceSubscriptionItemListResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 422                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## CancelSubscriptionItem

Cancel a specific subscription item. The subscription item can be canceled immediately or at the end of the current billing period.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CancelCommerceSubscriptionItem" method="delete" path="/billing/subscription_items/{subscription_item_id}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Billing.CancelSubscriptionItemAsync(
    subscriptionItemId: "<id>",
    endNow: false
);

// handle response
```

### Parameters

| Parameter                                                                                                          | Type                                                                                                               | Required                                                                                                           | Description                                                                                                        |
| ------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------------------------ |
| `SubscriptionItemId`                                                                                               | *string*                                                                                                           | :heavy_check_mark:                                                                                                 | The ID of the subscription item to cancel                                                                          |
| `EndNow`                                                                                                           | *bool*                                                                                                             | :heavy_minus_sign:                                                                                                 | Whether to cancel the subscription immediately (true) or at the end of the current billing period (false, default) |

### Response

**[CancelCommerceSubscriptionItemResponse](../../Models/Operations/CancelCommerceSubscriptionItemResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## ExtendSubscriptionItemFreeTrial

Extends the free trial period for a specific subscription item to the specified timestamp.
The subscription item must be currently in a free trial period, and the plan must support free trials.
The timestamp must be in the future and not more than 365 days from the end of the current trial period
This operation is idempotent - repeated requests with the same timestamp will not change the trial period.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="ExtendBillingSubscriptionItemFreeTrial" method="post" path="/billing/subscription_items/{subscription_item_id}/extend_free_trial" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;
using System;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Billing.ExtendSubscriptionItemFreeTrialAsync(
    subscriptionItemId: "<id>",
    extendFreeTrialRequest: new ExtendFreeTrialRequest() {
        ExtendTo = System.DateTime.Parse("2026-01-08T00:00:00Z"),
    }
);

// handle response
```

### Parameters

| Parameter                                                                   | Type                                                                        | Required                                                                    | Description                                                                 |
| --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- |
| `SubscriptionItemId`                                                        | *string*                                                                    | :heavy_check_mark:                                                          | The ID of the subscription item to extend the free trial for                |
| `ExtendFreeTrialRequest`                                                    | [ExtendFreeTrialRequest](../../Models/Components/ExtendFreeTrialRequest.md) | :heavy_check_mark:                                                          | Parameters for extending the free trial                                     |

### Response

**[ExtendBillingSubscriptionItemFreeTrialResponse](../../Models/Operations/ExtendBillingSubscriptionItemFreeTrialResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 422                    | application/json                           |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## CreatePriceTransition

Creates a price transition for the specified subscription item.
This may create an upcoming subscription item or activate immediately depending on plan and payer rules.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="CreateBillingPriceTransition" method="post" path="/billing/subscription_items/{subscription_item_id}/price_transition" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Billing.CreatePriceTransitionAsync(
    subscriptionItemId: "<id>",
    priceTransitionRequest: new PriceTransitionRequest() {
        FromPriceId = "<id>",
        ToPriceId = "<id>",
    }
);

// handle response
```

### Parameters

| Parameter                                                                   | Type                                                                        | Required                                                                    | Description                                                                 |
| --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- | --------------------------------------------------------------------------- |
| `SubscriptionItemId`                                                        | *string*                                                                    | :heavy_check_mark:                                                          | The ID of the subscription item to transition                               |
| `PriceTransitionRequest`                                                    | [PriceTransitionRequest](../../Models/Components/PriceTransitionRequest.md) | :heavy_check_mark:                                                          | Parameters for the price transition                                         |

### Response

**[CreateBillingPriceTransitionResponse](../../Models/Operations/CreateBillingPriceTransitionResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 403, 404, 409, 422               | application/json                           |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## ListStatements

Returns a list of all billing statements for the instance. The statements are returned sorted by creation date,
with the newest statements appearing first. Pagination is supported.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetBillingStatementList" method="get" path="/billing/statements" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Billing.ListStatementsAsync(
    limit: 20,
    offset: 10
);

// handle response
```

### Parameters

| Parameter                                                                                                                                 | Type                                                                                                                                      | Required                                                                                                                                  | Description                                                                                                                               | Example                                                                                                                                   |
| ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- |
| `Paginated`                                                                                                                               | *bool*                                                                                                                                    | :heavy_minus_sign:                                                                                                                        | Whether to paginate the results.<br/>If true, the results will be paginated.<br/>If false, the results will not be paginated.             |                                                                                                                                           |
| `Limit`                                                                                                                                   | *long*                                                                                                                                    | :heavy_minus_sign:                                                                                                                        | Applies a limit to the number of results returned.<br/>Can be used for paginating the results together with `offset`.                     | 20                                                                                                                                        |
| `Offset`                                                                                                                                  | *long*                                                                                                                                    | :heavy_minus_sign:                                                                                                                        | Skip the first `offset` results when paginating.<br/>Needs to be an integer greater or equal to zero.<br/>To be used in conjunction with `limit`. | 10                                                                                                                                        |

### Response

**[GetBillingStatementListResponse](../../Models/Operations/GetBillingStatementListResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 422                              | application/json                           |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## GetStatement

Retrieves the details of a billing statement.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetBillingStatement" method="get" path="/billing/statements/{statementID}" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Billing.GetStatementAsync(statementID: "<id>");

// handle response
```

### Parameters

| Parameter                            | Type                                 | Required                             | Description                          |
| ------------------------------------ | ------------------------------------ | ------------------------------------ | ------------------------------------ |
| `StatementID`                        | *string*                             | :heavy_check_mark:                   | The ID of the statement to retrieve. |

### Response

**[GetBillingStatementResponse](../../Models/Operations/GetBillingStatementResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |

## GetStatementPaymentAttempts

Returns a list of all payment attempts for a specific billing statement. The payment attempts are returned sorted by creation date,
with the newest payment attempts appearing first. Pagination is supported.

### Example Usage

<!-- UsageSnippet language="csharp" operationID="GetBillingStatementPaymentAttempts" method="get" path="/billing/statements/{statementID}/payment_attempts" -->
```csharp
using Clerk.BackendAPI;
using Clerk.BackendAPI.Models.Components;

var sdk = new ClerkBackendApi(bearerAuth: "<YOUR_BEARER_TOKEN_HERE>");

var res = await sdk.Billing.GetStatementPaymentAttemptsAsync(
    statementID: "<id>",
    limit: 20,
    offset: 10
);

// handle response
```

### Parameters

| Parameter                                                                                                                                 | Type                                                                                                                                      | Required                                                                                                                                  | Description                                                                                                                               | Example                                                                                                                                   |
| ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------- |
| `StatementID`                                                                                                                             | *string*                                                                                                                                  | :heavy_check_mark:                                                                                                                        | The ID of the statement to retrieve payment attempts for.                                                                                 |                                                                                                                                           |
| `Paginated`                                                                                                                               | *bool*                                                                                                                                    | :heavy_minus_sign:                                                                                                                        | Whether to paginate the results.<br/>If true, the results will be paginated.<br/>If false, the results will not be paginated.             |                                                                                                                                           |
| `Limit`                                                                                                                                   | *long*                                                                                                                                    | :heavy_minus_sign:                                                                                                                        | Applies a limit to the number of results returned.<br/>Can be used for paginating the results together with `offset`.                     | 20                                                                                                                                        |
| `Offset`                                                                                                                                  | *long*                                                                                                                                    | :heavy_minus_sign:                                                                                                                        | Skip the first `offset` results when paginating.<br/>Needs to be an integer greater or equal to zero.<br/>To be used in conjunction with `limit`. | 10                                                                                                                                        |

### Response

**[GetBillingStatementPaymentAttemptsResponse](../../Models/Operations/GetBillingStatementPaymentAttemptsResponse.md)**

### Errors

| Error Type                                 | Status Code                                | Content Type                               |
| ------------------------------------------ | ------------------------------------------ | ------------------------------------------ |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 400, 401, 404, 422                         | application/json                           |
| Clerk.BackendAPI.Models.Errors.ClerkErrors | 500                                        | application/json                           |
| Clerk.BackendAPI.Models.Errors.SDKError    | 4XX, 5XX                                   | \*/\*                                      |