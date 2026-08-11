# SAMLConnectionLoginHint

Configuration for the login_hint sent to the IdP on SSO sign-in


## Fields

| Field                                                                                            | Type                                                                                             | Required                                                                                         | Description                                                                                      |
| ------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------ |
| `Mode`                                                                                           | [Models.Components.Mode](../../Models/Components/Mode.md)                                        | :heavy_check_mark:                                                                               | Controls the login_hint sent to the IdP on SSO sign-in                                           |
| `Source`                                                                                         | *string*                                                                                         | :heavy_minus_sign:                                                                               | The user public_metadata key whose value is sent as the login_hint when mode is custom_attribute |