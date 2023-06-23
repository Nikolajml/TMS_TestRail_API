Feature: TestCase

	@API	
	Scenario Outline: Add Case Test
	Given API client is initialized
	When added new case: sectionId "1" title "New BDD-API_Test" typeId "3" priorityId "1"
	Then added case should match the expected case

	@API	
	Scenario: Get Case Test
	Given API client is initialized
	And new case is added: sectionId "1" title "New BDD-API_Test" typeId "3" priorityId "1"
	When received an existing case
	Then actual case should match the received case

	# This test again failed
	# error: Request failed with status code BadRequest (0,3s)	
	# MilestoneUpdateTest passed without problems
	@API	
	Scenario: Update Case Test
	Given API client is initialized
	And new case is added: sectionId "1" title "New BDD-API_Test" typeId "3" priorityId "1"
	When details of added case was update: sectionId "4" title "UPDATED BDD-API_Test"
	Then the updated case should match the expected information

	@API	
	Scenario: Delete Case Test
	Given API client is initialized
	And new case is added: sectionId "1" title "New BDD-API_Test" typeId "3" priorityId "1"
	When added case is deleted
	Then the added case must be deleted


	