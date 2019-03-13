using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Okta.Sdk.Abstractions;

namespace Okta.Sdk
{
    public class Resource : BaseResource
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Resource"/> class.
        /// </summary>
        public Resource()
        {
            Initialize(null, null, null, null);
        }

        internal void Initialize(
            IOktaClient client,
            ResourceFactory resourceFactory,
            IDictionary<string, object> data,
            ILogger logger)
        {
            resourceFactory = resourceFactory ?? new ResourceFactory(client, logger, new ResourceTypeResolverFactory());
            base.Initialize(client, resourceFactory, data, logger);
        }

        /// <summary>
        /// Gets the <see cref="IOktaClient">OktaClient</see> that created this resource.
        /// </summary>
        /// <returns>The <see cref="IOktaClient">OktaClient</see> that created this resource.</returns>
        protected new IOktaClient GetClient()
        {
            return (IOktaClient)_client ?? throw new InvalidOperationException("Only resources retrieved or saved through a Client object cna call server-side methods.");
        }
    }
}
