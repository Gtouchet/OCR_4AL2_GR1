using FluentAssertions;
using OCR_4AL2_GR1.Application.Models;
using Xunit;

namespace OCR_Testing
{
    public class ChecksumTests
    {
        [Fact]
        public void Checksum_457508000_ShouldBe_Valid()
        {
            new Checksum("457508000").IsValid.Should().BeTrue();
        }

        [Fact]
        public void Checksum_664371495_ShouldBe_Invalid()
        {
            new Checksum("12?664371495").IsValid.Should().BeFalse();
        }

        [Fact]
        public void Checksum_12X13678X_ShouldBe_Invalid()
        {
            new Checksum("12?13678?").IsValid.Should().BeFalse();
        }
    }
}
