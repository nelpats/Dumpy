using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;



public class Logger
    {
      public static void Log(string input)
      {
        Console.WriteLine($"> {input}", Color.WhiteSmoke);
      }
      public static void LogError(string input)
      {
        Console.WriteLine($"# {input}", Color.IndianRed);   
      }
    }

