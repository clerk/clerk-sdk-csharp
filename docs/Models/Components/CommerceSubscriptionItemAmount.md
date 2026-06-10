# CommerceSubscriptionItemAmount

Base plan fee for the next payment. Does not include per-unit (e.g. seat) charges; see `totals.grand_total` for the full amount.


## Fields

| Field                                              | Type                                               | Required                                           | Description                                        |
| -------------------------------------------------- | -------------------------------------------------- | -------------------------------------------------- | -------------------------------------------------- |
| `Amount`                                           | *long*                                             | :heavy_check_mark:                                 | The amount in cents.                               |
| `AmountFormatted`                                  | *string*                                           | :heavy_check_mark:                                 | The formatted amount as a string (e.g., "$49.99"). |
| `Currency`                                         | *string*                                           | :heavy_check_mark:                                 | The currency code (e.g., "USD").                   |
| `CurrencySymbol`                                   | *string*                                           | :heavy_check_mark:                                 | The currency symbol (e.g., "$").                   |