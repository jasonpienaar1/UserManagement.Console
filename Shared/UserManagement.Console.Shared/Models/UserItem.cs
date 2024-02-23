﻿using System.Text.RegularExpressions;

namespace UserManagement.Console.Shared.Models
{
  public class UserItem : JobRole
  {
    public UserItem(int userId, string firstName, string lastName, string dateOfBrith, string emailAddress, int phoneNumber, int? jobRoleId = null, string? jobRoleName = "")

    {
      this.UserId = userId;
      this.FirstName = firstName;
      this.LastName = lastName;
      this.DateOfBrith = dateOfBrith;
      this.EmailAddress = emailAddress;
      this.PhoneNumber = phoneNumber;
      this.JobRoleId = jobRoleId;
      this.JobRoleName = jobRoleName;
    }

    public UserItem(int userId)
    {
      this.UserId = userId;
    }

    public int? UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? DateOfBrith { get; set; }

    public string? EmailAddress { get; set; }

    public int? PhoneNumber { get; set; }

    public string AddFirstName()
    {
      var validEntry = true;
      var readResult = " ";
      var response = "";
      do
      {
        readResult = System.Console.ReadLine();
        readResult = readResult.Trim();
        validEntry = !string.IsNullOrEmpty(readResult);

        response = validEntry ? $"{readResult} is a valid first name" : $"{readResult} is not a valid first name. Enter a valid first name.";
        System.Console.WriteLine(response);
      }
      while (!validEntry);
      this.FirstName = readResult;

      return this.FirstName;
    }

    public string AddLastName()
    {
      var validEntry = true;
      var readResult = " ";
      do
      {
        readResult = System.Console.ReadLine();
        readResult = readResult.Trim();
        validEntry = !string.IsNullOrEmpty(readResult);

        var response = validEntry ? $"{readResult} is a valid last name" : $"{readResult} is not a valid last name. Enter a valid last name.";
        System.Console.WriteLine(response);
      }
      while (!validEntry);

      this.LastName = readResult;
      return this.LastName;
    }

    public string AddDateOfBirth()
    {
      var date = DateTime.Now;
      var validEntry = true;
      var response = "Invalid date of birth enetered. Please enter a valid date of brith(mm/dd/yyyy)";
      do
      {
        var readResult = System.Console.ReadLine();
        validEntry = !string.IsNullOrEmpty(readResult);
        if (DateTime.TryParse(readResult, out date))
        {
          var datePartOnly = date.ToShortDateString();
          this.DateOfBrith = datePartOnly;
          response = "Valid date entered";
        }

        System.Console.WriteLine(response);
        if (response != "Valid date entered")
        {
          validEntry = false;
        }
      } while (!validEntry);

      return this.DateOfBrith;
    }

    public string AddEmailAddress()
    {
      var validEntry = true;
      var response = " ";
      var pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
      do
      {
        var readResult = System.Console.ReadLine();
        readResult = readResult.Trim();
        validEntry = !string.IsNullOrEmpty(readResult);

        if (Regex.Match(readResult, pattern).Success)
        {
          validEntry = true;
          response = $"{readResult} is a valid email address";
          this.EmailAddress = readResult;
        }
        else
        {
          validEntry = false;
          response = "Invalid email address";
        }

        System.Console.WriteLine(response);
      }
      while (!validEntry);

      return this.EmailAddress;
    }

    public int AddPhoneNumber()
    {
      var validEntry = true;
      var response = " ";
      do
      {
        var readResult = System.Console.ReadLine();
        readResult = readResult.Trim();
        try
        {
          validEntry = !string.IsNullOrWhiteSpace(readResult);
          var phoneNumber = int.Parse(readResult);
          if (readResult.Length == 10)
          {
            validEntry = true;
            response = $"{phoneNumber} is a valid phone number";
            this.PhoneNumber = phoneNumber;
          }
          else
          {
            System.Console.WriteLine("Invalid phone number entered. Please enter a valid number of 10 digits.");
            validEntry = false;
          }
        }
        catch (Exception e)
        {
          System.Console.WriteLine("Invalid phone number entered. Please enter a valid number of 10 digits.");
          validEntry = false;
        }
      } while (!validEntry);

      return (int)this.PhoneNumber;
    }

    public int? AssignJobRole(int numOfJobRoles)
    {
      var validEntry = true;
      var readResult = " ";
      do
      {
        readResult = System.Console.ReadLine();
        validEntry = !string.IsNullOrWhiteSpace(readResult);
        readResult = readResult.Trim();

        if (!int.TryParse(readResult, out var option) || option > numOfJobRoles - 1)
        {
          validEntry = false;
        }
        else
        {
          this.JobRoleId = option;
        }

        var response = validEntry ? $"{readResult} is a valid Job role." : "Job role not valid. Enter a valid Job role.";
        System.Console.WriteLine(response);
      }
      while (!validEntry);
      return this.JobRoleId;
    }
  }
}
