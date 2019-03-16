Given I wish to keep a list of goals
When I open the application
Then the application shall allow for creating, displaying, updating, and deleting my goals

Given that I wish to learn web application development using Microsoft's latest technology,
Then the application shall be built using ASP.NET Core

Give that I wish to learn postgres
Then the database for the application shall be built using postgresql

Given that I have navigated to the application home page
When I click the Goals link at the top
Then I will be taken to the Goals Index

Given that I wish to add a goal
When I click the Create New link
Then a form will appear, with fields I can complete to add a goal

Given that I have completed all the required fields on the create goal form
When I submit the form
Then a new goal will be added to the list of goals on the goals index

Given that I want the goals I add to persist to the database
When I submit the form
Then a new goal will be added to the goals table in postgres

Given that I want to update a goal
When I click the Edit link
Then a form will appear populated with the goal's information

Given that I have made changes to a goal
When I submit the edit form
Then the goal will appear updated on the goal index

Given that I have made changes to a goal
When I submit the edit form
Then the goal will appear updated in the postgres table

Given that I wish to delete a goal
When I click the delete link
Then the goal will no longer appear in the index

Given that I wish to delete a goal
When I click the delete link
Then the goal will no longer appear in the database

Given that I want to keep track of my goals
When I add or update a goal
Then it shall have a Goal name

Given that I want to keep track of my goals
When I add or update a goal
Then it shall have a goal description

Given that I want to rank my goals
When I add or update a goal
Then is shall have a number-based rank

Given that I want to achieve my goals
When I add or update a goal
Then it shall have a Deliverable Date

Given that I want my goals to be SMART
When I add or update a goal
Then it shall say whether or not it is specific

Given that I want my goals to be SMART
When I add or update a goal
Then it shall say whether or not it is measureable

Given that I want my goals to be SMART
When I add or update a goal
Then it shall say whether or not it is achieveable

Given that I want my goals to be SMART
When I add or update a goal
Then it shall say whether or not it is relevant

Given that I want my goals to be SMART
When I add or update a goal
Then it shall say whether or not it is timebound

Given that I want to track different types of goals
When I add or update a goal
Then is shall have a free-form goaltype field

Given that I am on the Edit goal information page
When I click Back to List
Then I will be taken back to the goal index

Given that I am on the Create goal information page
When I click Back to List
Then I will be taken back to the goal index
