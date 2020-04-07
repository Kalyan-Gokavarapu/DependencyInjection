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
      WithoutDI WithoutDependencyInjection = new WithoutDI();
      WithoutDependencyInjection.Run();

      ConstInjection ConstructorInjection = new ConstInjection();
      ConstructorInjection.Run();

      WithDI WithDependencyInjection = new WithDI();
      WithDependencyInjection.Run();
    }
  }
}
