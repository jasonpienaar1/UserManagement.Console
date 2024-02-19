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

    public string AddJobRole(int jobRoleId)
    {
      bool validEntry = false;
      string response = "Valid name enetered.";

      while (!validEntry)
      {
        string? readResult = System.Console.ReadLine();
        readResult = readResult.Trim();
        validEntry = readResult == "" ? false : true;
        response = validEntry ? $"{readResult} is a valid name" : response = "Enter a valid name.";
        JobRoleName = readResult;
        JobRoleId = jobRoleId;
        System.Console.WriteLine(response);
      }

      return JobRoleName;
    }
  }
}
