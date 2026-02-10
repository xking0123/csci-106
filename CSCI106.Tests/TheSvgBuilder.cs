namespace CSCI106.Tests
{
    public class TheSvgBuilder
    {
        [Test]
        public void BuildsSvgsWithTheCorrectSize()
        {
            var svg = SvgBuilder.New((123, 456)).Build();

            Assert.That(svg, Contains.Substring("width=\"123\""));
            Assert.That(svg, Contains.Substring("height=\"456\""));
        }

        [TestCase(-1, 2, ExpectedResult = true)]
        [TestCase(1, 3, ExpectedResult = true)]
        [TestCase(6, 7, ExpectedResult = true)]
        [TestCase(-3, 2, ExpectedResult = false)]
        [TestCase(8, 1, ExpectedResult = false)]
        
        public bool isOverlappingX(int x, int width)
        {
            var svg = SvgBuilder.New((7, 456));

            return svg.isOverlappingX(x, width);
        }
    }
}