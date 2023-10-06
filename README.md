# 10 steps for Code-SetUp

1. Obtain the GitHub Repository link.
2. Clone the repository using Visual Studio.
3. Navigate to: thesis → appsettings. Modify the SQL Database Connection String. (Tip: Use SQL Object Explorer).
4. Access the Migrations Folder and delete all its files.
5. Execute: Add-Migration “one”, followed by update-database.
6. Execute: Add-Migration “two”. Visit codeshare.io/3ARj94 and copy the code structure from there. Modify the code using your variable names.
7. Make all user registration fields optional. To do this, navigate to Account → Pages → Identity → Areas and open Register.cshtml. Remove the requirement for all fields except for InspectorAdministrator.
8. Launch the program and create an admin account.
9. Undo the modifications made in Step 7.
10. Log in using the admin account to access the dashboard.
