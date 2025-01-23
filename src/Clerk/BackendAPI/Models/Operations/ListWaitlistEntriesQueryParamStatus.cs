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
    using System;
    
    /// <summary>
    /// Filter waitlist entries by their status
    /// </summary>
    public enum ListWaitlistEntriesQueryParamStatus
    {
        [JsonProperty("pending")]
        Pending,
        [JsonProperty("invited")]
        Invited,
        [JsonProperty("completed")]
        Completed,
        [JsonProperty("rejected")]
        Rejected,
    }

    public static class ListWaitlistEntriesQueryParamStatusExtension
    {
        public static string Value(this ListWaitlistEntriesQueryParamStatus value)
        {
            return ((JsonPropertyAttribute)value.GetType().GetMember(value.ToString())[0].GetCustomAttributes(typeof(JsonPropertyAttribute), false)[0]).PropertyName ?? value.ToString();
        }

        public static ListWaitlistEntriesQueryParamStatus ToEnum(this string value)
        {
            foreach(var field in typeof(ListWaitlistEntriesQueryParamStatus).GetFields())
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

                    if (enumVal is ListWaitlistEntriesQueryParamStatus)
                    {
                        return (ListWaitlistEntriesQueryParamStatus)enumVal;
                    }
                }
            }

            throw new Exception($"Unknown value {value} for enum ListWaitlistEntriesQueryParamStatus");
        }
    }

}