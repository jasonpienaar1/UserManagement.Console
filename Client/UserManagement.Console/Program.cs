using UserManagement.Console.Application.Services;
using UserManagement.Console.Shared.Models;
var menuSelection = " ";
string? readResult;
do
{
  Console.WriteLine("Welcome to your User Management System! \nPlease select an option from the menu below: \n");
  MenuItemService.GetMenuItems();

  readResult = Console.ReadLine();
  if (readResult != null)
  {
    menuSelection = readResult.ToLower();
    Console.WriteLine($"You selected menu option {menuSelection}.");
    switch (menuSelection)
    {
      case "1":
        var userId = UserItemService.GetUserID();
        var userItem = new UserItem(userId);

        Console.WriteLine("\n\rEnter the first name of the user");
        var addUser = userItem.AddFirstName();
        Console.WriteLine(addUser);

        Console.WriteLine("\n\rEnter the last name of the user");
        userItem.AddLastName();

        Console.WriteLine("\n\rEnter the date of birth of the user (mm/dd/yyyy)");
        userItem.AddDateOfBirth();

        Console.WriteLine("\n\rEnter the email address of the user");
        userItem.AddEmailAddress();

        Console.WriteLine("\n\rEnter the phone number of the user");
        userItem.AddPhoneNumber();

        Console.WriteLine("\n\rSelect job role for new user based on ID displayed below.");
        JobRoleService.RetrieveAllJobRoles();
        var numOfJobRoles = JobRoleService.JobRoles.Count;
        userItem.AssignJobRole(numOfJobRoles);

        UserItemService.AddUser(userItem);
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
        break;
      case "2":
        var jobRoleId = JobRoleService.GetJobRoleID();
        var jobRole = new JobRole();
        Console.WriteLine("Add a job role.");
        jobRole.AddJobRole(jobRoleId);
        JobRoleService.AddJobRole(jobRole);
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
        break;
      case "3":
        UserItemService.RetrieveAllUsers();
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
        break;
      case "4":
        Console.WriteLine("\nPlease enter a users name or email address to search the user list. \n");
        UserItemService.SearchForUser();
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
        break;
      case "5":
        Console.WriteLine("\nBelow is a list of users. \n");
        UserItemService.UpdateUser();
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
        break;
      case "6":
        UserItemService.DeleteUser();
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
        break;
      default:
        Console.WriteLine("Incorrect menu option selected");
        break;
    }
  }
}
while (menuSelection != "7" && menuSelection != "exit");