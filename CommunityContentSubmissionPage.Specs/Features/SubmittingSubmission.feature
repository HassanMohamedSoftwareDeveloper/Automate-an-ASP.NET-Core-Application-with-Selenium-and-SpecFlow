Feature: Submitting Submission

Scenario: Entered values from submission page is saved
	Given the submission page is open
	And the filled out submission entry form
		| Label       | Value                        |
		| Url         | https://www.specflow.org     |
		| Type        | Books                        |
		| Email       | HassanMohamed_Hm@Hotmail.com |
		| Description | Test                         |
	And the privacy policy is accepted
	When the submission entry form is submitted
	Then there is a submission entry stored with the following data :
		| Id | Url                      | Type  | Email                        | Description |
		| 1  | https://www.specflow.org | Books | HassanMohamed_Hm@Hotmail.com | Test        |