@Feature_1.1
Feature: API Actions with Users

Background: The Users API URL is "https://reqres.in/"

@Scenario_1.1.1.
Scenario: When a user sends request to the list of users, then the OK status code should be received and the list of users will be returned
Given the Endpoint is "/api/users?page=2"
When User sends the GET request to the list of users
Then the "200" status code is received
	And the list of users is returned

@Scenario_1.1.2
Scenario: When a user sends request to a not found single user, then the Not Found status code should be received
Given the Endpoint is "/api/users/23"
When User sends the GET request to the not found single user
Then the "404" status code is received

@Scenario_1.1.3
Scenario: When a user sends request to a single user, then the OK status code should be received and the user data will be returned
Given the Endpoint is "/api/users/2"
When User sends the GET request to the single user
Then the "200" status code is received
	And the user data is returned

@Scenario_1.1.4
Scenario: When a user sends request to create a user, then the Created status code should be received and the created user data will be returned
Given the Endpoint is "/api/users"
When User sends the POST request to create a user with data in the request body
| Name | morpheus |
| Job  | leader   |
Then the "201" status code is received
	And the updated user data is returned

@Scenario_1.1.5
Scenario: When a user sends request to update a user, then the the OK status code should be received and the updated user data is returned
Given the Endpoint is "/api/users/2"
When User sends the PUT request to update a user with data in the request body
| Name | morpheus      |
| Job  | zion resident | 
Then the "200" status code is received
	And the updated user data is returned

@Scenario_1.1.6
Scenario: When a user sends a request to update user fields, then the the OK status code should be received and the updated user data is returned
Given the Endpoint is "/api/users/2"
When User sends the PATCH request to update a user with data in the request body
| Name | morpheus      |
| Job  | zion resident | 
Then the "200" status code is received
	And the updated user data is returned

@Scenario_1.1.7
Scenario: When a user sends a request to delete a user, then the No Content status code should be received
Given the Endpoint is "/api/users/2"
When User sends the DELETE request to delete a user
Then the "204" status code is received

@Scenario_1.1.8
Scenario: When a user sends a request for successful register, then the OK status code should be received
Given the Endpoint is "/api/register"
When User sends the POST request to register successfully with data in the request body
| Email    | eve.holt@reqres.in |
| Password | pistol             |
Then the "200" status code is received
	And the id and token are received

@Scenario_1.1.9
Scenario: When user sends a request for unsuccessful login, then the Bad Request status code should be received and the error should be returned
Given the Endpoint is "/api/login"
When User sends the POST request to login unsuccessfully with data in the request body
| Email | peter@klaven | 
Then the "400" status code is received
	And the error "Missing password" is returned

@Scenario_1.1.10
Scenario: When user sends a request for the delayed response, then the OK status code should be received and users list should be returned
Given the Endpoint is "/api/users?delay=3"
When User sends the GET request for the delayed response
Then the "200" status code is received
	And the users list is returned

Examples: 
| Method | Endpoint           | StatusCode |
| GET    | /api/users?page=2  | 200        |
| GET    | /api/users/23      | 404        |
| GET    | /api/users/2       | 200        |
| POST   | /api/users         | 201        |
| PUT    | /api/users/2       | 200        |
| PATCH  | /api/users/2       | 200        |
| DELETE | /api/users/2       | 204        |
| POST   | /api/register      | 200        |
| POST   | /api/login         | 400        |
| GET    | /api/users?delay=3 | 200        |