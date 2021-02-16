using Paypal.Net.Sdk.Definitions;
using System.Threading.Tasks;

namespace Paypal.Net.Sdk.Client {
  public interface IPaypalRestApiClient {
    Task<T> Get<T>(string apiRelativeUrl);
    Task Patch(Patch[] patches, string apiRelativeUrl);
    Task Post(object body, string apiRelativeUrl);
    Task Post(string apiRelativeUrl);
    Task<T> Post<T>(object body, string apiRelativeUrl);
  }
}