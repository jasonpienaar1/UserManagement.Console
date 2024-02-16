namespace UserManagement.Console.Shared.Models
{
  /// <summary>
  /// The Menu Item class.
  /// </summary>
  /// <remarks>
  /// Tip: Use LINQ to get and validate the menu the selected item.
  /// </remarks>
  public class MenuItem
  {
    public MenuItem(int menuItemId, string menuItemDescription)
    {
      MenuItemId = menuItemId;
      MenuItemDescription = menuItemDescription;
    }

    public int MenuItemId { get; set; }

    public string MenuItemDescription { get; set; } = string.Empty;
  }
}
