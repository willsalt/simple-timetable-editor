using System;
using System.IO;
using Unicorn.FontTools.Afm;

namespace Unicorn.FontTools.Afm2Code
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ns = "Unicorn.FontTools.Afm";
            const string cn = "StandardFontMetrics";
            const string outputFile = "output.cs";

            ClassCoder coder = new ClassCoder(ns, cn);
            using StreamWriter writer = new StreamWriter(outputFile);
            writer.Write(coder.OutputStart(args));
            foreach (string input in args)
            {
                using StreamReader reader = new StreamReader(input);
                AfmFontMetrics metrics = AfmFontMetrics.FromReader(reader);
                foreach (string line in FontMetricsCoder.PropertyCoder(metrics, SafeFontName(metrics.FontName), 8))
                {
                    writer.WriteLine(line);
                }
                reader.Close();
            }
            writer.Write(coder.OutputEnd());
            writer.Close();
        }

        private static string SafeFontName(string fn)
        {
            return fn.Replace("-", "");
        }
    }
}
