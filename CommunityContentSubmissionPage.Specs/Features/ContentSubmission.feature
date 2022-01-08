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

Scenario: Type should offer a list of unique entries
	When the submission page is open
	Then you can choose from the following Types:
		| TypeName |
		| Books    |
		| Videos   |
		| Examples |

Scenario: Entered values from submission page is saved
	Given the submission page is open
	And the filled out submission entry form
		| Label       | Value                        |
		| Url         | https://www.specflow.org     |
		| Type        | Books                      |
		| Email       | HassanMohamed_Hm@Hotmail.com |
		| Description | Test                         |
	When the submission entry form is submitted
	Then there is a submission entry stored with the following data :
		| Id | Url                      | Type    | Email                        | Description |
		| 1  | https://www.specflow.org | Books | HassanMohamed_Hm@Hotmail.com | Test        |

Scenario: User does not accept the privacy policy should be an error when submitting
	Given the submission page is open
	And the submission entry form is filled
	But the privacy policy is not accepted
	When the submission entry form is submitted
	Then  tthe submittingg of data was not possible

Scenario: User agrees to privacy data should be submitted
	Given the submission page is open
	And the submission entry form is filled
	But the privacy policy is accepted
	When the submission entry form is submitted
	Then  the submittingg of data was possible