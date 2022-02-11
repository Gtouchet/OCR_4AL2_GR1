
namespace OCR_4AL2_GR1.Application
{
    public class Checksum
    {
        public readonly bool IsValid;

        public Checksum(char unreadableElement, string code)
        {
            this.IsValid = code.Contains(unreadableElement) ? false : this.Validate(code);
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
