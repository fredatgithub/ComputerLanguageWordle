using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
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
      var computerLanguageListForWordle = new List<string>();
      computerLanguageList.AddRange(GetElements("ComputerLanguages.xml", "Language"));
      display("Computer language wordle");
      computerLanguageListForWordle.AddRange(GetRandomItems(computerLanguageList, 500));
      // TODO create the Wordle image from the computerLanguageListForWordle and save it to current directory
      // save several images and start a process to display them

      display("Press any key to exit: ");
      Console.ReadKey();
    }

    private static IEnumerable<string> GetRandomItems(List<string> itemList, int numberOfItems)
    {
      List<string>result = new List<string>();
      for (int j = 0; j < numberOfItems; j++)
      {
        result.Add(itemList[GenerateRandomNumberUsingCrypto(0, itemList.Count - 1)]);
      }

      return result;
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

    private static int GenerateRandomNumberUsingCrypto(int min, int max)
    {
      if (max >= 255)
      {
        max = 254;
      }

      int result;
      RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
      byte[] randomNumber = new byte[1];
      do
      {
        crypto.GetBytes(randomNumber);
        result = randomNumber[0];
      } while (result <= min || result >= max);
      return result;
    }
  }
}
