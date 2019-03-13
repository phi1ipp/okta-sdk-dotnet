// <copyright file="OktaClient.cs" company="Okta, Inc">
// Copyright (c) 2014 - present Okta, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Okta.Sdk.Abstractions;
using Okta.Sdk.Abstractions.Configuration;

namespace Okta.Sdk
{
    /// <summary>
    /// A client that communicates with the Okta management API.
    /// </summary>
    /// <example>
    /// Initialize an OktaClient by passing configuration via code
    /// <code>
    /// var oktaClient = new OktaClient(new OktaClientConfiguration
    /// {
    ///   OrgUrl = "https://dev-12345.oktapreview.com/",
    ///   Token = "my_api_token"
    /// });
    /// </code>
    /// </example>
    public partial class OktaClient : BaseOktaClient, IOktaClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OktaClient"/> class.
        /// </summary>
        /// <param name="apiClientConfiguration">
        /// The client configuration. If <c>null</c>, the library will attempt to load
        /// configuration from an <c>okta.yaml</c> file or environment variables.
        /// </param>
        /// <param name="logger">The logging interface to use, if any.</param>
        public OktaClient(OktaClientConfiguration apiClientConfiguration = null, ILogger logger = null)
        {
            Configuration = GetConfigurationOrDefault(apiClientConfiguration);
            OktaClientConfigurationValidator.Validate(Configuration);

            logger = logger ?? NullLogger.Instance;

            var defaultClient = DefaultHttpClient.Create(
                Configuration.ConnectionTimeout,
                Configuration.Proxy,
                logger);

            var requestExecutor = new DefaultRequestExecutor(Configuration, defaultClient, logger);
            var resourceFactory = new ResourceFactory(this, logger, new ResourceTypeResolverFactory());

            _dataStore = new DefaultDataStore(
                requestExecutor,
                new DefaultSerializer(),
                resourceFactory,
                logger);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OktaClient"/> class using the specified <see cref="HttpClient"/>.
        /// </summary>
        /// <param name="apiClientConfiguration">
        /// The client configuration. If <c>null</c>, the library will attempt to load
        /// configuration from an <c>okta.yaml</c> file or environment variables.
        /// </param>
        /// <param name="httpClient">The HTTP client to use for requests to the Okta API.</param>
        /// <param name="logger">The logging interface to use, if any.</param>
        public OktaClient(OktaClientConfiguration apiClientConfiguration, HttpClient httpClient, ILogger logger = null)
        {
            Configuration = GetConfigurationOrDefault(apiClientConfiguration);
            OktaClientConfigurationValidator.Validate(Configuration);

            logger = logger ?? NullLogger.Instance;

            var requestExecutor = new DefaultRequestExecutor(Configuration, httpClient, logger);
            var resourceFactory = new ResourceFactory(this, logger, new ResourceTypeResolverFactory());
            _dataStore = new DefaultDataStore(
                requestExecutor,
                new DefaultSerializer(),
                resourceFactory,
                logger);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OktaClient"/> class.
        /// </summary>
        /// <param name="dataStore">The <see cref="IDataStore">DataStore</see> to use.</param>
        /// <param name="configuration">The client configuration.</param>
        /// <param name="requestContext">The request context, if any.</param>
        /// <remarks>This overload is used internally to create cheap copies of an existing client.</remarks>
        protected OktaClient(IDataStore dataStore, OktaClientConfiguration configuration, RequestContext requestContext)
            : base(dataStore, configuration, requestContext)
        {
        }

        /// <inheritdoc/>
        public IUsersClient Users => new UsersClient(_dataStore, Configuration, _requestContext);

        /// <inheritdoc/>
        public IUserFactorsClient UserFactors => new UserFactorsClient(_dataStore, Configuration, _requestContext);

        /// <inheritdoc/>
        public IGroupsClient Groups => new GroupsClient(_dataStore, Configuration, _requestContext);

        /// <inheritdoc/>
        public IApplicationsClient Applications => new ApplicationsClient(_dataStore, Configuration, _requestContext);

        /// <inheritdoc/>
        public ISessionsClient Sessions => new SessionsClient(_dataStore, Configuration, _requestContext);

        /// <inheritdoc/>
        public ILogsClient Logs => new LogsClient(_dataStore, Configuration, _requestContext);
    }
}
