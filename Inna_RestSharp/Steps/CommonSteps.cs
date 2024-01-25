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

    }
}
