using Inna_RestSharp.Constants;
using Inna_RestSharp.Models;
using Newtonsoft.Json;
using RestSharp;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.Infrastructure;

namespace Inna_RestSharp.Steps
{
    [Binding]
    public class ActionsWithUsersAPISteps : CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly RestClient _restClient;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
        private const string baseUrl = "https://reqres.in";

        public ActionsWithUsersAPISteps(ScenarioContext scenarioContext, ISpecFlowOutputHelper outputHelper) : base(scenarioContext, outputHelper)
        {
            _scenarioContext = scenarioContext ?? throw new ArgumentException(nameof(scenarioContext));
            _specFlowOutputHelper = outputHelper ?? throw new ArgumentNullException(nameof(outputHelper));
            _restClient = new RestClient(new Uri(baseUrl));
        }

        [When(@"the user sends the (GET|) request to page (.*) of users list")]
        public void WhenTheUserSendsTheRequestToGetPageOfUsersList(Method method, int pageNumber)
        {
            var getRequestListOfUsers = new RestRequest($"{RouteConstants.UserOperationEndpoint}?page={pageNumber}", method);
            var response = _restClient.Execute(getRequestListOfUsers);

            _scenarioContext.Add(ContextConstants.Response, response);
        }

        [When(@"User sends the (GET|) request to page (.*) for the not found single user")]
        public void WhenUserSendsTheGETRequestToPageForTheNotFoundSingleUser(Method method, int pageNumber)
        {
            var getRequestToNotFoundUser = new RestRequest($"{RouteConstants.UserOperationEndpoint}{pageNumber}", method);
            var response = _restClient.Execute(getRequestToNotFoundUser);

            _scenarioContext.Add(ContextConstants.Response, response);
        }

        [When(@"User sends the (GET|) request to the single user for the page (.*)")]
        public void WhenUserSendsTheGETRequestToTheSingleUserForThePage(Method method, int pageNumber)
        {
            var getRequestToSingleUser = new RestRequest($"{RouteConstants.UserOperationEndpoint}{pageNumber}", method);
            var response = _restClient.Execute(getRequestToSingleUser);

            _scenarioContext.Add(ContextConstants.Response, response);
        }

        [When(@"User sends the (POST|) request to users page to create a user with data in the request body")]
        public void WhenUserSendsThePOSTRequestToUsersPageToCreateAUserWithDataInTheRequestBody(Method method, Table table)
        {
            var createUserData = table.CreateInstance<CreateUser>();
            var postRequestCreateUser = new RestRequest(RouteConstants.UserOperationEndpoint, method)
                .AddJsonBody(createUserData);
            var response = _restClient.Execute(postRequestCreateUser);

            _scenarioContext.Add(ContextConstants.Response, response);
            _scenarioContext["CreateUserData"] = createUserData;
        }

        [When(@"User sends the (PUT|PATCH|) request to users page (.*) to update a user with data in the request body")]
        public void WhenUserSendsThePUTRequestToUpdateAUserWithDataInTheRequestBody(Method method, int pageNumber, Table table)
        {
            var updateUser = table.CreateInstance<UpdateUser>();
            var requestToUpdateUser = new RestRequest($"{RouteConstants.UserOperationEndpoint}?page={pageNumber}", method)
               .AddJsonBody(updateUser);
            var response = _restClient.Execute(requestToUpdateUser);

            _scenarioContext.Add(ContextConstants.Response, response);
        }

        [When(@"User sends the (DELETE|) request to user page (.*) to delete a user")]
        public void WhenUserSendsTheDELETERequestToDeleteAUser(Method method, int pageNumber)
        {
            var requestDeleteUser = new RestRequest($"{RouteConstants.UserOperationEndpoint}?page={pageNumber}", method);
            var response = _restClient.Execute(requestDeleteUser);

            _scenarioContext.Add(ContextConstants.Response, response);
        }

        [When(@"User sends the (POST|) request to register successfully with data in the request body")]
        public void WhenUserSendsThePOSTRequestToRegisterSuccessfullyWithDataInTheRequestBody(Method method, Table table)
        {
            var registerData = table.CreateInstance<RegisterData>();

            var postRequestSuccessfulRegister = new RestRequest(RouteConstants.RegisterEndpoint, method)
              .AddJsonBody(registerData);
            var response = _restClient.Execute(postRequestSuccessfulRegister);

            _scenarioContext.Add(ContextConstants.Response, response);
        }

        [When(@"User sends the (POST|) request to login unsuccessfully with data in the request body")]
        public void WhenUserSendsThePOSTRequestToLoginUnsuccessfullyWithDataInTheRequestBody(Method method, Table table)
        {
            var loginData = table.CreateInstance<LoginData>();

            var postRequestUnsuccessfulLogin = new RestRequest(RouteConstants.LoginEndpoint, method)
            .AddJsonBody(loginData);
            var response = _restClient.Execute(postRequestUnsuccessfulLogin);

            _scenarioContext.Add(ContextConstants.Response, response);
        }

        [When(@"User sends the (GET|) request to page (.*) for the delayed response")]
        public void WhenUserSendsTheGETRequestForTheDelayedResponse(Method method, int pageNumber)
        {
            var postRequestDelayed = new RestRequest($"{RouteConstants.UserOperationEndpoint}?delay ={pageNumber}", method);

            var response = _restClient.Execute(postRequestDelayed);

            _scenarioContext.Add(ContextConstants.Response, response);
        }
        
        [Then(@"the list of users is returned")]
        public void ThenTheListOfUsersIsDisplayed(Table expectedTableData)
        {
            var expectedData = expectedTableData.CreateSet<UserInformation>();
            var responseBody = _scenarioContext.Get<RestResponse>(ContextConstants.Response).Content;
            var usersList = JsonConvert.DeserializeObject<UsersList>(responseBody);

            usersList.Items.Should().BeEquivalentTo(expectedData);

            foreach (var expectedUser in expectedData)
            {
                _specFlowOutputHelper.WriteLine($"Id: {expectedUser.Id}");
                _specFlowOutputHelper.WriteLine($"Email: {expectedUser.Email}");
                _specFlowOutputHelper.WriteLine($"First Name: {expectedUser.FirstName}");
                _specFlowOutputHelper.WriteLine($"Last Name: {expectedUser.LastName}");
                _specFlowOutputHelper.WriteLine($"Avatar: {expectedUser.Avatar}");
            }
                _specFlowOutputHelper.WriteLine("------------------------------------------");
        }

        [Then(@"the user data is returned")]
        public void ThenTheUserDataIsReturned(Table expectedTableData)
        {
            var expectedData = expectedTableData.CreateInstance<UserInformation>();
            var responseBody = _scenarioContext.Get<RestResponse>(ContextConstants.Response).Content;
            var singleUserData = JsonConvert.DeserializeObject<SingleUserData>(responseBody); 

            singleUserData.Data.Should().BeEquivalentTo(expectedData);

            _specFlowOutputHelper.WriteLine($"Id: {singleUserData.Data.Id}");
            _specFlowOutputHelper.WriteLine($"Email: {singleUserData.Data.Email}");
            _specFlowOutputHelper.WriteLine($"First Name: {singleUserData.Data.FirstName}");
            _specFlowOutputHelper.WriteLine($"Last Name: {singleUserData.Data.LastName}");
            _specFlowOutputHelper.WriteLine($"Avatar: {singleUserData.Data.Avatar}");

            _specFlowOutputHelper.WriteLine("------------------------------------------");
        }

        [Then(@"the created user data is returned")]
        public void ThenTheCreatedUserDataIsReturned(Table expectedTableData)
        {
            var expectedData = expectedTableData.CreateInstance<CreateUser>();
            var responseBody = _scenarioContext.Get<RestResponse>(ContextConstants.Response).Content;

            var createdUserData = JsonConvert.DeserializeObject<CreateUser>(responseBody);

            createdUserData.Name.Should().Be(expectedData.Name);
            createdUserData.Job.Should().BeEquivalentTo(expectedData.Job);
            int.TryParse(createdUserData.Id, out _).Should().BeTrue();
            createdUserData.CreatedAt.Should().BeBefore(DateTime.Now);

            _specFlowOutputHelper.WriteLine($"Name: {createdUserData.Name}");
            _specFlowOutputHelper.WriteLine($"Job: {createdUserData.Job}");
            _specFlowOutputHelper.WriteLine($"ID: {createdUserData.Id}");
            _specFlowOutputHelper.WriteLine($"CreatedAt: {createdUserData.CreatedAt}");

            _specFlowOutputHelper.WriteLine("------------------------------------------");
        }

        [Then(@"the updated user data is returned")]
        public void ThenTheUpdatedUserDataIsReturned(Table expectedTableData)
        {
            var expectedData = expectedTableData.CreateInstance<UpdateUser>();
            var responseBody = _scenarioContext.Get<RestResponse>(ContextConstants.Response).Content;
            
            var updatedUserData = JsonConvert.DeserializeObject<UpdateUser>(responseBody);

            updatedUserData.Name.Should().Be(expectedData.Name);
            updatedUserData.Job.Should().Be(expectedData.Job);
            updatedUserData.UpdatedAt.Should().BeBefore(DateTime.Now);

            _specFlowOutputHelper.WriteLine($"Name: {updatedUserData.Name}");
            _specFlowOutputHelper.WriteLine($"Job: {updatedUserData.Job}");
            _specFlowOutputHelper.WriteLine($"Updated at: {updatedUserData.UpdatedAt}");

            _specFlowOutputHelper.WriteLine("------------------------------------------");
        }

        [Then(@"the id and token are received")]
        public void ThenTheIdAndTokenAreReceived()
        {
            var responseBody = _scenarioContext.Get<RestResponse>(ContextConstants.Response).Content;
            RegisterData postJsonResponse = JsonConvert.DeserializeObject<RegisterData>(responseBody);

            postJsonResponse.Should().NotBeNull();

            _specFlowOutputHelper.WriteLine($"Id: {postJsonResponse.Id}");
            _specFlowOutputHelper.WriteLine($"Token: {postJsonResponse.Token}");
            _specFlowOutputHelper.WriteLine("------------------------------------------");
        }

        [Then(@"the error ""(.*)"" is returned")]
        public void ThenTheErrorIsReturned(string expectedErrorMessage)
        {
            var responseBody = _scenarioContext.Get<RestResponse>(ContextConstants.Response).Content;
            UnsuccessfulLogin errorMessageUnsuccessfulLogin = JsonConvert.DeserializeObject<UnsuccessfulLogin>(responseBody);

            errorMessageUnsuccessfulLogin.Error.Should().Be(expectedErrorMessage);

            _specFlowOutputHelper.WriteLine($"Error: {errorMessageUnsuccessfulLogin.Error}");
            _specFlowOutputHelper.WriteLine("------------------------------------------");
        }

        [Then(@"the users list is returned")]
        public void ThenTheUsersListIsReturned(Table expectedTableData)
        {
            var expectedData = expectedTableData.CreateSet<UserInformation>();
            var responseBody = _scenarioContext.Get<RestResponse>(ContextConstants.Response).Content;
            var usersList = JsonConvert.DeserializeObject<UsersList>(responseBody);
            usersList.Items.Should().BeEquivalentTo(expectedData);

            foreach (var item in usersList.Items)
            {
                _specFlowOutputHelper.WriteLine($"Id: {item.Id}");
                _specFlowOutputHelper.WriteLine($"Email: {item.Email}");
                _specFlowOutputHelper.WriteLine($"First Name: {item.FirstName}");
                _specFlowOutputHelper.WriteLine($"Last Name: {item.LastName}");
                _specFlowOutputHelper.WriteLine($"Avatar: {item.Avatar}");
            }
            _specFlowOutputHelper.WriteLine("------------------------------------------");
        }
    }
}