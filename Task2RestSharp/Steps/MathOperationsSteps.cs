using RestSharp;
using Task2RestSharp.Constants;
using TechTalk.SpecFlow.Infrastructure;

namespace Task2RestSharp.Steps
{
    [Binding]
    public class MathOperationsSteps : CommonSteps
    {
        private RestClient _restClient;
        private RestResponse _restResponse;
        private readonly ScenarioContext _scenarioContext;
        private const string baseUrl = "http://api.mathjs.org/v4";

        public MathOperationsSteps(ISpecFlowOutputHelper outputHelper, ScenarioContext scenarioContext) : base(outputHelper)
        {
            _scenarioContext = scenarioContext ?? throw new ArgumentNullException(nameof(scenarioContext));
            _restClient = new RestClient(new Uri(baseUrl));
        }

        [When(@"the user adds (.*) and (.*) by (POST|) request")]
        public void WhenTheUserAddsAnd(double summand1, double summand2, Method method)
        {
            var additionRequest = new RestRequest(RouteConstants.ExprEndpoint, method);
            additionRequest.AddHeader("content-type", "application/json");
            additionRequest.AddHeader("User-Agent", "Learning RestSharp");

            var requestBody = new
            {
                expr = $"({summand1})+({summand2})"
            };

            additionRequest.AddJsonBody(requestBody);

            var response = _restClient.Execute(additionRequest);

            _scenarioContext.Add(ContextConstants.Response, response);
        }

        [When(@"the user substracts (.*) from (.*) by (POST|) request")]
        public void WhenTheUserSubstractsFrom(double minuend, double subtrahend, Method method)
        {
            var substractionRequest = new RestRequest(RouteConstants.ExprEndpoint, method);
            substractionRequest.AddHeader("content-type", "application/json");
            substractionRequest.AddHeader("User-Agent", "Learning RestSharp");

            var requestBody = new
            {
                expr = $"({subtrahend})-({minuend})"
            };

            substractionRequest.AddJsonBody(requestBody);

            var response = _restClient.Execute(substractionRequest);

            _scenarioContext.Add(ContextConstants.Response, response);
        }

        [When(@"the user multiplies (.*) and (.*) by (POST|) request")]
        public void WhenTheUserMultipliesAnd(double multiplier, double multiplicand, Method method)
        {
            var multiplicationRequest = new RestRequest(RouteConstants.ExprEndpoint, method);
            multiplicationRequest.AddHeader("content-type", "application/json");
            multiplicationRequest.AddHeader("User-Agent", "Learning RestSharp");

            var requestBody = new
            {
                expr = $"({multiplier})*({multiplicand})"
            };

            multiplicationRequest.AddJsonBody(requestBody);

            var response = _restClient.Execute(multiplicationRequest);

            _scenarioContext.Add(ContextConstants.Response, response);
        }

        [When(@"the user divides (.*) on (.*) by (POST|) request")]
        public void WhenTheUserDividesOn(double dividend, double divisor, Method method)
        {
            var divisionRequest = new RestRequest(RouteConstants.ExprEndpoint, method);
            divisionRequest.AddHeader("content-type", "application/json");
            divisionRequest.AddHeader("User-Agent", "Learning RestSharp");

            var requestBody = new
            {
                expr = $"({dividend})/({divisor})"
            };

            divisionRequest.AddJsonBody(requestBody);

            var response = _restClient.Execute(divisionRequest);

            _scenarioContext.Add(ContextConstants.Response, response);
        }

        [When(@"the user enters (.*) to find square root by (GET|) request")]
        public void WhenTheUserEntersToFindSquareRoot(double numberForSqrt, Method method)
        {
            var findSquareRootRequest = new RestRequest($"{RouteConstants.ExprEndpoint}{numberForSqrt}%5E%28%28%31%29%2F%28%32%29%29", method); // implemented expression ^((1)/(2))
           
            findSquareRootRequest.AddHeader("User-Agent", "Learning RestSharp");

            var response = _restClient.Execute(findSquareRootRequest);

            _scenarioContext.Add(ContextConstants.Response, response);
        }
    }
}