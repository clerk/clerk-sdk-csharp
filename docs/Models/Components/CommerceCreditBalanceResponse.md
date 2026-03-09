# CommerceCreditBalanceResponse

A payer's credit balance.


## Fields

| Field                                                                    | Type                                                                     | Required                                                                 | Description                                                              |
| ------------------------------------------------------------------------ | ------------------------------------------------------------------------ | ------------------------------------------------------------------------ | ------------------------------------------------------------------------ |
| `Object`                                                                 | *string*                                                                 | :heavy_check_mark:                                                       | String representing the object's type. Always "commerce_credit_balance". |
| `Balance`                                                                | [Balance](../../Models/Components/Balance.md)                            | :heavy_check_mark:                                                       | The current credit balance. Null when the payer has never had credits.   |