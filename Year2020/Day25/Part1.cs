using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day25
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      long cardPublicKey = long.Parse(input.Split(Environment.NewLine)[0]);
      long doorPublicKey = long.Parse(input.Split(Environment.NewLine)[1]);

      long cardLoopSize = GetSecretLoopSize(cardPublicKey);
      long doorLoopSize = GetSecretLoopSize(doorPublicKey);

      long encryptionKeyCard = TransformSubjectNumber(cardPublicKey, doorLoopSize);
      long encryptionKeyDoor = TransformSubjectNumber(doorPublicKey, cardLoopSize);

      return encryptionKeyCard;
    }

    private long GetSecretLoopSize(long publicKey)
    {
      long subjectNumber = 7;
      long value = 1;

      for (int loopCount = 1; loopCount < int.MaxValue; loopCount++)
      {
        value *= subjectNumber;
        value %= 20201227;

        if (value == publicKey)
          return loopCount;
      }

      return 0L;
    }

    private long TransformSubjectNumber(long subjectNumber, long loopSize)
    {
      long value = 1;

      for (int loopCount = 0; loopCount < loopSize; loopCount++)
      {
        value *= subjectNumber;
        value %= 20201227;
      }

      return value;
    }
  }
}
