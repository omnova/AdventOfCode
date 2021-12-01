using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
  internal static class ArrayExtensions
  {
    /// <summary>
    /// Returns a copy of this array
    /// </summary>
    public static T[,] Copy<T>(this T[,] source)
    {
      var destination = new T[source.GetLength(0), source.GetLength(1)];

      for (int i = 0; i < source.GetLength(0); i++)
      {
        for (int j = 0; j < source.GetLength(1); j++)
        {
          destination[i, j] = source[i, j];
        }
      }

      return destination;
    }

    /// <summary>
    /// Copies the contents of this array into another
    /// </summary>
    public static void CopyTo<T>(this T[,] source, T[,] destination, int destinationOffsetX = 0, int destinationOffsetY = 0)
    {
      if (source.GetLength(0) + destinationOffsetX > destination.GetLength(0) || source.GetLength(1) + destinationOffsetY > destination.GetLength(1))
        throw new ArgumentException("The values of this array will not fit into the destination array");

      for (int i = 0; i < source.GetLength(0); i++)
      {
        for (int j = 0; j < source.GetLength(1); j++)
        {
          destination[i, j] = source[i, j];
        }
      }
    }

    /// <summary>
    /// Transforms the nested collections into a multi-dimensional array
    /// </summary>
    public static T[,] ToMultidimensionalArray<T>(this IEnumerable<IEnumerable<T>> source) where T : new()
    {
      if (source.Count() == 0 || source.FirstOrDefault()?.Count() == 0)
        throw new ArgumentException("This would result in a 0-dimension array");

      var destination = new T[source.Count(), source.Select(s => s.Count()).Max()];

      int j = 0;
      
      foreach (var row in source)
      {
        int i = 0;

        foreach (var column in row)
        {
          destination[i++, j] = column;
        }

        j++;
      }

      return destination;
    }

    /// <summary>
    /// Converts the array into a multi-dimensional array with the provided partition size
    /// </summary>
    public static T[,] ToMultidimensionalArray<T>(this T[] source, int partition) where T : new()
    {
      if (partition <= 0)
        throw new ArgumentException("Partition must be greater than 0");

      if (source == null || source.Length == 0)
        throw new ArgumentException("Use a real source");

      var destination = new T[partition, source.Length % partition == 0 ? source.Length / partition : (source.Length / partition) + 1];

      for (int i = 0; i < source.Length; i++)
      {
        destination[i % partition, i / partition] = source[i];
      }

      return destination;
    }

    /// <summary>
    /// Serializes a two-dimensional array in a single-dimensional array
    /// </summary>
    public static T[] ToArray<T>(this T[,] source) where T : new()
    {    
      if (source == null || source.Length == 0)
        throw new ArgumentException("Use a real source");

      int sourceX = source.GetLength(0);
      int sourceY = source.GetLength(1);

      var destination = new T[sourceX * sourceY];

      for (int y = 0; y < sourceY; y++)
      {
        for (int x = 0; x < sourceX; x++)
          destination[(y * sourceY) + x] = source[x, y];
      }

      return destination;
    }


    /// <summary>
    /// Serializes a two-dimensional array into a List
    /// </summary>
    public static List<T> ToList<T>(this T[,] source) where T : new()
    {
      if (source == null || source.Length == 0)
        throw new ArgumentException("Use a real source");

      int sourceX = source.GetLength(0);
      int sourceY = source.GetLength(1);

      var destination = new List<T>(Enumerable.Repeat(default(T), sourceX * sourceY));

      for (int y = 0; y < sourceY; y++)
      {
        for (int x = 0; x < sourceX; x++)
          destination[(y * sourceY) + x] = source[x, y];
      }

      return destination;
    }

    /// <summary>
    /// Rotates the array clockwise
    /// </summary>
    public static T[,] RotateClockwise<T>(this T[,] source) where T : new()
    {
      var destination = new T[source.GetLength(1), source.GetLength(0)];

      for (int x = 0; x < source.GetLength(0); x++)
      {
        for (int y = 0; y < source.GetLength(1); y++)
        {
          destination[x, y] = source[y, source.GetLength(0) - x - 1];
        }
      }

      return destination;
    }

    /// <summary>
    /// Rotates the array counterclockwise
    /// </summary>
    public static T[,] RotateCounterClockwise<T>(this T[,] source) where T : new()
    {
      var destination = new T[source.GetLength(1), source.GetLength(0)];

      for (int x = 0; x < source.GetLength(0); x++)
      {
        for (int y = 0; y < source.GetLength(1); y++)
        {
          destination[x, y] = source[source.GetLength(1) - y - 1, x];
        }
      }

      return destination;
    }

    /// <summary>
    /// Flips the array horizontally
    /// </summary>
    public static T[,] FlipHorizontal<T>(this T[,] source) where T : new()
    {
      var destination = new T[source.GetLength(0), source.GetLength(1)];

      for (int x = 0; x < source.GetLength(0); x++)
      {
        for (int y = 0; y < source.GetLength(1); y++)
        {
          destination[x, y] = source[source.GetLength(0) - x - 1, y];
        }
      }

      return destination;
    }

    /// <summary>
    /// Flips the array vertically
    /// </summary>
    public static T[,] FlipVertical<T>(this T[,] source) where T : new()
    {
      var destination = new T[source.GetLength(0), source.GetLength(1)];

      for (int x = 0; x < source.GetLength(0); x++)
      {
        for (int y = 0; y < source.GetLength(1); y++)
        {
          destination[x, y] = source[x, source.GetLength(1) - y - 1];
        }
      }

      return destination;
    }

    /// <summary>
    /// Returns an array representing a row of this array
    /// </summary>
    public static T[] Row<T>(this T[,] source, int rowIndex) where T : new()
    {
      if (rowIndex < 0 || rowIndex >= source.GetLength(0))
        throw new ArgumentException(rowIndex + " is not a valid row index in this array");

      var row = new T[source.GetLength(0)];

      for (int i = 0; i < row.Length; i++)
        row[i] = source[i, rowIndex];

      return row;
    }

    /// <summary>
    /// Returns an array representing a column of this array
    /// </summary>
    public static T[] Column<T>(this T[,] source, int columnIndex) where T : new()
    {
      if (columnIndex < 0 || columnIndex >= source.GetLength(0))
        throw new ArgumentException(columnIndex + " is not a valid column index in this array");

      var row = new T[source.GetLength(0)];

      for (int i = 0; i < row.Length; i++)
        row[i] = source[columnIndex, i];

      return row;
    }

    /// <summary>
    /// Prints a visual representation of the array
    /// </summary>
    public static string ToString<T>(this T[,] source, Func<T, object> selector) where T : new()
    {
      string output = "";

      for (int y = 0; y < source.GetLength(1); y++)
      {
        for (int x = 0; x < source.GetLength(0); x++)
          output += selector(source[x, y]).ToString();

        output += Environment.NewLine;
      }

      return output;
    }
  }
}
