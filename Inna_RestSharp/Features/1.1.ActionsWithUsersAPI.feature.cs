﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Inna_RestSharp.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("API Actions with Users")]
    [NUnit.Framework.CategoryAttribute("Feature_1.1")]
    public partial class APIActionsWithUsersFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "Feature_1.1"};
        
#line 1 "1.1.ActionsWithUsersAPI.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "API Actions with Users", null, ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 4
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("When a user sends request to the list of users, then the OK status code should be" +
            " received and the list of users will be returned")]
        [NUnit.Framework.CategoryAttribute("Scenario_1.1.1.")]
        public void WhenAUserSendsRequestToTheListOfUsersThenTheOKStatusCodeShouldBeReceivedAndTheListOfUsersWillBeReturned()
        {
            string[] tagsOfScenario = new string[] {
                    "Scenario_1.1.1."};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When a user sends request to the list of users, then the OK status code should be" +
                    " received and the list of users will be returned", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 7
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
this.FeatureBackground();
#line hidden
#line 8
testRunner.Given("the Endpoint is \"/api/users?page=2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 9
testRunner.When("User sends the GET request to the list of users", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 10
testRunner.Then("the \"200\" status code is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 11
 testRunner.And("the list of users is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("When a user sends request to a not found single user, then the Not Found status c" +
            "ode should be received")]
        [NUnit.Framework.CategoryAttribute("Scenario_1.1.2")]
        public void WhenAUserSendsRequestToANotFoundSingleUserThenTheNotFoundStatusCodeShouldBeReceived()
        {
            string[] tagsOfScenario = new string[] {
                    "Scenario_1.1.2"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When a user sends request to a not found single user, then the Not Found status c" +
                    "ode should be received", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 14
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
this.FeatureBackground();
#line hidden
#line 15
testRunner.Given("the Endpoint is \"/api/users/23\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 16
testRunner.When("User sends the GET request to the not found single user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 17
testRunner.Then("the \"404\" status code is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("When a user sends request to a single user, then the OK status code should be rec" +
            "eived and the user data will be returned")]
        [NUnit.Framework.CategoryAttribute("Scenario_1.1.3")]
        public void WhenAUserSendsRequestToASingleUserThenTheOKStatusCodeShouldBeReceivedAndTheUserDataWillBeReturned()
        {
            string[] tagsOfScenario = new string[] {
                    "Scenario_1.1.3"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When a user sends request to a single user, then the OK status code should be rec" +
                    "eived and the user data will be returned", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 20
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
this.FeatureBackground();
#line hidden
#line 21
testRunner.Given("the Endpoint is \"/api/users/2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 22
testRunner.When("User sends the GET request to the single user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 23
testRunner.Then("the \"200\" status code is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 24
 testRunner.And("the user data is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("When a user sends request to create a user, then the Created status code should b" +
            "e received and the created user data will be returned")]
        [NUnit.Framework.CategoryAttribute("Scenario_1.1.4")]
        public void WhenAUserSendsRequestToCreateAUserThenTheCreatedStatusCodeShouldBeReceivedAndTheCreatedUserDataWillBeReturned()
        {
            string[] tagsOfScenario = new string[] {
                    "Scenario_1.1.4"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When a user sends request to create a user, then the Created status code should b" +
                    "e received and the created user data will be returned", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 27
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
this.FeatureBackground();
#line hidden
#line 28
testRunner.Given("the Endpoint is \"/api/users\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "morpheus"});
                table1.AddRow(new string[] {
                            "Job",
                            "leader"});
#line 29
testRunner.When("User sends the POST request to create a user with data in the request body", ((string)(null)), table1, "When ");
#line hidden
#line 32
testRunner.Then("the \"201\" status code is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 33
 testRunner.And("the updated user data is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("When a user sends request to update a user, then the the OK status code should be" +
            " received and the updated user data is returned")]
        [NUnit.Framework.CategoryAttribute("Scenario_1.1.5")]
        public void WhenAUserSendsRequestToUpdateAUserThenTheTheOKStatusCodeShouldBeReceivedAndTheUpdatedUserDataIsReturned()
        {
            string[] tagsOfScenario = new string[] {
                    "Scenario_1.1.5"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When a user sends request to update a user, then the the OK status code should be" +
                    " received and the updated user data is returned", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 36
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
this.FeatureBackground();
#line hidden
#line 37
testRunner.Given("the Endpoint is \"/api/users/2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "morpheus"});
                table2.AddRow(new string[] {
                            "Job",
                            "zion resident"});
#line 38
testRunner.When("User sends the PUT request to update a user with data in the request body", ((string)(null)), table2, "When ");
#line hidden
#line 41
testRunner.Then("the \"200\" status code is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 42
 testRunner.And("the updated user data is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("When a user sends a request to update user fields, then the the OK status code sh" +
            "ould be received and the updated user data is returned")]
        [NUnit.Framework.CategoryAttribute("Scenario_1.1.6")]
        public void WhenAUserSendsARequestToUpdateUserFieldsThenTheTheOKStatusCodeShouldBeReceivedAndTheUpdatedUserDataIsReturned()
        {
            string[] tagsOfScenario = new string[] {
                    "Scenario_1.1.6"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When a user sends a request to update user fields, then the the OK status code sh" +
                    "ould be received and the updated user data is returned", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 45
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
this.FeatureBackground();
#line hidden
#line 46
testRunner.Given("the Endpoint is \"/api/users/2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "morpheus"});
                table3.AddRow(new string[] {
                            "Job",
                            "zion resident"});
#line 47
testRunner.When("User sends the PATCH request to update a user with data in the request body", ((string)(null)), table3, "When ");
#line hidden
#line 50
testRunner.Then("the \"200\" status code is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 51
 testRunner.And("the updated user data is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("When a user sends a request to delete a user, then the No Content status code sho" +
            "uld be received")]
        [NUnit.Framework.CategoryAttribute("Scenario_1.1.7")]
        public void WhenAUserSendsARequestToDeleteAUserThenTheNoContentStatusCodeShouldBeReceived()
        {
            string[] tagsOfScenario = new string[] {
                    "Scenario_1.1.7"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When a user sends a request to delete a user, then the No Content status code sho" +
                    "uld be received", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 54
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
this.FeatureBackground();
#line hidden
#line 55
testRunner.Given("the Endpoint is \"/api/users/2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 56
testRunner.When("User sends the DELETE request to delete a user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 57
testRunner.Then("the \"204\" status code is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("When a user sends a request for successful register, then the OK status code shou" +
            "ld be received")]
        [NUnit.Framework.CategoryAttribute("Scenario_1.1.8")]
        public void WhenAUserSendsARequestForSuccessfulRegisterThenTheOKStatusCodeShouldBeReceived()
        {
            string[] tagsOfScenario = new string[] {
                    "Scenario_1.1.8"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When a user sends a request for successful register, then the OK status code shou" +
                    "ld be received", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 60
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
this.FeatureBackground();
#line hidden
#line 61
testRunner.Given("the Endpoint is \"/api/register\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "eve.holt@reqres.in"});
                table4.AddRow(new string[] {
                            "Password",
                            "pistol"});
#line 62
testRunner.When("User sends the POST request to register successfully with data in the request bod" +
                        "y", ((string)(null)), table4, "When ");
#line hidden
#line 65
testRunner.Then("the \"200\" status code is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 66
 testRunner.And("the id and token are received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("When user sends a request for unsuccessful login, then the Bad Request status cod" +
            "e should be received and the error should be returned")]
        [NUnit.Framework.CategoryAttribute("Scenario_1.1.9")]
        public void WhenUserSendsARequestForUnsuccessfulLoginThenTheBadRequestStatusCodeShouldBeReceivedAndTheErrorShouldBeReturned()
        {
            string[] tagsOfScenario = new string[] {
                    "Scenario_1.1.9"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When user sends a request for unsuccessful login, then the Bad Request status cod" +
                    "e should be received and the error should be returned", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 69
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
this.FeatureBackground();
#line hidden
#line 70
testRunner.Given("the Endpoint is \"/api/login\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "Email",
                            "peter@klaven"});
#line 71
testRunner.When("User sends the POST request to login unsuccessfully with data in the request body" +
                        "", ((string)(null)), table5, "When ");
#line hidden
#line 73
testRunner.Then("the \"400\" status code is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 74
 testRunner.And("the error \"Missing password\" is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("When user sends a request for the delayed response, then the OK status code shoul" +
            "d be received and users list should be returned")]
        [NUnit.Framework.CategoryAttribute("Scenario_1.1.10")]
        [NUnit.Framework.TestCaseAttribute("GET", "/api/users?page=2", "200", null)]
        [NUnit.Framework.TestCaseAttribute("GET", "/api/users/23", "404", null)]
        [NUnit.Framework.TestCaseAttribute("GET", "/api/users/2", "200", null)]
        [NUnit.Framework.TestCaseAttribute("POST", "/api/users", "201", null)]
        [NUnit.Framework.TestCaseAttribute("PUT", "/api/users/2", "200", null)]
        [NUnit.Framework.TestCaseAttribute("PATCH", "/api/users/2", "200", null)]
        [NUnit.Framework.TestCaseAttribute("DELETE", "/api/users/2", "204", null)]
        [NUnit.Framework.TestCaseAttribute("POST", "/api/register", "200", null)]
        [NUnit.Framework.TestCaseAttribute("POST", "/api/login", "400", null)]
        [NUnit.Framework.TestCaseAttribute("GET", "/api/users?delay=3", "200", null)]
        public void WhenUserSendsARequestForTheDelayedResponseThenTheOKStatusCodeShouldBeReceivedAndUsersListShouldBeReturned(string method, string endpoint, string statusCode, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "Scenario_1.1.10"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("Method", method);
            argumentsOfScenario.Add("Endpoint", endpoint);
            argumentsOfScenario.Add("StatusCode", statusCode);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When user sends a request for the delayed response, then the OK status code shoul" +
                    "d be received and users list should be returned", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 77
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
this.FeatureBackground();
#line hidden
#line 78
testRunner.Given("the Endpoint is \"/api/users?delay=3\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 79
testRunner.When("User sends the GET request for the delayed response", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 80
testRunner.Then("the \"200\" status code is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 81
 testRunner.And("the users list is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
