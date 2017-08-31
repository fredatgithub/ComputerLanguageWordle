using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace ComputerLanguageWordle
{
  internal static class Program
  {
    private static void Main()
    {
      Action<string> display = Console.WriteLine;
      var computerLanguageList = new List<string>();
      computerLanguageList.AddRange(GetElements("ComputerLanguages.xml", "Language"));
      display("Computer language wordle");


      display("Press any key to exit: ");
      Console.ReadKey();
    }

    private static IEnumerable<string> GetElements(string fileName, string tag)
    {
      List<string> result = new List<string>();
      if (string.IsNullOrEmpty(fileName))
      {
        return result;
      }

      XmlDocument xmlDoc = new XmlDocument();
      try
      {
        xmlDoc.Load(fileName);
      }
      catch (Exception exception)
      {
        Console.WriteLine($"Error while loading the XML file: {fileName}");
        Console.WriteLine($"The exception is {exception.Message}");
        return result;
      }

      XmlNodeList elementList = xmlDoc.GetElementsByTagName(tag);
      for (int i = 0; i < elementList.Count; i++)
      {
        result.Add(elementList[i].InnerText);
      }

      elementList = null;
      xmlDoc = null;
      return result;
    }
  }
}