using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExempleCollisionThread
{
    public class StringBenchmarkPerformance
    {
        int[] numbers;
        public StringBenchmarkPerformance()
        {
            numbers = Enumerable.Range(start: 1, count: 20).ToArray();
        }

        [Benchmark(Baseline = true)]
        public string StringConcatenationTest()
        {
            string s = string.Empty;
            for (int i = 0; i < numbers.Length; i++)
                s += numbers[i] + " ";
            return s;
        }


        [Benchmark]
        public string StringBuilderTest()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < numbers.Length; i++)
                builder.Append(numbers[i]).Append(" ");
            
            return builder.ToString();
        }
    }
}
