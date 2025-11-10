# Groups

A statement group.


## Fields

| Field                                                                                   | Type                                                                                    | Required                                                                                | Description                                                                             |
| --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------- |
| `Object`                                                                                | [BillingStatementGroupsObject](../../Models/Components/BillingStatementGroupsObject.md) | :heavy_check_mark:                                                                      | String representing the object's type. Objects of the same type share the same value.   |
| `Timestamp`                                                                             | *long*                                                                                  | :heavy_check_mark:                                                                      | Unix timestamp (in milliseconds) of the date the group's payment attempts were created  |
| `Items`                                                                                 | List<[BillingPaymentAttempt](../../Models/Components/BillingPaymentAttempt.md)>         | :heavy_check_mark:                                                                      | The payment attempts included in the group                                              |