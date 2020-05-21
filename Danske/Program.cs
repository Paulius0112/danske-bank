using System;
using Danske.Models;

namespace Danske
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // Change the path of the text file
                var load = new FileInToTreeModel<int>(
                    "/Users/pauliusgasp/Desktop/Danske/Danske/test.txt");
            
                var model = load.ConfigureRoot();
                var maxPath = Calculation.FindMaxPath(model, (child, child1) => child.Value % 2 != child1.Value % 2,
                    out string path);
                Console.WriteLine($"Max sum: {maxPath}");
                Console.WriteLine($"Path: {path}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}