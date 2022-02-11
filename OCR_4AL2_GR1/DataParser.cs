using System.Collections.Generic;

namespace OCR_4AL2_GR1
{
    public class DataParser
    {
        private readonly string[] data;
        private readonly IOcrConfiguration configuration;

        public DataParser(IOcrConfiguration configuration, string[] data)
        {
            this.configuration = configuration;
            this.data = data;
        }

        // TODO: refacto cette horreur
        public IEnumerable<Entry> Parse()
        {
            string[] lines = new string[4];

            for (int i = 0; i < this.data.Length; i += configuration.CodeHeightInLines)
            {
                if (this.data.Length - i < configuration.CodeHeightInLines)
                {
                    // TODO: exception non bloquante
                    yield break;
                }

                lines[0] = this.data[i];
                lines[1] = this.data[i + 1];
                lines[2] = this.data[i + 2];
                lines[3] = this.data[i + 3];

                yield return new Entry(this.configuration, lines);
            }
        }
    }
}
