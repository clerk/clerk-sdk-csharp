# OauthConfig

Present when the enterprise connection uses OIDC


## Fields

| Field                                                           | Type                                                            | Required                                                        | Description                                                     |
| --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- |
| `Id`                                                            | *string*                                                        | :heavy_minus_sign:                                              | OAuth config ID                                                 |
| `Name`                                                          | *string*                                                        | :heavy_minus_sign:                                              | Custom OIDC provider display name                               |
| `ProviderKey`                                                   | *string*                                                        | :heavy_minus_sign:                                              | OAuth provider key (e.g. oidc_custom)                           |
| `ClientId`                                                      | *string*                                                        | :heavy_minus_sign:                                              | OAuth client ID                                                 |
| `DiscoveryUrl`                                                  | *string*                                                        | :heavy_minus_sign:                                              | OIDC discovery URL                                              |
| `LogoPublicUrl`                                                 | *string*                                                        | :heavy_minus_sign:                                              | Logo URL for the provider                                       |
| `CreatedAt`                                                     | *long*                                                          | :heavy_minus_sign:                                              | Unix timestamp in milliseconds when the config was created      |
| `UpdatedAt`                                                     | *long*                                                          | :heavy_minus_sign:                                              | Unix timestamp in milliseconds when the config was last updated |