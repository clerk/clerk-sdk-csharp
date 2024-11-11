//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components
{
    using Newtonsoft.Json;
    using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components;
    using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Utils;
    
    public class OrganizationMembershipOrganization
    {

        [JsonProperty("object")]
        public OrganizationMembershipOrganizationObject Object { get; set; } = default!;

        [JsonProperty("id")]
        public string Id { get; set; } = default!;

        [JsonProperty("name")]
        public string Name { get; set; } = default!;

        [JsonProperty("slug")]
        public string Slug { get; set; } = default!;

        [JsonProperty("members_count")]
        public long? MembersCount { get; set; } = null;

        [JsonProperty("max_allowed_memberships")]
        public long MaxAllowedMemberships { get; set; } = default!;

        [JsonProperty("admin_delete_enabled")]
        public bool? AdminDeleteEnabled { get; set; }

        [JsonProperty("public_metadata")]
        public OrganizationMembershipOrganizationPublicMetadata PublicMetadata { get; set; } = default!;

        [JsonProperty("private_metadata")]
        public OrganizationMembershipOrganizationPrivateMetadata PrivateMetadata { get; set; } = default!;

        [JsonProperty("created_by")]
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Unix timestamp of creation.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [JsonProperty("created_at")]
        public long CreatedAt { get; set; } = default!;

        /// <summary>
        /// Unix timestamp of last update.<br/>
        /// 
        /// <remarks>
        /// 
        /// </remarks>
        /// </summary>
        [JsonProperty("updated_at")]
        public long UpdatedAt { get; set; } = default!;
    }
}