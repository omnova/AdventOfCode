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
    private const string OutputFormat = "{0}.{1:0#}.{2}: {3}";

    public static void Run(int year)
    {
      for (int day = 1; day <= 25; day++)
      {
        Run(year, day);
      }
    }

    public static void Run(int year, int day)
    {
      Run(year, day, 1);
      Run(year, day, 2);
    }

    public static void Run(int year, int day, int part)
    {
      Run(year, day, part, InputManager.GetInputText(year, day));
    }

    public static void Run(int year, int day, int part, string input)
    {
      try
      {
        string typeName = string.Format(TypeNameFormat, year, day, part);
        var type = Assembly.GetExecutingAssembly().GetType(typeName);

        if (type == null || type.GetConstructor(new Type[] { }) == null)
          return;
        
        var puzzle = Activator.CreateInstance(type) as IPuzzle;

        if (puzzle == null)
          return;

        try
        {
          string output = puzzle.Run(input).ToString();

          Console.WriteLine(OutputFormat, year, day, part, output);
        }
        catch (NotImplementedException)
        {
          // Ignore if not implemented.
        }
        catch
        {
          Console.WriteLine(OutputFormat, year, day, part, "Execution failed (probably bad or missing input)");
        }
      }
      catch
      {
        // Safety net.
      }
    }
  }

  public static class InputManager
  {
    private const string InputPathFormat = "../../../Year{0}/Day{1:0#}/Input.txt";

    public static string GetInputText(int year, int day)
    {
      string relativePath = string.Format(InputPathFormat, year, day);

      if (File.Exists(relativePath))
        return File.ReadAllText(relativePath);
    
      return string.Empty;
    }
  }
}
