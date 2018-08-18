using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeRetry
{
    /// <summary>
    /// Generic class for Code Retry Implementation
    /// </summary>
    public static class CodeRetryExtensions
    {
        /// <summary>
        /// Retry
        /// </summary>
        /// <param name="action"></param>
        /// <param name="retryInterval"></param>
        /// <param name="maxAttemptCount"></param>
        /// <returns></returns>
        public static Task Retry(Action action, TimeSpan retryInterval, int maxAttemptCount = 3)
        {
            return Retry<object>(() =>
            {
                action();
                return null;
            }, retryInterval, maxAttemptCount);
        }

        /// <summary>
        /// Generic Retry<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="retryInterval"></param>
        /// <param name="maxAttemptCount"></param>
        /// <returns></returns>
        public async static Task<T> Retry<T>(Func<Task<T>> action, TimeSpan retryInterval, int maxAttemptCount = 3)
        {
            var exceptions = new List<Exception>();

            for (int attempted = 0; attempted < maxAttemptCount; attempted++)
            {
                try
                {
                    if (attempted > 0)
                    {
                        await Task.Delay(retryInterval).ConfigureAwait(true);
                    }
                    return await action();
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
            throw new AggregateException(exceptions);
        }


    }
}
