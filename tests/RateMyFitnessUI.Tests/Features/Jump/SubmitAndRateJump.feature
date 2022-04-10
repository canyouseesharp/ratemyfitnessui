Feature: Submit a jump measurement and see ranking
	In order to see my jump ranking
	As a user
	I want to submit my jump measurement and see my ranking on screen
	
@jump
Scenario: Rank valid jump measurement
	Given I have filled in the jump measurement form
	When I press Submit
	Then my ranking should be displayed