// See https://aka.ms/new-console-template for more information
// Load the configuration
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var builder = BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly);

builder.Run(args, new ConfigOptions()
    .WithOptions(ConfigOptions.DisableOptimizationsValidator)
    .WithOptions(ConfigOptions.JoinSummary);

builder.Services.AddSingleton<IConfiguration>(configuration);