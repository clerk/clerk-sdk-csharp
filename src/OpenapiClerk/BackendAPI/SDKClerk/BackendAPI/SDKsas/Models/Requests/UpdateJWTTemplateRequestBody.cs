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
    
    public class UpdateJWTTemplateRequestBody
    {

        /// <summary>
        /// JWT template name
        /// </summary>
        [JsonProperty("name")]
        public string? Name { get; set; }

        /// <summary>
        /// JWT template claims in JSON format
        /// </summary>
        [JsonProperty("claims")]
        public UpdateJWTTemplateClaims? Claims { get; set; }

        /// <summary>
        /// JWT token lifetime
        /// </summary>
        [JsonProperty("lifetime")]
        public double? Lifetime { get; set; } = null;

        /// <summary>
        /// JWT token allowed clock skew
        /// </summary>
        [JsonProperty("allowed_clock_skew")]
        public double? AllowedClockSkew { get; set; } = null;

        /// <summary>
        /// Whether a custom signing key/algorithm is also provided for this template
        /// </summary>
        [JsonProperty("custom_signing_key")]
        public bool? CustomSigningKey { get; set; }

        /// <summary>
        /// The custom signing algorithm to use when minting JWTs
        /// </summary>
        [JsonProperty("signing_algorithm")]
        public string? SigningAlgorithm { get; set; } = null;

        /// <summary>
        /// The custom signing private key to use when minting JWTs
        /// </summary>
        [JsonProperty("signing_key")]
        public string? SigningKey { get; set; } = null;
    }
}