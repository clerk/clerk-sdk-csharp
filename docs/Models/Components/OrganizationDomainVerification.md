# OrganizationDomainVerification

Verification details for the domain


## Fields

| Field                                                                           | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `Status`                                                                        | [OrganizationDomainStatus](../../Models/Components/OrganizationDomainStatus.md) | :heavy_check_mark:                                                              | Status of the verification. It can be `unverified` or `verified`                |
| `Strategy`                                                                      | *string*                                                                        | :heavy_check_mark:                                                              | Name of the strategy used to verify the domain                                  |
| `Attempts`                                                                      | *long*                                                                          | :heavy_check_mark:                                                              | How many attempts have been made to verify the domain                           |
| `ExpireAt`                                                                      | *long*                                                                          | :heavy_check_mark:                                                              | Unix timestamp of when the verification will expire                             |