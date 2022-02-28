using OCR_4AL2_GR1.Application.Parser;
using OCR_4AL2_GR1.CliEngine;
using OCR_4AL2_GR1.Parser.OcrConfigurations;
using System.IO;
using Xunit;

namespace OCR_Testing
{
    public class ConsoleEngineTests
    {
        private readonly ConsoleCommandHandler consoleCommandHandler;
        private readonly string ocrSamplesFolderPath;

        public ConsoleEngineTests()
        {
            this.consoleCommandHandler = new ConsoleCommandHandler(OcrParser.Of(new Ocr4x3Number()));
            this.ocrSamplesFolderPath = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.ToString();
        }

        [Fact]
        public void TEST()
        {
            this.consoleCommandHandler.Handle(new string[] { this.ocrSamplesFolderPath, "merged" });
        }
    }
}
