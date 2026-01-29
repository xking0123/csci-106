namespace CSCI106
{
    internal class Program
    {
        static void Main()
        {
            var svg = SvgBuilder.New((500, 500));

            svg.makeRect(50, 50, 20, 7);

            var path = "C:\\Users\\Xavier Harding\\csci-106\\CSCI106\\test.svg";

            using (var fileWriter = FileWriter.FromAbsolutePath(path))
                fileWriter.WriteLine(svg.Build());
        }
    }
}
