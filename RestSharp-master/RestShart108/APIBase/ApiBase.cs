using RestSharp108.Core;
using RestSharp;
using System.Net;
using RestShart108.Core;

namespace RestSharp108.APIBase
{
    public class ApiBase
    {
        /// <summary>
        /// Creates an instance object of the ApiDetails class
        /// </summary>
        private readonly ApiDetails apiDetails;

        public ApiBase() => apiDetails = new ApiDetails();

        /// <summary>
        /// Call the public apis with no authentication and get the entries
        /// https://api.publicapis.org/entries
        /// </summary>
        /// <returns>The https://api.publicapis.org/entries API response</returns>
        public RestResponse CallThePublicApisWithNoAuthenticationAndGetTheEntries()
        {
            apiDetails.ApiUrl = "https://api.publicapis.org/entries";
            apiDetails.Request = new RestRequest(apiDetails.ApiUrl, Method.Get);
            apiDetails.Response = apiDetails.RestClient.Execute(apiDetails.Request);
            return apiDetails.Response;
        }

        /// <summary>
        /// Call the public apis with basic authentication
        /// </summary>
        /// <param name="userName">User name</param>
        /// <param name="password">Password</param>
        /// <returns>API Response</returns>
        public RestResponse CallThePublicApisWithBasicAuthentication(string userName, string password)
        {
            apiDetails.ApiUrl = "https://postman-echo.com/basic-auth";
            apiDetails.Request = new RestRequest(apiDetails.ApiUrl, Method.Get);
            apiDetails.RestClient.HttpBasicAuthenticator(userName, password);
            apiDetails.Response = apiDetails.RestClient.Execute(apiDetails.Request);
            return apiDetails.Response;
        }

        /// <summary>
        /// Get the cookie collections for a user
        /// </summary>
        /// <param name="userEmail">The email id of the user you are trying to login</param>
        /// <param name="password">The password of the user</param>
        /// <returns>The cookie details</returns>
        public CookieCollection GetTheCookieCollectionsForAUser(string userEmail, string password)
        {
            apiDetails.ApiUrl = "http://url_of_Login_To_The_Required_Site";//The login url of the site you are trying to login to
            apiDetails.Request = new RestRequest(apiDetails.ApiUrl, Method.Post);
            apiDetails.Request.AddParameter("email", userEmail);// The "email" in the AddParameter is just an example, change it with your needed api payload of login
            apiDetails.Request.AddParameter("password", password);// The "password" in the AddParameter is just an example, change it with your needed api payload of login
            apiDetails.Response = apiDetails.RestClient.Execute(apiDetails.Request);
            apiDetails.CookieCollection = apiDetails.Response.Cookies;
            return apiDetails.CookieCollection;
        }

        /// <summary>
        /// Call the api using cookie authentication
        /// </summary>
        /// <returns>API Response</returns>
        public RestResponse CallApiUsingCookieAuthentication()
        {
            apiDetails.ApiUrl = "http://url_of_api_using_cookie_authentication";
            apiDetails.Request = new RestRequest(apiDetails.ApiUrl, Method.Post);
            apiDetails.RestClient.AddCookie(apiDetails.CookieCollection, "CookieNameNeeded");
            apiDetails.Response = apiDetails.RestClient.Execute(apiDetails.Request);
            return apiDetails.Response;
        }

        /// <summary>
        /// Call apis using network credential
        /// </summary>
        /// <returns>API Response</returns>
        public RestResponse CallApiUsingNetworkCredential(string userName, string password, string domain)
        {
            apiDetails.ApiUrl = "http://url_of_api_using_network_Credentilas";
            apiDetails.Request = new RestRequest(apiDetails.ApiUrl, Method.Get);
            apiDetails.RestClientOptions = new RestClientOptions(apiDetails.ApiUrl)
            {
                Credentials = new NetworkCredential(userName, password, domain),
            };
            apiDetails.RestClient = new RestClient(apiDetails.RestClientOptions);
            apiDetails.Response = apiDetails.RestClient.Execute(apiDetails.Request);
            return apiDetails.Response;
        }
    }
}