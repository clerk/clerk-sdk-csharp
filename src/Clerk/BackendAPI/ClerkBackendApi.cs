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
    using Clerk.BackendAPI.Utils;
    using Clerk.BackendAPI.Utils.Retries;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    /// <summary>
    /// Clerk Backend API: The Clerk REST Backend API, meant to be accessed by backend servers.<br/>
    /// 
    /// <remarks>
    /// <br/>
    /// ### Versions<br/>
    /// <br/>
    /// When the API changes in a way that isn&apos;t compatible with older versions, a new version is released.<br/>
    /// Each version is identified by its release date, e.g. `2024-10-01`. For more information, please see <a href="https://clerk.com/docs/versioning/available-versions">Clerk API Versions</a>.<br/>
    /// <br/>
    /// Please see https://clerk.com/docs for more information.
    /// </remarks>
    /// 
    /// <see>https://clerk.com/docs}</see>
    /// </summary>
    public interface IClerkBackendApi
    {
        public IMiscellaneous Miscellaneous { get; }
        public IJwks Jwks { get; }
        public IClients Clients { get; }
        public IEmailAddresses EmailAddresses { get; }
        public IPhoneNumbers PhoneNumbers { get; }
        public ISessions Sessions { get; }
        public IEmailSMSTemplates EmailSMSTemplates { get; }
        public IEmailAndSmsTemplates EmailAndSmsTemplates { get; }
        public ITemplates Templates { get; }
        public IUsers Users { get; }
        public IInvitations Invitations { get; }
        public IOrganizationInvitations OrganizationInvitations { get; }
        public IAllowlistIdentifiers AllowlistIdentifiers { get; }
        public IBlocklistIdentifiers BlocklistIdentifiers { get; }
        public IBetaFeatures BetaFeatures { get; }
        public IActorTokens ActorTokens { get; }
        public IDomains Domains { get; }
        public IInstanceSettings InstanceSettings { get; }
        public IWebhooks Webhooks { get; }
        public IJwtTemplates JwtTemplates { get; }
        public IOrganizations Organizations { get; }
        public IOrganizationMemberships OrganizationMemberships { get; }
        public IOrganizationDomains OrganizationDomains { get; }
        public IProxyChecks ProxyChecks { get; }
        public IRedirectUrls RedirectUrls { get; }
        public ISignInTokens SignInTokens { get; }
        public ISignUps SignUps { get; }
        public IOauthApplications OauthApplications { get; }
        public ISamlConnections SamlConnections { get; }
        public ITestingTokens TestingTokens { get; }
        public IWaitlistEntries WaitlistEntries { get; }
        public IExperimentalAccountlessApplications ExperimentalAccountlessApplications { get; }
    }

    public class SDKConfig
    {
        /// <summary>
        /// List of server URLs available to the SDK.
        /// </summary>
        public static readonly string[] ServerList = {
            "https://api.clerk.com/v1",
        };

        public string ServerUrl = "";
        public int ServerIndex = 0;
        public SDKHooks Hooks = new SDKHooks();
        public RetryConfig? RetryConfig = null;

        public string GetTemplatedServerUrl()
        {
            if (!String.IsNullOrEmpty(this.ServerUrl))
            {
                return Utilities.TemplateUrl(Utilities.RemoveSuffix(this.ServerUrl, "/"), new Dictionary<string, string>());
            }
            return Utilities.TemplateUrl(SDKConfig.ServerList[this.ServerIndex], new Dictionary<string, string>());
        }

        public ISpeakeasyHttpClient InitHooks(ISpeakeasyHttpClient client)
        {
            string preHooksUrl = GetTemplatedServerUrl();
            var (postHooksUrl, postHooksClient) = this.Hooks.SDKInit(preHooksUrl, client);
            if (preHooksUrl != postHooksUrl)
            {
                this.ServerUrl = postHooksUrl;
            }
            return postHooksClient;
        }
    }

    /// <summary>
    /// Clerk Backend API: The Clerk REST Backend API, meant to be accessed by backend servers.<br/>
    /// 
    /// <remarks>
    /// <br/>
    /// ### Versions<br/>
    /// <br/>
    /// When the API changes in a way that isn&apos;t compatible with older versions, a new version is released.<br/>
    /// Each version is identified by its release date, e.g. `2024-10-01`. For more information, please see <a href="https://clerk.com/docs/versioning/available-versions">Clerk API Versions</a>.<br/>
    /// <br/>
    /// Please see https://clerk.com/docs for more information.
    /// </remarks>
    /// 
    /// <see>https://clerk.com/docs}</see>
    /// </summary>
    public class ClerkBackendApi: IClerkBackendApi
    {
        public SDKConfig SDKConfiguration { get; private set; }

        private const string _language = "csharp";
        private const string _sdkVersion = "0.7.2";
        private const string _sdkGenVersion = "2.605.0";
        private const string _openapiDocVersion = "2024-10-01";
        private const string _userAgent = "speakeasy-sdk/csharp 0.7.2 2.605.0 2024-10-01 Clerk.BackendAPI";
        private string _serverUrl = "";
        private int _serverIndex = 0;
        private ISpeakeasyHttpClient _client;
        private Func<Clerk.BackendAPI.Models.Components.Security>? _securitySource;
        public IMiscellaneous Miscellaneous { get; private set; }
        public IJwks Jwks { get; private set; }
        public IClients Clients { get; private set; }
        public IEmailAddresses EmailAddresses { get; private set; }
        public IPhoneNumbers PhoneNumbers { get; private set; }
        public ISessions Sessions { get; private set; }
        public IEmailSMSTemplates EmailSMSTemplates { get; private set; }
        public IEmailAndSmsTemplates EmailAndSmsTemplates { get; private set; }
        public ITemplates Templates { get; private set; }
        public IUsers Users { get; private set; }
        public IInvitations Invitations { get; private set; }
        public IOrganizationInvitations OrganizationInvitations { get; private set; }
        public IAllowlistIdentifiers AllowlistIdentifiers { get; private set; }
        public IBlocklistIdentifiers BlocklistIdentifiers { get; private set; }
        public IBetaFeatures BetaFeatures { get; private set; }
        public IActorTokens ActorTokens { get; private set; }
        public IDomains Domains { get; private set; }
        public IInstanceSettings InstanceSettings { get; private set; }
        public IWebhooks Webhooks { get; private set; }
        public IJwtTemplates JwtTemplates { get; private set; }
        public IOrganizations Organizations { get; private set; }
        public IOrganizationMemberships OrganizationMemberships { get; private set; }
        public IOrganizationDomains OrganizationDomains { get; private set; }
        public IProxyChecks ProxyChecks { get; private set; }
        public IRedirectUrls RedirectUrls { get; private set; }
        public ISignInTokens SignInTokens { get; private set; }
        public ISignUps SignUps { get; private set; }
        public IOauthApplications OauthApplications { get; private set; }
        public ISamlConnections SamlConnections { get; private set; }
        public ITestingTokens TestingTokens { get; private set; }
        public IWaitlistEntries WaitlistEntries { get; private set; }
        public IExperimentalAccountlessApplications ExperimentalAccountlessApplications { get; private set; }

        public ClerkBackendApi(string? bearerAuth = null, Func<string>? bearerAuthSource = null, int? serverIndex = null, string? serverUrl = null, Dictionary<string, string>? urlParams = null, ISpeakeasyHttpClient? client = null, RetryConfig? retryConfig = null)
        {
            if (serverIndex != null)
            {
                if (serverIndex.Value < 0 || serverIndex.Value >= SDKConfig.ServerList.Length)
                {
                    throw new Exception($"Invalid server index {serverIndex.Value}");
                }
                _serverIndex = serverIndex.Value;
            }

            if (serverUrl != null)
            {
                if (urlParams != null)
                {
                    serverUrl = Utilities.TemplateUrl(serverUrl, urlParams);
                }
                _serverUrl = serverUrl;
            }

            _client = client ?? new SpeakeasyHttpClient();

            if(bearerAuthSource != null)
            {
                _securitySource = () => new Clerk.BackendAPI.Models.Components.Security() { BearerAuth = bearerAuthSource() };
            }
            else if(bearerAuth != null)
            {
                _securitySource = () => new Clerk.BackendAPI.Models.Components.Security() { BearerAuth = bearerAuth };
            }

            SDKConfiguration = new SDKConfig()
            {
                ServerIndex = _serverIndex,
                ServerUrl = _serverUrl,
                RetryConfig = retryConfig
            };

            _client = SDKConfiguration.InitHooks(_client);


            Miscellaneous = new Miscellaneous(_client, _securitySource, _serverUrl, SDKConfiguration);


            Jwks = new Jwks(_client, _securitySource, _serverUrl, SDKConfiguration);


            Clients = new Clients(_client, _securitySource, _serverUrl, SDKConfiguration);


            EmailAddresses = new EmailAddresses(_client, _securitySource, _serverUrl, SDKConfiguration);


            PhoneNumbers = new PhoneNumbers(_client, _securitySource, _serverUrl, SDKConfiguration);


            Sessions = new Sessions(_client, _securitySource, _serverUrl, SDKConfiguration);


            EmailSMSTemplates = new EmailSMSTemplates(_client, _securitySource, _serverUrl, SDKConfiguration);


            EmailAndSmsTemplates = new EmailAndSmsTemplates(_client, _securitySource, _serverUrl, SDKConfiguration);


            Templates = new Templates(_client, _securitySource, _serverUrl, SDKConfiguration);


            Users = new Users(_client, _securitySource, _serverUrl, SDKConfiguration);


            Invitations = new Invitations(_client, _securitySource, _serverUrl, SDKConfiguration);


            OrganizationInvitations = new OrganizationInvitations(_client, _securitySource, _serverUrl, SDKConfiguration);


            AllowlistIdentifiers = new AllowlistIdentifiers(_client, _securitySource, _serverUrl, SDKConfiguration);


            BlocklistIdentifiers = new BlocklistIdentifiers(_client, _securitySource, _serverUrl, SDKConfiguration);


            BetaFeatures = new BetaFeatures(_client, _securitySource, _serverUrl, SDKConfiguration);


            ActorTokens = new ActorTokens(_client, _securitySource, _serverUrl, SDKConfiguration);


            Domains = new Domains(_client, _securitySource, _serverUrl, SDKConfiguration);


            InstanceSettings = new InstanceSettings(_client, _securitySource, _serverUrl, SDKConfiguration);


            Webhooks = new Webhooks(_client, _securitySource, _serverUrl, SDKConfiguration);


            JwtTemplates = new JwtTemplates(_client, _securitySource, _serverUrl, SDKConfiguration);


            Organizations = new Organizations(_client, _securitySource, _serverUrl, SDKConfiguration);


            OrganizationMemberships = new OrganizationMemberships(_client, _securitySource, _serverUrl, SDKConfiguration);


            OrganizationDomains = new OrganizationDomains(_client, _securitySource, _serverUrl, SDKConfiguration);


            ProxyChecks = new ProxyChecks(_client, _securitySource, _serverUrl, SDKConfiguration);


            RedirectUrls = new RedirectUrls(_client, _securitySource, _serverUrl, SDKConfiguration);


            SignInTokens = new SignInTokens(_client, _securitySource, _serverUrl, SDKConfiguration);


            SignUps = new SignUps(_client, _securitySource, _serverUrl, SDKConfiguration);


            OauthApplications = new OauthApplications(_client, _securitySource, _serverUrl, SDKConfiguration);


            SamlConnections = new SamlConnections(_client, _securitySource, _serverUrl, SDKConfiguration);


            TestingTokens = new TestingTokens(_client, _securitySource, _serverUrl, SDKConfiguration);


            WaitlistEntries = new WaitlistEntries(_client, _securitySource, _serverUrl, SDKConfiguration);


            ExperimentalAccountlessApplications = new ExperimentalAccountlessApplications(_client, _securitySource, _serverUrl, SDKConfiguration);
        }
    }
}