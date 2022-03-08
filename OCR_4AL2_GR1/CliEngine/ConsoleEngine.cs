using OCR_4AL2_GR1.Application.Parser;
using System;
using System.Text.RegularExpressions;

namespace OCR_4AL2_GR1.CliEngine
{
    public class ConsoleEngine
    {
        private readonly ConsoleCommandHandler consoleCommandHandler;

        public ConsoleEngine(IOcrParser ocrParser)
        {
            this.consoleCommandHandler = new ConsoleCommandHandler(ocrParser);
        }

        public void Run()
        {
            Console.WriteLine(
                "Console engine started\n" +
                "Usage: OcrAbsoluteFolderOrFilePath, merged|sorted"
            );

            while (true)
            {
                Console.Write(" > ");

                string input = Console.ReadLine();
                input = this.FormatSpacesIn(input);
                string[] args = input.Split(",");

                this.consoleCommandHandler.Handle(args);
            }
        }

        private string FormatSpacesIn(string source)
        {
            return Regex.Replace(source, @"\s+", " ").Trim();
        }
    }
}
