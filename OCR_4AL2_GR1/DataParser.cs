
using System.Collections.Generic;
using System.Linq;

namespace OCR_4AL2_GR1
{
    public class DataParser
    {
        private readonly IEnumerable<string> Data;

        public DataParser(IEnumerable<string> data)
        {
            this.Data = data;
        }

        public IEnumerable<Entry> Parse()
        {
            string[] lines = new string[4];

            for (int i = 0; i < this.Data.Count(); i += 4)
            {
                lines[0] = this.Data.ElementAt(i);
                lines[1] = this.Data.ElementAt(i + 1);
                lines[2] = this.Data.ElementAt(i + 2);
                lines[3] = this.Data.ElementAt(i + 3);

                yield return new Entry(lines);
            }
        }
    }
}
