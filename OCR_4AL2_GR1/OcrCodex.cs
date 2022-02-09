using System.Collections.Generic;

namespace OCR_4AL2_GR1
{
    public static class OcrCodex
    {
        public static readonly string CODES_FILENAME = "/OcrCodes.txt";

        public static readonly int ENTRY_LINE_COUNT = 4;
        public static readonly int ENTRY_COLUMN_COUNT = 27;
        public static readonly int TOTAL_NUMBER_IN_CODE = 9;
        public static readonly int COLUMN_PER_NUMBER = ENTRY_COLUMN_COUNT / TOTAL_NUMBER_IN_CODE;

        private static readonly string ZERO =
            " _ " +
            "| |" +
            "|_|" +
            "   ";
        private static readonly string ONE =
            "   " +
            "  |" +
            "  |" + 
            "   ";
        private static readonly string TWO =
            " _ " +
            " _|" +
            "|_ " + 
            "   ";
        private static readonly string THREE =
            " _ " +
            " _|" +
            " _|" + 
            "   ";
        private static readonly string FOUR =
            "   " +
            "|_|" +
            "  |" +
            "   ";
        private static readonly string FIVE =
            " _ " +
            "|_ " +
            " _|" +
            "   ";
        private static readonly string SIX =
            " _ " +
            "|_ " +
            "|_|" + 
            "   ";
        private static readonly string SEVEN =
            " _ " +
            "  |" +
            "  |" + 
            "   ";
        private static readonly string HEIGHT =
            " _ " +
            "|_|" +
            "|_|" + 
            "   ";
        private static readonly string NINE =
            " _ " +
            "|_|" +
            " _|" + 
            "   ";

        public static readonly Dictionary<string, string> CODEX = new Dictionary<string, string>
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
            { NINE, "9" },
        };
    }
}
