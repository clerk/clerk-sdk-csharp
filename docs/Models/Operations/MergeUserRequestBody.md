# MergeUserRequestBody


## Fields

| Field                                                                        | Type                                                                         | Required                                                                     | Description                                                                  |
| ---------------------------------------------------------------------------- | ---------------------------------------------------------------------------- | ---------------------------------------------------------------------------- | ---------------------------------------------------------------------------- |
| `FromUserId`                                                                 | *string*                                                                     | :heavy_check_mark:                                                           | The ID of the user to merge into the user in the path. This user is deleted. |
| `DryRun`                                                                     | *bool*                                                                       | :heavy_minus_sign:                                                           | Return the merged user without changing anything.                            |