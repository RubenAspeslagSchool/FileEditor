using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.IO;

namespace FileEditor.Actions
{
    public class ConvertImageToPdf : IAction
    {
        public string Name { get; init; } = "Convert Image to PDF";
        public string Description { get; init; } = "Converts a single image (PNG, JPG) to PDF.";
        public string Verb { get; init; } = "convertimagetopdf";

        public void Execute(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: convertimagetopdf <inputImageFile> [outputPdfFile.pdf]");
                return;
            }

            string inputImagePath = args[1];
            string outputPdfPath = args.Length > 2 ? args[2] : Path.ChangeExtension(inputImagePath, ".pdf");

            if (!File.Exists(inputImagePath))
            {
                Console.WriteLine($"Input image file '{inputImagePath}' does not exist.");
                return;
            }

            try
            {
                using (PdfDocument pdf = new PdfDocument())
                {
                    PdfPage page = pdf.AddPage();
                    XGraphics graphics = XGraphics.FromPdfPage(page);
                    XImage image = XImage.FromFile(inputImagePath);

                    page.Width = image.PixelWidth * 72 / image.HorizontalResolution;
                    page.Height = image.PixelHeight * 72 / image.VerticalResolution;

                    graphics.DrawImage(image, 0, 0, page.Width, page.Height);
                    pdf.Save(outputPdfPath);

                    Console.WriteLine($"Image converted to PDF successfully: {outputPdfPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during image to PDF conversion: {ex.Message}");
            }
        }
    }
}
