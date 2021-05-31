using System;

namespace Algorithm.ST
{
    
    public interface ST<Key, Value>　where Key : IComparable
    {
        public void Put(Key key, Value value);

        public Value Get(Key key);

        public void Delete(Key key);

        public bool Contains(Key key);

        public bool IsEmpty();

        public int Size();

        public Key Min();

        public Key Max();

  //      public Key Floor(Key key);


  //      public Key Ceiling(Key key);


        public int Rank(Key key);

        public Key Select(int k);

        public void DeleteMin();


        public void DeleteMax();

        public int Size(Key lo, Key hi);

    }
}
