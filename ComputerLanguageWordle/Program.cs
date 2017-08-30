using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;

namespace ComputerLanguageWordle
{
  internal static class Program
  {
    private static void Main()
    {
      Action<string> display = Console.WriteLine;
      var computerLanguageList = new List<string>();
      computerLanguageList.AddRange(GetElements("ComputerLanguages.xml", "Languages"));

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
        result = ParseXmlToList(fileName, tag);

      }
      catch (Exception exception)
      {
        Console.WriteLine($"An error occured: {exception.Message}");
        return result;
      }

      return result;
    }

    private static IEnumerable<string> ParseXmlToList(string fileName, string firstXmlTag)
    {
      var result = new List<string>();
      using (var reader = XmlReader.Create(new StringReader(fileName)))
      {
        reader.ReadToFollowing(firstXmlTag);
        string genre = reader.Value;
        result.Add(genre);
      }

      return result;
    }
  }
}