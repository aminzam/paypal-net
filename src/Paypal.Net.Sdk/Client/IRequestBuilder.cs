using System.Net.Http;
using System.Threading.Tasks;

namespace Paypal.Net.Sdk.Client {

  public interface IRequestBuilder {

    Task<HttpRequestMessage> CreateRequestAsync(HttpMethod method, object body, string apiRelativeUrl);
  }
}