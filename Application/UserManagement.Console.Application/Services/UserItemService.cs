using UserManagement.Console.Shared.Models;

namespace UserManagement.Console.Application.Services
{
  public static class UserItemService
  {
    private static List<UserItem> Users { get; set; } = new List<UserItem>()
    {
      new UserItem(0, "Jeremy", "Doe", "01/01/2000", "doe.jeremy@easy.com", 0826372817, 0, "Manager"),
      new UserItem(1, "Jimmy", "Cool", "09/12/2001", "Jimmy@cool.com", 0826372876, 1, "Junior"),
    };

    public static void AddUser(UserItem userItem)
    {
      var query = from job in JobRoleService.JobRoles where userItem.JobRoleId == job.JobRoleId select job.JobRoleName;
      userItem.JobRoleName = query.FirstOrDefault();
      Users.Add(userItem);
    }

    public static int GetUserID()
    {
      var lastUser = Users.LastOrDefault();
      if (lastUser != null)
      {
        return (int)lastUser.UserId + 1;
      }
      else
      {
        return 0;
      }
    }

    public static void RetrieveAllUsers()
    {
      var query = from user in Users select user;
      foreach (var users in query)
      {
        System.Console.WriteLine($"UserID: \t\t{users.UserId} \nFirst name: \t\t{users.FirstName} \nLast name: \t\t{users.LastName} \nDate of Birth: \t\t{users.DateOfBrith} \nEmail address: \t\t{users.EmailAddress} \nPhone number: \t\t{users.PhoneNumber} \nJob role: \t\t{users.JobRoleName} \n");
      }
    }

    public static void SearchForUser()
    {
      var readResult = System.Console.ReadLine();

      var searchForUser = Users.Where(user => user.FirstName.Match(readResult) | user.EmailAddress.Match(readResult));
      foreach (var users in searchForUser)
      {
        System.Console.WriteLine($"UserID: \t\t{users.UserId} \nFirst name: \t\t{users.FirstName} \nLast name: \t\t{users.LastName} \nDate of Birth: \t\t{users.DateOfBrith} \nEmail address: \t\t{users.EmailAddress} \nPhone number: \t\t{users.PhoneNumber} \nJob role: \t\t{users.JobRoleName} \n");
      }
    }
    public static bool UpdateCheck()
    {
      System.Console.WriteLine("Would you like to update more info on this user? Yes?");
      var readResult = System.Console.ReadLine();
      readResult = readResult.Trim().ToLower();
      if (readResult != null && readResult == "yes")
      {
        return true;
      }
      else
      {
        return false;
      }
    }
    public static int UserValidation()
    {
      int readResult;
      string userResponse;
      var validEntry = true;
      var numberOfUsers = Users.Count;
      System.Console.WriteLine("Select which user you would like to update based on UserId");
      do
      {
        userResponse = System.Console.ReadLine();
        if (int.TryParse(userResponse, out readResult) && readResult <= numberOfUsers - 1)
        {
          validEntry = true;
        }
        else
        {
          validEntry = false;
          System.Console.WriteLine("Please use an interger to select a user and ensure it matches a valid user.");
        }
      }
      while (!validEntry);

      return readResult;
    }

    public static void UpdateUser()
    {
      var returnToMainMenu = true;
      RetrieveAllUsers();
      var readResult = UserValidation();
      var query = Users.FirstOrDefault(user => user.UserId == readResult);
      do
      {
        System.Console.WriteLine();
        MenuItemService.GetUpdateMenuItems();
        readResult = Convert.ToInt32(System.Console.ReadLine());
        switch (readResult)
        {
          case 1:
            System.Console.WriteLine($"The current first name is {query.FirstName}. Please edit the first name.");
            query.AddFirstName();
            returnToMainMenu = UpdateCheck();
            break;
          case 2:
            System.Console.WriteLine($"The current last name is {query.LastName}. Please edit the last name.");
            query.AddLastName();
            returnToMainMenu = UpdateCheck();
            break;
          case 3:
            System.Console.WriteLine($"The current date of birth is {query.DateOfBrith}. Please edit the date of birth (mm/dd/yyyy).");
            query.AddDateOfBirth();
            returnToMainMenu = UpdateCheck();
            break;
          case 4:
            System.Console.WriteLine($"The current email address is {query.EmailAddress}. Please edit the email address.");
            query.AddEmailAddress();
            returnToMainMenu = UpdateCheck();
            break;
          case 5:
            System.Console.WriteLine($"The current phone number is {query.PhoneNumber}. Please edit the phone number.");
            query.AddPhoneNumber();
            returnToMainMenu = UpdateCheck();
            break;
          case 6:
            JobRoleService.RetrieveAllJobRoles();
            System.Console.WriteLine($"The current job role is {query.JobRoleName}. Please edit the job role.");
            var numOfJobRoles = JobRoleService.JobRoles.Count;
            var newJobRoleId = query.AssignJobRole(numOfJobRoles);
            var assignJobRoleName = JobRoleService.JobRoles.FirstOrDefault(user => user.JobRoleId == newJobRoleId.Value).JobRoleName;
            query.JobRoleName = assignJobRoleName;
            returnToMainMenu = UpdateCheck();
            break;
          default:
            System.Console.WriteLine("Incorrect Menu option. Returning to main menu.");
            break;
        }
      }
      while (returnToMainMenu);
    }

    public static void DeleteUser()
    {
      UserItemService.RetrieveAllUsers();
      System.Console.WriteLine("Select a user to delete based on their ID");
      var userResponse = UserValidation();
      var userToRemove = Users.FirstOrDefault(user => user.UserId == userResponse);
      if (userToRemove != null)
      {
        System.Console.WriteLine($"You are about to delete {userToRemove.FirstName} {userToRemove.LastName}");
        System.Console.WriteLine("Are you sure you want to remove this user? Yes? No?");
        var userDeleteResponse = System.Console.ReadLine();
        userDeleteResponse = userDeleteResponse.Trim()
                                               .ToLower();
        if (userDeleteResponse == "yes")
        {
          Users.Remove(userToRemove);
          System.Console.WriteLine("User successfully deleted.");
        }
        else
        {
          System.Console.WriteLine("User not deleted.");
        }
      }
      else
      {
        System.Console.WriteLine("User not found. No user was deleted");
      }
    }
  }
}
