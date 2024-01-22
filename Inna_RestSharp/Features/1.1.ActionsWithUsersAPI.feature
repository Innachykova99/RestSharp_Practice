Feature: Actions with Users

Scenario Outline: Perform actions on the Users API
Given The Users API URL is "https://reqres.in/"
When User sends a <Method> request to <Endpoint>
Then The Response code should be <ExpectedStatusCode>

Examples: 
| Method | Endpoint           | ExpectedStatusCode |
| GET    | /api/users?page=2  | 200                |
| GET    | /api/users/23      | 404                |
| GET    | /api/users/2       | 200                |
| POST   | /api/users         | 201                |
| PUT    | /api/users/2       | 200                |
| PATCH  | /api/users/2       | 200                |
| DELETE | /api/users/2       | 204                |
| POST   | /api/register      | 200                |
| POST   | /api/login         | 400                |
| GET    | /api/users?delay=3 | 200                |
