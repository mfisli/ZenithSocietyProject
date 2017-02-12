Maks Fisli 
a00952948
mfisli2@gmail.com

Dalton Walter
a00954297
Daltond@shaw.ca 

Done
________________
Application Functionality
Data Seeding
	Activity lookup and Event tables seeded with data as prescribed
	Admin & Member accounts seeded as prescribed
Separate Class Library for EF Model
Form 
	Layout
C# and ASP.NET coding best practices
	All pages accessible thru links/buttons on the main page
	Users do not see links/buttons that they do not have access to.
	Meaningful content on all pages
	All pages have sensible titles
	Customers do not enter fields that are supposed to be auto-generated (Example: Id, CreationDate and Username)
	One database file in the App_Data directory
	One EF context class
	EF migrations commands in docs/migrations.txt file
Other
	The CreationDate field should be system generated, not provided by user
	Filenames, directory names, solution name, project names & database name as prescribed
 Contents & quality of readme.txt file

Not Done:
________________
// Not sure if edit date time for events is working properly
// The dropdown list seems to default to the wrong activity description   
Appropriate validations implemented on all data entry pages


Major Challenges
________________
- Getting the ZenithWebSite to talk to the DataLib models
- Implementing the Homepage controller logic for the homepage view 
- Deploying to the Azure website