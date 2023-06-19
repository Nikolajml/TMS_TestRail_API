Feature: SpecFlow TestCase

Scenario Outline: Add Case Test
	Given API client is initialized
	When added new case: sectionId "1" title "New BDD-API_Test" typeId "3" priorityId "1"
	Then added case should match the expected case



	