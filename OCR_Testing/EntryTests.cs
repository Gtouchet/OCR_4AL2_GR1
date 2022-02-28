using FluentAssertions;
using OCR_4AL2_GR1.Application.Models;
using OCR_4AL2_GR1.Parser.OcrConfigurations;
using Xunit;

namespace OCR_Testing
{
    public class EntryTests
    {
        private readonly IOcrConfiguration configuration;
        private Entry entry;

        public EntryTests()
        {
            this.configuration = new Ocr4x3Number();
        }

        [Fact]
        public void DecryptedCode_StatusIsAuthorized()
        {
            string[] cryptedEntry = new string[4]
            {
                "    _  _  _  _  _  _  _  _ ",
                "|_||_   ||_ | ||_|| || || |",
                "  | _|  | _||_||_||_||_||_|",
                "                           ",
            };

            this.entry = new Entry(this.configuration, cryptedEntry);

            this.entry.Status.Should().Be("");
            this.entry.DecryptedEntry.Should().Be("457508000");
            this.entry.ToString().Should().Be("457508000 ");
        }

        [Fact]
        public void DecryptedCode_StatusIsErrored()
        {
            string[] cryptedEntry = new string[4]
            {
                " _  _     _  _        _  _ ",
                "|_ |_ |_| _|  |  ||_||_||_ ",
                "|_||_|  | _|  |  |  | _| _|",
                "                           ",
            };

            this.entry = new Entry(this.configuration, cryptedEntry);

            this.entry.Status.Should().Be("ERR");
            this.entry.DecryptedEntry.Should().Be("664371495");
            this.entry.ToString().Should().Be("664371495 ERR");
        }

        [Fact]
        public void DecryptedCode_StatusIsUnreadable()
        {
            string[] cryptedEntry = new string[4]
            {
                "    _  _     _  _  _  _  _ ",
                "  | _|  |  | _||_   ||_|| |",
                "  ||_  _|  | _||_|  ||_| _|",
                "                           ",
            };

            this.entry = new Entry(this.configuration, cryptedEntry);

            this.entry.Status.Should().Be("ILL");
            this.entry.DecryptedEntry.Should().Be("12?13678?");
            this.entry.ToString().Should().Be("12?13678? ILL");
        }
    }
}
