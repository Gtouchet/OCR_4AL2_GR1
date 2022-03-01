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
                "Usage: OcrAbsoluteFolderOrFilePath merged|sorted"
            );

            while (true)
            {
                Console.Write(" > ");

                string[] args = Regex.Replace(Console.ReadLine().Trim(), @"\s+", " ").Split(",");

                this.consoleCommandHandler.Handle(args);
            }
        }
    }
}
