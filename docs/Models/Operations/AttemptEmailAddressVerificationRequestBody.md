# AttemptEmailAddressVerificationRequestBody


## Fields

| Field                                                                             | Type                                                                              | Required                                                                          | Description                                                                       |
| --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- | --------------------------------------------------------------------------------- |
| `VerificationId`                                                                  | *string*                                                                          | :heavy_check_mark:                                                                | The ID of the verification to check, such as one returned by prepare_verification |
| `Code`                                                                            | *string*                                                                          | :heavy_check_mark:                                                                | The verification code that was sent to the email address                          |