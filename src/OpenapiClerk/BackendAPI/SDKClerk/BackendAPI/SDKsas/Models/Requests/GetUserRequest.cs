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
    using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Utils;
    
    public class GetUserRequest
    {

        /// <summary>
        /// The ID of the user to retrieve
        /// </summary>
        [SpeakeasyMetadata("pathParam:style=simple,explode=false,name=user_id")]
        public string UserId { get; set; } = default!;
    }
}