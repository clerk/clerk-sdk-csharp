//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Requests
{
    using Newtonsoft.Json;
    using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Requests;
    using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Utils;
    using System.Collections.Generic;
    
    public class CreateUserRequestBody
    {

        /// <summary>
        /// The ID of the user as used in your external systems or your previous authentication solution.<br/>
        /// 
        /// <remarks>
        /// Must be unique across your instance.
        /// </remarks>
        /// </summary>
        [JsonProperty("external_id")]
        public string? ExternalId { get; set; } = null;

        /// <summary>
        /// The first name to assign to the user
        /// </summary>
        [JsonProperty("first_name")]
        public string? FirstName { get; set; } = null;

        /// <summary>
        /// The last name to assign to the user
        /// </summary>
        [JsonProperty("last_name")]
        public string? LastName { get; set; } = null;

        /// <summary>
        /// Email addresses to add to the user.<br/>
        /// 
        /// <remarks>
        /// Must be unique across your instance.<br/>
        /// The first email address will be set as the user&apos;s primary email address.
        /// </remarks>
        /// </summary>
        [JsonProperty("email_address")]
        public List<string>? EmailAddress { get; set; }

        /// <summary>
        /// Phone numbers to add to the user.<br/>
        /// 
        /// <remarks>
        /// Must be unique across your instance.<br/>
        /// The first phone number will be set as the user&apos;s primary phone number.
        /// </remarks>
        /// </summary>
        [JsonProperty("phone_number")]
        public List<string>? PhoneNumber { get; set; }

        /// <summary>
        /// Web3 wallets to add to the user.<br/>
        /// 
        /// <remarks>
        /// Must be unique across your instance.<br/>
        /// The first wallet will be set as the user&apos;s primary wallet.
        /// </remarks>
        /// </summary>
        [JsonProperty("web3_wallet")]
        public List<string>? Web3Wallet { get; set; }

        /// <summary>
        /// The username to give to the user.<br/>
        /// 
        /// <remarks>
        /// It must be unique across your instance.
        /// </remarks>
        /// </summary>
        [JsonProperty("username")]
        public string? Username { get; set; } = null;

        /// <summary>
        /// The plaintext password to give the user.<br/>
        /// 
        /// <remarks>
        /// Must be at least 8 characters long, and can not be in any list of hacked passwords.
        /// </remarks>
        /// </summary>
        [JsonProperty("password")]
        public string? Password { get; set; } = null;

        /// <summary>
        /// In case you already have the password digests and not the passwords, you can use them for the newly created user via this property.<br/>
        /// 
        /// <remarks>
        /// The digests should be generated with one of the supported algorithms.<br/>
        /// The hashing algorithm can be specified using the `password_hasher` property.
        /// </remarks>
        /// </summary>
        [JsonProperty("password_digest")]
        public string? PasswordDigest { get; set; }

        /// <summary>
        /// The hashing algorithm that was used to generate the password digest.<br/>
        /// 
        /// <remarks>
        /// <br/>
        /// The algorithms we support at the moment are <a href="https://en.wikipedia.org/wiki/Bcrypt">`bcrypt`</a>, <a href="https://docs.djangoproject.com/en/4.0/topics/auth/passwords/">`bcrypt_sha256_django`</a>, <a href="https://en.wikipedia.org/wiki/MD5">`md5`</a>, `pbkdf2_sha1`, `pbkdf2_sha256`, <a href="https://docs.djangoproject.com/en/4.0/topics/auth/passwords/">`pbkdf2_sha256_django`</a>,<br/>
        /// <a href="https://www.openwall.com/phpass/">`phpass`</a>, <a href="https://firebaseopensource.com/projects/firebase/scrypt/">`scrypt_firebase`</a>,<br/>
        /// <a href="https://werkzeug.palletsprojects.com/en/3.0.x/utils/#werkzeug.security.generate_password_hash">`scrypt_werkzeug`</a>, <a href="https://en.wikipedia.org/wiki/SHA-2">`sha256`</a>,<br/>
        /// and the <a href="https://argon2.online/">`argon2`</a> variants: `argon2i` and `argon2id`.<br/>
        /// <br/>
        /// Each of the supported hashers expects the incoming digest to be in a particular format. See the <a href="https://clerk.com/docs/references/backend/user/create-user">Clerk docs</a> for more information.
        /// </remarks>
        /// </summary>
        [JsonProperty("password_hasher")]
        public string? PasswordHasher { get; set; }

        /// <summary>
        /// When set to `true` all password checks are skipped.<br/>
        /// 
        /// <remarks>
        /// It is recommended to use this method only when migrating plaintext passwords to Clerk.<br/>
        /// Upon migration the user base should be prompted to pick stronger password.
        /// </remarks>
        /// </summary>
        [JsonProperty("skip_password_checks")]
        public bool? SkipPasswordChecks { get; set; }

        /// <summary>
        /// When set to `true`, `password` is not required anymore when creating the user and can be omitted.<br/>
        /// 
        /// <remarks>
        /// This is useful when you are trying to create a user that doesn&apos;t have a password, in an instance that is using passwords.<br/>
        /// Please note that you cannot use this flag if password is the only way for a user to sign into your instance.
        /// </remarks>
        /// </summary>
        [JsonProperty("skip_password_requirement")]
        public bool? SkipPasswordRequirement { get; set; }

        /// <summary>
        /// In case TOTP is configured on the instance, you can provide the secret to enable it on the newly created user without the need to reset it.<br/>
        /// 
        /// <remarks>
        /// Please note that currently the supported options are:<br/>
        /// * Period: 30 seconds<br/>
        /// * Code length: 6 digits<br/>
        /// * Algorithm: SHA1
        /// </remarks>
        /// </summary>
        [JsonProperty("totp_secret")]
        public string? TotpSecret { get; set; }

        /// <summary>
        /// If Backup Codes are configured on the instance, you can provide them to enable it on the newly created user without the need to reset them.<br/>
        /// 
        /// <remarks>
        /// You must provide the backup codes in plain format or the corresponding bcrypt digest.
        /// </remarks>
        /// </summary>
        [JsonProperty("backup_codes")]
        public List<string>? BackupCodes { get; set; }

        /// <summary>
        /// Metadata saved on the user, that is visible to both your Frontend and Backend APIs
        /// </summary>
        [JsonProperty("public_metadata")]
        public Models.Requests.PublicMetadata? PublicMetadata { get; set; }

        /// <summary>
        /// Metadata saved on the user, that is only visible to your Backend API
        /// </summary>
        [JsonProperty("private_metadata")]
        public Models.Requests.PrivateMetadata? PrivateMetadata { get; set; }

        /// <summary>
        /// Metadata saved on the user, that can be updated from both the Frontend and Backend APIs.<br/>
        /// 
        /// <remarks>
        /// Note: Since this data can be modified from the frontend, it is not guaranteed to be safe.
        /// </remarks>
        /// </summary>
        [JsonProperty("unsafe_metadata")]
        public Models.Requests.UnsafeMetadata? UnsafeMetadata { get; set; }

        /// <summary>
        /// If enabled, user can delete themselves via FAPI.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [JsonProperty("delete_self_enabled")]
        public bool? DeleteSelfEnabled { get; set; } = null;

        /// <summary>
        /// A custom timestamp denoting _when_ the user accepted legal requirements, specified in RFC3339 format (e.g. `2012-10-20T07:15:20.902Z`).
        /// </summary>
        [JsonProperty("legal_accepted_at")]
        public string? LegalAcceptedAt { get; set; } = null;

        /// <summary>
        /// When set to `true` all legal checks are skipped.<br/>
        /// 
        /// <remarks>
        /// It is not recommended to skip legal checks unless you are migrating a user to Clerk.
        /// </remarks>
        /// </summary>
        [JsonProperty("skip_legal_checks")]
        public bool? SkipLegalChecks { get; set; } = null;

        /// <summary>
        /// If enabled, user can create organizations via FAPI.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [JsonProperty("create_organization_enabled")]
        public bool? CreateOrganizationEnabled { get; set; } = null;

        /// <summary>
        /// The maximum number of organizations the user can create. 0 means unlimited.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [JsonProperty("create_organizations_limit")]
        public long? CreateOrganizationsLimit { get; set; } = null;

        /// <summary>
        /// A custom date/time denoting _when_ the user signed up to the application, specified in RFC3339 format (e.g. `2012-10-20T07:15:20.902Z`).
        /// </summary>
        [JsonProperty("created_at")]
        public string? CreatedAt { get; set; }
    }
}