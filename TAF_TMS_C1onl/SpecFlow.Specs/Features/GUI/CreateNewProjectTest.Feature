Feature: CreateProject
    
    @GUI   
    Scenario: create newproject
        Given the browser is opened
        * the login page is opened
        When the user is logged in: user "atrostyanko@gmail.com" password "Qwertyu_1"
        * the dashboard page is opened 
        * the user went to project page
        * entered the project name "The project created like GUI BDD test"
        * added new project
        Then check that project was added