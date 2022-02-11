using System.Collections.Generic;

namespace OCR_4AL2_GR1.OcrConfigurations
{
    public class Ocr4x3Number : IOcrConfiguration
    {
        public int CodeHeightInLines { get => 4; }
        public int CodeWidthInColumns { get => 27; }
        public int CodeSize { get => 9; }

        private readonly string ZERO =
            " _ " +
            "| |" +
            "|_|" +
            "   ";
        private readonly string ONE =
            "   " +
            "  |" +
            "  |" +
            "   ";
        private readonly string TWO =
            " _ " +
            " _|" +
            "|_ " +
            "   ";
        private readonly string THREE =
            " _ " +
            " _|" +
            " _|" +
            "   ";
        private readonly string FOUR =
            "   " +
            "|_|" +
            "  |" +
            "   ";
        private readonly string FIVE =
            " _ " +
            "|_ " +
            " _|" +
            "   ";
        private readonly string SIX =
            " _ " +
            "|_ " +
            "|_|" +
            "   ";
        private readonly string SEVEN =
            " _ " +
            "  |" +
            "  |" +
            "   ";
        private readonly string HEIGHT =
            " _ " +
            "|_|" +
            "|_|" +
            "   ";
        private readonly string NINE =
            " _ " +
            "|_|" +
            " _|" +
            "   ";

        public IDictionary<string, string> Codex => new Dictionary<string, string>
        {
            { ZERO, "0" },
            { ONE, "1" },
            { TWO, "2" },
            { THREE, "3" },
            { FOUR, "4" },
            { FIVE, "5" },
            { SIX, "6" },
            { SEVEN, "7" },
            { HEIGHT, "8" },
            { NINE, "9" }
        };
    }
}
