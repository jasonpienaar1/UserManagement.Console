﻿namespace UserManagement.Console.Shared.Models
{
  internal class JobRole
  {
    public JobRole(int jobRoleId, string jobRoleName)
    {
      JobRoleId = jobRoleId;
      JobRoleName = jobRoleName;
    }

    public int JobRoleId { get; set; }

    public string JobRoleName { get; set; }
  }
}