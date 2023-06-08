using RestSharp;
using System.Net;

namespace RestSharp108.Core
{
    public class ApiDetails
    {
        /// <summary>
        /// Gets or sets the ApiUrl
        /// </summary>
        public string ApiUrl { get; set; }

        /// <summary>
        /// Gets or sets the Response
        /// </summary>
        public RestResponse Response { get; set; }

        /// <summary>
        /// Gets or sets the Request
        /// </summary>
        public RestRequest Request { get; set; }

        /// <summary>
        /// Gets or sets the ResClient
        /// </summary>
        public RestClient RestClient { get; set; } = new RestClient();

        /// <summary>
        /// Gets or sets the RestClient option
        /// </summary>
        public RestClientOptions RestClientOptions { get; set; }

        /// <summary>
        /// Gets or sets the Cookie Collection
        /// </summary>
        public CookieCollection CookieCollection { get; set; }
    }
}