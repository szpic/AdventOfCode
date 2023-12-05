using System.Text.RegularExpressions;

namespace AdventOFCode2023.Day5
{
    public class Day5Solution : BaseUtils
    {
        public Day5Solution() : base("input2023_5.txt") { }
        public override void SolveIssue()
        {
            var data = Data.SplitByEmptyLine();
            var seeds = Regex.Matches(data[0], @"\d+").Select(s => double.Parse(s.Value)).ToArray();
            //seeds to soil
            var seedsToSoil = ParsePart(data, 1);
            // soil to ferilizer
            var soilToFertilizer = ParsePart(data, 2);
            // fertilizer to water
            var fertilizerToWater = ParsePart(data, 3);
            // water to light
            var waterToLigth = ParsePart(data, 4);
            //light to temperature
            var lightToTemperature = ParsePart(data, 5);
            //temperature to humidty
            var temperatureToHumidity = ParsePart(data, 6);
            //humidity to location
            var humidityToLocation = ParsePart(data, 7);
            List<double> results = new List<double>();
            //part1
            foreach (double seed in seeds)
            {
                double target = 0;
                target = GetLocation(seedsToSoil, seed);
                target = GetLocation(soilToFertilizer, target);
                target = GetLocation(fertilizerToWater, target);
                target = GetLocation(waterToLigth, target);
                target = GetLocation(lightToTemperature, target);
                target = GetLocation(temperatureToHumidity, target);
                target = GetLocation(humidityToLocation, target);
                results.Add(target);
            }
            Console.WriteLine($"lowest location is {results.Min()}");

            //part2
            //List<double> seeds2 = new List<double>();
            //var temp = Regex.Matches(data[0], @"(\d+) (\d+)").Select(s => s.Value).ToArray();
            //foreach(var pair in temp)
            //{
            //    var z = Regex.Matches(data[0], @"\d+").Select(s => double.Parse(s.Value)).ToArray();
            //    for (int i = 0; i< z[1]; i++)
            //    {
            //        seeds2.Add(z[0]+i);
            //    }
            //}
            //Console.WriteLine(seeds2.Count());
            //results.Clear();
            //double number = 0;
            //foreach (double seed in seeds2)
            //{
            //    if(number %10000 == 0)
            //        Console.WriteLine(number);
            //    double target = 0;
            //    target = GetLocation(seedsToSoil, seed);
            //    target = GetLocation(soilToFertilizer, target);
            //    target = GetLocation(fertilizerToWater, target);
            //    target = GetLocation(waterToLigth, target);
            //    target = GetLocation(lightToTemperature, target);
            //    target = GetLocation(temperatureToHumidity, target);
            //    target = GetLocation(humidityToLocation, target);
            //    results.Add(target);
            //    number++;
            //}
            //Console.WriteLine($"lowest location is {results.Min()}");
        }

        private static double GetLocation(List<mapper> seedsToSoil, double seed)
        {
            double target;
            var result = seedsToSoil.FirstOrDefault(w => seed >= w.start && seed <= (w.start + w.length - 1));
            if (result is null)
            {
                target = seed;
            }
            else
            {
                target = result.target + (seed - result.start);
            }

            return target;
        }

        private static List<mapper> ParsePart(string[] data, int partNumber)
        {

            return data[partNumber].SplitByEndOfLine().Skip(1).Select(s =>
            {
                var matches = Regex.Matches(s, @"\d+").Select(s => double.Parse(s.Value)).ToArray();
                return new mapper(matches[0], matches[1], matches[2]);
            }).ToList();
        }

        public record mapper(double target, double start, double length);
    }
}