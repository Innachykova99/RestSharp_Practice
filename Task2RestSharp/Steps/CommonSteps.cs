using Newtonsoft.Json;
using RestSharp;
using System.Net;
using Task2RestSharp.Constants;
using Task2RestSharp.Models;
using TechTalk.SpecFlow.Infrastructure;

namespace Task2RestSharp.Steps
{
    [Binding]
    public class CommonSteps
    {
        protected readonly ISpecFlowOutputHelper OutputHelper;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;
        private readonly ScenarioContext _scenarioContext;

        public CommonSteps(ISpecFlowOutputHelper outputHelper)
        {
            OutputHelper = outputHelper ?? throw new ArgumentNullException(nameof(outputHelper));
        }

        [Then(@"the ""([^""]*)"" status code is received")]
        public void ThenTheStatusCodeIsReceived(HttpStatusCode expectedStatusCode)
        {
            var response = _scenarioContext.Get<RestResponse>(ContextConstants.Response);

            HttpStatusCode actualStatusCode = response.StatusCode;

            _specFlowOutputHelper.WriteLine($"Actual status code: {actualStatusCode}");
            _specFlowOutputHelper.WriteLine($"Expected status code: {expectedStatusCode}");

            actualStatusCode.Should().Be(expectedStatusCode);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(string mathOperationResult)
        {
            var responseBody = _scenarioContext.Get<RestResponse>(ContextConstants.Response).Content;
            var actualResult = JsonConvert.DeserializeObject<MathOperationResult>(responseBody);

            actualResult.Result.Should().BeEquivalentTo(mathOperationResult);
        }
    }
}
