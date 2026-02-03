namespace CSCI106
{
    public class SvgBuilder
    {
        private const string SVG_HEADER_TEMPLATE = "<svg width=\"{0}\" height=\"{1}\" xmlns=\"http://www.w3.org/2000/svg\">";
        private const string SVG_FOOTER = "</svg>";

        public void makeRect(int x, int y, int width, int height)
        {
            //style it like html... REMEBER ARMSTRONG!
            //"don't hard code the tag in test.svg, just make your tag in the buffer with the attributes" (it's so simple Mr. Harding, stop overthinking...)"
            Buffer += $"<rect x='{x}' y='{y}' width='{width}' height='{height}'/>"; 
        }
        private const string MAKING_RECT_STRING = "<svg width=\"{5}\" height=\"{7}\" x=\"{50}\" y=\"{50}\" xmlns=\"http://www.w3.org/2000/svg\">";

        private string Buffer;
        private uint Width;
        private uint Height;

        public static SvgBuilder New((uint, uint) dimensions)
        {
            var (width, height) = dimensions;

            return new()
            {
                Buffer = string.Empty,
                Width = width,
                Height = height,
            };
        }

        public string Build() =>
            string.Format(SVG_HEADER_TEMPLATE, Width, Height, MAKING_RECT_STRING)
                + Buffer
                + SVG_FOOTER;
    }
}
