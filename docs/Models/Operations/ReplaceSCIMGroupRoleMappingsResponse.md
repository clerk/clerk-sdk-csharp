# ReplaceSCIMGroupRoleMappingsResponse


## Fields

| Field                                                                           | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `HttpMeta`                                                                      | [HTTPMetadata](../../Models/Components/HTTPMetadata.md)                         | :heavy_check_mark:                                                              | N/A                                                                             |
| `SCIMGroupRoleMappingList`                                                      | [SCIMGroupRoleMappingList](../../Models/Components/SCIMGroupRoleMappingList.md) | :heavy_minus_sign:                                                              | A list of SCIM group role mappings, ordered by precedence.                      |