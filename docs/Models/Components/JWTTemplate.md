# JWTTemplate

List of JWT templates


## Fields

| Field                                                             | Type                                                              | Required                                                          | Description                                                       |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `Object`                                                          | [JWTTemplateObject](../../Models/Components/JWTTemplateObject.md) | :heavy_check_mark:                                                | N/A                                                               |
| `Id`                                                              | *string*                                                          | :heavy_check_mark:                                                | N/A                                                               |
| `Name`                                                            | *string*                                                          | :heavy_check_mark:                                                | N/A                                                               |
| `Claims`                                                          | [Models.Components.Claims](../../Models/Components/Claims.md)     | :heavy_check_mark:                                                | N/A                                                               |
| `Lifetime`                                                        | *long*                                                            | :heavy_check_mark:                                                | N/A                                                               |
| `AllowedClockSkew`                                                | *long*                                                            | :heavy_check_mark:                                                | N/A                                                               |
| `CustomSigningKey`                                                | *bool*                                                            | :heavy_minus_sign:                                                | N/A                                                               |
| `SigningAlgorithm`                                                | *string*                                                          | :heavy_minus_sign:                                                | N/A                                                               |
| `CreatedAt`                                                       | *long*                                                            | :heavy_check_mark:                                                | Unix timestamp of creation.<br/>                                  |
| `UpdatedAt`                                                       | *long*                                                            | :heavy_check_mark:                                                | Unix timestamp of last update.<br/>                               |