using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StdRandom
{
    class RandomSet : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            while (true)
                yield return generator.Next();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            while (true)
                yield return generator.Next();
        }

        Random generator = new Random();
    }

    public class RandomGeneration
    {
        public static List<int>  GenerateInt(int count)
        {
            return new RandomSet().Take(count).Select(m=>m%count).ToList();
        }
    }
}
