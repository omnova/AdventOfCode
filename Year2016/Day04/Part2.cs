using System;
using System.Linq;

namespace AdventOfCode.Year2016.Day04
{
  public class Part2 : IPuzzle
  {
    public string Run(string input)
    {
      return input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(i => new
                  {
                    Name = i.Substring(0, i.LastIndexOf('-')),
                    SectorID = int.Parse(i.Substring(i.LastIndexOf('-') + 1, i.IndexOf('[') - i.LastIndexOf('-') - 1)),
                    CheckSum = i.Substring(i.IndexOf('[') + 1).Trim(']')
                  })
                  .Where(i => string.Concat(i.Name.OrderByDescending(c => i.Name.Count(l => l == c)).ThenBy(l => l).Distinct()).Replace("-", "").Substring(0, 5) == i.CheckSum)
                  .Select(s => new
                  {
                    Name = string.Concat(s.Name.Select(c => c == '-' ? ' ' : (char)(((c - 97 + s.SectorID) % 26) + 97))),
                    s.SectorID
                  })
                  .First(r => r.Name == "northpole object storage")
                  .SectorID
                  .ToString();
    }
  }
}
