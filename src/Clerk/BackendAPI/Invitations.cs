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
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    /// <summary>
    /// Invitations allow you to invite someone to sign up to your application, via email.
    /// 
    /// <see>https://clerk.com/docs/authentication/invitations}</see>
    /// </summary>
    public interface IInvitations
    {

        /// <summary>
        /// Create an invitation
        /// 
        /// <remarks>
        /// Creates a new invitation for the given email address and sends the invitation email.<br/>
        /// Keep in mind that you cannot create an invitation if there is already one for the given email address.<br/>
        /// Also, trying to create an invitation for an email address that already exists in your application will result to an error.
        /// </remarks>
        /// </summary>
        Task<CreateInvitationResponse> CreateAsync(CreateInvitationRequestBody? request = null);

        /// <summary>
        /// List all invitations
        /// 
        /// <remarks>
        /// Returns all non-revoked invitations for your application, sorted by creation date
        /// </remarks>
        /// </summary>
        Task<ListInvitationsResponse> ListAsync(long? limit = 10, long? offset = 0, ListInvitationsQueryParamStatus? status = null, string? query = null);

        /// <summary>
        /// Create multiple invitations
        /// 
        /// <remarks>
        /// Use this API operation to create multiple invitations for the provided email addresses. You can choose to send the<br/>
        /// invitations as emails by setting the `notify` parameter to `true`. There cannot be an existing invitation for any<br/>
        /// of the email addresses you provide unless you set `ignore_existing` to `true` for specific email addresses. Please<br/>
        /// note that there must be no existing user for any of the email addresses you provide, and this rule cannot be bypassed.
        /// </remarks>
        /// </summary>
        Task<CreateBulkInvitationsResponse> CreateBulkInvitationsAsync(List<RequestBody>? request = null);

        /// <summary>
        /// Revokes an invitation
        /// 
        /// <remarks>
        /// Revokes the given invitation.<br/>
        /// Revoking an invitation will prevent the user from using the invitation link that was sent to them.<br/>
        /// However, it doesn&apos;t prevent the user from signing up if they follow the sign up flow.<br/>
        /// Only active (i.e. non-revoked) invitations can be revoked.
        /// </remarks>
        /// </summary>
        Task<RevokeInvitationResponse> RevokeAsync(string invitationId);
    }

    /// <summary>
    /// Invitations allow you to invite someone to sign up to your application, via email.
    /// 
    /// <see>https://clerk.com/docs/authentication/invitations}</see>
    /// </summary>
    public class Invitations: IInvitations
    {
        public SDKConfig SDKConfiguration { get; private set; }
        private const string _language = "csharp";
        private const string _sdkVersion = "0.5.0";
        private const string _sdkGenVersion = "2.515.4";
        private const string _openapiDocVersion = "v1";
        private const string _userAgent = "speakeasy-sdk/csharp 0.5.0 2.515.4 v1 Clerk.BackendAPI";
        private string _serverUrl = "";
        private ISpeakeasyHttpClient _client;
        private Func<Clerk.BackendAPI.Models.Components.Security>? _securitySource;

        public Invitations(ISpeakeasyHttpClient client, Func<Clerk.BackendAPI.Models.Components.Security>? securitySource, string serverUrl, SDKConfig config)
        {
            _client = client;
            _securitySource = securitySource;
            _serverUrl = serverUrl;
            SDKConfiguration = config;
        }

        public async Task<CreateInvitationResponse> CreateAsync(CreateInvitationRequestBody? request = null)
        {
            string baseUrl = this.SDKConfiguration.GetTemplatedServerUrl();

            var urlString = baseUrl + "/invitations";

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, urlString);
            httpRequest.Headers.Add("user-agent", _userAgent);

            var serializedBody = RequestBodySerializer.Serialize(request, "Request", "json", false, true);
            if (serializedBody != null)
            {
                httpRequest.Content = serializedBody;
            }

            if (_securitySource != null)
            {
                httpRequest = new SecurityMetadata(_securitySource).Apply(httpRequest);
            }

            var hookCtx = new HookContext("CreateInvitation", null, _securitySource);

            httpRequest = await this.SDKConfiguration.Hooks.BeforeRequestAsync(new BeforeRequestContext(hookCtx), httpRequest);

            HttpResponseMessage httpResponse;
            try
            {
                httpResponse = await _client.SendAsync(httpRequest);
                int _statusCode = (int)httpResponse.StatusCode;

                if (_statusCode == 400 || _statusCode == 422 || _statusCode >= 400 && _statusCode < 500 || _statusCode >= 500 && _statusCode < 600)
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
                if(Utilities.IsContentTypeMatch("application/json", contentType))
                {
                    var obj = ResponseBodyDeserializer.Deserialize<Invitation>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Include);
                    var response = new CreateInvitationResponse()
                    {
                        HttpMeta = new Models.Components.HTTPMetadata()
                        {
                            Response = httpResponse,
                            Request = httpRequest
                        }
                    };
                    response.Invitation = obj;
                    return response;
                }

                throw new Models.Errors.SDKError("Unknown content type received", httpRequest, httpResponse);
            }
            else if(new List<int>{400, 422}.Contains(responseStatusCode))
            {
                if(Utilities.IsContentTypeMatch("application/json", contentType))
                {
                    var obj = ResponseBodyDeserializer.Deserialize<ClerkErrors>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Include);
                    throw obj!;
                }

                throw new Models.Errors.SDKError("Unknown content type received", httpRequest, httpResponse);
            }
            else if(responseStatusCode >= 400 && responseStatusCode < 500)
            {
                throw new Models.Errors.SDKError("API error occurred", httpRequest, httpResponse);
            }
            else if(responseStatusCode >= 500 && responseStatusCode < 600)
            {
                throw new Models.Errors.SDKError("API error occurred", httpRequest, httpResponse);
            }

            throw new Models.Errors.SDKError("Unknown status code received", httpRequest, httpResponse);
        }

        public async Task<ListInvitationsResponse> ListAsync(long? limit = 10, long? offset = 0, ListInvitationsQueryParamStatus? status = null, string? query = null)
        {
            var request = new ListInvitationsRequest()
            {
                Limit = limit,
                Offset = offset,
                Status = status,
                Query = query,
            };
            string baseUrl = this.SDKConfiguration.GetTemplatedServerUrl();
            var urlString = URLBuilder.Build(baseUrl, "/invitations", request);

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, urlString);
            httpRequest.Headers.Add("user-agent", _userAgent);

            if (_securitySource != null)
            {
                httpRequest = new SecurityMetadata(_securitySource).Apply(httpRequest);
            }

            var hookCtx = new HookContext("ListInvitations", null, _securitySource);

            httpRequest = await this.SDKConfiguration.Hooks.BeforeRequestAsync(new BeforeRequestContext(hookCtx), httpRequest);

            HttpResponseMessage httpResponse;
            try
            {
                httpResponse = await _client.SendAsync(httpRequest);
                int _statusCode = (int)httpResponse.StatusCode;

                if (_statusCode >= 400 && _statusCode < 500 || _statusCode >= 500 && _statusCode < 600)
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
                if(Utilities.IsContentTypeMatch("application/json", contentType))
                {
                    var obj = ResponseBodyDeserializer.Deserialize<List<Invitation>>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Include);
                    var response = new ListInvitationsResponse()
                    {
                        HttpMeta = new Models.Components.HTTPMetadata()
                        {
                            Response = httpResponse,
                            Request = httpRequest
                        }
                    };
                    response.InvitationList = obj;
                    return response;
                }

                throw new Models.Errors.SDKError("Unknown content type received", httpRequest, httpResponse);
            }
            else if(responseStatusCode >= 400 && responseStatusCode < 500)
            {
                throw new Models.Errors.SDKError("API error occurred", httpRequest, httpResponse);
            }
            else if(responseStatusCode >= 500 && responseStatusCode < 600)
            {
                throw new Models.Errors.SDKError("API error occurred", httpRequest, httpResponse);
            }

            throw new Models.Errors.SDKError("Unknown status code received", httpRequest, httpResponse);
        }

        public async Task<CreateBulkInvitationsResponse> CreateBulkInvitationsAsync(List<RequestBody>? request = null)
        {
            string baseUrl = this.SDKConfiguration.GetTemplatedServerUrl();

            var urlString = baseUrl + "/invitations/bulk";

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, urlString);
            httpRequest.Headers.Add("user-agent", _userAgent);

            var serializedBody = RequestBodySerializer.Serialize(request, "Request", "json", false, true);
            if (serializedBody != null)
            {
                httpRequest.Content = serializedBody;
            }

            if (_securitySource != null)
            {
                httpRequest = new SecurityMetadata(_securitySource).Apply(httpRequest);
            }

            var hookCtx = new HookContext("CreateBulkInvitations", null, _securitySource);

            httpRequest = await this.SDKConfiguration.Hooks.BeforeRequestAsync(new BeforeRequestContext(hookCtx), httpRequest);

            HttpResponseMessage httpResponse;
            try
            {
                httpResponse = await _client.SendAsync(httpRequest);
                int _statusCode = (int)httpResponse.StatusCode;

                if (_statusCode == 400 || _statusCode == 422 || _statusCode >= 400 && _statusCode < 500 || _statusCode >= 500 && _statusCode < 600)
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
                if(Utilities.IsContentTypeMatch("application/json", contentType))
                {
                    var obj = ResponseBodyDeserializer.Deserialize<List<Invitation>>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Include);
                    var response = new CreateBulkInvitationsResponse()
                    {
                        HttpMeta = new Models.Components.HTTPMetadata()
                        {
                            Response = httpResponse,
                            Request = httpRequest
                        }
                    };
                    response.InvitationList = obj;
                    return response;
                }

                throw new Models.Errors.SDKError("Unknown content type received", httpRequest, httpResponse);
            }
            else if(new List<int>{400, 422}.Contains(responseStatusCode))
            {
                if(Utilities.IsContentTypeMatch("application/json", contentType))
                {
                    var obj = ResponseBodyDeserializer.Deserialize<ClerkErrors>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Include);
                    throw obj!;
                }

                throw new Models.Errors.SDKError("Unknown content type received", httpRequest, httpResponse);
            }
            else if(responseStatusCode >= 400 && responseStatusCode < 500)
            {
                throw new Models.Errors.SDKError("API error occurred", httpRequest, httpResponse);
            }
            else if(responseStatusCode >= 500 && responseStatusCode < 600)
            {
                throw new Models.Errors.SDKError("API error occurred", httpRequest, httpResponse);
            }

            throw new Models.Errors.SDKError("Unknown status code received", httpRequest, httpResponse);
        }

        public async Task<RevokeInvitationResponse> RevokeAsync(string invitationId)
        {
            var request = new RevokeInvitationRequest()
            {
                InvitationId = invitationId,
            };
            string baseUrl = this.SDKConfiguration.GetTemplatedServerUrl();
            var urlString = URLBuilder.Build(baseUrl, "/invitations/{invitation_id}/revoke", request);

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, urlString);
            httpRequest.Headers.Add("user-agent", _userAgent);

            if (_securitySource != null)
            {
                httpRequest = new SecurityMetadata(_securitySource).Apply(httpRequest);
            }

            var hookCtx = new HookContext("RevokeInvitation", null, _securitySource);

            httpRequest = await this.SDKConfiguration.Hooks.BeforeRequestAsync(new BeforeRequestContext(hookCtx), httpRequest);

            HttpResponseMessage httpResponse;
            try
            {
                httpResponse = await _client.SendAsync(httpRequest);
                int _statusCode = (int)httpResponse.StatusCode;

                if (_statusCode == 400 || _statusCode == 404 || _statusCode >= 400 && _statusCode < 500 || _statusCode >= 500 && _statusCode < 600)
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
                if(Utilities.IsContentTypeMatch("application/json", contentType))
                {
                    var obj = ResponseBodyDeserializer.Deserialize<InvitationRevoked>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Ignore);
                    var response = new RevokeInvitationResponse()
                    {
                        HttpMeta = new Models.Components.HTTPMetadata()
                        {
                            Response = httpResponse,
                            Request = httpRequest
                        }
                    };
                    response.InvitationRevoked = obj;
                    return response;
                }

                throw new Models.Errors.SDKError("Unknown content type received", httpRequest, httpResponse);
            }
            else if(new List<int>{400, 404}.Contains(responseStatusCode))
            {
                if(Utilities.IsContentTypeMatch("application/json", contentType))
                {
                    var obj = ResponseBodyDeserializer.Deserialize<ClerkErrors>(await httpResponse.Content.ReadAsStringAsync(), NullValueHandling.Ignore);
                    throw obj!;
                }

                throw new Models.Errors.SDKError("Unknown content type received", httpRequest, httpResponse);
            }
            else if(responseStatusCode >= 400 && responseStatusCode < 500)
            {
                throw new Models.Errors.SDKError("API error occurred", httpRequest, httpResponse);
            }
            else if(responseStatusCode >= 500 && responseStatusCode < 600)
            {
                throw new Models.Errors.SDKError("API error occurred", httpRequest, httpResponse);
            }

            throw new Models.Errors.SDKError("Unknown status code received", httpRequest, httpResponse);
        }
    }
}