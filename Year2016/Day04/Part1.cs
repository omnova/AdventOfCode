using System;
using System.Linq;

namespace AdventOfCode.Year2016.Day04
{
  public class Part1 : IPuzzle
  {
    public string Run(string input)
    {
      return input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(i => new
                  {
                    Name = i.Substring(0, i.LastIndexOf('-')).Replace("-", ""),
                    SectorID = int.Parse(i.Substring(i.LastIndexOf('-') + 1, i.IndexOf('[') - i.LastIndexOf('-') - 1)),
                    CheckSum = i.Substring(i.IndexOf('[') + 1).Trim(']')
                  })
                  .Select(i => new
                  {
                    Name = string.Concat(i.Name.OrderByDescending(c => i.Name.Count(l => l == c)).ThenBy(c => c).Distinct()),
                    i.SectorID,
                    i.CheckSum
                  })
                  .Where(r => r.Name.Substring(0, 5) == r.CheckSum)
                  .Sum(r => r.SectorID)
                  .ToString();
    }
  }
}
