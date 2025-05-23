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
    
    public class UpdateProductionInstanceDomainRequestBody
    {

        /// <summary>
        /// The new home URL of the production instance e.g. https://www.example.com
        /// </summary>
        [JsonProperty("home_url")]
        public string? HomeUrl { get; set; }

        /// <summary>
        /// Whether the domain is a secondary app.
        /// </summary>
        [JsonProperty("is_secondary")]
        public bool? IsSecondary { get; set; }
    }
}