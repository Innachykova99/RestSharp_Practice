namespace Inna_RestSharp.Constants
{
    internal class RouteConstants
    {
        private const string BaseUrl = "https://reqres.in/";
        public static readonly Uri UserOperationEndpoint = new Uri(new Uri(BaseUrl), "/api/users/");

        public static readonly Uri LoginEndpoint = new Uri(new Uri(BaseUrl), "api/login");
        public static readonly Uri RegisterEndpoint = new Uri(new Uri(BaseUrl), "api/register");

    }
}
