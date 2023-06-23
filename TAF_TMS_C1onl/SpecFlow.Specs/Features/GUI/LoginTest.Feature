Feature: LoginTest
    
    @GUI
    Scenario: successful login with correct credentials
        Given the browser is opened
        And the login page is opened        
        When the user is logged in: user "atrostyanko@gmail.com" password "Qwertyu_1"
        Then the dashboard page is opened     