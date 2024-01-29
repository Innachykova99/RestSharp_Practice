using TechTalk.SpecFlow.Infrastructure;

namespace Task2RestSharp.Steps
{
    public class BaseSteps
    {
        protected readonly ISpecFlowOutputHelper OutputHelper;
        protected readonly ScenarioContext ScenarioContext;

        public BaseSteps(ISpecFlowOutputHelper outputHelper, ScenarioContext scenarioContext)
        {
            OutputHelper = outputHelper ?? throw new ArgumentNullException(nameof(outputHelper));
            ScenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
        }
    }
}