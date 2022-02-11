using FluentAssertions;
using OCR_4AL2_GR1;
using Xunit;

namespace OCR_Testing
{
    public class ChecksumTests
    {
        [Fact]
        public void Checksum_123456789_ShouldBe_Valid()
        {
            new Checksum("123456789").IsValid.Should().BeTrue();
        }

        [Fact]
        public void Checksum_123x567x9_ShouldBe_Invalid()
        {
            new Checksum("12?456789").IsValid.Should().BeFalse();
        }

        [Fact]
        public void Checksum_111111111_ShouldBe_Invalid()
        {
            new Checksum("111111111").IsValid.Should().BeFalse();
        }

        [Fact]
        public void Checksum_000000000_ShouldBe_Invalid()
        {
            new Checksum("000000000").IsValid.Should().BeTrue();
        }
    }
}
