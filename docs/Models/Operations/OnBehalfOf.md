# OnBehalfOf

Identifies the user on whose behalf the agent task is created.
Exactly one of user_id or identifier must be provided.


## Fields

| Field                                                             | Type                                                              | Required                                                          | Description                                                       |
| ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- | ----------------------------------------------------------------- |
| `UserId`                                                          | *string*                                                          | :heavy_minus_sign:                                                | The ID of the user.                                               |
| `Identifier`                                                      | *string*                                                          | :heavy_minus_sign:                                                | A verified identifier (e.g. email address) belonging to the user. |