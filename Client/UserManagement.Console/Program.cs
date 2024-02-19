using UserManagement.Console.Application.Services;
using UserManagement.Console.Shared.Models;
string menuSelection = " ";
string? readResult;
do
{
  Console.WriteLine("Welcome to your User Management System! \nPlease select an option from the menu below: \n");
  MenuItemService menuItemService = new MenuItemService();
  AddUser addUser = new AddUser();
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
        Console.WriteLine("\n\rEnter the first name of the user");
        addUser.AddFirstName();
        Console.WriteLine("\n\rEnter the last name of the user");
        addUser.AddLastName();
        Console.WriteLine("\n\rEnter the date of birth of the user (dd/mm/yy)");
        Console.WriteLine("\n\rEnter the email address of the user");
        Console.WriteLine("\n\rEnter the phone number of the user");
        break;
      case "2":
        break;
      case "3":
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