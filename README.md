# Dyfort.Umbraco.AdPasswordChecker

Streamline your user management and enhance security with seamless integration between Umbraco's backoffice login and Active Directory. With this powerful integration, you can leverage your existing Active Directory infrastructure to manage user access and permissions within the Umbraco content management system.


## Install Package to your project

```
    PM> Install-Package Dyfort.Umbraco.AdPasswordChecker
```

### Settings and defaults

1. Locate the appsettings.json file: The appsettings.json file is usually found in the root directory of your application.

1. Open the appsettings.json file: You can use a text editor or an integrated development environment (IDE) to open and edit the file.

1. Configure AD settings
    ```
    "ActiveDirectory": {
        "Enabled": true,
        "Domain": "domain.local"
      }
    ```

1. Find the UsernameIsEmail setting: Within the appsettings.json file, search for the UsernameIsEmail setting. It might look something like this:


```
"Umbraco": {
    "CMS": {         
      "Security": {
        "UsernameIsEmail": false
      }     
    }
  }
```

### Change Umbraco users to use username

When using Umbraco backoffice, the process of changing the "username" field to be based on a username instead of an email address involves the following steps:

1. Login to Umbraco Backoffice: Go to the login page of your Umbraco backoffice and log in using your administrator credentials.

1. Access User Section: Once logged in, navigate to the "Users" section in the Umbraco backoffice. This is where you manage user accounts and their details.

1. Edit User: Find the user account that you want to modify, and click on it to open the user details for editing.

1. Update Username: In the user details form, locate the field that represents the current email-based "username" and modify it to use the desired username instead. This could be an existing field like "Username" or any other field that you want to repurpose for this purpose.

1. Save Changes: After making the necessary changes, save the user details to apply the updated username.

1. Repeat for Other Users (if needed): If you want to update the usernames for other users as well, repeat the above steps for each user account.

Consider Validation and Constraints: Ensure that any validation rules or constraints you have set for usernames are appropriately adjusted to accommodate the new format.

## Test the Changes:
After updating the usernames, perform thorough testing to make sure the changes haven't caused any issues with user login, authentication, or any other related functionalities.
