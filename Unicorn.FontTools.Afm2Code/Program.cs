using CommandLine;
using System;
using System.IO;
using Unicorn.FontTools.Afm;

namespace Unicorn.FontTools.Afm2Code
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(o =>
                {
                    ClassCoder coder = new ClassCoder(o.NameSpace, o.ClassName);
                    using StreamWriter writer = new StreamWriter(o.Output);
                    writer.Write(coder.OutputStart(args));
                    foreach (string input in args)
                    {
                        using StreamReader reader = new StreamReader(input);
                        AfmFontMetrics metrics = AfmFontMetrics.FromReader(reader);
                        foreach (string line in FontMetricsCoder.PropertyCoder(metrics, SafeFontName(metrics.FontName), input, 8))
                        {
                            writer.WriteLine(line);
                        }
                        reader.Close();
                    }
                    writer.Write(coder.OutputEnd());
                    writer.Close();
                })
                .WithNotParsed(o => Environment.Exit(1));
        }

        private static string SafeFontName(string fn)
        {
            return fn.Replace("-", "", StringComparison.InvariantCulture);
        }
    }
}
