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
    using Clerk.BackendAPI.Utils;
    using Newtonsoft.Json;
    
    /// <summary>
    /// Parameters.
    /// </summary>
    public class VerifyClientRequestBody
    {

        /// <summary>
        /// A JWT that represents the active client.
        /// </summary>
        [JsonProperty("token")]
        public string? Token { get; set; }
    }
}