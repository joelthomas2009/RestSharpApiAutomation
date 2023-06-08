using RestSharp;
using RestSharp.Authenticators;
using System.Net;

namespace RestShart108.Core
{
    static class ApiHelper
    {

        /// <summary>
        /// AddCookie is an extension menthod of RestClient that can add the value of specific cookie into a request
        /// Call multiple times if you need to add multiple cookies to a reques
        /// </summary>
        /// <param name="client">RestClient</param>
        /// <param name="cookieCollection">The CookieCollection got form the login cookie</param>
        /// <param name="cookieName">Required name of the cookie</param>
        /// <returns>RestClient</returns>
        public static RestClient AddCookie(this RestClient client, CookieCollection cookieCollection, string cookieName)
        {
            for (int index = 0; index < cookieCollection.Count; index++)
            {
                if (cookieCollection[index].Name == cookieName)
                {
                    client.AddCookie(cookieCollection[index].Name, cookieCollection[index].Value, cookieCollection[index].Path, cookieCollection[index].Domain);
                    break;
                }
            }

            return client;
        }

        /// <summary>
        /// HttpBasicAuthenticator Extension method
        /// </summary>
        /// <param name="client">RestClient</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>client</returns>
        public static RestClient HttpBasicAuthenticator(this RestClient client, string username, string password)
        {
            client.Authenticator = new HttpBasicAuthenticator(username, password);
            return client;
        }
    }
}