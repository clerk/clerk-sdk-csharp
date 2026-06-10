# Otp


## Fields

| Field                                                               | Type                                                                | Required                                                            | Description                                                         |
| ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- | ------------------------------------------------------------------- |
| `Object`                                                            | [VerificationObject](../../Models/Components/VerificationObject.md) | :heavy_minus_sign:                                                  | N/A                                                                 |
| `Status`                                                            | [VerificationStatus](../../Models/Components/VerificationStatus.md) | :heavy_check_mark:                                                  | N/A                                                                 |
| `Strategy`                                                          | [Strategy](../../Models/Components/Strategy.md)                     | :heavy_check_mark:                                                  | N/A                                                                 |
| `Attempts`                                                          | *long*                                                              | :heavy_check_mark:                                                  | N/A                                                                 |
| `ExpireAt`                                                          | *long*                                                              | :heavy_check_mark:                                                  | N/A                                                                 |
| `Channel`                                                           | *string*                                                            | :heavy_minus_sign:                                                  | The delivery channel of the code (phone codes only).                |
| `VerifiedAtClient`                                                  | *string*                                                            | :heavy_minus_sign:                                                  | N/A                                                                 |