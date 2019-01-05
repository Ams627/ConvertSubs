using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertSubs
{
    internal class Program
    {
        private static void Main(string[] args)
        {   
            try
            {
                if (args.Length == 0)
                {
                    throw new Exception("You must supply one or more subtitle files to convert to UTF-8");
                }

                foreach (var filename in args)
                {
                    var outputfile = filename + ".utf8";
                    var content = File.ReadAllText(filename, Encoding.Default);
                    File.WriteAllText(filename, content, Encoding.UTF8);
                }

            }
            catch (Exception ex)
            {
                var codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
                var progname = Path.GetFileNameWithoutExtension(codeBase);
                Console.Error.WriteLine(progname + ": Error: " + ex.Message);
            }

        }
    }
}
