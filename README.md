# .NET-5-Mapper-Benchmark
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1139 (1909/November2018Update/19H2)
Intel Core i7-9850H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=5.0.102
  [Host]   : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT  [AttachedDebugger]
  ShortRun : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|              Method | loops |         Mean |        Error |       StdDev |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|-------------------- |------ |-------------:|-------------:|-------------:|--------:|-------:|------:|----------:|
|             Mapster |     1 |     66.19 ns |     34.36 ns |     1.884 ns |  0.0331 |      - |     - |     208 B |
|         HandMadeMap |     1 |     69.42 ns |     58.59 ns |     3.211 ns |  0.0343 |      - |     - |     216 B |
| TinyMapperBenchmark |     1 |     85.55 ns |     63.32 ns |     3.471 ns |  0.0267 |      - |     - |     168 B |
| AutoMapperBenchmark |     1 |    180.93 ns |    130.48 ns |     7.152 ns |  0.0534 |      - |     - |     336 B |
|         HandMadeMap |    10 |    231.38 ns |     16.03 ns |     0.879 ns |  0.1605 | 0.0005 |     - |    1008 B |
|             Mapster |    10 |    257.18 ns |    142.97 ns |     7.837 ns |  0.2050 | 0.0005 |     - |    1288 B |
| AutoMapperBenchmark |    10 |    521.41 ns |    264.33 ns |    14.489 ns |  0.2518 |      - |     - |    1584 B |
| TinyMapperBenchmark |    10 |    713.57 ns |    132.73 ns |     7.276 ns |  0.1793 |      - |     - |    1128 B |
|         HandMadeMap |   100 |  1,903.63 ns |  1,484.60 ns |    81.376 ns |  1.4229 | 0.0420 |     - |    8928 B |
|             Mapster |   100 |  2,157.49 ns |  2,178.18 ns |   119.393 ns |  1.9264 | 0.0572 |     - |   12088 B |
| AutoMapperBenchmark |   100 |  3,562.61 ns |  3,269.75 ns |   179.226 ns |  2.1553 | 0.0725 |     - |   13528 B |
| TinyMapperBenchmark |   100 |  6,543.41 ns |    497.76 ns |    27.284 ns |  1.6174 | 0.0534 |     - |   10192 B |
|         HandMadeMap |  1000 | 23,392.61 ns | 22,233.67 ns | 1,218.702 ns | 14.0381 | 2.8076 |     - |   88128 B |
|             Mapster |  1000 | 24,573.72 ns |  1,302.94 ns |    71.419 ns | 19.1345 | 3.8147 |     - |  120088 B |
| AutoMapperBenchmark |  1000 | 32,980.86 ns |  2,713.86 ns |   148.756 ns | 20.5078 | 4.0894 |     - |  128736 B |
| TinyMapperBenchmark |  1000 | 74,295.80 ns |  5,064.79 ns |   277.618 ns | 15.3809 | 3.0518 |     - |   96600 B |
