using System;
using System.Collections.Generic;
using System.Text;

namespace DIConsoleApplication.Bsl
{
    public class NumberService : INumberService
    {
        public List<int> GetEvenNumber(int from, int to)
        {
            if (from <= 0 && to <= 0) return null;
            if (from > to) return null;
            List<int> result = new List<int>();
            for(int i = from; i<= to; i++)
            {
                if(i % 2 == 0)
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}
