Feature: SpecFlow TestCase2

	@API	
	Scenario Outline: Add Project Test
	Given API client for milestone is initialized
	When added new project: name "New BDD project" announcement "Progect for BDD-tests" suite mode "2"
	Then added project should match the expected project

	@API	
	Scenario Outline: Add Milestone Test
	Given API client for milestone is initialized
	And added new project: name "New BDD project" announcement "Progect for BDD-tests" suite mode "2"
	When added new milestone: name "New Milesone BDD" description "Created milestone for BDD home work"
	Then added milestone should match the expected milestone

	@API	
	Scenario: Get Milestone Test
	Given API client for milestone is initialized
	* added new project: name "New BDD project" announcement "Progect for BDD-tests" suite mode "2"
	* added new milestone: name "New Milesone BDD" description "Created milestone for BDD home work"
	When received an existing milestone
	Then actual milestone should match the received milestone

	@API	
	Scenario: Update Milestone Test
	Given API client for milestone is initialized
	* added new project: name "New BDD project" announcement "Progect for BDD-tests" suite mode "2"
	* added new milestone: name "New Milesone BDD" description "Created milestone for BDD home work"
	When details of added milestone was update: name "Updated MILESTONE" description "Update milestone test"
	Then the updated milestone should match the expected information

	@API	
	Scenario: Delete Milestone Test
	Given API client for milestone is initialized
	* added new project: name "New BDD project" announcement "Progect for BDD-tests" suite mode "2"
	* added new milestone: name "New Milesone BDD" description "Created milestone for BDD home work"
	When added milestone is deleted
	Then the added milestone must be deleted