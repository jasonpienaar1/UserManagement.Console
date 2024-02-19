namespace UserManagement.Console.Shared.Models
{
  public class UserItem : JobRole
  {
    public UserItem(int userId, string firstName, string lastName, string dateOfBrith, string emailAddress, int phoneNumber, int jobRoleId, string jobRoleName)
      : base(jobRoleId, jobRoleName)
    {
      UserId = userId;
      FirstName = firstName;
      LastName = lastName;
      DateOfBrith = dateOfBrith;
      EmailAddress = emailAddress;
      PhoneNumber = phoneNumber;
      JobRoleId = jobRoleId;
    }

    public int UserId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string DateOfBrith { get; set; }

    public string EmailAddress { get; set; }

    public int PhoneNumber { get; set; }
  }
}
