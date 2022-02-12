using FluentAssertions;
using OCR_4AL2_GR1.Application.Exceptions;
using OCR_4AL2_GR1.Application.Parser;
using OCR_4AL2_GR1.OcrConfigurations;
using System;
using Xunit;

namespace OCR_Testing
{
    public class DataParserTests
    {
        private readonly IDataParser dataParser;

        public DataParserTests()
        {
            this.dataParser = DataParser.Of(new Ocr4x3Number());
        }

        [Fact]
        public void UnreadableEntry_Line2TooLong()
        {
            string[] entries = new string[4]
            {
                "    _  _  _  _  _  _  _  _ ",
                "|_||_   ||_ | ||_|| || || |  _||",
                "  | _|  | _||_||_||_||_||_|",
                "                           ",
            };

            Action action = () => this.dataParser.Parse(entries);

            action.Should().Throw<UnreadableEntryException>().WithMessage("Error: unreadable entry at line 2");
        }

        [Fact]
        public void UnreadableEntry_Line4TooShort()
        {
            string[] entries = new string[4]
            {
                "    _  _  _  _  _  _  _  _ ",
                "|_||_   ||_ | ||_|| || || |",
                "  | _|  | _||_||_||",
                "                           ",
            };

            Action action = () => this.dataParser.Parse(entries);

            action.Should().Throw<UnreadableEntryException>().WithMessage("Error: unreadable entry at line 3");
        }

        [Fact]
        public void UnreadableEntry_NotEnoughLinesToCompleteAnEntry()
        {
            string[] entries = new string[6]
            {
                "    _  _  _  _  _  _  _  _ ",
                "|_||_   ||_ | ||_|| || || |",
                "  | _|  | _||_||_||_||_||_|",
                "                           ",
                "    _  _  _  _  _  _  _  _ ",
                "|_||_   ||_ | ||_|| || || |",
            };

            Action action = () => this.dataParser.Parse(entries);

            action.Should().Throw<UnreadableEntryException>().WithMessage("Error: unreadable entry at line 5");
        }

        [Fact]
        public void ReadableEntry()
        {
            string[] entries = new string[4]
            {
                "    _  _  _  _  _  _  _  _ ",
                "|_||_   ||_ | ||_|| || || |",
                "  | _|  | _||_||_||_||_||_|",
                "                           ",
            };

            this.dataParser.Parse(entries).ToList().Count.Should().Be(1);
        }
    }
}
