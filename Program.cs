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
      const string argHelp = "Usage: advent <year> [<day> [[<part>] \"<input file path>\"]]";

      if (args.Length == 0)
      {
        Console.WriteLine(argHelp);

        return;
      }

      int year;
      int? day = null;
      int? part = null;
      string inputFilePath = null;

      try
      {
        year = int.Parse(args[0]);

        if (args.Length > 1)
        {
          day = int.Parse(args[1]);

          if (args.Length > 2)
          {
            if (args[2] == "1" || args[2] == "2")
            {
              part = int.Parse(args[2]);

              if (args.Length > 3)
                inputFilePath = args[3];
            }
            else
              inputFilePath = args[2];
          }
        }
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
          if (!string.IsNullOrEmpty(inputFilePath))
            PuzzleRunner.Run(year, day.Value, part.Value, inputFilePath);
          else
            PuzzleRunner.Run(year, day.Value, part.Value);
        }
        else if (!string.IsNullOrEmpty(inputFilePath))
          PuzzleRunner.Run(year, day.Value, inputFilePath);
        else
          PuzzleRunner.Run(year, day.Value);
      }
      else
        PuzzleRunner.Run(year);
    }
  }
}
