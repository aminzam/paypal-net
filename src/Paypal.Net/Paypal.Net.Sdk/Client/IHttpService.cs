using System.Net.Http;
using System.Threading.Tasks;

namespace Paypal.Net.Sdk.Client {

  public interface IHttpService {

    Task<HttpResponseMessage> SendAndReturnResponseAsync(HttpRequestMessage request);
  }
}