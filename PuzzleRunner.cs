using System;
using System.IO;
using System.Reflection;

namespace AdventOfCode
{
  public interface IPuzzle
  {
    object Run(string input);
  }

  [System.AttributeUsage(System.AttributeTargets.Class)]
  public class PuzzleAttribute : System.Attribute
  {
    public int Year;
    public int Day;
    public int Part;

    public PuzzleAttribute(int year, int day, int part)
    {
      this.Year = year;
      this.Day = day;
      this.Part = part;
    }
  }


  public static class PuzzleRunner
  {
    private const string TypeNameFormat = "AdventOfCode.Year{0}.Day{1:0#}.Part{2}";
    private const string InputPathFormat = "Year{0}/Day{1:0#}/Input.txt";
    private const string OutputFormat = "{0}.{1:0#}.{2}: {3}";

    /// <summary>
    /// Runs all puzzle solutions for the provided year.  Missing or not implemented solutions will be ignored.
    /// </summary>
    public static void Run(int year)
    {
      for (int day = 1; day <= 25; day++)
      {
        string inputFilePath = GetDefaultInputFilePath(year, day);

        RunInternal(year, day, 1, inputFilePath, true);
        RunInternal(year, day, 2, inputFilePath, true);
      }
    }

    /// <summary>
    /// Runs all puzzle solutions for the provided year and day.  
    /// </summary>
    public static void Run(int year, int day)
    {
      string inputFilePath = GetDefaultInputFilePath(year, day);

      RunInternal(year, day, 1, inputFilePath, false);
      RunInternal(year, day, 2, inputFilePath, false);
    }

    /// <summary>
    /// Runs the puzzle solution for the provided year, day, and part.    
    /// </summary>
    public static void Run(int year, int day, int part)
    {
      string inputFilePath = GetDefaultInputFilePath(year, day);

      RunInternal(year, day, part, inputFilePath, false);
    }

    /// <summary>
    /// Runs the puzzle solutions for the provided year and day, using the provided input file.    
    /// </summary>
    public static void Run(int year, int day, string inputFilePath)
    {
      RunInternal(year, day, 1, inputFilePath, false);
      RunInternal(year, day, 2, inputFilePath, false);
    }

    /// <summary>
    /// Runs the puzzle solution for the provided year, day, and part, using the provided input file.
    /// </summary>
    public static void Run(int year, int day, int part, string inputFilePath)
    {
      RunInternal(year, day, part, inputFilePath, false);
    }

    private static void RunInternal(int year, int day, int part, string inputFilePath, bool ignoreNotImplemented = false)
    {
      var puzzle = GetPuzzle(year, day, part);

      if (puzzle == null)
      {
        if (!ignoreNotImplemented)
          Console.WriteLine(OutputFormat, year, day, part, "Solution not implemented (Unable to find type " + string.Format(TypeNameFormat, year, day, part) + ")");

        return;
      }

      string input = string.Empty;
      bool fileFound = false;

      try
      {
        input = GetInputFileText(inputFilePath);
        fileFound = true;
      }
      catch { }

      try
      {
        string output = puzzle.Run(input)?.ToString() ?? "<null>";

        if (!fileFound)
          Console.WriteLine(OutputFormat, year, day, part, "Unable to read input file (" + Path.GetFullPath(inputFilePath) + ")");
        else
          Console.WriteLine(OutputFormat, year, day, part, output);
      }
      catch (NotImplementedException)
      {
        if (!ignoreNotImplemented)
          Console.WriteLine(OutputFormat, year, day, part, "Solution not implemented");
      }
      catch (Exception e)
      {
        if (!fileFound)
          Console.WriteLine(OutputFormat, year, day, part, "Unable to read input file (" + Path.GetFullPath(inputFilePath) + ")");
        else
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

    private static string GetDefaultInputFilePath(int year, int day)
    {
      return string.Format(InputPathFormat, year, day);
    }

    private static string GetInputFileText(string inputFilePath)
    {
      if (!File.Exists(inputFilePath))
        throw new FileNotFoundException(Path.GetFullPath(inputFilePath));

      return File.ReadAllText(inputFilePath);
    }
  }
}
