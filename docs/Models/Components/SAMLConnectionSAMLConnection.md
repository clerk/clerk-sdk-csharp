# SAMLConnectionSAMLConnection


## Fields

| Field                              | Type                               | Required                           | Description                        | Example                            |
| ---------------------------------- | ---------------------------------- | ---------------------------------- | ---------------------------------- | ---------------------------------- |
| `Id`                               | *string*                           | :heavy_check_mark:                 | N/A                                | sc_1234567890                      |
| `Name`                             | *string*                           | :heavy_check_mark:                 | N/A                                | My Company SAML Config             |
| `Domain`                           | *string*                           | :heavy_check_mark:                 | N/A                                | mycompany.com                      |
| `Active`                           | *bool*                             | :heavy_check_mark:                 | N/A                                | true                               |
| `Provider`                         | *string*                           | :heavy_check_mark:                 | N/A                                | saml_custom                        |
| `SyncUserAttributes`               | *bool*                             | :heavy_check_mark:                 | N/A                                | true                               |
| `AllowSubdomains`                  | *bool*                             | :heavy_minus_sign:                 | N/A                                | false                              |
| `AllowIdpInitiated`                | *bool*                             | :heavy_minus_sign:                 | N/A                                | true                               |
| `DisableAdditionalIdentifications` | *bool*                             | :heavy_minus_sign:                 | N/A                                |                                    |
| `CreatedAt`                        | *long*                             | :heavy_check_mark:                 | Unix timestamp of creation.<br/>   | 1614768000                         |
| `UpdatedAt`                        | *long*                             | :heavy_check_mark:                 | Unix timestamp of last update.<br/> | 1622540800                         |