# OrganizationDomainVerification

Verification details for the domain


## Fields

| Field                                                                           | Type                                                                            | Required                                                                        | Description                                                                     |
| ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- | ------------------------------------------------------------------------------- |
| `Status`                                                                        | [OrganizationDomainStatus](../../Models/Components/OrganizationDomainStatus.md) | :heavy_minus_sign:                                                              | Status of the verification. It can be `unverified` or `verified`                |
| `Strategy`                                                                      | *string*                                                                        | :heavy_minus_sign:                                                              | Name of the strategy used to verify the domain                                  |
| `Attempts`                                                                      | *long*                                                                          | :heavy_minus_sign:                                                              | How many attempts have been made to verify the domain                           |
| `ExpireAt`                                                                      | *long*                                                                          | :heavy_minus_sign:                                                              | Unix timestamp of when the verification will expire                             |