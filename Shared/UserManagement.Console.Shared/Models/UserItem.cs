using System.Text.RegularExpressions;

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

    public UserItem(int userId)
    {
      UserId = userId;
    }

    public int UserId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string DateOfBrith { get; set; }

    public string EmailAddress { get; set; }

    public int PhoneNumber { get; set; }

    public string AddFirstName()
    {
      bool validEntry = false;
      string response = "Valid name enetered.";
      while (!validEntry)
      {
        string? readResult = System.Console.ReadLine();
        readResult = readResult.Trim();
        validEntry = readResult == "" ? false : true;
        response = validEntry == true ? $"{readResult} is a valid name" : response = "Enter a valid name.";
        FirstName = readResult;
        System.Console.WriteLine(response);
      }

      return FirstName;
    }

    public string AddLastName()
    {
      bool validEntry = false;
      string response = "Valid name enetered.";
      while (!validEntry)
      {
        string? readResult = System.Console.ReadLine();
        readResult = readResult.Trim();
        validEntry = readResult == "" ? false : true;
        response = validEntry ? $"{readResult} is a valid name" : response = "Enter a valid name.";
        LastName = readResult;
        System.Console.WriteLine(response);
      }

      return LastName;
    }

    public string AddDateOfBirth()
    {
      DateTime date = DateTime.Now;
      bool validEntry = false;
      string response = "Invalid date enetered.";
      while (!validEntry)
      {
        string? readResult = System.Console.ReadLine();
        validEntry = readResult == "" ? false : true;
        if (DateTime.TryParse(readResult, out date))
        {
          string datePartOnly = date.ToShortDateString();
          DateOfBrith = datePartOnly;
          response = "Valid date entered";
        }

        System.Console.WriteLine(response);
        if (response != "Valid date entered")
        {
          validEntry = false;
        }
      }

      return DateOfBrith;
    }
    public string AddEmailAddress()
    {
      bool validEntry = false;
      string response = "Invalid email address";
      string pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
      while (!validEntry)
      {
        string? readResult = System.Console.ReadLine();
        readResult = readResult.Trim();
        validEntry = readResult == "" ? false : true;

        if (Regex.Match(readResult, pattern).Success)
        {
          validEntry = true;
          response = $"{readResult} is a valid email address";
          EmailAddress = readResult;
        }

        if (response == "Invalid email address")
        {
          validEntry = false;
        }

        System.Console.WriteLine(response);
      }

      return EmailAddress;
    }

    public int AddPhoneNumber()
    {
      bool validEntry = false;
      string response = "Invalid phone number.";
      while (!validEntry)
      {
        string? readResult = System.Console.ReadLine();
        readResult = readResult.Trim();
        try
        {
          int phoneNumber = int.Parse(readResult);
          validEntry = readResult == "" ? false : true;
          if (readResult.Length == 10)
          {
            validEntry = true;
            response = $"{phoneNumber} is a valid phone number";
            PhoneNumber = phoneNumber;
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

      return PhoneNumber;
    }
    public string AssignJobRole()
    {
      bool validEntry = false;
      string response = "Valid name enetered.";
      while (!validEntry)
      {
        string? readResult = System.Console.ReadLine();
        readResult = readResult.Trim();
        validEntry = readResult == "" ? false : true;
        int jobId = int.Parse(readResult);
        response = validEntry ? $"{readResult} is a valid name" : response = "Enter a valid name.";
        JobRoleId = jobId;
        System.Console.WriteLine(response);
      }

      return LastName;
    }
  }
}
