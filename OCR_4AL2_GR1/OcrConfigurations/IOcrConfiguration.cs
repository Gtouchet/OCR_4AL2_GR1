using System.Collections.Generic;

namespace OCR_4AL2_GR1.OcrConfigurations
{
    public interface IOcrConfiguration
    {
        int CodeHeightInLines { get; }
        int CodeWidthInColumns { get; }
        int CodeSize { get; }
        int ElementWidth { get => CodeWidthInColumns / CodeSize; }

        IDictionary<string, string> Codex { get; }
    }
}
