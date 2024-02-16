using UserManagement.Console.Shared.Models;

namespace UserManagement.Console.Application.Services
{
  public class MenuItemService
  {
    public List<MenuItem> menuItems;

    public MenuItemService()
    {
      menuItems = new List<MenuItem>
      {
        new MenuItem(1, "Add a new user."),
        new MenuItem(2, "Add a new job role."),
        new MenuItem(3, "Display all users."),
        new MenuItem(4, "Search for a user."),
        new MenuItem(5, "Update user information."),
        new MenuItem(6, "Delete a user."),
        new MenuItem(7, "Exit the application.")
      };
    }

    public List<MenuItem> GetMenuItems()
    {
      return menuItems;
    }
  }
}
