using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR_4AL2_GR1
{
    public class OcrConfiguration : IOcrConfiguration
    {
        public string FileName { get; set; }
        public string Test { get; set; }
        public int LineCount { get; set; }
        public int ColumnCount { get; set; }
        public int NumberCountInCode { get; set; }
        public int ColumnPerNumber => ColumnCount / NumberCountInCode;
    }
}
