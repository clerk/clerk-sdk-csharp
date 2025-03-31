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
    using Clerk.BackendAPI.Models.Components;
    using Clerk.BackendAPI.Utils;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Reflection;
    

    public class VerificationErrorType
    {
        private VerificationErrorType(string value) { Value = value; }

        public string Value { get; private set; }
        public static VerificationErrorType OauthErrorClerkError { get { return new VerificationErrorType("Oauth_error_ClerkError"); } }
        
        public static VerificationErrorType Null { get { return new VerificationErrorType("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(VerificationErrorType v) { return v.Value; }
        public static VerificationErrorType FromString(string v) {
            switch(v) {
                case "Oauth_error_ClerkError": return OauthErrorClerkError;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for VerificationErrorType");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((VerificationErrorType)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }


    [JsonConverter(typeof(VerificationError.VerificationErrorConverter))]
    public class VerificationError {
        public VerificationError(VerificationErrorType type) {
            Type = type;
        }

        [SpeakeasyMetadata("form:explode=true")]
        public OauthErrorClerkError? OauthErrorClerkError { get; set; }

        public VerificationErrorType Type { get; set; }


        public static VerificationError CreateOauthErrorClerkError(OauthErrorClerkError oauthErrorClerkError) {
            VerificationErrorType typ = VerificationErrorType.OauthErrorClerkError;

            VerificationError res = new VerificationError(typ);
            res.OauthErrorClerkError = oauthErrorClerkError;
            return res;
        }

        public static VerificationError CreateNull() {
            VerificationErrorType typ = VerificationErrorType.Null;
            return new VerificationError(typ);
        }

        public class VerificationErrorConverter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(VerificationError);

            public override bool CanRead => true;

            public override object? ReadJson(JsonReader reader, System.Type objectType, object? existingValue, JsonSerializer serializer)
            {
                var json = JRaw.Create(reader).ToString();
                if (json == "null")
                {
                    return null;
                }

                var fallbackCandidates = new List<(System.Type, object, string)>();

                try
                {
                    return new VerificationError(VerificationErrorType.OauthErrorClerkError)
                    {
                        OauthErrorClerkError = ResponseBodyDeserializer.DeserializeUndiscriminatedUnionMember<OauthErrorClerkError>(json)
                    };
                }
                catch (ResponseBodyDeserializer.MissingMemberException)
                {
                    fallbackCandidates.Add((typeof(OauthErrorClerkError), new VerificationError(VerificationErrorType.OauthErrorClerkError), "OauthErrorClerkError"));
                }
                catch (ResponseBodyDeserializer.DeserializationException)
                {
                    // try next option
                }
                catch (Exception)
                {
                    throw;
                }

                if (fallbackCandidates.Count > 0)
                {
                    fallbackCandidates.Sort((a, b) => ResponseBodyDeserializer.CompareFallbackCandidates(a.Item1, b.Item1, json));
                    foreach(var (deserializationType, returnObject, propertyName) in fallbackCandidates)
                    {
                        try
                        {
                            return ResponseBodyDeserializer.DeserializeUndiscriminatedUnionFallback(deserializationType, returnObject, propertyName, json);
                        }
                        catch (ResponseBodyDeserializer.DeserializationException)
                        {
                            // try next fallback option
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }

                throw new InvalidOperationException("Could not deserialize into any supported types.");
            }

            public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
            {
                if (value == null) {
                    writer.WriteRawValue("null");
                    return;
                }
                VerificationError res = (VerificationError)value;
                if (VerificationErrorType.FromString(res.Type).Equals(VerificationErrorType.Null))
                {
                    writer.WriteRawValue("null");
                    return;
                }
                if (res.OauthErrorClerkError != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.OauthErrorClerkError));
                    return;
                }

            }

        }

    }
}