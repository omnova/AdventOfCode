using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2022.Day07
{
  public class Part2 : IPuzzle
  {
    private class Folder
    {
      public string Name;
      public Folder Parent;
      public int Size;
      public List<Folder> Children = new List<Folder>();

      public int TotalSize => this.Children.Sum(c => c.TotalSize) + this.Size;
    }


    public object Run(string input)
    {
      var commands = input.Split(Environment.NewLine).Select(l => l.Split(' ')).ToArray();

      var rootFolder = new Folder { Name = "root" };
      var folders = new List<Folder> { rootFolder };
      var folderPath = new Stack<Folder>(folders);

      for (int i = 0; i < commands.Length; i++)
      {
        var command = commands[i];

        if (command[0] == "$")
        {
          if (command[1] == "cd")
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
              var child = folderPath.Peek().Children.FirstOrDefault(c => c.Name == command[2]);

              if (child == null)
              {
                child = new Folder
                {
                  Name = command[2],
                  Parent = folderPath.Peek(),
                  Children = new List<Folder>()
                };

                folderPath.Peek().Children.Add(child);

                folders.Add(child);
              }

              folderPath.Push(child);
            }
          }
          else if (command[1] == "ls")
          {
            while (i + 1 < commands.Length && commands[i + 1][0] != "$")
            {
              if (commands[++i][0] != "dir")
                folderPath.Peek().Size += int.Parse(commands[i][0]);
            }
          }
        }
      }

      int targetDelete = 30000000 - (70000000 - rootFolder.TotalSize);
      int totalSize = folders.Select(d => d.TotalSize).Where(d => d >= targetDelete).OrderBy(d => d).FirstOrDefault();

      return totalSize;
    }
  }
}
