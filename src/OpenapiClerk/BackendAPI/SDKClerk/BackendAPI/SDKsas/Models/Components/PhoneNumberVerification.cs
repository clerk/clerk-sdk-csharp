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
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Models.Components;
    using OpenapiClerk.BackendAPI.SDKClerk.BackendAPI.SDKsas.Utils;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Reflection;
    using System;
    

    public class PhoneNumberVerificationType
    {
        private PhoneNumberVerificationType(string value) { Value = value; }

        public string Value { get; private set; }
        public static PhoneNumberVerificationType VerificationOTP { get { return new PhoneNumberVerificationType("verification_OTP"); } }
        
        public static PhoneNumberVerificationType VerificationAdmin { get { return new PhoneNumberVerificationType("verification_Admin"); } }
        
        public static PhoneNumberVerificationType Null { get { return new PhoneNumberVerificationType("null"); } }

        public override string ToString() { return Value; }
        public static implicit operator String(PhoneNumberVerificationType v) { return v.Value; }
        public static PhoneNumberVerificationType FromString(string v) {
            switch(v) {
                case "verification_OTP": return VerificationOTP;
                case "verification_Admin": return VerificationAdmin;
                case "null": return Null;
                default: throw new ArgumentException("Invalid value for PhoneNumberVerificationType");
            }
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return Value.Equals(((PhoneNumberVerificationType)obj).Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }


    [JsonConverter(typeof(PhoneNumberVerification.PhoneNumberVerificationConverter))]
    public class PhoneNumberVerification {
        public PhoneNumberVerification(PhoneNumberVerificationType type) {
            Type = type;
        }

        [SpeakeasyMetadata("form:explode=true")]
        public VerificationOTP? VerificationOTP { get; set; }

        [SpeakeasyMetadata("form:explode=true")]
        public VerificationAdmin? VerificationAdmin { get; set; }

        public PhoneNumberVerificationType Type { get; set; }


        public static PhoneNumberVerification CreateVerificationOTP(VerificationOTP verificationOTP) {
            PhoneNumberVerificationType typ = PhoneNumberVerificationType.VerificationOTP;

            PhoneNumberVerification res = new PhoneNumberVerification(typ);
            res.VerificationOTP = verificationOTP;
            return res;
        }

        public static PhoneNumberVerification CreateVerificationAdmin(VerificationAdmin verificationAdmin) {
            PhoneNumberVerificationType typ = PhoneNumberVerificationType.VerificationAdmin;

            PhoneNumberVerification res = new PhoneNumberVerification(typ);
            res.VerificationAdmin = verificationAdmin;
            return res;
        }

        public static PhoneNumberVerification CreateNull() {
            PhoneNumberVerificationType typ = PhoneNumberVerificationType.Null;
            return new PhoneNumberVerification(typ);
        }

        public class PhoneNumberVerificationConverter : JsonConverter
        {

            public override bool CanConvert(System.Type objectType) => objectType == typeof(PhoneNumberVerification);

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
                    return new PhoneNumberVerification(PhoneNumberVerificationType.VerificationOTP)
                    {
                        VerificationOTP = ResponseBodyDeserializer.DeserializeUndiscriminatedUnionMember<VerificationOTP>(json)
                    };
                }
                catch (ResponseBodyDeserializer.MissingMemberException)
                {
                    fallbackCandidates.Add((typeof(VerificationOTP), new PhoneNumberVerification(PhoneNumberVerificationType.VerificationOTP), "VerificationOTP"));
                }
                catch (ResponseBodyDeserializer.DeserializationException)
                {
                    // try next option
                }
                catch (Exception)
                {
                    throw;
                }

                try
                {
                    return new PhoneNumberVerification(PhoneNumberVerificationType.VerificationAdmin)
                    {
                        VerificationAdmin = ResponseBodyDeserializer.DeserializeUndiscriminatedUnionMember<VerificationAdmin>(json)
                    };
                }
                catch (ResponseBodyDeserializer.MissingMemberException)
                {
                    fallbackCandidates.Add((typeof(VerificationAdmin), new PhoneNumberVerification(PhoneNumberVerificationType.VerificationAdmin), "VerificationAdmin"));
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
                PhoneNumberVerification res = (PhoneNumberVerification)value;
                if (PhoneNumberVerificationType.FromString(res.Type).Equals(PhoneNumberVerificationType.Null))
                {
                    writer.WriteRawValue("null");
                    return;
                }
                if (res.VerificationOTP != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.VerificationOTP));
                    return;
                }
                if (res.VerificationAdmin != null)
                {
                    writer.WriteRawValue(Utilities.SerializeJSON(res.VerificationAdmin));
                    return;
                }

            }

        }

    }
}