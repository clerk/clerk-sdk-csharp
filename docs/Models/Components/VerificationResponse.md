# VerificationResponse

The verification. After prepare_verification it is pending (unverified);
after attempt_verification its status reflects the attempt outcome.


## Fields

| Field                                                                      | Type                                                                       | Required                                                                   | Description                                                                |
| -------------------------------------------------------------------------- | -------------------------------------------------------------------------- | -------------------------------------------------------------------------- | -------------------------------------------------------------------------- |
| `Object`                                                                   | *string*                                                                   | :heavy_minus_sign:                                                         | The type of the verification object.                                       |
| `Id`                                                                       | *string*                                                                   | :heavy_minus_sign:                                                         | The ID of the verification. Pass this to attempt_verification.             |
| `Status`                                                                   | *string*                                                                   | :heavy_minus_sign:                                                         | The status of the verification (unverified, verified, expired, or failed). |
| `Strategy`                                                                 | *string*                                                                   | :heavy_minus_sign:                                                         | The verification strategy (email_code or phone_code).                      |
| `Attempts`                                                                 | *long*                                                                     | :heavy_minus_sign:                                                         | The number of attempts made against this verification.                     |
| `ExpireAt`                                                                 | *long*                                                                     | :heavy_minus_sign:                                                         | Unix timestamp (milliseconds) at which the code expires.                   |
| `Channel`                                                                  | *string*                                                                   | :heavy_minus_sign:                                                         | The channel the code was sent over (phone numbers only).                   |