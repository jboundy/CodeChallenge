## Justin Boundy Code Challenge ##

This Readme contains some information about the project and instructions on setup

### Technologies ###

- The project uses ASP.Net Core 2 with EntityFramework Core 2
- ViewComponents, Bootstrap and jQuery are used to render the UI
- Moq and xunit were used for the test solution
- A third party jQuery grid view was used to show data

### Instructions ###

In order to to setup the database and table you will need to do the following:

- Use the command prompt and navigate to the folder below the solution folder
- Run the following commands
	- dotnet ef migrations add MigrationNameHere
	- dotnet ef database update

### Improvements ###
- More tests involving the interaction with the database
	- The api is basic/small but could be more refined
- Use a framework for building view components like angular cli or react
- Building a UI that supported multiple edits in the grid
- Use one form to interact with the data
- Better validation on the form
 -  There isn't much right now
- The first record inserted into the table from the form does not show in the grid until the page is refreshed. After refresh this issue is resolved. 
