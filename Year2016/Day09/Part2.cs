using System;
using System.Linq;

namespace AdventOfCode.Year2016.Day09
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      return GetDecompressedLength(input).ToString();
    }

    private long GetDecompressedLength(string input)
    {
      int i = 0;
      long decompressedLength = 0;

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

          decompressedLength += (GetDecompressedLength(input.Substring(i, arguments[0])) * arguments[1]);
          i += arguments[0];
        }
      }

      return decompressedLength;
    }
  }
}
