using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day16
{
  public class Part2 : IPuzzle
  {
    private class Field
    {
      public string Name;
      public int? Position;
      private List<FieldRange> valueRanges;

      public Field(string fieldString)
      {
        var parts = fieldString.Split(": ");

        this.Name = parts[0];
        this.Position = null;
        this.valueRanges = parts[1].Split(" or ").Select(r => new FieldRange(r)).ToList();
      }

      public bool IsValidValue(int value)
      {
        foreach (var range in this.valueRanges)
        {
          if (value >= range.Min && value <= range.Max)
            return true;
        }

        return false;
      }
    }

    private class FieldRange
    {
      public int Min;
      public int Max;

      public FieldRange(string rangeString)
      {
        var parts = rangeString.Split('-');

        this.Min = int.Parse(parts[0]);
        this.Max = int.Parse(parts[1]);
      }
    }

    public object Run(string input)
    {
      var sections = input.Split(Environment.NewLine + Environment.NewLine);

      var fields = sections[0].Split(Environment.NewLine).Select(f => new Field(f)).ToList();
      var ticket = sections[1].Split(Environment.NewLine)[1].Split(',').Select(int.Parse).ToList();
      var nearbyTickets = sections[2].Split(Environment.NewLine).Where(t => !t.StartsWith("nearby")).Select(t => t.Split(',').Select(int.Parse).ToList()).ToList();

      var validTickets = nearbyTickets.Where(t => t.All(v => fields.Any(f => f.IsValidValue(v)))).ToList();

      while (fields.Any(f => f.Position == null))
      {
        foreach (var field in fields)
        {
          var validPositions = new List<int>();

          for (int position = 0; position < fields.Count; position++)
          {
            if (fields.Any(f => f.Position == position))
              continue;

            bool isPositionValid = validTickets.All(t => field.IsValidValue(t[position]));

            if (isPositionValid)
              validPositions.Add(position);
          }

          if (validPositions.Count == 1)
          {
            field.Position = validPositions[0];
            break;
          }
        }
      }

      var departureFieldIndexes = fields.Where(f => f.Name.StartsWith("departure")).Select(f => f.Position.Value).ToList();
      long result = ticket.Where((v, i) => departureFieldIndexes.Contains(i)).Aggregate(1L, (acc, val) => acc * val);

      return result;
    }
  }
}
