using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEditor.Actions
{
    public class CreateFile : IAction
    {
        public string Name { get; init; } = "create file";
        public string Description { get; init; } = "creates a file";
        public string Verb { get; init; } = "CreateFile";

        public void Execute(string[] args)
        {
            string fileName = args.Length > 1 ? args[1] : null;
            string content = args.Length > 2 ? args[2] : "";
            try
            {
                // Check if file already exists
                if (File.Exists(fileName))
                {
                    Console.WriteLine($"File '{fileName}' already exists.");
                }
                else
                {
                    // Create the file
                    File.WriteAllText(fileName, content); 
                    Console.WriteLine($"File '{fileName}' created successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while creating the file: {ex.Message}");
            }
        }
    }
}
