Feature: Content Submission

Scenario: Title is set to SpecFlow Community Content Submission
	When the submission page is open
	Then the title of the page is 'SpecFlow Community Content Submission'


Scenario Outline: Input for submission is available
	When the submission page is open
	Then it is possible to enter a '<Input type>' with label '<Label>'
Examples:
	| Input type  | Label              |
	| Url         | Url to content     |
	| Type        | Type of content    |
	| EMail       | Your EMail address |
	| Description | Description        |


Scenario: Entered values from submission page is saved
	Given the submission page is open
	And the filled out submission entry form
		| Label       | Value                        |
		| Url         | https://www.specflow.org     |
		| Type        | Website                      |
		| Email       | HassanMohamed_Hm@Hotmail.com |
		| Description | Test                         |
	When the submission entry form is submitted
	Then there is a submission entry stored with the following data :
		| Id | Url                      | Type    | Email                        | Description |
		| 10  | https://www.specflow.org | Website | HassanMohamed_Hm@Hotmail.com | Test        |