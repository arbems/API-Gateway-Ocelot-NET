using System.Net;

namespace OCELOT_API_Gateway
{
    public class ApiKeyHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!ValidateKey(request))
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return response;
            }
            return await base.SendAsync(request, cancellationToken);
        }

        private bool ValidateKey(HttpRequestMessage request)
        {
            if (request.Headers.TryGetValues("ApiKey", out IEnumerable<string> myHeaderList))
            {
                var myHeader = myHeaderList.First();

                //do something with the header value
                if (!string.IsNullOrEmpty(myHeader) && myHeader == "123456")
                    return true;
            }

            return false;
        }
    }
}
