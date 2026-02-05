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

        public void validateRect(int x, int y, int width, int height)
        {
            if (x <= Width && y <= Height)
            {
                //for valid
                Console.WriteLine("Good Job :)");
                makeRect(x, y, width, height);
            }
            else
            {
                //for invalid
                Console.WriteLine("Invalid rect, try again");
                throw new Exception("X or Y may be too big, rect no fit in viable space");
            }
        }

        public bool isOverlappingX(int x, int width)
        {
            if(x < Width && x + width > 0)
            {
                return true;
            //x < Width = left side within svg
            //x + width > 0 = right side within svg. how it becomes an overlap in the first place, the "width" drags it out
            }
            return false;
        }
        //TO MAKE REMEMBERING EASIER
        //x = left edge
        //x + width = right edge
        //Width = right edge corner of svg
        //width = how wide object is

        // public bool isOverlappingX(int x, int width)
        // {
        //     return x < Width && x + width > 0;
        // }


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
