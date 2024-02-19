using UserManagement.Console.Application.Services;
using UserManagement.Console.Shared.Models;
string menuSelection = " ";
string? readResult;

do
{
  Console.WriteLine("Welcome to your User Management System! \nPlease select an option from the menu below: \n");
  MenuItemService menuItemService = new MenuItemService();
  List<MenuItem> menutItems = menuItemService.GetMenuItems();
  foreach (MenuItem menuItem in menutItems)
  {
    Console.WriteLine($"{menuItem.MenuItemId} {menuItem.MenuItemDescription}");
  }

  readResult = Console.ReadLine();
  if (readResult != null)
  {
    menuSelection = readResult.ToLower();
    Console.WriteLine($"You selected menu option {menuSelection}.");
    switch (menuSelection)
    {
      case "1":
        int userId = UserItemService.GetUserID();
        UserItem userItem = new UserItem(userId, 1, "Manager");
        Console.WriteLine("\n\rEnter the first name of the user");
        userItem.AddFirstName();
        Console.WriteLine("\n\rEnter the last name of the user");
        userItem.AddLastName();
        Console.WriteLine("\n\rEnter the date of birth of the user (mm/dd/yyyy)");
        userItem.AddDateOfBirth();
        Console.WriteLine("\n\rEnter the email address of the user");
        userItem.AddEmailAddress();
        Console.WriteLine("\n\rEnter the phone number of the user");
        userItem.AddPhoneNumber();
        UserItemService.AddUser(userItem);
        break;
      case "2":
        int jobRoleId = JobRoleService.GetJobRoleID();
        JobRole jobRole = new JobRole();
        JobRoleService.AddJobRole(jobRole);
        break;
      case "3":
        UserItemService.RetrieveAllUsers();
        break;
      case "4":
        break;
      case "5":
        break;
      case "6":
        break;
      default:
        break;
    }
  }
}
while (menuSelection != "7" && menuSelection != "exit");