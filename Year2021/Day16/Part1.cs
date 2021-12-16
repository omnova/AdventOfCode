using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2021.Day16
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      string packet = string.Join(null, input.Select(c => Convert.ToByte("0" + c.ToString(), 16)).Select(b => Convert.ToString(b, 2).PadLeft(8, '0').Substring(4)).ToArray());

      int versionNumberTotal = 0;
      int cursor = 0;

      ProcessPacket(packet, ref cursor, ref versionNumberTotal);

      return versionNumberTotal;
    }

    private void ProcessPacket(string packet, ref int cursor, ref int versionTotal)
    {
      int packetVersion = Convert.ToInt32(packet.Substring(cursor, 3), 2);
      int packetTypeID = Convert.ToInt32(packet.Substring(cursor + 3, 3), 2);

      versionTotal += packetVersion;

      cursor += 6;

      if (packetTypeID == 4)
        ProcessLiteralPacket(packet, ref cursor);
      else
        ProcessOperatorPacket(packet, ref cursor, ref versionTotal);
    }

    private void ProcessLiteralPacket(string packet, ref int cursor)
    {
      while (true)
      {
        cursor += 5;

        if (packet[cursor - 5] == '0')
          break;
      }
    }

    private void ProcessOperatorPacket(string packet, ref int cursor, ref int versionTotal)
    {
      char lengthMode = packet[cursor++];

      if (lengthMode == '0')
      {
        int length = Convert.ToInt32(packet.Substring(cursor, 15), 2);

        cursor += 15;

        int subPacketEnd = cursor + length;

        while (cursor < subPacketEnd)
        {
          ProcessPacket(packet, ref cursor, ref versionTotal);
        }
      }
      else
      {
        int numSubPackets = Convert.ToInt32(packet.Substring(cursor, 11), 2);

        cursor += 11;

        for (int i = 0; i < numSubPackets; i++)
        {
          ProcessPacket(packet, ref cursor, ref versionTotal);
        }
      }
    }
  }
}
