# CommerceSubscriptionNextPaymentTotalsProration

Proration details from passed subscription time


## Fields

| Field                                                                     | Type                                                                      | Required                                                                  | Description                                                               |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `Amount`                                                                  | [CommerceMoneyResponse](../../Models/Components/CommerceMoneyResponse.md) | :heavy_check_mark:                                                        | N/A                                                                       |
| `CycleDaysPassed`                                                         | *long*                                                                    | :heavy_check_mark:                                                        | Number of days that have passed in the billing cycle                      |
| `CycleDaysTotal`                                                          | *long*                                                                    | :heavy_check_mark:                                                        | Total number of days in the billing cycle                                 |
| `CyclePassedPercent`                                                      | *double*                                                                  | :heavy_check_mark:                                                        | Percentage of the billing cycle that has passed                           |