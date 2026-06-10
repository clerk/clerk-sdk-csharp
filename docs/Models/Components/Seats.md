# Seats

Seat quantity for seat-based billing.


## Fields

| Field                                                                                               | Type                                                                                                | Required                                                                                            | Description                                                                                         |
| --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------- |
| `Quantity`                                                                                          | *long*                                                                                              | :heavy_check_mark:                                                                                  | Seat quantity being billed; null means unlimited                                                    |
| `Tiers`                                                                                             | List<[SchemasCommercePerUnitTotalTier](../../Models/Components/SchemasCommercePerUnitTotalTier.md)> | :heavy_minus_sign:                                                                                  | Per-unit cost breakdown by pricing tier                                                             |