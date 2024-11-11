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
    using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Requests;
    using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Utils;
    
    public class UpdateOrganizationMembershipRequest
    {

        /// <summary>
        /// The ID of the organization the membership belongs to
        /// </summary>
        [SpeakeasyMetadata("pathParam:style=simple,explode=false,name=organization_id")]
        public string OrganizationId { get; set; } = default!;

        /// <summary>
        /// The ID of the user that this membership belongs to
        /// </summary>
        [SpeakeasyMetadata("pathParam:style=simple,explode=false,name=user_id")]
        public string UserId { get; set; } = default!;

        [SpeakeasyMetadata("request:mediaType=application/json")]
        public UpdateOrganizationMembershipRequestBody RequestBody { get; set; } = default!;
    }
}