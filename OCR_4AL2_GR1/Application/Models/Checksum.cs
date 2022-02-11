
namespace OCR_4AL2_GR1.Application.Models
{
    public class Checksum
    {
        public readonly bool IsValid;

        public Checksum(string code)
        {
            IsValid = code.Contains("?") ? false : Validate(code);
        }

        private bool Validate(string code)
        {
            int checksum = 0;

            for (int i = 0; i < code.Length; i += 1)
            {
                checksum += (code.Length - i) * (code[i] - '0');
            }

            return checksum % 11 == 0;
        }
    }
}
