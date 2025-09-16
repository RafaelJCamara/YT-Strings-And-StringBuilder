using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Text;

//var str = "";

//for (var i = 0; i < 100; i++)
//{
//    //append to string in each iteration
//    str += i;
//}

//var sb = new StringBuilder("Hello start ");
//sb.Append("Hello, ");

//Console.WriteLine(sb.ToString());

[MemoryDiagnoser]
public class StringVsStringBuilderBenchmarks
{
    [Params(1,10,100,1_000,10_000)]
    public int NumOfConcats;

    [Benchmark(Baseline = true)]
    public string PlusConcatenation()
    {
        var str = "";
        for (var i = 0; i < NumOfConcats; i++)
        {
            str += i;
        }
        return str;
    }

    [Benchmark]
    public string StringBuilderConcatenation()
    {
        var sb = new StringBuilder();
        for (var i = 0; i < NumOfConcats; i++)
        {
            sb.Append(i);
        }
        return sb.ToString();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<StringVsStringBuilderBenchmarks>();
    }
}