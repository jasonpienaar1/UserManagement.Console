using UserManagement.Console.Shared.Models;

namespace UserManagement.Console.Application.Services
{
  public static class MenuItemService
  {
    public static List<MenuItem> menuItems = new()
      {
        new MenuItem(1, "Add a new user."),
        new MenuItem(2, "Add a new job role."),
        new MenuItem(3, "Display all users."),
        new MenuItem(4, "Search for a user."),
        new MenuItem(5, "Update user information."),
        new MenuItem(6, "Delete a user."),
        new MenuItem(7, "Exit the application."),
      };

    public static List<MenuItem> GetMenuItems()
    {
      foreach (var menuItem in menuItems)
      {
        System.Console.WriteLine($"{menuItem.MenuItemId} {menuItem.MenuItemDescription}");
      }

      return menuItems;
    }

    public static List<MenuItem> updateMenuItem = new List<MenuItem>()
    {
      new MenuItem(1, "Update First Name"),
      new MenuItem(2, "Update Last Name"),
      new MenuItem(3, "Update Date of Birth"),
      new MenuItem(4, "Update Email Address"),
      new MenuItem(5, "Update Phone Number"),
      new MenuItem(6, "Update Job Role"),
    };

    public static List<MenuItem> GetUpdateMenuItems()
    {
      foreach (var menuItem in updateMenuItem)
      {
        System.Console.WriteLine($"{menuItem.MenuItemId} {menuItem.MenuItemDescription}");
      }

      return menuItems;
    }
  }
}
