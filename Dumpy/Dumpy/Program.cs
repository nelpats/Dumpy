using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using Console = Colorful.Console;
using dnlib.DotNet;
using System.Diagnostics;

namespace Dumpy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Dumpy by Prometheo#6510";
            Stopwatch sWatch = new Stopwatch();
            if (args.Length < 1) { Logger.LogError("Invalid argument !"); Console.Read(); Environment.Exit(0); }
            ModuleImport mImport = new ModuleImport();
            Color whitesmoke = Color.WhiteSmoke;
            Console.WriteAscii("        Dumpy", whitesmoke);
            Logger.Log("Looking for .NET Assembly");
            mImport.path = args[0];
            ModuleDefMD module = ModuleDefMD.Load(mImport.path);
            Logger.Log("Assembly Loaded");
            sWatch.Start();
            Logger.Log("Decoding Assembly");
            Maths.MathsDecoder.Decode(module);
            Logger.Log("Assembly Decoded");
            sWatch.Stop();
            Logger.Log($"Work done in {sWatch.ElapsedMilliseconds} ms");
            Logger.Log("Saving Module");
            module.Write($@"{Environment.CurrentDirectory}\Decoded.exe");
            Logger.Log("Module Saved");
            Console.Read();
            
          
        }
    }
}
