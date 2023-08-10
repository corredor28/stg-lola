# stg-lola

INSTRUCTIONS:

1. Deploy d_database project to local database (you can use the included publish profile d_database.publish.xml).
2. (Optional) Run the Scripts\04_insert_5000_animals.sql script of the d_database project to populate data.
3. Run the API (q_api project).
4. Run the POST /token method, using one of the test users from appsettings.json as the body. *
5. Copy token from result and use it to call other methods.

* An example Postman collection is provided on the git root folder. This collection has the call to token endpoint scripted so it is easier to test.

SPECIFICATIONS COMPLIANCE:

1. The scripts are located inside the d_database project, on the Scripts folder.
2. There is an extra script (07) for the Order table creation.
3. All endpoints require a JWT token, the tests users are in the appsettings.json file in the q_api project. I did not move them to the database since that was not the main goal of this test.
4. The Web API is built in .NET 7.
5. The Micro ORM Dapper was used.
6. All endpoints using async/await, the only exception being the token endpoint.
7. No warnings on compile.
