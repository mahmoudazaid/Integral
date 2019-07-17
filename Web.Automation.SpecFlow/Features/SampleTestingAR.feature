## @AR that means run on Arabic interface if you need to run to English interface just Replace the @AR with @EN

@Chrome  @AR
Feature: Verify sample tests for home and login screen Arabic

Background: 
Given Jawwytv site opens successfully
When User changes language in welcome screen
And User clicks on seven days free subscribe now button

@Toptest
Scenario: Validate back button on payment screen on entering username and password
    Then User enters username as "testuser@gm.com"
    And User enters password as "12345678"
    And User clicks on continue button
    Then User should see back button displayed on payment screen
@Toptest
Scenario: Validate that one single payment method is available for Lebanon country
    Then User enters username as "testuser@gm.com"
    And User enters password as "12345678"
    And User clicks on continue button
    And User should selects "Lebanon" from country dropdown menu
    Then User should see that only "Credit Card" payment method is displayed 

@Bottomtest
Scenario: Validate that two payment methods are available for Bahrain country
    Then User enters username as "testuser@gm.com"
    And User enters password as "12345678"
    And User clicks on continue button
    And User should selects "Bahrain" from country dropdown menu
    Then User should see that 2 payment methods are displayed 
@Bottomtest
Scenario: Validate user navigates back to subscribe now page 
    Then User clicks on Click here link in create your account section
    And User clicks on Subscribe link in Existing User section
    Then User should navigate to Create your account section
@Bottomtest
Scenario: Validate terms and conditions page
    Then User clicks on Terms and Conditions link in create your account section
    Then User should see that Terms & Conditions section is displayed

