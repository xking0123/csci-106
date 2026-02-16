using System.Text.RegularExpressions;

namespace CSCI106
{
    internal class Program
    {
        //making a single string of readable data possible (regex101.com)
        const string matchRectangle = @"\((?<x>[^\(\)]+), ?(?<y>[^\(\)]+), ?(?<width>[^\(\)]+), ?(?<height>[^\(\)]+), ?(?<color>[^\(\)]+)\)";

        static void Main()
        {
            var svg = SvgBuilder.New((50, 50));

            svg.makeRect(1, 1, 100, 50, "red");
            svg.validateRect(1, 1, 100, 50);

            //matching user input to singular string of data. BLACH MAGIC AHHHHHHH
            var matches = new Regex(matchRectangle).Matches(Console.ReadLine());
            foreach (var match in matches.ToList())
            {
                var x = int.Parse(match.Groups["x"].ToString());
                var y = int.Parse(match.Groups["y"].ToString());
                var width = int.Parse(match.Groups["width"].ToString());
                var height = int.Parse(match.Groups["height"].ToString());
                var color = match.Groups["color"].ToString();
            }

            var path = "C:\\Users\\Xavier Harding\\csci-106\\CSCI106\\test.svg";

            using (var fileWriter = FileWriter.FromAbsolutePath(path))
                fileWriter.WriteLine(svg.Build());
        }
    }
}
