using UserManagement.Console.Shared.Models;

namespace UserManagement.Console.Application.Services
{
  public static class UserItemService
  {
    private static List<UserItem> Users { get; set; } = new List<UserItem>();

    public static void AddUser(UserItem userItem)
    {
      Users.Add(userItem);
    }

    public static int GetUserID()
    {
      UserItem? lastUser = Users.LastOrDefault();
      if (lastUser != null)
      {
        return lastUser.UserId + 1;
      }
      else
      {
        return 0;
      }
    }

    public static void RetrieveAllUsers()
    {
      IEnumerable<UserItem> query = from user in Users select user;
      foreach (UserItem? users in query)
      {
        System.Console.WriteLine($"UserID: \t\t{users.UserId} \nFirst name: \t\t{users.FirstName} \nLast name: \t\t{users.LastName} \nDate of Birth: \t\t{users.DateOfBrith} \nEmail address: \t\t{users.EmailAddress} \nPhone number: \t\t{users.PhoneNumber} \nJob role: \t\t{users.JobRoleName} \n");
      }
    }
  }
}
