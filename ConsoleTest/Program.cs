using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Parser.Entities;
using Parser.Helpers;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new Parser.Parser(@"C:\Users\Pavel_Davidouski\Desktop\T100.config");
            
            parser.AddToConfigFile(new Element
                                       {
                                           UsedPackages = new List<string> { "T100_Standard_Life" },
                                           FormName = "PASHA"
                                       });
        }
    }
}
