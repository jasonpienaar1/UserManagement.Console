public class AddUser
{
  public string AddFirstName()
  {
    bool validEntry = false;
    string response = "Valid name enetered.";
    string firstName;
    while (!validEntry)
    {
      string? readResult = Console.ReadLine();
      readResult = readResult.Trim();
      readResult = readResult.ToLower();
      validEntry = readResult == "" ? false : true;
      response = validEntry == true ? $"{readResult} is a valid name" : response = "Enter a valid name.";
      firstName = readResult;
      Console.WriteLine(response);
    }

    return response;
  }

  public string AddLastName()
  {
    bool validEntry = false;
    string response = "Valid name enetered.";
    string? lastName;
    while (!validEntry)
    {
      string? readResult = Console.ReadLine();
      readResult = readResult.Trim();
      readResult = readResult.ToLower();
      validEntry = readResult == "" ? false : true;
      response = validEntry ? $"{readResult} is a valid name" : response = "Enter a valid name.";
      lastName = readResult;
      Console.WriteLine(response);
    }

    return response;
  }
}
