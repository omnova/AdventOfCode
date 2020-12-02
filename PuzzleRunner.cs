using System;
using System.IO;
using System.Reflection;

namespace AdventOfCode
{
  public interface IPuzzle
  {
    object Run(string input);
  }

  public static class PuzzleRunner
  {
    private const string TypeNameFormat = "AdventOfCode.Year{0}.Day{1:0#}.Part{2}";
    private const string InputPathFormat = "Year{0}/Day{1:0#}/Input.txt";
    private const string OutputFormat = "{0}.{1:0#}.{2}: {3}";

    public static void Run(int year)
    {
      for (int day = 1; day <= 25; day++)
      {
        Run(year, day, 1, true);
        Run(year, day, 2, true);
      }
    }

    public static void Run(int year, int day)
    {
      Run(year, day, 1, false);
      Run(year, day, 2, false);
    }

    public static void Run(int year, int day, int part)
    {
      Run(year, day, part, false);
    }

    private static void Run(int year, int day, int part, bool ignoreNotImplemented)
    {
      var puzzle = GetPuzzle(year, day, part);

      if (puzzle == null)
      {
        if (!ignoreNotImplemented)
          Console.WriteLine(OutputFormat, year, day, part, "Solution not implemented");

        return;
      }

      string input;

      try
      {
        input = GetInputFileText(year, day);
      }
      catch (FileNotFoundException e)
      {
        Console.WriteLine(OutputFormat, year, day, part, "Unable to find input file (" + e.Message + ")");
        return;
      }

      try
      {
        string output = puzzle.Run(input)?.ToString() ?? "<null>";

        Console.WriteLine(OutputFormat, year, day, part, output);
      }
      catch (NotImplementedException)
      {
        if (!ignoreNotImplemented)
          Console.WriteLine(OutputFormat, year, day, part, "Solution not implemented");
      }
      catch (Exception e)
      {
        Console.WriteLine(OutputFormat, year, day, part, "Execution failed (" + e.Message + ")");
      }
    }

    public static void Run(int year, int day, int part, string input)
    {
      var puzzle = GetPuzzle(year, day, part);

      if (puzzle == null)
      {
        Console.WriteLine(OutputFormat, year, day, part, "Unable to find type");
        return;
      }

      if (string.IsNullOrEmpty(input))
      {
        Console.WriteLine(OutputFormat, year, day, part, "No input provided");
        return;
      }

      try
      {
        string output = puzzle.Run(input)?.ToString() ?? "<null>";

        Console.WriteLine(OutputFormat, year, day, part, output);
      }
      catch (NotImplementedException)
      {
        Console.WriteLine(OutputFormat, year, day, part, "Solution not implemented");
      }
      catch (Exception e)
      {
        Console.WriteLine(OutputFormat, year, day, part, "Execution failed (" + e.Message + ")");
      }
    }

    private static IPuzzle GetPuzzle(int year, int day, int part)
    {
      try
      {
        string typeName = string.Format(TypeNameFormat, year, day, part);
        var type = Assembly.GetExecutingAssembly().GetType(typeName);

        if (type == null || type.GetConstructor(new Type[] { }) == null)
          return null;

        return Activator.CreateInstance(type) as IPuzzle;
      }
      catch
      {
        return null;
      }
    }

    private static string GetInputFileText(int year, int day)
    {
      string inputFilePath = string.Format(InputPathFormat, year, day);

      if (!File.Exists(inputFilePath))
        throw new FileNotFoundException(Path.GetFullPath(inputFilePath));

      return File.ReadAllText(inputFilePath);
    }
  }
}
