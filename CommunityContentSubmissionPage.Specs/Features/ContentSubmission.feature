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
Scenario:Check Submit Button
	When the submission page is open
	Then Call Submit Button