//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Clerk.BackendAPI.Models.Components
{
    using Clerk.BackendAPI.Utils;
    using Newtonsoft.Json;
    using System;
    
    public enum IdentifierType
    {
        [JsonProperty("email_address")]
        EmailAddress,
        [JsonProperty("phone_number")]
        PhoneNumber,
        [JsonProperty("web3_wallet")]
        Web3Wallet,
    }

    public static class IdentifierTypeExtension
    {
        public static string Value(this IdentifierType value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static IdentifierType ToEnum(this string value)
        {
            foreach(var field in typeof(IdentifierType).GetFields())
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

                    if (enumVal is IdentifierType)
                    {
                        return (IdentifierType)enumVal;
                    }
                }
            }

            throw new Exception($"Unknown value {value} for enum IdentifierType");
        }
    }

}