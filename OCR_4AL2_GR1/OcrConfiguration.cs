using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR_4AL2_GR1
{
    public class OcrConfiguration : IOcrConfiguration
    {
        public int CodeHeightInLines => 4 ;
        public int CodeWidthInColumns => 27;
        public int CodeSize => 9;

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
