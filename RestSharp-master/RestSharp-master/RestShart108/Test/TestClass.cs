using RestSharp108.APIBase;
using NUnit.Framework;
using Newtonsoft.Json.Linq;

namespace RestSharp108.Test
{
    [Parallelizable]
    [TestFixture]
    internal class TestClass
    {
        #region OBJECT INITIALIZATION

        /// <summary>
        /// The object for the ApiBase is create in the test class itself
        /// </summary>
        private readonly ApiBase apiBase;

        #endregion

        /// <summary>
        /// The object creation for all the used classes can be done in the constructor of the test class
        /// For adding new classes, define the class and the object just above the constructor and create the object inside the constructor  
        /// </summary>
        public TestClass() => apiBase = new ApiBase();

        [OneTimeSetUp]
        public void TestFixtureInitialization()
        {
            /// In the future if any one time actions are needed, you can call the funtions to do the actions here
            // Method intentionally left empty.
        }

        [SetUp]
        public void SetUp()
        {
            /// If any actions are needed to be performed before every test, the you can cal those actions here
            // Method intentionally left empty.
        }

        /// <summary>
        /// Test the GET method api with no authentication
        /// </summary>
        [Test]
        [Order(1)]
        [Category("RestSharpAPITesting")]
        [Description("Verify the public apis and get the entries")]
        public void VerifyThePublicApisAndGetTheEntries()
        {
            var newResponse = apiBase.CallThePublicApisWithNoAuthenticationAndGetTheEntries();
            JObject publicApisResponse = JObject.Parse(newResponse.Content.ToString());
            JToken apiEntries = publicApisResponse["entries"];
            Assert.AreEqual(200, (int)newResponse.StatusCode);
            Assert.IsTrue(apiEntries.HasValues);
        }

        /// <summary>
        /// Test the GET method api with basic authentication
        /// </summary>
        [Test]
        [Order(2)]
        [Category("RestSharpAPITesting")]
        [Description("Test the GET method api with basic authentication")]
        public void VerifyThePublicApisWithBasicAuthentication()
        {
            var newResponse = apiBase.CallThePublicApisWithBasicAuthentication("postman", "password");
            JObject publicApisResponse = JObject.Parse(newResponse.Content.ToString());
            Assert.AreEqual(200, (int)newResponse.StatusCode);
            Assert.IsTrue(publicApisResponse.HasValues);
        }

        /// <summary>
        /// Test the GET method api with Cookie authentication
        /// </summary>
        [Test]
        [Order(3)]
        [Category("RestSharpAPITesting")]
        [Description("Test the GET method api with Cookie authentication")]
        public void VerifyThePublicApisWithCookieAuthentication()
        {
            apiBase.GetTheCookieCollectionsForAUser("postman", "password");//Cookie value assignment is happening inside the GetTheCookieCollectionsForAUser itself.
            var newResponse = apiBase.CallApiUsingCookieAuthentication();
            Assert.AreEqual(200, (int)newResponse.StatusCode);
        }

        /// <summary>
        /// Test the GET method api with network credential
        /// </summary>
        [Test]
        [Order(4)]
        [Category("RestSharpAPITesting")]
        [Description("Test the GET method api with network credential")]
        public void VerifyApisUsingNetworkCredentials()
        {
            ///You can use the RestClientOptions class for network credential
            var newResponse = apiBase.CallApiUsingNetworkCredential("username", "password", "domain");
            Assert.AreEqual(200, (int)newResponse.StatusCode);
        }
    }
}