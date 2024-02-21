namespace UserManagement.Console.Shared.Models
{
  public class JobRole
  {
    public JobRole(int jobRoleId, string jobRoleName)
    {
      this.JobRoleId = jobRoleId;
      this.JobRoleName = jobRoleName;
    }

    public JobRole()
    {
    }

    public int? JobRoleId { get; set; }

    public string? JobRoleName { get; set; }

    public string AddJobRole(int jobRoleId)
    {
      var validEntry = true;
      var readResult = " ";
      do
      {
        readResult = System.Console.ReadLine();
        readResult = readResult.Trim();
        validEntry = string.IsNullOrEmpty(readResult);
        var response = !validEntry ? $"{readResult} is a valid Job role." : "Job role not valid. Enter a valid Job role.";
        System.Console.WriteLine(response);
      }
      while (validEntry);
      this.JobRoleName = readResult;
      this.JobRoleId = jobRoleId;
      return this.JobRoleName;
    }
  }
}
