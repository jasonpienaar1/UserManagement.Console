namespace UserManagement.Console.Shared.Models
{
  public static class StringExtensions
  {
    public static bool Match(this string input, string inputToMatch)
    {
      return input.Contains(inputToMatch, StringComparison.OrdinalIgnoreCase);
    }
  }
}
