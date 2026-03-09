# CommercePlanUnitPriceTier


## Fields

| Field                                                                     | Type                                                                      | Required                                                                  | Description                                                               |
| ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- | ------------------------------------------------------------------------- |
| `StartsAtBlock`                                                           | *long*                                                                    | :heavy_check_mark:                                                        | Start block (inclusive) for this tier                                     |
| `EndsAfterBlock`                                                          | *long*                                                                    | :heavy_minus_sign:                                                        | End block (inclusive) for this tier; null means unlimited                 |
| `FeePerBlock`                                                             | [CommerceMoneyResponse](../../Models/Components/CommerceMoneyResponse.md) | :heavy_check_mark:                                                        | N/A                                                                       |