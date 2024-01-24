@Feature_1.1
Feature: 1.1 API Actions with Users

Background: 
Given The Users API URL is "https://reqres.in"

@Scenario_1.1.1.
Scenario: 1.1.1. When a user sends request to the list of users, then the OK status code should be received and the list of users will be returned
When the user sends the GET request to page 2 of users list
Then the "200" status code is received
	And the list of users is returned

@Scenario_1.1.2
Scenario: 1.1.2. When a user sends request to a not found single user, then the Not Found status code should be received
When User sends the GET request to page 23 for the not found single user
Then the "404" status code is received

@Scenario_1.1.3
Scenario: 1.1.3. When a user sends request to a single user, then the OK status code should be received and the user data will be returned
When User sends the GET request to the single user for the page 2
Then the "200" status code is received
	And the user data is returned

@Scenario_1.1.4
Scenario: 1.1.4. When a user sends request to create a user, then the Created status code should be received and the created user data will be returned
When User sends the POST request to users page to create a user with data in the request body
| Name | morpheus |
| Job  | leader   |
Then the "201" status code is received
	And the created user data is returned

@Scenario_1.1.5
Scenario: 1.1.5. When a user sends request to update a user, then the the OK status code should be received and the updated user data is returned
When User sends the PUT request to users page 2 to update a user with data in the request body
| Name | morpheus      |
| Job  | zion resident | 
Then the "200" status code is received
	And the updated user data is returned

@Scenario_1.1.6
Scenario: 1.1.6. When a user sends a request to update user fields, then the the OK status code should be received and the updated user data is returned
When User sends the PATCH request to users page 2 to update a user with data in the request body
| Name | morpheus      |
| Job  | zion resident | 
Then the "200" status code is received
	And the updated user data is returned

@Scenario_1.1.7
Scenario: 1.1.7. When a user sends a request to delete a user, then the No Content status code should be received
When User sends the DELETE request to user page 2 to delete a user
Then the "204" status code is received

@Scenario_1.1.8
Scenario: 1.1.8. When a user sends a request for successful register, then the OK status code should be received
When User sends the POST request to register successfully with data in the request body
| Email    | eve.holt@reqres.in |
| Password | pistol             |
Then the "200" status code is received
	And the id and token are received

@Scenario_1.1.9
Scenario: 1.1.9. When user sends a request for unsuccessful login, then the Bad Request status code should be received and the error should be returned
When User sends the POST request to login unsuccessfully with data in the request body
| Email | peter@klaven | 
Then the "400" status code is received
	And the error is returned

@Scenario_1.1.10
Scenario: 1.1.10. When user sends a request for the delayed response, then the OK status code should be received and users list should be returned
When User sends the GET request to page 3 for the delayed response
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