using System;
using System.Reflection;

namespace WithDependencyInjection
{

  #region interfaces

  public interface IUserInterface
  {
    void render();
  }
  public interface IBusiness
  {
    void signUp(string userName, string Passwor);
  }
  public interface IDataAccess
  {
    void store(string userName, string password);
  }

  #endregion

  class WithDI
  {
    private IUserInterface _ui;
    public WithDI(IUserInterface ui)
    {
      this._ui = ui;
    }
    public void Run()
    {
      //UserInterface UI = new UserInterface();
      _ui.render();
      Console.Read();
    }
  }

  public class UserInterface : IUserInterface
  {
    private IBusiness _bl;
    public UserInterface(IBusiness bl)
    {
      this._bl = bl;
    }
    public void render()
    {
      Console.ReadLine();
      var method = MethodBase.GetCurrentMethod();
      Console.Write("Please enter your Username:");
      var username = Console.ReadLine();
      Console.Write("Please enter the password:");
      var password = Console.ReadLine();
      //Business BL = new Business();
      Console.WriteLine("UI: Done collecting Username & Password :{0}.{1}", method.ReflectedType.FullName, method.Name);
      _bl.signUp(username, password);
    }

  }

  public class Business : IBusiness
  {
    private IDataAccess _da;
    public Business(IDataAccess da)
    {
      this._da = da;
    }
    public void signUp(string userName, string Password)
    {
      var method = MethodBase.GetCurrentMethod();
      //Validation
      //IDataAccess DL = new DataAccess();
      Console.WriteLine("BL: Done Validating the User :{0}.{1}", method.ReflectedType.FullName, method.Name);
      _da.store(userName, Password);
    }
  }

  public class DataAccess : IDataAccess
  {
    // Insert/Update DB
    public void store(string userName, string password)
    {
      var method = MethodBase.GetCurrentMethod();
      Console.WriteLine("DA: Done Updating the SQL db :{0}.{1}", method.ReflectedType.FullName, method.Name);
    }
  }

  public class DataAccessMongo : IDataAccess
  {
    // Insert/Update DB
    public void store(string userName, string password)
    {
      var method = MethodBase.GetCurrentMethod();
      Console.WriteLine("DA: Done Updating the Mongo db :{0}.{1}", method.ReflectedType.FullName, method.Name);
    }
  }
}
