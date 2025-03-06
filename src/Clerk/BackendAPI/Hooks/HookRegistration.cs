
namespace Clerk.BackendAPI.Hooks
{
    using System;
    using System.Collections.Generic;
    using Clerk.BackendAPI.Hooks.Telemetry;

    /// <summary>
    /// Hook Registration File.
    /// </summary>
    /// <remarks>
    /// This file is only ever generated once on the first generation and then is free to be modified.
    /// Any hooks you wish to add should be registered in the InitHooks function. Feel free to define them
    /// in this file or in separate files in the Hooks folder.
    /// </remarks>
    public static class HookRegistration
    {
        /// <summary>
        /// Initializes hooks.
        /// </summary>
        /// <remarks>
        /// Add hooks by calling `Clerk.BackendAPI.Hooks.Register&lt;HookInterface&gt;(myHook);`
        /// where `I&lt;HookInterface&gt;` is one of the following interfaces defined in HookTypes.cs:
        ///   - ISDKInitHook
        ///   - IBeforeRequestHook
        ///   - IAfterSuccess
        ///   - IAfterError
        /// and `myHook` an instance that implements that specific interface.
        /// </remarks>
        public static void InitHooks(IHooks hooks)
        {
            var clerkBeforeRequestHook = new ClerkBeforeRequestHook();
            hooks.RegisterBeforeRequestHook(clerkBeforeRequestHook);

            // Register telemetry hooks
            var telemetryCollectors = new List<ITelemetryCollector> { LiveTelemetryCollector.Standard() };
            if (Environment.GetEnvironmentVariable("CLERK_TELEMETRY_DEBUG") == "1") {
                telemetryCollectors.Add(new DebugTelemetryCollector());
            }

            var telemetryBeforeRequestHook = new TelemetryBeforeRequestHook(telemetryCollectors);
            hooks.RegisterBeforeRequestHook(telemetryBeforeRequestHook);
            
            var telemetryAfterSuccessHook = new TelemetryAfterSuccessHook(telemetryCollectors);
            hooks.RegisterAfterSuccessHook(telemetryAfterSuccessHook);
            
            var telemetryAfterErrorHook = new TelemetryAfterErrorHook(telemetryCollectors);
            hooks.RegisterAfterErrorHook(telemetryAfterErrorHook);
        }
    }
}