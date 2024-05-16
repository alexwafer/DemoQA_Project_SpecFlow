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
namespace DemoQA_Project_SpecFlow.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("PracticeForm")]
    [NUnit.Framework.CategoryAttribute("RegressionSuite")]
    public partial class PracticeFormFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = new string[] {
                "RegressionSuite"};
        
#line 1 "PracticeFormFeature.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "PracticeForm", "// renuntat la astea lasat doar ultimul ", ProgrammingLanguage.CSharp, featureTags);
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
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Navigate to PracticeFormPage and fill the entire form with valid values")]
        [NUnit.Framework.CategoryAttribute("JIRA-123")]
        [NUnit.Framework.TestCaseAttribute("alex", "rosca", "alexrosca@yahoo.com", "1234567890", "str. calarasilor", null)]
        public void NavigateToPracticeFormPageAndFillTheEntireFormWithValidValues(string firstName, string lastName, string userEmail, string userNumber, string currentAddress, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "JIRA-123"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("FirstName", firstName);
            argumentsOfScenario.Add("LastName", lastName);
            argumentsOfScenario.Add("UserEmail", userEmail);
            argumentsOfScenario.Add("UserNumber", userNumber);
            argumentsOfScenario.Add("CurrentAddress", currentAddress);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to PracticeFormPage and fill the entire form with valid values", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
 testRunner.Given("Home page was displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 8
 testRunner.When("I click on Forms menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 9
 testRunner.And("I click on Practice Form subMenu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "UserEmail",
                            "UserNumber",
                            "CurrentAddress"});
                table3.AddRow(new string[] {
                            string.Format("{0}", firstName),
                            string.Format("{0}", lastName),
                            string.Format("{0}", userEmail),
                            string.Format("{0}", userNumber),
                            string.Format("{0}", currentAddress)});
#line 10
 testRunner.And("I fill the entire form with the following details", ((string)(null)), table3, "And ");
#line hidden
#line 13
 testRunner.When("I submit form from site", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "UserEmail",
                            "UserNumber",
                            "CurrentAddress"});
                table4.AddRow(new string[] {
                            string.Format("{0}", firstName),
                            string.Format("{0}", lastName),
                            string.Format("{0}", userEmail),
                            string.Format("{0}", userNumber),
                            string.Format("{0}", currentAddress)});
#line 14
 testRunner.Then("I validate all the entered fields from form page", ((string)(null)), table4, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Navigate to PracticeFormPage and fill the entire form with invalid values")]
        [NUnit.Framework.TestCaseAttribute("alex", "rosca", "delete", "1234567855", "str.Iorga", null)]
        [NUnit.Framework.TestCaseAttribute("alex", "dorha", "alexdorha@yahoo.com", "", "", null)]
        [NUnit.Framework.TestCaseAttribute("sandu", "", "sandumoca@yahoo.com", "1234512311", "", null)]
        [NUnit.Framework.TestCaseAttribute("", "shjasd", "sandel@yahoo.com", "1234543245", "str.Iancu", null)]
        [NUnit.Framework.TestCaseAttribute("", "", "", "", "", null)]
        public void NavigateToPracticeFormPageAndFillTheEntireFormWithInvalidValues(string firstName, string lastName, string userEmail, string userNumber, string currentAddress, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("FirstName", firstName);
            argumentsOfScenario.Add("LastName", lastName);
            argumentsOfScenario.Add("UserEmail", userEmail);
            argumentsOfScenario.Add("UserNumber", userNumber);
            argumentsOfScenario.Add("CurrentAddress", currentAddress);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Navigate to PracticeFormPage and fill the entire form with invalid values", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 22
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 23
 testRunner.Given("Home page was displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 24
 testRunner.When("I click on Forms menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 25
 testRunner.And("I click on Practice Form subMenu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "UserEmail",
                            "UserNumber",
                            "CurrentAddress"});
                table5.AddRow(new string[] {
                            string.Format("{0}", firstName),
                            string.Format("{0}", lastName),
                            string.Format("{0}", userEmail),
                            string.Format("{0}", userNumber),
                            string.Format("{0}", currentAddress)});
#line 26
 testRunner.And("I fill the entire form with the following details", ((string)(null)), table5, "And ");
#line hidden
#line 29
 testRunner.When("I submit form from site", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
                TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                            "FirstName",
                            "LastName",
                            "UserEmail",
                            "UserNumber",
                            "CurrentAddress"});
                table6.AddRow(new string[] {
                            string.Format("{0}", firstName),
                            string.Format("{0}", lastName),
                            string.Format("{0}", userEmail),
                            string.Format("{0}", userNumber),
                            string.Format("{0}", currentAddress)});
#line 30
 testRunner.Then("I validate all the entered fields from form page", ((string)(null)), table6, "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("PracticeFormScenario")]
        public void PracticeFormScenario()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("PracticeFormScenario", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 42
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 43
  testRunner.Given("Home page was displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
                TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                            "key"});
                table7.AddRow(new string[] {
                            "resources.practiceFormResource.PracticeFormResource"});
#line 44
  testRunner.And("Test data was successfully loaded", ((string)(null)), table7, "And ");
#line hidden
#line 47
  testRunner.When("I click on Forms menu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 48
  testRunner.And("I click on Practice Form subMenu", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 49
  testRunner.And("I fill the form", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
