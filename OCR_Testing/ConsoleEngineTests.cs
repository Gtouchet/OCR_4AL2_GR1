using FluentAssertions;
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
        private readonly string ocrSamplePath;
        private readonly string ocrFolderSamplesPath;
        private readonly string corruptedOcrSamplePath;

        public ConsoleEngineTests()
        {
            this.consoleCommandHandler = new ConsoleCommandHandler(OcrParser.Of(new Ocr4x3Number()));

            string currentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.Parent + "\\OCR_Testing\\OcrSamples\\";
            this.ocrSamplePath = currentDirectory + "OcrSamples.ocr";
            this.ocrFolderSamplesPath = currentDirectory + "MultipleOcrSamples";
            this.corruptedOcrSamplePath = currentDirectory + "CorruptedOcrSample.ocr";
        }

        [Fact]
        public void Handle_FileNotFound()
        {
            ConsoleReturnCodes result = this.consoleCommandHandler.Handle(new string[] { "nonExistantPath", "SorTed" });

            result.Should().Be(ConsoleReturnCodes.FileNotFound);
        }

        [Fact]
        public void Handle_SingleFile_Success()
        {
            ConsoleReturnCodes result = this.consoleCommandHandler.Handle(new string[] { this.ocrSamplePath, "MerGeD" });

            result.Should().Be(ConsoleReturnCodes.Success);
        }

        [Fact]
        public void Handle_MultipleFile_Success()
        {
            ConsoleReturnCodes result = this.consoleCommandHandler.Handle(new string[] { this.ocrFolderSamplesPath, "Hello" });

            result.Should().Be(ConsoleReturnCodes.Success);
        }

        [Fact]
        public void Handle_SingleCorruptedFile_UnreadableFileContent()
        {
            ConsoleReturnCodes result = this.consoleCommandHandler.Handle(new string[] { this.corruptedOcrSamplePath, string.Empty });

            result.Should().Be(ConsoleReturnCodes.UnreadableFileContent);
        }
    }
}
