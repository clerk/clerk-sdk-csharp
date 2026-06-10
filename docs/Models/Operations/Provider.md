# Provider

The identity provider (e.g. saml_custom, oidc_custom, oidc_github_enterprise, oidc_gitlab)

## Example Usage

```csharp
using Clerk.BackendAPI.Models.Operations;

var value = Provider.SamlCustom;
```


## Values

| Name                   | Value                  |
| ---------------------- | ---------------------- |
| `SamlCustom`           | saml_custom            |
| `SamlOkta`             | saml_okta              |
| `SamlGoogle`           | saml_google            |
| `SamlMicrosoft`        | saml_microsoft         |
| `OidcCustom`           | oidc_custom            |
| `OidcGithubEnterprise` | oidc_github_enterprise |
| `OidcGitlab`           | oidc_gitlab            |