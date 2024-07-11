@RegressionSuite 
Feature: PracticeForm

Completes Practice Form page with different data sets

Scenario Outline: Navigate to PracticeFormPage and fill the entire form with valid values
	Given Home page was displayed
	When I click on Forms menu
	And I click on Practice Form subMenu
	And I fill the entire form with the following details
	| FirstName   | LastName   | UserEmail   | UserNumber   | CurrentAddress   | Gender   | Hobbies   | Subjects    | Day    | Month   | Year   | State   | City   |
	| <FirstName> | <LastName> | <UserEmail> | <UserNumber> | <CurrentAddress> | <Gender> | <Hobbies> | <Subjects>  | <Day>  | <Month> | <Year> | <State> | <City> |
	Then I validate all the entered fields from form page
	| FirstName   | LastName   | UserEmail   | UserNumber   | CurrentAddress   | Gender   | Hobbies   | Subjects    | Day    | Month   | Year   | State   | City   |
	| <FirstName> | <LastName> | <UserEmail> | <UserNumber> | <CurrentAddress> | <Gender> | <Hobbies> | <Subjects>  | <Day>  | <Month> | <Year> | <State> | <City> |
	
	Examples: 
		| FirstName | LastName | UserEmail           | UserNumber | CurrentAddress   |Gender | Hobbies      | Subjects | Day | Month    | Year | State | City  |
		| alex      | rosca    | alexrosca@yahoo.com | 1234567890 | str. calarasilor |Male   | Sports,Music | English  | 15  | November | 1998 | NCR   | Delhi |

@PracticeFormValidScenarios
Scenario Outline: Navigate to PracticeFormPage and fill the entire form with multiple valid values
	Given Home page was displayed
	When I click on Forms menu
	And I click on Practice Form subMenu
	And I fill the entire form with the following details
	| FirstName   | LastName   | UserEmail   | UserNumber   | CurrentAddress   | Gender   | Hobbies   | Subjects    | Day    | Month   | Year   | State   | City   |
	| <FirstName> | <LastName> | <UserEmail> | <UserNumber> | <CurrentAddress> | <Gender> | <Hobbies> | <Subjects>  | <Day>  | <Month> | <Year> | <State> | <City> |
	And I subbmit form
	Then I validate all the entered fields from form page
	| FirstName   | LastName   | UserEmail   | UserNumber   | CurrentAddress   | Gender   | Hobbies   | Subjects    | Day    | Month   | Year   | State   | City   |
	| <FirstName> | <LastName> | <UserEmail> | <UserNumber> | <CurrentAddress> | <Gender> | <Hobbies> | <Subjects>  | <Day>  | <Month> | <Year> | <State> | <City> |
	
	Examples: 
		| FirstName | LastName | UserEmail           | UserNumber | CurrentAddress | Gender | Hobbies      | Subjects | Day | Month    | Year | State | City  |
		| alex      | rosca    | test@mail.com       | 1234567855 | str.Iorga      | Male   | Sports,Music | English  | 15  |          | 1998 | NCR   | Delhi |
		| alex      | dorha    | mail@yahoo.com      | 1234567890 | str.alex       | Female |   Sports     | Math     | 10  | December | 2000 | NCR   | Delhi |
		| cristain  |   test   | sandumoca@yahoo.com | 1234512311 |   asda         | Other  |   Music      | Arts     | 20  |          | 1995 | NCR   | Delhi |


	Scenario: PracticeFormScenario
		Given Home page was displayed
		And Test data was successfully loaded
		| key															 |
		| resources.practiceFormResource.PracticeFormResource			 |
		When I click on Forms menu
		And I click on Practice Form subMenu
		And I fill the form
		
		

