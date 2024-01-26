using Inna_RestSharp.Constants;
using RestSharp;
using System.Net;
using TechTalk.SpecFlow.Infrastructure;

namespace Inna_RestSharp.Steps
{
    public class CommonSteps
    {
        protected readonly ScenarioContext ScenarioContext;
        protected readonly ISpecFlowOutputHelper OutputHelper;

        public CommonSteps(ScenarioContext scenarioContext, ISpecFlowOutputHelper outputHelper)
        {
            ScenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
            OutputHelper = outputHelper ?? throw new ArgumentNullException(nameof(outputHelper));
        }

        [Then(@"the ""([^""]*)"" status code is received")]
        public void ThenTheStatusCodeIsReceived(HttpStatusCode expectedStatusCode)
        {
            var response = ScenarioContext.Get<RestResponse>(ContextConstants.Response);

            HttpStatusCode actualStatusCode = response.StatusCode;

            actualStatusCode.Should().Be(expectedStatusCode);
        }
    }
}