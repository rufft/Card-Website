``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 11 (10.0.22621.1413/22H2/2022Update/SunValley2)
AMD Ryzen 5 3600X, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.201
  [Host]     : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.3 (7.0.323.6910), X64 RyuJIT AVX2


```
|               Method |     Mean |   Error |  StdDev |   Gen0 |   Gen1 | Allocated |
|--------------------- |---------:|--------:|--------:|-------:|-------:|----------:|
| GetTagAsyncBenchmark | 250.3 μs | 3.66 μs | 3.43 μs | 8.3008 | 1.4648 |   70.4 KB |
|      GetTagBenchmark | 222.0 μs | 3.32 μs | 3.10 μs | 8.0566 | 1.2207 |  66.93 KB |
