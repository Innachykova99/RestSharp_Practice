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
        private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Inna_RestSharpActionsWithUsersSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _restClient = new RestClient();
        }

        [Given(@"The Users API URL is ""([^""]*)""")]
        public void GivenTheUsersAPILinkIs(string baseUrl)
        {
            _restClient = new RestClient(baseUrl);
        }

        [Given(@"the Endpoint is ""([^""]*)""")]
        public void GivenTheEndpointIs(string endpoint)
        {
            _restClient = new RestClient(endpoint);
            _scenarioContext.Add(endpoint, "Endpoint");
        }

        [When(@"the user sends the (GET|) request to page (.*) of users list")]
        public void WhenTheUserSendsTheRequestToGetPageOfUsersList(int pageNumber, string method)
        {
            _restClient = new RestClient(new Uri(RouteConstants.UserOperationEndpoint, $"?page={pageNumber}"));

            var restMethod = (Method)Enum.Parse(typeof(Method), method, true);

            var getRequestListOfUsers = new RestRequest();
            _restResponse = _restClient.Execute(getRequestListOfUsers);

            _scenarioContext.Add(ContextConstants.Response, getRequestListOfUsers);
            _scenarioContext.Add(StatusCodesContainer.StatusCode, _restResponse);
        }

        [Then(@"the ""([^""]*)"" status code is received")]
        public void ThenTheStatusCodeIsReceived(string expectedStatusCode)
        {
            var statusCodeObject = _scenarioContext.Get<StatusCodes>(StatusCodesContainer.StatusCode);

            string statusCodeString = statusCodeObject.StatusCode;

            int expectedStatusCodeValue = int.Parse(expectedStatusCode);
            int actualStatusCodeValue = int.Parse(statusCodeString);

            actualStatusCodeValue.Should().Be(expectedStatusCodeValue);
        }

        [Then(@"the list of users is returned")]
        public void ThenTheListOfUsersIsDisplayed()
        {
            var usersList = JsonConvert.DeserializeObject<UsersList>(_restResponse.Content);

            foreach (var item in usersList.Items)
            {
                log.Info($"Id: {item.Id}");
                log.Info($"Email: {item.Email}");
                log.Info($"First Name: {item.FirstName}");
                log.Info($"Last Name: {item.LastName}");
                log.Info($"Avatar: {item.Avatar}");
            }
        }

        [When(@"User sends the (GET|) request to page (.*) for the not found single user")]
        public void WhenUserSendsTheGETRequestToPageForTheNotFoundSingleUser(int pageNumber, Method restMethod)
        {
            _restClient = new RestClient(new Uri(RouteConstants.UserOperationEndpoint, $"{pageNumber}"));

            var getRequestToNotFoundUser = new RestRequest(restMethod.ToString());
            _restResponse = _restClient.Execute(getRequestToNotFoundUser);
            _scenarioContext.Add(StatusCodesContainer.StatusCode, _restResponse.StatusCode.ToString());
        }

        [When(@"User sends the (GET|) request to the single user for the page (.*)")]
        public void WhenUserSendsTheGETRequestToTheSingleUserForThePage(int pageNumber, Method restMethod)
        {
            _restClient = new RestClient(new Uri(RouteConstants.UserOperationEndpoint, $"{pageNumber}"));

            var getRequestToSingleUser = new RestRequest(restMethod.ToString());
            _restResponse = _restClient.Execute(getRequestToSingleUser);
            _scenarioContext.Add(StatusCodesContainer.StatusCode, _restResponse.StatusCode.ToString());
        }

        [Then(@"the user data is returned")]
        public void ThenTheUserDataIsReturned()
        {
            var singleUserData = JsonConvert.DeserializeObject<UsersList>(_restResponse.Content);

            foreach (var item in singleUserData.Items)
            {
                log.Info($"Id: {item.Id}");
                log.Info($"Email: {item.Email}");
                log.Info($"First Name: {item.FirstName}");
                log.Info($"Last Name: {item.LastName}");
                log.Info($"Avatar: {item.Avatar}");
            }
        }

        [When(@"User sends the (POST|) request to users page to create a user with data in the request body")]
        public void WhenUserSendsThePOSTRequestToUsersPageToCreateAUserWithDataInTheRequestBody(Method restMethod, Table table)
        {
            _restClient = new RestClient(RouteConstants.UserOperationEndpoint);

            var createUserData = table.CreateInstance<CreateUser>();
            var postRequestCreateUser = new RestRequest(restMethod.ToString())
            .AddJsonBody(createUserData);
            _restResponse = _restClient.Execute(postRequestCreateUser);

            _scenarioContext.Add(StatusCodesContainer.StatusCode, _restResponse.StatusCode.ToString());
            _scenarioContext["CreateUserData"] = createUserData;

        }

        [Then(@"the created user data is returned")]
        public void ThenTheCreatedUserDataIsReturned()
        {
            CreateUser postJsonResponse = JsonConvert.DeserializeObject<CreateUser>(_restResponse.Content);

            log.Info($"Name: {postJsonResponse.Name}");
            log.Info($"Job: {postJsonResponse.Job}");
            log.Info($"ID: {postJsonResponse.Id}");
            log.Info($"CreatedAt: {postJsonResponse.CreatedAt}");
        }

        [When(@"User sends the (PUT|PATCH|) request to users page (.*) to update a user with data in the request body")]
        public void WhenUserSendsThePUTRequestToUpdateAUserWithDataInTheRequestBody(Method restMethod, Table table, int pageNumber)
        {
            _restClient = new RestClient(new Uri(RouteConstants.UserOperationEndpoint, $"{pageNumber}"));

            var updateUser = table.CreateInstance<UpdateUser>();
            var postRequestUpdateUser = new RestRequest(restMethod.ToString())
                .AddJsonBody(updateUser);
            _restResponse = _restClient.Execute(postRequestUpdateUser);
        }

        [Then(@"the updated user data is returned")]
        public void ThenTheUpdatedUserDataIsReturned()
        {
            UpdateUser updateJsonResponse = JsonConvert.DeserializeObject<UpdateUser>(_restResponse.Content);

            log.Info($"Name: {updateJsonResponse.Name}");
            log.Info($"Job: {updateJsonResponse.Job}");
            log.Info($"Updated at: {updateJsonResponse.UpdatedAt}");
        }

        [When(@"User sends the (DELETE|) request to user page (.*) to delete a user")]
        public void WhenUserSendsTheDELETERequestToDeleteAUser(int pageNumber, Method restMethod)
        {
            _restClient = new RestClient(new Uri(RouteConstants.UserOperationEndpoint, $"{pageNumber}"));
            var requestDeleteUser = new RestRequest(restMethod.ToString());
            _restResponse = _restClient.Execute(requestDeleteUser);
        }

        [When(@"User sends the (POST|) request to register successfully with data in the request body")]
        public void WhenUserSendsThePOSTRequestToRegisterSuccessfullyWithDataInTheRequestBody(Method restMethod, Table table)
        {
            _restClient = new RestClient(RouteConstants.RegisterEndpoint);
            var registerData = table.CreateInstance<RegisterData>();
            var postRequestSuccessfulRegister = new RestRequest(restMethod.ToString())
              .AddJsonBody(registerData);
            _restResponse = _restClient.Execute(postRequestSuccessfulRegister);
        }

        [Then(@"the id and token are received")]
        public void ThenTheIdAndTokenAreReceived()
        {
            RegisterData postJsonResponse = JsonConvert.DeserializeObject<RegisterData>(_restResponse.Content);

            log.Info($"Id: {postJsonResponse.Id}");
            log.Info($"Token: {postJsonResponse.Token}");
        }

        [When(@"User sends the (POST|) request to login unsuccessfully with data in the request body")]
        public void WhenUserSendsThePOSTRequestToLoginUnsuccessfullyWithDataInTheRequestBody(Method restMethod, Table table)
        {
            _restClient = new RestClient(RouteConstants.LoginEndpoint);
            var loginData = table.CreateInstance<LoginData>();
            var postRequestUnsuccessfulLogin = new RestRequest(restMethod.ToString())
            .AddJsonBody(loginData);
            _restResponse = _restClient.Execute(postRequestUnsuccessfulLogin);
        }

        [Then(@"the error is returned")]
        public void ThenTheErrorIsReturned()
        {
            UnsuccessfulLogin postJsonResponseUnsuccessfulLogin = JsonConvert.DeserializeObject<UnsuccessfulLogin>(_restResponse.Content);

            log.Info($"Error: {postJsonResponseUnsuccessfulLogin.Error}");
        }

        [When(@"User sends the (GET|) request to page (.*) for the delayed response")]
        public void WhenUserSendsTheGETRequestForTheDelayedResponse(int pageNumber, Method restMethod)
        {
            _restClient = new RestClient(new Uri(RouteConstants.UserOperationEndpoint, $"?delay={pageNumber}"));
            var postRequestDelayed = new RestRequest(restMethod.ToString());

            _restResponse = _restClient.Execute(postRequestDelayed);
        }

        [Then(@"the users list is returned")]
        public void ThenTheUsersListIsReturned()
        {
            var usersList = JsonConvert.DeserializeObject<UsersList>(_restResponse.Content);

            foreach (var item in usersList.Items)
            {
                log.Info($"Id: {item.Id}");
                log.Info($"Email: {item.Email}");
                log.Info($"First Name: {item.FirstName}");
                log.Info($"Last Name: {item.LastName}");
                log.Info($"Avatar: {item.Avatar}");
            }
        }

    }

}