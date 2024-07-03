Before you start:

1. You can change the connection string to what DB Server you have currently installed on you machine. Otherwise, you'll need to install SQL Express.
2. Run the update database command so the solution can create the DB and prepopulate it. It's possible the migration script might not work with PostgreSQL.
3. Clone this repo and make you changes there. You can just send the link to the repo once done.

Objective:
The objective of this test is to see how easily you can adapt to an already existing code base and to test your DB migration skills. 
The application consists of two tables in the database - Product and Category. Currently, Product only supports one Category. We want to change this so that we can set multiple categories to a product. 
Existing data should still persist after the model change.
