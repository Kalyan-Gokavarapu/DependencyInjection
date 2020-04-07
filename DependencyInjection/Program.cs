using System;
using System.Collections.Generic;
using System.Text;
using WithDependencyInjection;
using WithoutDependencyInjection;
using ConstructorInjection;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
  class Program
  {
    public static void Main(string[] args)
    {
      //Crude way
      WithoutDI WithoutDependencyInjection = new WithoutDI();
      WithoutDependencyInjection.Run();


      //Constructure Injection
      //ConstructorInjection.DataAccess da = new ConstructorInjection.DataAccess();
      //ConstructorInjection.Business bl = new ConstructorInjection.Business(da);
      //ConstructorInjection.UserInterface ui = new ConstructorInjection.UserInterface(bl);
      // or      
      ConstructorInjection.IUserInterface ui = 
        new ConstructorInjection.UserInterface(
          new ConstructorInjection.Business(
            //new ConstructorInjection.DataAccess()
            new ConstructorInjection.DataAccessMongo()
          )
        );
      ConstInjection CInjection = new ConstInjection(ui);
      CInjection.Run();

      //Dependency Injection Container
      ServiceCollection collection = new ServiceCollection();
      //collection.AddScoped<WithDependencyInjection.IDataAccess, WithDependencyInjection.DataAccess>();
      collection.AddScoped<WithDependencyInjection.IUserInterface, WithDependencyInjection.UserInterface>();
      collection.AddScoped<WithDependencyInjection.IBusiness, WithDependencyInjection.Business>();
      collection.AddScoped<WithDependencyInjection.IDataAccess, WithDependencyInjection.DataAccessMongo>();
      
      var provider = collection.BuildServiceProvider();
      var userInterface =provider.GetService<WithDependencyInjection.IUserInterface>();
      WithDI WithDInjection = new WithDI(userInterface);
      WithDInjection.Run();
    }
  }
}
