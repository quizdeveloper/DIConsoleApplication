using System;
using System.Collections.Generic;
using System.Text;

namespace DIConsoleApplication.Bsl
{
    public interface INumberService
    {
        List<int> GetEvenNumber(int from, int to);
    }
}
