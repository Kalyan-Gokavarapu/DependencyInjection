using System;
using System.Collections.Generic;
using System.Text;
using WithDependencyInjection;
using WithoutDependencyInjection;
using ConstructorInjection;

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
      WithDI WithDependencyInjection = new WithDI();
      WithDependencyInjection.Run();
    }
  }
}
