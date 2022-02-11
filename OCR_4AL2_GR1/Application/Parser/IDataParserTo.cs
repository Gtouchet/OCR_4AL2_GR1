using OCR_4AL2_GR1.Application.Models;
using System.Collections.Generic;

namespace OCR_4AL2_GR1.Application.Parser
{
    public interface IDataParserTo
    {
        IEnumerable<Entry> ToList();
        Dictionary<string, List<Entry>> ToDictionary();
    }
}
