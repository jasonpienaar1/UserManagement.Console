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
      var query = from user in Users where user.FirstName.Contains(readResult, StringComparison.OrdinalIgnoreCase) | user.EmailAddress.Contains(readResult, StringComparison.OrdinalIgnoreCase) select user;
      foreach (var users in query)
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
      var query = from user in Users where user.UserId == readResult select user;
      var obj = query.FirstOrDefault();
      if (obj != null)
      {
        System.Console.WriteLine($"The current first name is {obj.FirstName}. Please edit the first name.");
        var newFirstName = System.Console.ReadLine();
        obj.FirstName = newFirstName;

        System.Console.WriteLine($"The current last name is {obj.LastName}. Please edit the last name.");
        var newLastName = System.Console.ReadLine();
        obj.LastName = newLastName;

        System.Console.WriteLine($"The current date of birth is {obj.DateOfBrith}. Please edit the date of birth (mm/dd/yyyy).");
        var newDateOfBirth = System.Console.ReadLine();
        obj.DateOfBrith = newDateOfBirth;

        System.Console.WriteLine($"The current email address is {obj.EmailAddress}. Please edit the email address.");
        var newEmailAddress = System.Console.ReadLine();
        obj.EmailAddress = newEmailAddress;

        System.Console.WriteLine($"The current phone number is {obj.PhoneNumber}. Please edit the phone number.");
        int newPhoneNumber;
        newPhoneNumber = Convert.ToInt32(System.Console.ReadLine());
        obj.PhoneNumber = newPhoneNumber;
      }
    }

    public static void DeleteUser()
    {
      UserItemService.RetrieveAllUsers();
      System.Console.WriteLine("Select a user to delete based on their ID");
      int userResponse;
      userResponse = Convert.ToInt32(System.Console.ReadLine());
      var query = from user in Users where user.UserId == userResponse select user;
      var numberOfUsers = query.Count();
      if (userResponse <= numberOfUsers)
      {
        var userToRemove = query.FirstOrDefault();
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
