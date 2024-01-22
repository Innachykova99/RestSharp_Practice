using Inna_RestSharp.Constants;
using RestSharp;

namespace Inna_RestSharp.Steps
{

    [Binding]
    public class Inna_RestSharpActionsWithUsersSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private RestClient _restClient;
        private RestResponse _restResponse;
        private StatusCodes receivedStatusCodes;

        public Inna_RestSharpActionsWithUsersSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"The Users API URL is ""([^""]*)""")]
        public void GivenTheUsersAPILinkIs(string baseUrl)
        {
            _restClient = new RestClient(baseUrl);
        }

        [When(@"User sends a (.*) request to (.*)")]
        public void WhenUserSendsARequestToApiUsersPage(string method, string endpoint)
        {
            var restMethod = (Method)Enum.Parse(typeof(Method), method, true);
            var request = new RestRequest(endpoint, restMethod);
            _restResponse = _restClient.Execute(request);

            var postRequestBody = new
            {
                name = "morpheus",
                job = "leader"
            };

            var patchRequestBody = new
            {
                name = "morpheus",
                job = "zion resident"
            };

            var postRegisterBody = new
            {
                email = "eve.holt@reqres.in",
                password = "pistol"
            };

            var postUnsuccessfulLoginBody = new
            {
                email = "peter@klaven"
            };

            var postRequestLogin = new RestRequest(endpoint, restMethod)
            .AddJsonBody(postUnsuccessfulLoginBody);
            _restResponse = _restClient.Execute(postRequestLogin);

            dynamic postJsonResponseUnsuccessfulLogin = Newtonsoft.Json.JsonConvert.DeserializeObject(_restResponse.Content);
            Console.WriteLine("\nParsed JSON:");
            Console.WriteLine($"Error: {postJsonResponseUnsuccessfulLogin.error}");


            var postRequestRegister = new RestRequest(endpoint, restMethod)
                .AddJsonBody(postRegisterBody);
            _restResponse = _restClient.Execute(postRequestRegister);

            dynamic postJsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(_restResponse.Content);
            Console.WriteLine("\nParsed JSON:");
            Console.WriteLine($"Id: {postJsonResponse.id}");
            Console.WriteLine($"Token: {postJsonResponse.token}");


            var patchRequest = new RestRequest(endpoint, restMethod)
                .AddJsonBody(patchRequestBody);
            _restResponse = _restClient.Execute(patchRequest);

            dynamic patchJsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(_restResponse.Content);
            Console.WriteLine("\nParsed JSON:");
            Console.WriteLine($"Name: {patchJsonResponse.name}");
            Console.WriteLine($"Job: {patchJsonResponse.job}");
            Console.WriteLine($"Updated at: {patchJsonResponse.updatedAt}");

            var postRequest = new RestRequest(endpoint, restMethod)
            .AddJsonBody(postRequestBody);
            _restResponse = _restClient.Execute(postRequest);

            dynamic jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject(_restResponse.Content);
            Console.WriteLine("\nParsed JSON:");
            Console.WriteLine($"Name: {jsonResponse.name}");
            Console.WriteLine($"Job: {jsonResponse.job}");
            Console.WriteLine($"ID: {jsonResponse.id}");
            Console.WriteLine($"CreatedAt: {jsonResponse.createdAt}");


            var getRequestListOfUsers = new RestRequest(endpoint, restMethod);
            _restResponse = _restClient.Execute(getRequestListOfUsers);

            dynamic jsonListOfUsers = Newtonsoft.Json.JsonConvert.DeserializeObject(_restResponse.Content);
            Console.WriteLine("\nParsed JSON:");
            Console.WriteLine($"Page: {jsonListOfUsers.page}");
            Console.WriteLine($"Per page: {jsonListOfUsers.per_page}");
            Console.WriteLine($"Total: {jsonListOfUsers.total}");
            Console.WriteLine($"Total pages: {jsonListOfUsers.total_pages}");

            foreach (var item in jsonResponse.data)
            {
                Console.WriteLine($"Id: {item.id}");
                Console.WriteLine($"Email: {item.email}");
                Console.WriteLine($"First Name: {item.first_name}");
                Console.WriteLine($"Last Name: {item.last_name}");
                Console.WriteLine($"Avatar: {item.avatar}");
            }

            var getRequestOneUser = new RestRequest(endpoint, restMethod);
            _restResponse = _restClient.Execute(getRequestOneUser);

            dynamic jsonOneUser = Newtonsoft.Json.JsonConvert.DeserializeObject(_restResponse.Content);
            Console.WriteLine("\nParsed JSON:");
            foreach (var item in jsonOneUser.data)
            {
                Console.WriteLine($"Id: {jsonOneUser.id}");
                Console.WriteLine($"Email: {jsonOneUser.email}");
                Console.WriteLine($"First Name: {jsonOneUser.first_name}");
                Console.WriteLine($"Last Name: {jsonOneUser.last_name}");
                Console.WriteLine($"Avatar: {jsonOneUser.avatar}");
            }
        }

        [Then(@"The Response code should be (.*)")]
        public void ThenTheResponseCodeShouldBe(string expectedStatusCode)
        {
            int actualStatusCode = (int)_restResponse.StatusCode;
            int expectedStatusCodeValue = int.Parse(expectedStatusCode);

            actualStatusCode.Should().Be(expectedStatusCodeValue);
            Console.WriteLine($"Actual status code: {actualStatusCode}");
            Console.WriteLine($"Expected status code: {expectedStatusCodeValue}");
        }


    }

}


