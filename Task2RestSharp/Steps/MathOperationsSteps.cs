using Newtonsoft.Json;
using RestSharp;
using System.Net;
using Task2RestSharp.Constants;
using Task2RestSharp.Models;
using TechTalk.SpecFlow.Infrastructure;

namespace Task2RestSharp.Steps
{
    [Binding]
    public class MathOperationsSteps : BaseSteps
    {
        private RestClient _restClient;
        private const string baseUrl = "http://api.mathjs.org/v4";

        public MathOperationsSteps(ISpecFlowOutputHelper outputHelper, ScenarioContext scenarioContext) : base(outputHelper, scenarioContext)
        {
            _restClient = new RestClient(new Uri(baseUrl));
            _restClient.AddDefaultHeader("User-Agent", "Learning RestSharp");
        }

        [When(@"the user adds (.*) and (.*) by (POST|) request")]
        public void WhenTheUserAddsAnd(double summand1, double summand2, Method method)
        {
            var additionRequest = new RestRequest(RouteConstants.ExprEndpoint, method);

            var requestBody = new
            {
                expr = $"({summand1})+({summand2})"
            };

            additionRequest.AddJsonBody(requestBody);

            var response = _restClient.Execute(additionRequest);

            ScenarioContext.Add(ContextConstants.Response, response);
        }

        [When(@"the user substracts (.*) from (.*) by (POST|) request")]
        public void WhenTheUserSubstractsFrom(double minuend, double subtrahend, Method method)
        {
            var substractionRequest = new RestRequest(RouteConstants.ExprEndpoint, method);

            var requestBody = new
            {
                expr = $"({subtrahend})-({minuend})"
            };

            substractionRequest.AddJsonBody(requestBody);

            var response = _restClient.Execute(substractionRequest);

            ScenarioContext.Add(ContextConstants.Response, response);
        }

        [When(@"the user multiplies (.*) and (.*) by (POST|) request")]
        public void WhenTheUserMultipliesAnd(double multiplier, double multiplicand, Method method)
        {
            var multiplicationRequest = new RestRequest(RouteConstants.ExprEndpoint, method);

            var requestBody = new
            {
                expr = $"({multiplier})*({multiplicand})"
            };

            multiplicationRequest.AddJsonBody(requestBody);

            var response = _restClient.Execute(multiplicationRequest);

            ScenarioContext.Add(ContextConstants.Response, response);
        }

        [When(@"the user divides (.*) on (.*) by (POST|) request")]
        public void WhenTheUserDividesOn(double dividend, double divisor, Method method)
        {
            var divisionRequest = new RestRequest(RouteConstants.ExprEndpoint, method);

            var requestBody = new
            {
                expr = $"({dividend})/({divisor})"
            };

            divisionRequest.AddJsonBody(requestBody);

            var response = _restClient.Execute(divisionRequest);

            ScenarioContext.Add(ContextConstants.Response, response);
        }

        [When(@"the user enters (.*) to find square root by (GET|) request")]
        public void WhenTheUserEntersToFindSquareRoot(double numberForSqrt, Method method)
        {
            var findSquareRootRequest = new RestRequest($"{RouteConstants.ExprEndpoint}sqrt({numberForSqrt})", method);
            var response = _restClient.Execute(findSquareRootRequest);

            ScenarioContext.Add(ContextConstants.Response, response);
        }

        [When(@"the user performs math operation for two numbers: (.*) and (.*) by (POST|) request")]
        public void WhenTheUserPerformsForTwoNumbersAndByPOSTRequest(int p1, int p2, Method method)
        {
            var generalRequest = new RestRequest(RouteConstants.ExprEndpoint, method);

            var expressions = new[]
            {
            $"({p1})+({p2})",

            $"({p1})-({p2})",

            $"({p1})*({p2})",

            $"({p1})/({p2})"

            };

            var requestBody = new
            {
                expr = expressions,
                precision = 10
            };

            generalRequest.AddJsonBody(requestBody);
            var response = _restClient.Execute(generalRequest);

            ScenarioContext.Add(ContextConstants.Response, response);
        }
    }
}