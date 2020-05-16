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
      //WithoutDIMain WithoutDependencyInjection = new WithoutDIMain();
      //WithoutDependencyInjection.Run();


      //Constructure Injection
      //ConstructorInjection.IDataAccess da = new ConstructorInjection.DataAccessMongo();
      //ConstructorInjection.IBusiness bl = new ConstructorInjection.Business(da);
      //ConstructorInjection.IUserInterface ui = new ConstructorInjection.UserInterface(bl);
      //ConstInjectionMain CInjection = new ConstInjectionMain(ui);
      //CInjection.Run();

      // or      
      //ConstructorInjection.IUserInterface ui =
      //  new ConstructorInjection.UserInterface(
      //    new ConstructorInjection.Business(
      //      //new ConstructorInjection.DataAccess()
      //      new ConstructorInjection.DataAccessMongo()
      //    )
      //  );
      //ConstInjectionMain CInjection = new ConstInjectionMain(ui);
      //CInjection.Run();

      //Dependency Injection Container
      ServiceCollection collection = new ServiceCollection();
      //collection.AddScoped<WithDependencyInjection.IDataAccess, WithDependencyInjection.DataAccess>();
      collection.AddScoped<WithDependencyInjection.IUserInterface, WithDependencyInjection.UserInterface>();
      collection.AddScoped<WithDependencyInjection.IBusiness, WithDependencyInjection.BusinessMock>();
      collection.AddScoped<WithDependencyInjection.IDataAccess, WithDependencyInjection.DataAccess>();
      // just maintains a mapping
      // instances are not created until here
      
      var provider = collection.BuildServiceProvider();

      var userInterface = provider.GetService<WithDependencyInjection.IUserInterface>();
      // instance is created

      WithDI WithDInjection = new WithDI(userInterface);
      WithDInjection.Run();
    }
  }
}
