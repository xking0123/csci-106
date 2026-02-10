namespace CSCI106
{
    internal class Program
    {
        static void Main()
        {
            var svg = SvgBuilder.New((1, 1));

            //rect 1
            svg.makeRect(0, 0, 100, 50);
            svg.validateRect(0, 0, 100, 50);
            svg.isOverlappingX(0, 100);

            //rect 2
            svg.makeRect(501, 501, 1000, 1000);
            svg.validateRect(501, 501, 1000, 1000);
            svg.isOverlappingX(501, 1000);

            var path = "C:\\Users\\Xavier Harding\\csci-106\\CSCI106\\test.svg";

            using (var fileWriter = FileWriter.FromAbsolutePath(path))
                fileWriter.WriteLine(svg.Build());
        }
    }
}
