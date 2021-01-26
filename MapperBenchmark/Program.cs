using System;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

namespace MapperBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ManualConfig();
            config.Add(DefaultConfig.Instance);
            config.AddDiagnoser();

            BenchmarkRunner.Run<BenchmarkMapper>(config);
        }
    }
}
