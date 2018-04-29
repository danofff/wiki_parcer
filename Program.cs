using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace wiki_parcer
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "https://ru.wikipedia.org/wiki/%D0%92%D0%BE%D0%BB%D0%BE%D1%88%D0%B8%D0%BD,_%D0%9C%D0%B0%D0%BA%D1%81%D0%B8%D0%BC%D0%B8%D0%BB%D0%B8%D0%B0%D0%BD_%D0%90%D0%BB%D0%B5%D0%BA%D1%81%D0%B0%D0%BD%D0%B4%D1%80%D0%BE%D0%B2%D0%B8%D1%87";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            string name = doc.DocumentNode.SelectNodes("//table/tbody/tr/td").First().InnerText;
            Console.WriteLine(name);
            try
            {
                string birthDate = doc.DocumentNode.SelectNodes("//table/tbody/tr/td/p/span/a").First().InnerText + " "
              + doc.DocumentNode.SelectNodes("//table/tbody/tr/td/p/span/a").Elements().ElementAt(1).InnerText;
                Console.WriteLine(birthDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " " +"date birth parcing problem");
                
            }
          
            string birthPlace = doc.DocumentNode.SelectNodes("//table/tbody").Elements().ElementAt(3).SelectNodes("//td/p/span/a").First().InnerText;
            Console.WriteLine(birthPlace);
            Console.ReadLine();
        }
    }
}
