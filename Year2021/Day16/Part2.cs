using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021.Day16
{
  public class Part2 : IPuzzle
  {  
    public object Run(string input)
    {
      string packet = string.Join(null, input.Select(c => Convert.ToString(Convert.ToByte(c.ToString(), 16), 2).PadLeft(8, '0').Substring(4)).ToArray());

      int cursor = 0;

      long total = GetPacketValue(packet, ref cursor);

      return total;
    }

    private long GetPacketValue(string packet, ref int cursor)
    {      
      int packetTypeID = Convert.ToInt32(packet.Substring(cursor + 3, 3), 2);

      cursor += 6;

      if (packetTypeID == 4)
        return GetLiteralPacketValue(packet, ref cursor);
      else
        return GetOperatorPacketValue(packet, ref cursor, packetTypeID);
    }

    private long GetLiteralPacketValue(string packet, ref int cursor)
    {
      string literal = string.Empty;

      while (cursor < packet.Length)
      {
        literal += packet.Substring(cursor + 1, 4);

        cursor += 5;

        if (packet[cursor - 5] == '0')
          break;
      }

      return Convert.ToInt64(literal, 2);
    }

    private long GetOperatorPacketValue(string packet, ref int cursor, int packetTypeID)
    {
      char lengthMode = packet[cursor++];

      var packetValues = new List<long>();

      if (lengthMode == '0')
      {
        int length = Convert.ToInt32(packet.Substring(cursor, 15), 2);

        cursor += 15;

        int subPacketEnd = cursor + length;

        while (cursor < subPacketEnd)
        {
          long value = GetPacketValue(packet, ref cursor);

          packetValues.Add(value);
        }
      }
      else
      {
        int numSubPackets = Convert.ToInt32(packet.Substring(cursor, 11), 2);

        cursor += 11;

        for (int i = 0; i < numSubPackets; i++)
        {
          long value = GetPacketValue(packet, ref cursor);

          packetValues.Add(value);
        }
      }

      return packetTypeID switch
      {
        0 => packetValues.Sum(),
        1 => packetValues.Aggregate(1L, (a, b) => a * b),
        2 => packetValues.Min(),
        3 => packetValues.Max(),
        5 => packetValues[0] > packetValues[1] ? 1 : 0,
        6 => packetValues[0] < packetValues[1] ? 1 : 0,
        7 => packetValues[0] == packetValues[1] ? 1 : 0,
        _ => throw new Exception("wat")
      };
    }
  }
}
