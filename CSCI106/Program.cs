using System.Text.RegularExpressions;

namespace CSCI106
{
    internal class Program
    {

        //making a single string of readable data possible (regex101.com)
        const string matchRectangle = @"\((?<x>\d+),\s*(?<y>\d+),\s*(?<width>\d+),\s*(?<height>\d+),\s*(?<color>[^)]+)\)";

        static void Main()
        {
            var svg = SvgBuilder.New((50, 50));

            Console.WriteLine("Example: (10, 20, 100, 50, red)");
            Console.Write("Enter parameters for rectangle as (x, y, width, height, color): ");

            //matching user input to singular string of data. BLACH MAGIC AHHHHHHH
            var matches = new Regex(matchRectangle).Matches(Console.ReadLine()!);

            //once again... old way...
            foreach (var match in matches.ToList())
            {
                var x = int.Parse(match.Groups["x"].ToString());
                var y = int.Parse(match.Groups["y"].ToString());
                var width = int.Parse(match.Groups["width"].ToString());
                var height = int.Parse(match.Groups["height"].ToString());
                var color = match.Groups["color"].ToString();

                svg.makeRect(x, y, width, height, color);
            }

            var path = "C:\\Users\\Xavier Harding\\csci-106\\CSCI106\\test.svg";

            using (var fileWriter = FileWriter.FromAbsolutePath(path))
                fileWriter.WriteLine(svg.Build());
        }
    }
}
