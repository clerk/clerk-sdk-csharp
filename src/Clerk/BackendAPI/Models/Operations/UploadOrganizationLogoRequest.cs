//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Clerk.BackendAPI.Models.Operations
{
    using Clerk.BackendAPI.Models.Operations;
    using Clerk.BackendAPI.Utils;
    
    public class UploadOrganizationLogoRequest
    {

        /// <summary>
        /// The ID of the organization for which to upload a logo
        /// </summary>
        [SpeakeasyMetadata("pathParam:style=simple,explode=false,name=organization_id")]
        public string OrganizationId { get; set; } = default!;

        [SpeakeasyMetadata("request:mediaType=multipart/form-data")]
        public UploadOrganizationLogoRequestBody RequestBody { get; set; } = default!;
    }
}