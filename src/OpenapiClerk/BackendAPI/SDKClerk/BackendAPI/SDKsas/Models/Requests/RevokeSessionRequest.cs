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
    
    public class RevokeSessionRequest
    {

        /// <summary>
        /// The ID of the session
        /// </summary>
        [SpeakeasyMetadata("pathParam:style=simple,explode=false,name=session_id")]
        public string SessionId { get; set; } = default!;
    }
}