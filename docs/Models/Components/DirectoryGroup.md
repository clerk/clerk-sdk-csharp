# DirectoryGroup

A group reported by the identity provider for a directory.


## Fields

| Field                                                                                      | Type                                                                                       | Required                                                                                   | Description                                                                                |
| ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------ |
| `Object`                                                                                   | [DirectoryGroupObject](../../Models/Components/DirectoryGroupObject.md)                    | :heavy_check_mark:                                                                         | String representing the object's type. Always "directory_group".                           |
| `Id`                                                                                       | *string*                                                                                   | :heavy_check_mark:                                                                         | The group ID from the identity provider.                                                   |
| `DisplayName`                                                                              | *string*                                                                                   | :heavy_check_mark:                                                                         | The display name of the group.                                                             |
| `UpdatedAt`                                                                                | *long*                                                                                     | :heavy_check_mark:                                                                         | Unix timestamp (milliseconds) of when the group was last updated on the identity provider. |