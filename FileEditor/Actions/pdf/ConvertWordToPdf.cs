using Aspose.Words;
using System;
using System.IO;
using System.Reflection.Metadata;

namespace FileEditor.Actions
{
    public class ConvertWordToPdf : IAction
    {
        public string Name { get; init; } = "Convert Word to PDF";
        public string Description { get; init; } = "Converts a Word (.docx) file to PDF.";
        public string Verb { get; init; } = "convertwordtopdf";

        public void Execute(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: convertwordtopdf <inputWordFile.docx> [outputPdfFile.pdf]");
                return;
            }

            string inputFilePath = args[1];
            string outputFilePath = args.Length > 2 ? args[2] : Path.ChangeExtension(inputFilePath, ".pdf");

            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine($"Input file '{inputFilePath}' does not exist.");
                return;
            }

            try
            {
                Document doc = new Document(inputFilePath);
                doc.Save(outputFilePath);
                Console.WriteLine($"Word document converted to PDF successfully: {outputFilePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during Word to PDF conversion: {ex.Message}");
            }
        }
    }
}
