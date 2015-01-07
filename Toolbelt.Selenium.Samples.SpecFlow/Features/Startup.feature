Feature: Startup
	As a user
	I need to be able to load 'Test Possessed'
	So that I can read some amazing articles written by Mike

Background:
	Given I am a User
	
Scenario: Load Home Page
	When I attempt to load the application
	Then I should see the title is 'Mike Hanson | Test Possessed'