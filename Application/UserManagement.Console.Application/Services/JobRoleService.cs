using UserManagement.Console.Shared.Models;

namespace UserManagement.Console.Application.Services
{
  /// <summary>
  /// The Job Role Service class.
  /// </summary>
  /// <remarks>
  /// All related action to job role will be handled here.
  /// </remarks>
  public class JobRoleService
  {
    public static List<JobRole> JobRoles { get; set; } = new List<JobRole>()
    {
      new JobRole(0, "Manager"),
      new JobRole(1, "Junior"),
    };

    public static void AddJobRole(JobRole jobRole)
    {
      JobRoles.Add(jobRole);
    }

    public static int GetJobRoleID()
    {
      var lastJobRole = JobRoles.LastOrDefault();
      if (lastJobRole != null)
      {
        return (int)(lastJobRole.JobRoleId + 1);
      }
      else
      {
        return 0;
      }
    }

    public static IEnumerable<JobRole> RetrieveAllJobRoles()
    {
      return JobRoles;
    }

  }
}
