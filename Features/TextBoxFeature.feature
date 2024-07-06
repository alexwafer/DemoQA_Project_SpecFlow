@RegressionSuite @SmokeSuite
Feature: TextBoxFeature

A short summary of the feature

Scenario Outline: TextBoxScenario
	Given Home page was displayed
	And Test data was successfully loaded
	|						key						 |
	| resources.textBoxResource.TextBoxResource      |
	When I click on Elements menu 
	And I click on Text Box subMenu 
	Then I fill TextBox Form
