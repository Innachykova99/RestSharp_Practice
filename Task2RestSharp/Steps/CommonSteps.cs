using Newtonsoft.Json;
using RestSharp;
using System.Net;
using Task2RestSharp.Constants;
using Task2RestSharp.Models;
using TechTalk.SpecFlow.Infrastructure;

namespace Task2RestSharp.Steps
{
    [Binding]
    public class CommonSteps : BaseSteps
    {
        protected readonly ISpecFlowOutputHelper OutputHelper;
        protected readonly ScenarioContext scenarioContext;

        public CommonSteps(ISpecFlowOutputHelper outputHelper, ScenarioContext scenarioContext) : base(outputHelper, scenarioContext)
        {
            OutputHelper = outputHelper ?? throw new ArgumentNullException(nameof(outputHelper));
            scenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
        }
            
        [Then(@"the ""([^""]*)"" status code is received")]
        public void ThenTheStatusCodeIsReceived(HttpStatusCode expectedStatusCode)
        {
            var response = ScenarioContext.Get<RestResponse>(ContextConstants.Response);

            HttpStatusCode actualStatusCode = response.StatusCode;

            OutputHelper.WriteLine($"Actual status code: {actualStatusCode}");
            OutputHelper.WriteLine($"Expected status code: {expectedStatusCode}");

            actualStatusCode.Should().Be(expectedStatusCode);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(string mathOperationResult)
        {
            var responseBody = ScenarioContext.Get<RestResponse>(ContextConstants.Response).Content;
            var actualResult = JsonConvert.DeserializeObject<MathOperationResult>(responseBody);

            actualResult.Result.Should().BeEquivalentTo(mathOperationResult);
        }
    }
}