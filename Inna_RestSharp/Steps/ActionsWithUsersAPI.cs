using Inna_RestSharp.Constants;
using Inna_RestSharp.Models;
using log4net;
using Newtonsoft.Json;
using RestSharp;
using TechTalk.SpecFlow.Assist;

namespace Inna_RestSharp.Steps
{

    [Binding]
    public class Inna_RestSharpActionsWithUsersSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private RestClient _restClient;
        private RestResponse _restResponse;
        private StatusCodes statusCodes;
        //private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Inna_RestSharpActionsWithUsersSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _restClient = new RestClient();
        }

        //[When(@"User sends a (.*) request to (.*)")]
        //public void WhenUserSendsARequestToApiUsersPage(string method, string endpoint)
        //{
        //    var restMethod = (Method)Enum.Parse(typeof(Method), method, true);
        //    var request = new RestRequest(endpoint, restMethod);
        //    _restResponse = _restClient.Execute(request);


        [Given(@"The Users API URL is ""([^""]*)""")]
        public void GivenTheUsersAPILinkIs(string baseUrl)
        {
            _restClient = new RestClient(baseUrl);
        }

        [Given(@"the Endpoint is ""([^""]*)""")]
        public void GivenTheEndpointIs(string endpoint)
        {
            _restClient = new RestClient(endpoint);
            _scenarioContext.Set(endpoint, "Endpoint");
        }
        [When(@"User sends the GET request to the list of users")]
        public void WhenUserSendsTheGETRequestToTheListOfUsers(Method restMethod)
        {
            var endpoint = _scenarioContext.Get<string>("Endpoint");
            var getRequestListOfUsers = new RestRequest(endpoint, restMethod);
            _restResponse = _restClient.Execute(getRequestListOfUsers);
        }

        [Then(@"the ""([^""]*)"" status code is received")]
        public void ThenTheStatusCodeIsReceived(string expectedStatusCode)
        {
            int actualStatusCode = (int)_restResponse.StatusCode;
            int expectedStatusCodeValue = int.Parse(expectedStatusCode);
            actualStatusCode.Should().Be(expectedStatusCodeValue);
        }

        [Then(@"the list of users is returned")]
        public void ThenTheListOfUsersIsDisplayed()
        {
            var usersList = JsonConvert.DeserializeObject<UsersList>(_restResponse.Content);

            foreach (var item in usersList.Items)
            {
                //log.Info($"Id: {item.Id}");
                //log.Info($"Email: {item.Email}");
                //log.Info($"First Name: {item.FirstName}");
                //log.Info($"Last Name: {item.LastName}");
                //log.Info($"Avatar: {item.Avatar}");
            }
        }

        [When(@"User sends the GET request to the not found single user")]
        public void WhenUserSendsTheGETRequestToTheNotFoundSingleUser(Method restMethod)
        {
            var endpoint = _scenarioContext.Get<string>("Endpoint");
            var getRequestToNotFoundUser = new RestRequest(endpoint, restMethod);
            _restResponse = _restClient.Execute(getRequestToNotFoundUser);
        }

        [When(@"User sends the GET request to the single user")]
        public void WhenUserSendsTheGETRequestToTheSingleUser(Method restMethod)
        {
            var endpoint = _scenarioContext.Get<string>("Endpoint");
            var getRequestToSingleUser = new RestRequest(endpoint, restMethod);
            _restResponse = _restClient.Execute(getRequestToSingleUser);

        }

        [Then(@"the user data is returned")]
        public void ThenTheUserDataIsReturned()
        {
            var singleUserData = JsonConvert.DeserializeObject<UsersList>(_restResponse.Content);

            foreach (var item in singleUserData.Items)
            {
                //    log.Info($"Id: {item.id}");
                //    log.Info($"Email: {item.email}");
                //    log.Info($"First Name: {item.first_name}");
                //    log.Info($"Last Name: {item.last_name}");
                //    log.Info($"Avatar: {item.avatar}");
            }
        }

        [When(@"User sends the POST request to create a user with data in the request body")]
        public void WhenUserSendsThePOSTRequestToCreateAUserWithDataInTheRequestBody(Method restMethod, Table table)
        {
            var createUserData = table.CreateInstance<CreateUser>();
            var endpoint = _scenarioContext.Get<string>("Endpoint");
            var postRequestCreateUser = new RestRequest(endpoint, restMethod)
            .AddJsonBody(createUserData);
            _restResponse = _restClient.Execute(postRequestCreateUser);

            _scenarioContext["CreateUserData"] = createUserData;

            dynamic postJsonResponse = JsonConvert.DeserializeObject<CreateUser>(_restResponse.Content);


            //Console.WriteLine("\nParsed JSON:");
            //Console.WriteLine($"Name: {jsonResponse.name}");
            //Console.WriteLine($"Job: {jsonResponse.job}");
            //Console.WriteLine($"ID: {jsonResponse.id}");
            //Console.WriteLine($"CreatedAt: {jsonResponse.createdAt}");
        }


        [When(@"User sends the PUT request to update a user with data in the request body")]
        public void WhenUserSendsThePUTRequestToUpdateAUserWithDataInTheRequestBody(Method restMethod, Table table)
        {
            var endpoint = _scenarioContext.Get<string>("Endpoint");
            var updateUser = table.CreateInstance<UpdateUser>();
            var postRequestUpdateUser = new RestRequest(endpoint, restMethod)
                .AddJsonBody(updateUser);
            _restResponse = _restClient.Execute(postRequestUpdateUser);
            dynamic putJsonResponse = JsonConvert.DeserializeObject(_restResponse.Content);
        }

        [When(@"User sends the PATCH request to update a user with data in the request body")]
        public void WhenUserSendsThePATCHRequestToUpdateAUserWithDataInTheRequestBody(Method restMethod, Table table)
        {
            var endpoint = _scenarioContext.Get<string>("Endpoint");
            var updateUserData = table.CreateInstance<UpdateUser>();
            var patchRequestUpdateUser = new RestRequest(endpoint, restMethod)
             .AddJsonBody(updateUserData);
            _restResponse = _restClient.Execute(patchRequestUpdateUser);

            dynamic patchJsonResponse = JsonConvert.DeserializeObject(_restResponse.Content);

            //Console.WriteLine("\nParsed JSON:");
            //Console.WriteLine($"Name: {patchJsonResponse.name}");
            //Console.WriteLine($"Job: {patchJsonResponse.job}");
            //Console.WriteLine($"Updated at: {patchJsonResponse.updatedAt}");
        }


        [Then(@"the updated user data is returned")]
        public void ThenTheUpdatedUserDataIsReturned()
        {
            var createUserData = _scenarioContext.Get<CreateUser>("CreateUserData");

        }

        [When(@"User sends the DELETE request to delete a user")]
        public void WhenUserSendsTheDELETERequestToDeleteAUser()
        {
            throw new PendingStepException();
        }

        [When(@"User sends the POST request to register successfully with data in the request body")]
        public void WhenUserSendsThePOSTRequestToRegisterSuccessfullyWithDataInTheRequestBody(Method restMethod, Table table)
        {
            var endpoint = _scenarioContext.Get<string>("Endpoint");
            var registerData = table.CreateInstance<RegisterData>();
            var postRequestSuccessfulRegister = new RestRequest(endpoint, restMethod)
              .AddJsonBody(registerData);
            _restResponse = _restClient.Execute(postRequestSuccessfulRegister);

            dynamic postJsonResponse = JsonConvert.DeserializeObject(_restResponse.Content);

            //Console.WriteLine("\nParsed JSON:");
            //Console.WriteLine($"Id: {postJsonResponse.id}");
            //Console.WriteLine($"Token: {postJsonResponse.token}");
        }

        [Then(@"the id and token are received")]
        public void ThenTheIdAndTokenAreReceived()
        {
            throw new PendingStepException();
        }

        [When(@"User sends the POST request to login unsuccessfully with data in the request body")]
        public void WhenUserSendsThePOSTRequestToLoginUnsuccessfullyWithDataInTheRequestBody(Method restMethod, Table table)
        {
            var endpoint = _scenarioContext.Get<string>("Endpoint");
            var loginData = table.CreateInstance<LoginData>();
            var postRequestUnsuccessfulLogin = new RestRequest(endpoint, restMethod)
            .AddJsonBody(loginData);
            _restResponse = _restClient.Execute(postRequestUnsuccessfulLogin);

            dynamic postJsonResponseUnsuccessfulLogin = JsonConvert.DeserializeObject(_restResponse.Content);

            //Console.WriteLine("\nParsed JSON:");
            //Console.WriteLine($"Error: {postJsonResponseUnsuccessfulLogin.error}");
        }

        [Then(@"the error ""([^""]*)"" is returned")]
        public void ThenTheErrorIsReturned(string p0)
        {
        
        }


        [When(@"User sends the GET request for the delayed response")]
        public void WhenUserSendsTheGETRequestForTheDelayedResponse()
        {
            throw new PendingStepException();
        }

        [Then(@"the users list is returned")]
        public void ThenTheUsersListIsReturned()
        {
            throw new PendingStepException();
        }

    }

}