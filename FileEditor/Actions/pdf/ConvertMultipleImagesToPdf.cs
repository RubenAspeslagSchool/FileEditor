using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.IO;

namespace FileEditor.Actions
{
    public class ConvertMultipleImagesToPdf : IAction
    {
        public string Name { get; init; } = "Convert Multiple Images to PDF";
        public string Description { get; init; } = "Converts multiple images (PNG, JPG) into a single PDF.";
        public string Verb { get; init; } = "convertmultimagetopdf";

        public void Execute(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Usage: convertmultimagetopdf <outputPdfFile.pdf> <inputImage1> <inputImage2> ...");
                return;
            }

            string outputPdfPath = args[1];
            string[] inputImagePaths = args[2..];

            try
            {
                using (PdfDocument pdf = new PdfDocument())
                {
                    foreach (var imagePath in inputImagePaths)
                    {
                        if (!File.Exists(imagePath))
                        {
                            Console.WriteLine($"Image file '{imagePath}' does not exist.");
                            continue;
                        }

                        PdfPage page = pdf.AddPage();
                        XGraphics graphics = XGraphics.FromPdfPage(page);
                        XImage image = XImage.FromFile(imagePath);

                        page.Width = image.PixelWidth * 72 / image.HorizontalResolution;
                        page.Height = image.PixelHeight * 72 / image.VerticalResolution;

                        graphics.DrawImage(image, 0, 0, page.Width, page.Height);
                    }

                    pdf.Save(outputPdfPath);
                    Console.WriteLine($"Multiple images converted to PDF successfully: {outputPdfPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during multiple image to PDF conversion: {ex.Message}");
            }
        }
    }
}
