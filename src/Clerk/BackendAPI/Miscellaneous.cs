//------------------------------------------------------------------------------
// <auto-generated>
// This code was generated by Speakeasy (https://speakeasy.com). DO NOT EDIT.
//
// Changes to this file may cause incorrect behavior and will be lost when
// the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Clerk.BackendAPI
{
    using Clerk.BackendAPI.Hooks;
    using Clerk.BackendAPI.Models.Components;
    using Clerk.BackendAPI.Models.Errors;
    using Clerk.BackendAPI.Models.Operations;
    using Clerk.BackendAPI.Utils;
    using Clerk.BackendAPI.Utils.Retries;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    /// <summary>
    /// Various endpoints that do not belong in any particular category.
    /// </summary>
    public interface IMiscellaneous
    {

        /// <summary>
        /// Returns the markup for the interstitial page
        /// 
        /// <remarks>
        /// The Clerk interstitial endpoint serves an html page that loads clerk.js in order to check the user&apos;s authentication state.<br/>
        /// It is used by Clerk SDKs when the user&apos;s authentication state cannot be immediately determined.
        /// </remarks>
        /// </summary>
        Task<GetPublicInterstitialResponse> GetPublicInterstitialAsync(string? frontendApi = null, string? publishableKey = null);
    }

    /// <summary>
    /// Various endpoints that do not belong in any particular category.
    /// </summary>
    public class Miscellaneous: IMiscellaneous
    {
        public SDKConfig SDKConfiguration { get; private set; }
        private const string _language = "csharp";
        private const string _sdkVersion = "0.3.0";
        private const string _sdkGenVersion = "2.495.0";
        private const string _openapiDocVersion = "v1";
        private const string _userAgent = "speakeasy-sdk/csharp 0.3.0 2.495.0 v1 Clerk.BackendAPI";
        private string _serverUrl = "";
        private ISpeakeasyHttpClient _client;
        private Func<Clerk.BackendAPI.Models.Components.Security>? _securitySource;

        public Miscellaneous(ISpeakeasyHttpClient client, Func<Clerk.BackendAPI.Models.Components.Security>? securitySource, string serverUrl, SDKConfig config)
        {
            _client = client;
            _securitySource = securitySource;
            _serverUrl = serverUrl;
            SDKConfiguration = config;
        }

        public async Task<GetPublicInterstitialResponse> GetPublicInterstitialAsync(string? frontendApi = null, string? publishableKey = null)
        {
            var request = new GetPublicInterstitialRequest()
            {
                FrontendApi = frontendApi,
                PublishableKey = publishableKey,
            };
            string baseUrl = this.SDKConfiguration.GetTemplatedServerUrl();
            var urlString = URLBuilder.Build(baseUrl, "/public/interstitial", request);

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, urlString);
            httpRequest.Headers.Add("user-agent", _userAgent);

            var hookCtx = new HookContext("GetPublicInterstitial", null, null);

            httpRequest = await this.SDKConfiguration.Hooks.BeforeRequestAsync(new BeforeRequestContext(hookCtx), httpRequest);

            HttpResponseMessage httpResponse;
            try
            {
                httpResponse = await _client.SendAsync(httpRequest);
                int _statusCode = (int)httpResponse.StatusCode;

                if (_statusCode == 400 || _statusCode >= 400 && _statusCode < 500 || _statusCode == 500 || _statusCode >= 500 && _statusCode < 600)
                {
                    var _httpResponse = await this.SDKConfiguration.Hooks.AfterErrorAsync(new AfterErrorContext(hookCtx), httpResponse, null);
                    if (_httpResponse != null)
                    {
                        httpResponse = _httpResponse;
                    }
                }
            }
            catch (Exception error)
            {
                var _httpResponse = await this.SDKConfiguration.Hooks.AfterErrorAsync(new AfterErrorContext(hookCtx), null, error);
                if (_httpResponse != null)
                {
                    httpResponse = _httpResponse;
                }
                else
                {
                    throw;
                }
            }

            httpResponse = await this.SDKConfiguration.Hooks.AfterSuccessAsync(new AfterSuccessContext(hookCtx), httpResponse);

            var contentType = httpResponse.Content.Headers.ContentType?.MediaType;
            int responseStatusCode = (int)httpResponse.StatusCode;
            if(responseStatusCode == 200)
            {                
                return new GetPublicInterstitialResponse()
                {
                    HttpMeta = new Models.Components.HTTPMetadata()
                    {
                        Response = httpResponse,
                        Request = httpRequest
                    }
                };
            }
            else if(responseStatusCode == 400 || responseStatusCode >= 400 && responseStatusCode < 500)
            {
                throw new Models.Errors.SDKError("API error occurred", httpRequest, httpResponse);
            }
            else if(responseStatusCode == 500 || responseStatusCode >= 500 && responseStatusCode < 600)
            {
                throw new Models.Errors.SDKError("API error occurred", httpRequest, httpResponse);
            }

            throw new Models.Errors.SDKError("Unknown status code received", httpRequest, httpResponse);
        }
    }
}