namespace Clerk.BackendAPI.Hooks.Telemetry
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Xml;

    public class SdkInfo
    {
        public string Version { get; }
        public string Name { get; }
        public string GroupId { get; }

        public SdkInfo(string version, string name, string groupId)
        {
            Version = version;
            Name = name;
            GroupId = groupId;
        }

        public override string ToString()
        {
            return $"{{\"version\":\"{Version}\",\"name\":\"{Name}\",\"groupId\":\"{GroupId}\"}}";
        }

        public static SdkInfo? LoadFromAssembly()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var assemblyName = assembly.GetName();
                
                // Get the version from the assembly
                var version = assemblyName.Version?.ToString() ?? "unknown";
                
                // Get the name (without namespace)
                var name = assemblyName.Name ?? "unknown";
                
                // For .NET we'll use the first part of the namespace as groupId
                var groupId = name.Contains('.') ? name.Substring(0, name.IndexOf('.')) : "Clerk";

                return new SdkInfo(version, name, groupId);
            }
            catch
            {
                return null;
            }
        }
    }
}