@Feature_2.1
Feature: 2.1 API actions for Math operations

@Scenario_2.1.1
Scenario: Perform addition on two numbers
	When the user adds 7 and 8 by POST request
	Then the "200" status code is received
		And the result should be 15

@Scenario_2.1.2
Scenario: Perform substraction on two numbers
	When the user substracts 2 from 10 by POST request
	Then the "200" status code is received
		And the result should be 8

@Scenario_2.1.3
Scenario: Perform multiplication on two numbers
	When the user multiplies 11 and 3 by POST request
	Then the "200" status code is received
		And the result should be 33

@Scenario_2.1.4
Scenario: Perform division on two numbers
	When the user divides 20 on 4 by POST request
	Then the "200" status code is received
		And the result should be 5

@Scenario_2.1.5
Scenario: Find square root
	When the user enters 16 to find square root by GET request
	Then the "200" status code is received
		And the result should be 4