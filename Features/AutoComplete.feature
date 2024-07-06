﻿@RegressionSuite @SmokeSuite
Feature: AutoComplete

A short summary of the feature

Scenario Outline: AutoCompleteScenario
	Given Home page was displayed
	And Test data was successfully loaded
	|						key						           |
	| resources.autoCompleteResource.AutoCompleteResource      |
	When I click on Widgets menu 
	And I click on Auto Complete subMenu 
	Then I complete both color fields
