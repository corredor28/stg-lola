# stg-lola

INSTRUCTIONS:

1. Deploy d_database project to local database (you can use the included publish profile d_database.publish.xml).
2. (Optional) Run the Scripts\04_insert_5000_animals.sql script of the d_database project to populate data.
3. Run the API (q_api project).
4. Run the POST /token method, using one of the test users from appsettings.json as the body. *
5. Copy token from result and use it to call other methods.

* An example Postman collection is provided on the git root folder. This collection has the call to token endpoint scripted so it is easier to test.
