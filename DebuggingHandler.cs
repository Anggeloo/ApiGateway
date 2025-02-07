namespace ApiGateway
{
    public class DebuggingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Request URI: {request.RequestUri}");
            var response = await base.SendAsync(request, cancellationToken);
            Console.WriteLine($"Response Status: {response.StatusCode}");
            return response;
        }
    }
}
