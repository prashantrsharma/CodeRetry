using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRetry
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Task.Run(() => CodeRetryExtensions.Retry(() => Print(), TimeSpan.FromMinutes(1), 3));

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                Console.ReadKey();
            }
        }

        static void Print()
        {
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine($"val of  i-{i} at time : {DateTime.UtcNow}");
                if(i == 8)
                    throw new Exception($"i equals {i}");
            }

        }
    }
}
