using System;
using System.Threading.Tasks;
public class TestAsync
{
    public static async Task DoWorkAsync()
    {
        await Task.Run(() => System.Console.WriteLine(5.ToString()));
        Console.WriteLine((await Task.Run(()=>6)).ToString());
        await Task.Run(() => (Task.Run(() => Console.WriteLine(7.ToString()))));
        int value = await Task.Run(() => Task.Run(() => 8));
        Console.WriteLine(value.ToString());
    }
	static void Main()
	{
        Task t = TestAsync.DoWorkAsync();
        t.Wait();
        Console.WriteLine("Press Enter key to exit");
        Console.Read();
	}
}
