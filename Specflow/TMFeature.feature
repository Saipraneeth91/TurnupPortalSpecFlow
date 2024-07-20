Feature: TMFeature

A short summary of the feature

@regression
Scenario: 1 Create Time Record With Valid Data
	Given I login into Turnup portal succesfully
	When  I Navigate to Time and Material Page
	When I Create a Record
	Then  record should be created succesfully
@regression
Scenario Outline: 2 edit existing time record with valid data
	
	When I Login and Navigate to Edit Time record page
	When I update the '<Code>' and '<Description>'  on  existing Time record
	Then the record should have the updated '<Code>' and '<Description>' 

	Examples: 
	| Code             | Description | 
	| Industry Connect | First Edit Description     |
	| TA Job Ready     | Second Edit Description|
	| TA Prog sai	     | Third Edit Description  |	
@regression
Scenario: 3 delete existing time record
	
	When I Login and Navigate to Delete Time record Page
	When I delete an existing record
	Then the record should not be present on the table