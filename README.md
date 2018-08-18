# CodeRetry
Generic class for Code Retry Implementation

Usage:
Example 1 :

var httpResponse = await CodeRetryExtensions.Retry<HttpResponseMessage>(() => httpClient.PostAsJsonAsync<T>(argRoute, request), TimeSpan.FromMinutes(1), 2).ConfigureAwait(false);
  
Example 2:

Task.Run(() => CodeRetryExtensions.Retry(() => Print(), TimeSpan.FromMinutes(1), 3));

