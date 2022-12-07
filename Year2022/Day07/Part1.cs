using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2022.Day07
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var commands = input.Split(Environment.NewLine).Select(l => l.Split(' ')).ToArray();

      var folders = Dictionary<string, int>();
      var folderPath = new Stack<string>("root");

      for (int i = 0; i < commands.Length; i++)
      {
        var command = commands[i];

        if (command[0] == "$" && command[1] == "cd")
        {
          if (command[2] == "/")
          {
            while (folderPath.Count > 1)
            {
              folderPath.Pop();
            }
          }
          else if (command[2] == "..")
            folderPath.Pop();
          else
          {
            folderPath.Push(command[2]);

            string path = command[2]; // string.Join("/", folderPath);

            if (!folders.ContainsKey(path))
              folders.Add(path, 0);
          }
        }
        else if (command[0] != "$" && command[0] != "dir")
        {
          int size = int.Parse(commands[i][0]);

          folderPath.ToList().ForEach(f => f.Value += size);
        }
      }

      int totalSize = folders.Values.Where(d => d < 100000).Sum();

      return totalSize;
    }
  }
}
