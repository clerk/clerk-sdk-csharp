# SchemasEnterpriseConnectionSamlConnection

Present when the enterprise connection uses SAML


## Fields

| Field                                                           | Type                                                            | Required                                                        | Description                                                     |
| --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- | --------------------------------------------------------------- |
| `Id`                                                            | *string*                                                        | :heavy_minus_sign:                                              | SAML connection ID                                              |
| `Name`                                                          | *string*                                                        | :heavy_minus_sign:                                              | SAML connection display name                                    |
| `IdpEntityId`                                                   | *string*                                                        | :heavy_minus_sign:                                              | IdP entity ID (optional, when connection details are loaded)    |
| `IdpSsoUrl`                                                     | *string*                                                        | :heavy_minus_sign:                                              | IdP SSO URL (optional, when connection details are loaded)      |
| `IdpMetadataUrl`                                                | *string*                                                        | :heavy_minus_sign:                                              | IdP metadata URL (optional, when connection details are loaded) |
| `AcsUrl`                                                        | *string*                                                        | :heavy_minus_sign:                                              | Assertion Consumer Service URL                                  |
| `SpEntityId`                                                    | *string*                                                        | :heavy_minus_sign:                                              | Service Provider entity ID                                      |
| `SpMetadataUrl`                                                 | *string*                                                        | :heavy_minus_sign:                                              | Service Provider metadata URL                                   |
| `Active`                                                        | *bool*                                                          | :heavy_minus_sign:                                              | Whether the SAML connection is active                           |
| `AllowIdpInitiated`                                             | *bool*                                                          | :heavy_minus_sign:                                              | Whether IdP-initiated SSO is allowed                            |
| `AllowSubdomains`                                               | *bool*                                                          | :heavy_minus_sign:                                              | Whether subdomains are allowed for domain matching              |
| `ForceAuthn`                                                    | *bool*                                                          | :heavy_minus_sign:                                              | Whether to force re-authentication                              |