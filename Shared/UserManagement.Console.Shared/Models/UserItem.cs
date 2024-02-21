using System.Text.RegularExpressions;

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
      do
      {
        readResult = System.Console.ReadLine();
        readResult = readResult.Trim();
        validEntry = string.IsNullOrEmpty(readResult);

        var response = !validEntry ? $"{readResult} is a valid first name" : $"{readResult} is not a valid first name. Enter a valid first name.";
        System.Console.WriteLine(response);
      }
      while (validEntry);
      this.FirstName = readResult;

      return this.FirstName;
    }

    public string AddLastName()
    {
      var validEntry = true;
      var readResult = " ";
      while (!validEntry)
      {
        readResult = System.Console.ReadLine();
        readResult = readResult.Trim();
        validEntry = string.IsNullOrEmpty(readResult);

        var response = validEntry ? $"{readResult} is a valid last name" : $"{readResult} is not a valid last name. Enter a valid last name.";
        System.Console.WriteLine(response);
      }

      this.LastName = readResult;
      return this.LastName;
    }

    public string AddDateOfBirth()
    {
      var date = DateTime.Now;
      var validEntry = false;
      var response = "Invalid date enetered.";
      while (!validEntry)
      {
        var readResult = System.Console.ReadLine();
        validEntry = readResult == "" ? false : true;
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
      }

      return this.DateOfBrith;
    }

    public string AddEmailAddress()
    {
      var validEntry = false;
      var response = "Invalid email address";
      var pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
      while (!validEntry)
      {
        var readResult = System.Console.ReadLine();
        readResult = readResult.Trim();
        validEntry = readResult == "" ? false : true;

        if (Regex.Match(readResult, pattern).Success)
        {
          validEntry = true;
          response = $"{readResult} is a valid email address";
          this.EmailAddress = readResult;
        }

        if (response == "Invalid email address")
        {
          validEntry = false;
        }

        System.Console.WriteLine(response);
      }

      return this.EmailAddress;
    }

    public int AddPhoneNumber()
    {
      var validEntry = false;
      var response = "Invalid phone number.";
      while (!validEntry)
      {
        var readResult = System.Console.ReadLine();
        readResult = readResult.Trim();
        try
        {
          var phoneNumber = int.Parse(readResult);
          validEntry = readResult == "" ? false : true;
          if (readResult.Length == 10)
          {
            validEntry = true;
            response = $"{phoneNumber} is a valid phone number";
            this.PhoneNumber = phoneNumber;
          }
        }
        catch (Exception e)
        {
          System.Console.Error.WriteLine(e);
        }

        if (response == "Invalid phone number.")
        {
          validEntry = false;
        }
      }

      return (int)this.PhoneNumber;
    }

    public string AssignJobRole()
    {
      var validEntry = false;
      var response = "Valid name enetered.";
      while (!validEntry)
      {
        var readResult = System.Console.ReadLine();
        readResult = readResult.Trim();
        validEntry = readResult == "" ? false : true;
        var jobId = int.Parse(readResult);
        response = validEntry ? $"{readResult} is a valid name" : response = "Enter a valid name.";
        this.JobRoleId = jobId;
        System.Console.WriteLine(response);
      }

      return this.JobRoleName;
    }
  }
}
