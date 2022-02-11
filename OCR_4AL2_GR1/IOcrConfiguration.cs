using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCR_4AL2_GR1
{
    public interface IOcrConfiguration
    {
        int CodeHeightInLines { get; }
        int CodeWidthInColumns { get; }
        int CodeSize { get; }
        int SingleEntryWidth => CodeWidthInColumns / CodeSize;
        IDictionary<string, string> Codex { get; }
    }
}
