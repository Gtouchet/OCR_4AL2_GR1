using OCR_4AL2_GR1.Application.Exceptions;
using OCR_4AL2_GR1.Application.Models;
using OCR_4AL2_GR1.Application.Parser;
using OCR_4AL2_GR1.CliEngine;
using OCR_4AL2_GR1.Parser.OcrConfigurations;

namespace OCR_4AL2_GR1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new ConsoleEngine(OcrParser.Of(new Ocr4x3Number())).Run();
        }
    }
}
