using System;

namespace AdventOfCode.Year2017.Day03
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      int target = int.Parse(input);
      int spiralSize, edgeMax;
    
      for (spiralSize = 3; ((spiralSize + 1) * (spiralSize + 1)) <= target; spiralSize += 2) ;
      for (edgeMax = spiralSize * spiralSize; edgeMax - (spiralSize - 1) > target; edgeMax -= (spiralSize - 1)) ;

      return ((spiralSize / 2) + Math.Abs((edgeMax - target) - (spiralSize / 2))).ToString();
    }
  }
}
