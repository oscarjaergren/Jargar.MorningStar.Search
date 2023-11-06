using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;
using Microsoft.Extensions.Configuration;

namespace Jargar.MorningStar.Search.Api.Benchmark;

static class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run(typeof(PersonSearchBenchmarks));
    }
}