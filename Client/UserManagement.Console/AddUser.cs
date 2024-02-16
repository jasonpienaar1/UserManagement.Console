namespace UserManagement.Console
{
  internal class AddUser
  {
    public string AddFirstName(string firstName)
    {
      bool validEntry = false;
      // get species (cat or dog) - string animalSpecies is a required field 
      do
      {
        firstName = firstName.Trim();
        if (firstName != null)
        {
          firstName = firstName.ToLower();
          validEntry = firstName == "" ? false : true;
        }
      } while (validEntry == false);

      return "Name captured";
    }
  }
}
