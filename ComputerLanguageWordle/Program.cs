using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ComputerLanguageWordle
{
  internal static class Program
  {
    private static void Main()
    {
      Action<string> display = Console.WriteLine;
      var computerLanguageList = new List<string>();
      computerLanguageList.AddRange(GetElements("ComputerLanguages.xml", "language"));

      display("Computer language wordle");

      display("Press any key to exit: ");
      Console.ReadKey();
    }

    private static IEnumerable<string> GetElements(string fileName, string tag)
    {
      IEnumerable<string> result = new List<string>();
      if (string.IsNullOrEmpty(fileName))
      {
        return result;
      }

      try
      {
        

      }
      catch (Exception exception)
      {
        Console.WriteLine($"An error occured: {exception.Message}");
        return result;
      }

      return result;
    }
  }
}