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
        Task<GetPublicInterstitialResponse> GetPublicInterstitialAsync(GetPublicInterstitialRequest? request = null, RetryConfig? retryConfig = null);
    }

    public class Miscellaneous: IMiscellaneous
    {
        public SDKConfig SDKConfiguration { get; private set; }
        private const string _language = "csharp";
        private const string _sdkVersion = "0.6.2";
        private const string _sdkGenVersion = "2.563.0";
        private const string _openapiDocVersion = "2024-10-01";
        private const string _userAgent = "speakeasy-sdk/csharp 0.6.2 2.563.0 2024-10-01 Clerk.BackendAPI";
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

        public async Task<GetPublicInterstitialResponse> GetPublicInterstitialAsync(GetPublicInterstitialRequest? request = null, RetryConfig? retryConfig = null)
        {
            string baseUrl = this.SDKConfiguration.GetTemplatedServerUrl();
            var urlString = URLBuilder.Build(baseUrl, "/public/interstitial", request);

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, urlString);
            httpRequest.Headers.Add("user-agent", _userAgent);

            var hookCtx = new HookContext(baseUrl, "GetPublicInterstitial", new List<string> {  }, null);

            httpRequest = await this.SDKConfiguration.Hooks.BeforeRequestAsync(new BeforeRequestContext(hookCtx), httpRequest);
            if (retryConfig == null)
            {
                if (this.SDKConfiguration.RetryConfig != null)
                {
                    retryConfig = this.SDKConfiguration.RetryConfig;
                }
                else
                {
                    var backoff = new BackoffStrategy(
                        initialIntervalMs: 500L,
                        maxIntervalMs: 60000L,
                        maxElapsedTimeMs: 3600000L,
                        exponent: 1.5
                    );
                    retryConfig = new RetryConfig(
                        strategy: RetryConfig.RetryStrategy.BACKOFF,
                        backoff: backoff,
                        retryConnectionErrors: true
                    );
                }
            }

            List<string> statusCodes = new List<string>
            {
                "5XX",
            };

            Func<Task<HttpResponseMessage>> retrySend = async () =>
            {
                var _httpRequest = await _client.CloneAsync(httpRequest);
                return await _client.SendAsync(_httpRequest);
            };
            var retries = new Clerk.BackendAPI.Utils.Retries.Retries(retrySend, retryConfig, statusCodes);

            HttpResponseMessage httpResponse;
            try
            {
                httpResponse = await retries.Run();
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