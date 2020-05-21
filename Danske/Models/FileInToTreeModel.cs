using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Danske.Models
{
    /// <summary>
    /// Configure text file into binary tree
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FileInToTreeModel<T> : IModelLoader<T>
    {
        /// <summary>
        /// File address
        /// </summary>
        public string FileName { get; }

        public FileInToTreeModel(string fileName)
        {
            FileName = fileName;
        }
        
        /// <summary>
        /// Build binary tree object
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"> Empty file exception </exception>
        public IRoot<T> ConfigureRoot()
        {
            using (var reader = new StreamReader(FileName))
            {
                var firstLine = reader.ReadLine();
                if (firstLine == null)
                {
                    throw new Exception($"The file {FileName} is empty");
                }

                var root = ParseFileFromLine(firstLine, reader).Single();
                var model = new Root<T>(root);
                return model;
            }
        }

        /// <summary>
        /// Parsing text file one line at a time
        /// </summary>
        /// <param name="line"> String containing one line in the specified text file </param>
        /// <param name="reader"></param>
        /// <returns> Binary tree nodes </returns>
        private IChild<T>[] ParseFileFromLine(string line, TextReader textReader)
        {
            var values = ParseLine(line);
            var lineBelow = textReader.ReadLine();
            if (lineBelow == null)
            {
                // No lines below
                var nodes = values.Select(o => new Child<T>(o, new IChild<T>[] { }));
                return nodes.ToArray();
            }
            else
            {
                var nodesBelow = ParseFileFromLine(lineBelow, textReader);
                var nodes = new IChild<T>[nodesBelow.Length -
                                          1]; // Remember, there is one more node in the row below this.

                {
                    var i = 0;
                    foreach (var value in values)
                    {
                        nodes[i] = new Child<T>(value, new IChild<T>[] {nodesBelow[i], nodesBelow[i + 1]});
                        i++;
                    }
                }

                return nodes;
            }
        }

        /// <summary>
        /// Extract type T values from the string 
        /// </summary>
        /// <param name="line"> text line </param>
        /// <returns> List of values </returns>
        private IEnumerable<T> ParseLine(string line)
        {
            var values = line.Split(' ')
                .Select(e => (T) Convert.ChangeType(e, typeof(T)));
            return values;
        }
    }
}