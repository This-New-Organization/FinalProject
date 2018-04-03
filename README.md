# FinalProject 

- [Extension](#extension)
    - Markdown All in One 1.1.0
        - For creating a easier to read and format README.md file
    - vscode-database 1.5.1
        - Used to allow mysql queries in vscode, no longer having to go through mysql workbench to see what's going on
    - mssql 1.3.0
        - Same as vscode just with mssql
    - Blackboard Theme 0.0.2
        - Just a personal preference of the color theme of vscode

- [Database](#database)

To Connect to the Database you will want to make sure your appsettings.json has this code in it:

 {

  "ConnectionStrings": {
      
    "DefaultConnection": "Server=localhost;database=ccfp;uid=|**your uid**|;pwd=|**your pwd**|"

  },
