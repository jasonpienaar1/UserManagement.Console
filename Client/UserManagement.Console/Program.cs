using UserManagement.Console.Application.Services;
string menuSelection = " ";
string? readResult;
do
{
  Console.WriteLine("Welcome to your User Management System! \nPlease select an option from the menu below: \n");
  MenuItemService menuItemService = new MenuItemService();
  List<UserManagement.Console.Shared.Models.MenuItem> menutItems = menuItemService.GetMenuItems();
  foreach (UserManagement.Console.Shared.Models.MenuItem menuItem in menutItems)
  {
    Console.WriteLine($"{menuItem.MenuItemId} {menuItem.MenuItemDescription}");
  }

  readResult = Console.ReadLine();
  if (readResult != null)
  {
    menuSelection = readResult.ToLower();
    Console.WriteLine($"You selected menu option {menuSelection}.");
  }
}
while (menuSelection != "exit" || menuSelection != "7");