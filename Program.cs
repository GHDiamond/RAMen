// Initialization
using System.Diagnostics;
List<Int128[]> a = [];
int chunks = Array.MaxLength;

// Start the stopwatch
var stopwatch = Stopwatch.StartNew();

// The actual RAM filler (with handled exceptions)
try
{
    for(;;){a.Add(new Int128[chunks]);}
}
catch (Exception) { }

// Gets the elapsed time
stopwatch.Stop();
Console.WriteLine($"{stopwatch.ElapsedMilliseconds}ms");

// Statistics
Console.WriteLine($"Created {a.Count} arrays of {chunks} 128-bit signed integers (allocated {(UInt128)a.Count * (UInt128)chunks * (UInt128)128 / (UInt128)8}B)");
Console.ReadKey();
