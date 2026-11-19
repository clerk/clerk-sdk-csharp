# ~~Scim~~

Alias of directory. Use directories for all links.

> :warning: **DEPRECATED**: This will be removed in a future release, please migrate away from it as soon as possible.


## Fields

| Field                                                                           | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `Id`                                                                            | *string*                                                                        | :heavy_check_mark:                                                              | The user's resource ID in this directory.                                       |
| `DirectoryName`                                                                 | *string*                                                                        | :heavy_check_mark:                                                              | N/A                                                                             |
| `Provider`                                                                      | *string*                                                                        | :heavy_check_mark:                                                              | N/A                                                                             |
| `EnterpriseConnectionId`                                                        | *string*                                                                        | :heavy_check_mark:                                                              | N/A                                                                             |
| `Groups`                                                                        | List<[UserScimGroups](../../Models/Components/UserScimGroups.md)>               | :heavy_minus_sign:                                                              | Omitted when groups were not loaded; an empty array means no group memberships. |
| `DirectoryId`                                                                   | *string*                                                                        | :heavy_check_mark:                                                              | The ID of the directory the user is provisioned from.<br/>                      |
| `DirectoryEnabled`                                                              | *bool*                                                                          | :heavy_check_mark:                                                              | Whether the directory is currently enabled.<br/>                                |
| `ExternalId`                                                                    | *string*                                                                        | :heavy_check_mark:                                                              | The user's external ID as reported by the directory, if any.<br/>               |