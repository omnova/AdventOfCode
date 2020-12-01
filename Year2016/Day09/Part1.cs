using System;
using System.Linq;

namespace AdventOfCode.Year2016.Day09
{
  public class Part1 : IPuzzle
  {
    public string Run(string input)
    {
      //var instructions = Regex.Matches(input, @"(?:\(\d+x\d+)\)(?!\(.*\))(\w+)")
      //                        .Cast<object>()
      //                        .Select(match => match.ToString().Substring(1).Split(")".ToCharArray()))
      //                        .Select(i => new
      //                        {
      //                          NumChars = int.Parse(i[0].Split('x')[0]),
      //                          NumCopies = int.Parse(i[0].Split('x')[1]),
      //                          Text = i[1]
      //                        })
      //                        .ToList();

      //foreach (var instruction in instructions)
      //{
      //  for (int i = 0; i < instruction.NumCopies; i++)
      //  {
      //    outputBuilder.Append(instruction.Text.Substring(0, instruction.NumChars));
      //  }

      //  if (instruction.NumChars < instruction.Text.Length)
      //    outputBuilder.Append(instruction.Text.Substring(instruction.NumChars));

      //  Console.WriteLine(outputBuilder.ToString());
      //}

      int i = 0;
      int decompressedLength = 0;

      while (i < input.Length)
      {
        if (char.IsLetter(input[i]))
        {
          int length = input.IndexOf('(', i) != -1 ? input.IndexOf('(', i) - i : input.Substring(i).Length;

          decompressedLength += length;
          i += length;
        }
        else
        {
          string marker = input.Substring(i, input.IndexOf(')', i) - i + 1);
          
          i += marker.Length;

          var arguments = marker.Trim("()".ToCharArray()).Split('x').Select(int.Parse).ToArray();

          decompressedLength += (input.Substring(i, arguments[0]).Length*arguments[1]);
          i += arguments[0];
        }
      }

      return decompressedLength.ToString();
    }
  }
}
