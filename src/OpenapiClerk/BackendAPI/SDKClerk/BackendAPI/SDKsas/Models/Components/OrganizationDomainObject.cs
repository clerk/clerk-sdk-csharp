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
    using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Utils;
    using System;
    
    /// <summary>
    /// String representing the object&apos;s type. Objects of the same type share the same value. Always `organization_domain`<br/>
    /// 
    /// <remarks>
    /// 
    /// </remarks>
    /// </summary>
    public enum OrganizationDomainObject
    {
        [JsonProperty("organization_domain")]
        OrganizationDomain,
    }

    public static class OrganizationDomainObjectExtension
    {
        public static string Value(this OrganizationDomainObject value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static OrganizationDomainObject ToEnum(this string value)
        {
            foreach(var field in typeof(OrganizationDomainObject).GetFields())
            {
                var attributes = field.GetCustomAttributes(typeof(JsonPropertyAttribute), false);
                if (attributes.Length == 0)
                {
                    continue;
                }

                var attribute = attributes[0] as JsonPropertyAttribute;
                if (attribute != null && attribute.PropertyName == value)
                {
                    var enumVal = field.GetValue(null);

                    if (enumVal is OrganizationDomainObject)
                    {
                        return (OrganizationDomainObject)enumVal;
                    }
                }
            }

            throw new Exception($"Unknown value {value} for enum OrganizationDomainObject");
        }
    }

}