namespace CCTest2;

public class MyTest
{
    public async Task PrintNumbersAsync(int x, int y)
    {
        await Task.Delay(1000);

        Console.WriteLine($"{x} {y}");
    }
}
