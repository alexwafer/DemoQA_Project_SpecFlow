@RegressionSuite
Feature: WebTableFeature

Completes the webTable page 
@tag1
Scenario Outline: WebTableScenario
	Given Home page was displayed
	And Test data was successfully loaded
	|						key						 |
	| resources.WebTableResource.WebTableResource    |
	When I click on Elements menu 
	And I click on Web Tables subMenu 
	Then I add a new entry into table