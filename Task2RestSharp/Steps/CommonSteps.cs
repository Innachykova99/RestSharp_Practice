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
        public CommonSteps(ISpecFlowOutputHelper outputHelper, ScenarioContext scenarioContext) : base(outputHelper, scenarioContext)
        {

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

        [Then(@"the received result should be (.*)")]
        public void ThenTheReceivedResultShouldBe(string sqrtResult)
        {
            var responseBody = ScenarioContext.Get<RestResponse>(ContextConstants.Response).Content;
            var actualResult = responseBody;

            actualResult.Should().BeEquivalentTo(sqrtResult);
        }

        [Then(@"the received result should contain the following results:")]
        public void ThenTheReceivedResultShouldContaintheFollowingResults(Table table)
        {
            var expectedResults = table.Rows.Select(row => row["Result"]).ToList();
            var response = ScenarioContext.Get<RestResponse>(ContextConstants.Response);

            var responseBody = response.Content;

            var actualResult = JsonConvert.DeserializeObject<MathOperationResults>(responseBody);
            var actualResults = actualResult.Results.Select(value => value.ToString()).ToList();

            actualResults.Should().BeEquivalentTo(expectedResults);
        }
    }
}