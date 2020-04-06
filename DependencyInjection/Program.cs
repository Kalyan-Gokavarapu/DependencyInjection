using System;
using System.Collections.Generic;
using System.Text;
using WithDependencyInjection;
using WithoutDependencyInjection;

namespace DependencyInjection
{
  class Program
  {
    public static void Main(string[] args)
    {
      WithDI DI = new WithDI();
      DI.Run();

      WithoutDI NoDI = new WithoutDI();
      NoDI.Run();
    }
  }
}
