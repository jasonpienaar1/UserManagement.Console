namespace UserManagement.Console.Shared.Models
{
  public class JobRole
  {
    public JobRole(int jobRoleId, string jobRoleName)
    {
      JobRoleId = jobRoleId;
      JobRoleName = jobRoleName;
    }
    public JobRole()
    {

    }

    public int JobRoleId { get; set; }

    public string JobRoleName { get; set; }
  }
}
