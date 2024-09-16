using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.PortableExecutable;

namespace FileEditor.Actions.pdf
{
    public class ConcatenatePdf : IAction
    {
        public string Name { get; init; } = "Concatenate PDF Files";
        public string Description { get; init; } = "Concatenates multiple PDF files into a single PDF.";
        public string Verb { get; init; } = "concatpdf";

        public void Execute(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: concatpdf <outputFileName> <inputFile1> <inputFile2> ...");
                return;
            }

            string outputFileName = args[1];
            var inputFiles = args[2..];

            try
            {
                using (PdfDocument outputPdf = new PdfDocument())
                {
                    foreach (var inputFile in inputFiles)
                    {
                        if (!File.Exists(inputFile))
                        {
                            Console.WriteLine($"Input file {inputFile} does not exist.");
                            return;
                        }

                        PdfDocument inputPdf = PdfReader.Open(inputFile, PdfDocumentOpenMode.Import);
                        for (int i = 0; i < inputPdf.PageCount; i++)
                        {
                            outputPdf.AddPage(inputPdf.Pages[i]);
                        }
                    }

                    outputPdf.Save(outputFileName);
                    Console.WriteLine($"PDFs concatenated successfully to {outputFileName}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during concatenation: {ex.Message}");
            }
        }
    }
}
