using UserManagement.Console;
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
        readResult = Console.ReadLine();
        addUser.AddFirstName(readResult);
        Console.WriteLine();
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