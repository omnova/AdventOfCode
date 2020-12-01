using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Year2016.Day05
{
  public class Part2 : IPuzzle
  {
    public string Run(string input)
    {
      string password = "        ";
      int hashIndex = 0;
      var usedPositions = new List<char>();

      var md5 = MD5.Create();

      while (password.IndexOf(' ') != -1)
      {
        string hash = string.Concat(md5.ComputeHash(Encoding.UTF8.GetBytes(input + hashIndex++)).Select(b => b.ToString("x2")));

        if (hash.Substring(0, 5) == "00000" && "01234567".IndexOf(hash[5]) != -1 && !usedPositions.Contains(hash[5]))
        {
          password = string.Concat(password.Select((c, i) => "01234567".IndexOf(hash[5]) == i ? hash[6] : c));

          usedPositions.Add(hash[5]);
        }
      }

      return password;
    }
  }
}
