using System.Collections.Generic;
using System.Threading.Tasks;

namespace CCTest
{
    public static class Program
    {
        public static void Main()
        {
            Foo(1).GetAwaiter().GetResult();
            Goo(2).GetAwaiter().GetResult();
            Gee(3).GetAwaiter().GetResult();
            Hoo(4).GetAwaiter().GetResult();
        }

        private static async Task Foo(int x)
        {
            var test = new MyTest();

            await test.PrintNumbersAsync(x, 0);
            await test.PrintNumbersAsync(x, 1);
            await test.PrintNumbersAsync(x, 2);
            await test.PrintNumbersAsync(x, 3);
            await test.PrintNumbersAsync(x, 4);
        }

        private static async Task Goo(int x)
        {
            var test = new MyTest();

            var tasks =
                new List<Task>
                {
                    test.PrintNumbersAsync(x, 0),
                    test.PrintNumbersAsync(x, 1),
                    test.PrintNumbersAsync(x, 2),
                    test.PrintNumbersAsync(x, 3),
                    test.PrintNumbersAsync(x, 4),
                };

            foreach (var task in tasks)
            {
                await task;
            }
        }

        private static async Task Gee(int x)
        {
            var test = new MyTest();

            var tasks =
                new List<Task>
                {
                    test.PrintNumbersAsync(x, 0),
                    test.PrintNumbersAsync(x, 1),
                    test.PrintNumbersAsync(x, 2),
                    test.PrintNumbersAsync(x, 3),
                    test.PrintNumbersAsync(x, 4),
                };

            await tasks[0];
            await tasks[1];
            await tasks[2];
            await tasks[3];
            await tasks[4];
        }

        private static async Task Hoo(int x)
        {
            var test = new MyTest();

            var tasks =
                new List<Task>
                {
                    test.PrintNumbersAsync(x, 0),
                    test.PrintNumbersAsync(x, 1),
                    test.PrintNumbersAsync(x, 2),
                    test.PrintNumbersAsync(x, 3),
                    test.PrintNumbersAsync(x, 4),
                };

            await Task.WhenAll(tasks);
        }
    }
}
