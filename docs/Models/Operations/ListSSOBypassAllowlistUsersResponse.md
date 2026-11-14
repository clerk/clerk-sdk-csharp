# ListSSOBypassAllowlistUsersResponse


## Fields

| Field                                                                             | Type                                                                              | Required                                                                          | Description                                                                       |
| --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- |
| `HttpMeta`                                                                        | [HTTPMetadata](../../Models/Components/HTTPMetadata.md)                           | :heavy_check_mark:                                                                | N/A                                                                               |
| `SSOBypassAllowlistUsers`                                                         | List<[SSOBypassAllowlistUser](../../Models/Components/SSOBypassAllowlistUser.md)> | :heavy_minus_sign:                                                                | The instance's SSO bypass allowlist, deduplicated by user                         |