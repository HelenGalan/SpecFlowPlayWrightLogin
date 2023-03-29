Feature: Navigate to SpecFlow page

@login
Scenario: Google Search
	Given the user is on google
	And approve Google privacy policy
	And he types in SpecFlow into the search field
	When he clicks search the official site appears
	Then he clicks on the link and goes to 'https://specflow.org/'
