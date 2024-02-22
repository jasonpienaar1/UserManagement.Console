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

    public static void UpdateUser()
    {
      RetrieveAllUsers();
      System.Console.WriteLine("Select which user you would like to update based on UserId");
      int readResult;
      readResult = Convert.ToInt32(System.Console.ReadLine());
      var query = Users.FirstOrDefault(user => user.UserId == readResult);
      MenuItemService.GetUpdateMenuItems();
      readResult = Convert.ToInt32(System.Console.ReadLine());
      switch (readResult)
      {
        case 1:
          System.Console.WriteLine($"The current first name is {query.FirstName}. Please edit the first name.");
          query.AddFirstName();
          break;
        case 2:
          System.Console.WriteLine($"The current last name is {query.LastName}. Please edit the last name.");
          query.AddLastName();
          break;
        case 3:
          System.Console.WriteLine($"The current date of birth is {query.DateOfBrith}. Please edit the date of birth (mm/dd/yyyy).");
          query.AddDateOfBirth();
          break;
        case 4:
          System.Console.WriteLine($"The current email address is {query.EmailAddress}. Please edit the email address.");
          query.AddEmailAddress();
          break;
        case 5:
          System.Console.WriteLine($"The current phone number is {query.PhoneNumber}. Please edit the phone number.");
          query.AddPhoneNumber();
          break;
        case 6:
          JobRoleService.RetrieveAllJobRoles();
          System.Console.WriteLine($"The current job role is {query.JobRoleName}. Please edit the job role.");
          var newJobRoleId = query.AssignJobRole();
          var assignJobRoleName = JobRoleService.JobRoles.FirstOrDefault(user => user.JobRoleId == newJobRoleId.Value).JobRoleName;
          query.JobRoleName = assignJobRoleName;
          System.Console.WriteLine("");
          break;
        default:
          System.Console.WriteLine("Incorrect Menu option. Returning to main menu.");
          break;
      }
    }

    public static void DeleteUser()
    {
      UserItemService.RetrieveAllUsers();
      System.Console.WriteLine("Select a user to delete based on their ID");
      int userResponse;
      userResponse = Convert.ToInt32(System.Console.ReadLine());
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
