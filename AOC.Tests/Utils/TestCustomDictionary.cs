using AOC.Utils;
using FluentAssertions;
using Xunit;

namespace AOC.Tests.Utils
{
    [Trait("Type", "Internals")]
    public class TestCustomDictionary
    {
        [Fact]
        public void TestGet_Unknown()
        {
            CustomDictionary<string, int> sut = new(888);
            sut.Get("A").Should().Be(888);
        }

        [Fact]
        public void TestGet_Known()
        {
            CustomDictionary<string, int> sut = new(888);
            sut.Set("A", 5);
            sut.Get("A").Should().Be(5);
        }

        [Fact]
        public void TestTransform_Unknown()
        {
            CustomDictionary<string, int> sut = new(888);
            sut.Set("A", 5);
            sut.Transform("A", ex => ex + 1);
            sut.Get("A").Should().Be(6);
        }

        [Fact]
        public void TestTransform_Known()
        {
            CustomDictionary<string, int> sut = new(888);
            sut.Transform("A", ex => ex + 1);
            sut.Get("A").Should().Be(889);
        }
    }
}
