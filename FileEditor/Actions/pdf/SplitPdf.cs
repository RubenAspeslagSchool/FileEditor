using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;

namespace FileEditor.Actions
{
    public class SplitPdf : IAction
    {
        public string Name { get; init; } = "Split PDF File";
        public string Description { get; init; } = "Splits a PDF into individual pages as separate PDF files.";
        public string Verb { get; init; } = "splitpdf";

        public void Execute(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: splitpdf <inputFile>");
                return;
            }

            string inputFile = args[1];

            if (!File.Exists(inputFile))
            {
                Console.WriteLine($"Input file {inputFile} does not exist.");
                return;
            }

            try
            {
                PdfDocument inputPdf = PdfReader.Open(inputFile, PdfDocumentOpenMode.Import);
                for (int i = 0; i < inputPdf.PageCount; i++)
                {
                    using (PdfDocument outputPdf = new PdfDocument())
                    {
                        outputPdf.AddPage(inputPdf.Pages[i]);
                        string outputFileName = $"{Path.GetFileNameWithoutExtension(inputFile)}_Page_{i + 1}.pdf";
                        outputPdf.Save(outputFileName);
                        Console.WriteLine($"Saved {outputFileName}");
                    }
                }

                Console.WriteLine("PDF split successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while splitting the PDF: {ex.Message}");
            }
        }
    }
}
