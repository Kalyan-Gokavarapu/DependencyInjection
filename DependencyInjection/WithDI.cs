using System;
using System.Reflection;

namespace WithDependencyInjection
{
  class WithDI
  {
    public void Run()
    {
      UserInterface UI = new UserInterface();
      UI.render();
      Console.Read();
    }
  }

  public class UserInterface
  {
    public void render()
    {
      Console.ReadLine();
      var method = MethodBase.GetCurrentMethod();
      Console.Write("Please enter your Username:");
      var username = Console.ReadLine();
      Console.Write("Please enter the password:");
      var password = Console.ReadLine();
      Business BL = new Business();
      Console.WriteLine("UI: Done collecting Username & Password :{0}.{1}", method.ReflectedType.FullName, method.Name);
      BL.signUp(username, password);      
    }   
    
  }

  public class Business
  {
    public void signUp(string userName, string Password)
    {
      var method = MethodBase.GetCurrentMethod();
      //Validation
      DataAccess DL = new DataAccess();
      Console.WriteLine("BL: Done Validating the User :{0}.{1}", method.ReflectedType.FullName, method.Name);
      DL.store(userName, Password);
    }
  }

  public class DataAccess
  {
    // Insert/Update DB
    public void store(string userName, string password)
    {
      var method = MethodBase.GetCurrentMethod();
      Console.WriteLine("DA: Done Updating the SQL db :{0}.{1}", method.ReflectedType.FullName, method.Name);
    }
  }
}
