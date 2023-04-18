/** Recursive Fibonacci was just created to perform a calculation workload. 
    It takes the number of interations with the parameter -nX and that is the number
    of iterations it performs.
**/
using System.Threading;

if ((args.Length == 0) || Array.Find(args, element => element.Contains('?'))=="-?") 
{
    Console.WriteLine("Runs Fibonacci Sequence via recursion - just to create memory load.");
    Console.WriteLine("-nNUM          Runs the Fibonacci sequence recursively (NUM) times");
    Console.WriteLine("-d             Displays every TOTAL of Fibonacci");
    Console.WriteLine("-sx            Sleeps X milliseconds (i.e 1000=1s) between iterations");
}
else
{
    UInt128 permutations = 0;
    bool displayOut = false;
    int sleeper = 0;
    for(int idx=0; idx<args.Length; idx++)
    {
        try
        {
            if (args[idx].Contains("-n")) 
            {
                permutations = UInt128.Parse(args[idx].Substring(2, args[idx].Length-2));
            }
            if (args[idx].Contains("-d")) displayOut = true;
            if (args[idx].Contains("-s")) 
            {
                sleeper = int.Parse(args[idx].Substring(2, args[idx].Length-2));
            }
        }
        catch(Exception) 
        { 
            Console.WriteLine("Error: Runs Fibonacci Sequence via recursion - just to create memory load.");
            Console.WriteLine("-nNUM          Runs the Fibonacci sequence recursively (NUM) times");
            Console.WriteLine("-d             Displays every TOTAL of Fibonacci");
            Console.WriteLine("-sx            Sleeps X milliseconds (i.e 1000=1s) between iterations");
            System.Environment.Exit(1);
        }
    }
    Console.WriteLine($"{Fibonacci(0, 1, permutations, displayOut, sleeper)}");
}


UInt128 Fibonacci(UInt128 val2, UInt128 val1, UInt128 count, bool disp=false, int sleep = 0)
{
    Thread.Sleep(sleep);
    if (count-1 == 0) return 0;
    UInt128 current = val2 + val1;
    UInt128 nextNumbers = Fibonacci(val1, current, count - 1, disp, sleep);
    if (disp) Console.WriteLine(current);
    return nextNumbers != 0 ? nextNumbers : current;
}

