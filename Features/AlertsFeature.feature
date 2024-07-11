@RegressionSuite @SmokeSuite
Feature: AlertsFeature

Interacts with Alert page

Scenario: AlertsScenario
	Given Test data was successfully loaded
	|						key						     |
	| resources.alertFrameResource.AlertFrameResource    |
	And Home page was displayed
	When I click on Alerts, Frame & Windows menu 
	And I click on Alerts subMenu 
	Then I deal with everyAlert
	