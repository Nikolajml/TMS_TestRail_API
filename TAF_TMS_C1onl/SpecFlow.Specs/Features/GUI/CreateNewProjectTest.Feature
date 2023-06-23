Feature: Create New Project
    
    @GUI   
    Scenario: Creat project in TestRail
        Given new browser is opened
        And a login page is opened
        When the user "atrostyanko@gmail.com" with password "Qwertyu_1" logged in
        * the dashboard page is opened 
        * the current user switched to add project page
        * entered in the name field "Anastasiya Project Test 2 - bdd"
        * clicked the add project button
        Then the new project is displayed