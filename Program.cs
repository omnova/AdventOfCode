using System;

namespace AdventOfCode
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      RunWithArgs(args);
    }

    private static void RunWithArgs(string[] args)
    {
      const string argHelp = "Usage: advent <year> [<day [<part [\"<input text>\"]]]";

      if (args.Length == 0)
      {
        Console.WriteLine(argHelp);

        return;
      }

      int year;
      int? day = null;
      int? part = null;
      string input = null;

      try
      {
        year = int.Parse(args[0]);

        if (args.Length > 1)
          day = int.Parse(args[1]);

        if (args.Length > 2)
          part = int.Parse(args[2]);

        if (args.Length > 3)
          input = args[3];
      }
      catch
      {
        Console.WriteLine("Invalid commandline arguments");
        Console.WriteLine(argHelp);

        return;
      }

      if (day.HasValue)
      {
        if (part.HasValue)
        {
          if (!string.IsNullOrEmpty(input))
            PuzzleRunner.Run(year, day.Value, part.Value, input);
          else
            PuzzleRunner.Run(year, day.Value, part.Value);
        }
        else
          PuzzleRunner.Run(year, day.Value);
      }
      else
        PuzzleRunner.Run(year);
    }
  }
}
