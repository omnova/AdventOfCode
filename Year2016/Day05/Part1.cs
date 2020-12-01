using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AdventOfCode.Year2016.Day05
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      string password = string.Empty;
      int hashIndex = 0;

      var md5 = MD5.Create();

      while (password.Length < 8)
      {
        string hash = string.Concat(md5.ComputeHash(Encoding.UTF8.GetBytes(input + hashIndex++)).Select(b => b.ToString("x2")));

        if (hash.Substring(0, 5) == "00000")
          password += hash[5];
      }

      return password;
    }
  }
}
