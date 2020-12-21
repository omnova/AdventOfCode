using System;
using System.Collections.Generic;
using System.Linq;


namespace AdventOfCode.Year2020.Day20
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var tiles = input.Replace("Tile ", "").Replace(":", "").Split(Environment.NewLine + Environment.NewLine).Select(t => new Tile(t)).ToList();

      var image = new Image(tiles);

      var nessyPixels = new bool[image.Size, image.Size];
      
      for (int orientation = 0; orientation < image.Orientations.Count; orientation++)
      {
        var data = image.Orientations[orientation];
        bool foundNessy = false;
        
        for (int x = 0; x < image.Size - 18; x++)
        {
          for (int y = 0; y < image.Size - 2; y++)
          {
            if (data[x + 18, y]
              && data[x, y + 1] && data[x + 5, y + 1] && data[x + 6, y + 1] && data[x + 11, y + 1] && data[x + 12, y + 1] && data[x + 17, y + 1] && data[x + 18, y + 1] && data[x + 19, y + 1]
              && data[x + 1, y + 2] && data[x + 4, y + 2] && data[x + 7, y + 2] && data[x + 10, y + 2] && data[x + 13, y + 2] && data[x + 16, y + 2])
            {
              foundNessy = true;

              nessyPixels[x + 18, y] = true;
              nessyPixels[x, y + 1] = true;
              nessyPixels[x + 5, y + 1] = true;
              nessyPixels[x + 6, y + 1] = true;
              nessyPixels[x + 11, y + 1] = true;
              nessyPixels[x + 12, y + 1] = true;
              nessyPixels[x + 17, y + 1] = true;
              nessyPixels[x + 18, y + 1] = true;
              nessyPixels[x + 19, y + 1] = true;
              nessyPixels[x + 1, y + 2] = true;
              nessyPixels[x + 4, y + 2] = true;
              nessyPixels[x + 7, y + 2] = true;
              nessyPixels[x + 10, y + 2] = true;
              nessyPixels[x + 13, y + 2] = true;
              nessyPixels[x + 16, y + 2] = true;
            }
          }
        }

        if (foundNessy)
        {
          int seaRoughness = 0;

          for (int x = 0; x < image.Size; x++)
          {
            for (int y = 0; y < image.Size; y++)
            {
              if (data[x, y] && !nessyPixels[x, y])
                seaRoughness++;
            }
          }

          return seaRoughness;
        }
      }

      return null;
    }
  }
}
