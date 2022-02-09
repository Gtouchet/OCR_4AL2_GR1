using System.Collections.Generic;

namespace OCR_4AL2_GR1
{
    public static class OcrCodex
    {
        public static readonly int ENTRY_LINE_SIZE = 4;
        public static readonly int ENTRY_COLUMN_SIZE = 27;

        private static readonly string ZERO =
            " _ " +
            "| |" +
            " _ ";

        // TODO
        public static readonly Dictionary<int, string> CODEX = new Dictionary<int, string>
        {
            { 0, ZERO },
            { 1, ZERO },
            { 2, ZERO },
            { 3, ZERO },
            { 4, ZERO },
            { 5, ZERO },
            { 6, ZERO },
            { 7, ZERO },
            { 8, ZERO },
            { 9, ZERO },
        };
    }
}
