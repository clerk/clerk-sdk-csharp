# RoleSetItem

A role within a role set


## Fields

| Field                                                             | Type                                                              | Required                                                          | Description                                                       |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `Object`                                                          | [RoleSetItemObject](../../Models/Components/RoleSetItemObject.md) | :heavy_check_mark:                                                | N/A                                                               |
| `Id`                                                              | *string*                                                          | :heavy_check_mark:                                                | The unique identifier of the role                                 |
| `Name`                                                            | *string*                                                          | :heavy_check_mark:                                                | The name of the role                                              |
| `Key`                                                             | *string*                                                          | :heavy_check_mark:                                                | The key of the role (e.g., "org:admin", "org:member")             |
| `Description`                                                     | *string*                                                          | :heavy_check_mark:                                                | Optional description of the role                                  |
| `MembersCount`                                                    | *long*                                                            | :heavy_minus_sign:                                                | The number of members assigned to this role within the role set   |
| `HasMembers`                                                      | *bool*                                                            | :heavy_minus_sign:                                                | Whether this role has any members assigned within the role set    |
| `CreatedAt`                                                       | *long*                                                            | :heavy_check_mark:                                                | Unix timestamp of role creation                                   |
| `UpdatedAt`                                                       | *long*                                                            | :heavy_check_mark:                                                | Unix timestamp of last role update                                |