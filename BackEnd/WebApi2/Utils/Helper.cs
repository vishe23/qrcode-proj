using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using WebApi2.Models;

namespace WebApi2.Utils
{
    internal class Helper
    {
        public static List<DataModel> ParseXml(string inputFilePath)
        {
            var xmlDoc = XElement.Load(inputFilePath);

            var elements = xmlDoc.Descendants("element").Select(element => new DataModel
            {
                Id = Convert.ToInt32(element.Element("id")?.Value),
                Title = element.Element("title")?.Value,
                Url = element.Element("url")?.Value
            });

            return elements.ToList();
        }
    }
}