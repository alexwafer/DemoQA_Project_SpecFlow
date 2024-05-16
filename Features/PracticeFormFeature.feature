@RegressionSuite
Feature: PracticeForm
// renuntat la astea lasat doar ultimul 

@JIRA-123
Scenario Outline: Navigate to PracticeFormPage and fill the entire form with valid values
	Given Home page was displayed
	When I click on Forms menu
	And I click on Practice Form subMenu
	And I fill the entire form with the following details
	| FirstName   | LastName   | UserEmail   | UserNumber   | CurrentAddress   |
	| <FirstName> | <LastName> | <UserEmail> | <UserNumber> | <CurrentAddress> |
	When I submit form from site
	Then I validate all the entered fields from form page
	| FirstName   | LastName   | UserEmail   | UserNumber   | CurrentAddress   |
	| <FirstName> | <LastName> | <UserEmail> | <UserNumber> | <CurrentAddress> |
	
	Examples: 
		| FirstName | LastName | UserEmail           | UserNumber | CurrentAddress   |
		| alex      | rosca    | alexrosca@yahoo.com | 1234567890 | str. calarasilor |

Scenario Outline: Navigate to PracticeFormPage and fill the entire form with invalid values
	Given Home page was displayed
	When I click on Forms menu
	And I click on Practice Form subMenu
	And I fill the entire form with the following details
	| FirstName   | LastName   | UserEmail   | UserNumber   | CurrentAddress   | 
	| <FirstName> | <LastName> | <UserEmail> | <UserNumber> | <CurrentAddress> |
	When I submit form from site
	Then I validate all the entered fields from form page
	| FirstName   | LastName   | UserEmail   | UserNumber   | CurrentAddress   |
	| <FirstName> | <LastName> | <UserEmail> | <UserNumber> | <CurrentAddress> |
	
	Examples: 
		| FirstName | LastName | UserEmail           | UserNumber | CurrentAddress |
		| alex      | rosca    |    delete           | 1234567855 | str.Iorga      |
		| alex      | dorha    | alexdorha@yahoo.com |            |                |
		| sandu     |          | sandumoca@yahoo.com | 1234512311 |                |
		|           | shjasd   | sandel@yahoo.com    | 1234543245 | str.Iancu      |
		|           |          |                     |            |                |

	Scenario: PracticeFormScenario
		Given Home page was displayed
		And Test data was successfully loaded
		| key															 |
		| resources.practiceFormResource.PracticeFormResource			 |
		When I click on Forms menu
		And I click on Practice Form subMenu
		And I fill the form
		
		

