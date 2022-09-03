Feature: Lebris Partner selection page


Scenario: Verify type of partners on demo page
 Given that I am on the lebris website
 When I click on Get a demo Link
 Then verify we landed on Partner Selection page
 And has the required three Types of partners

Scenario: Verify validation message on Demo Page
 Given that I am on the lebris website
 When I click on Get a demo Link
 Then verify we landed on Partner Selection page
 And validation message when user does not make a partner selection and click ‘Get a demo’

 Scenario: Verify broker radio button leads to broker form
 Given that I am on the lebris website
 When I click on Get a demo Link
 And we landed on Partner Selection page
 Then We select broker radio button 
 And land on broker form

  Scenario: Verify ISO radio button leads to ISO form
 Given that I am on the lebris website
 When I click on Get a demo Link
 And we landed on Partner Selection page
 Then We select ISO radio button 
 And land on ISO form

 
  Scenario: Verify Strategic Partner radio button leads to Strategic Partner form
 Given that I am on the lebris website
 When I click on Get a demo Link
 And we landed on Partner Selection page
 Then We select Strategic Partner radio button 
 And land on Strategic Partner form

 Scenario: Validate Contact us link on lebris page
 Given that I am on the lebris website
 When I click on Get a demo Link
 When I scroll down to Contact us
 And click on Contact us button
 Then I land on Contact us page


