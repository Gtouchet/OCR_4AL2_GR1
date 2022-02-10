using System.Collections.Generic;

namespace OCR_4AL2_GR1
{
    public class DataParser
    {
        private readonly string[] Data;

        public DataParser(string[] data)
        {
            this.Data = data;
        }

        // TODO: refacto cette horreur
        public IEnumerable<Entry> Parse()
        {
            string[] lines = new string[4];

            for (int i = 0; i < this.Data.Length; i += OcrCodex.CODE_LINE_COUNT)
            {
                if (this.Data.Length - i < OcrCodex.CODE_LINE_COUNT)
                {
                    // TODO: exception non bloquante
                    yield break;
                }

                lines[0] = this.Data[i];
                lines[1] = this.Data[i + 1];
                lines[2] = this.Data[i + 2];
                lines[3] = this.Data[i + 3];

                yield return new Entry(lines);
            }
        }
    }
}
