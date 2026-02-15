# CreateBillingPriceRequest


## Fields

| Field                                                               | Type                                                                | Required                                                            | Description                                                         |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `PlanId`                                                            | *string*                                                            | :heavy_check_mark:                                                  | The ID of the plan this price belongs to.                           |
| `Currency`                                                          | *string*                                                            | :heavy_minus_sign:                                                  | The currency code (e.g., "USD"). Defaults to USD.                   |
| `Amount`                                                            | *long*                                                              | :heavy_check_mark:                                                  | The amount in cents for the price. Must be at least $1 (100 cents). |
| `AnnualMonthlyAmount`                                               | *long*                                                              | :heavy_minus_sign:                                                  | The monthly amount in cents when billed annually. Optional.         |
| `Description`                                                       | *string*                                                            | :heavy_minus_sign:                                                  | An optional description for this custom price.                      |