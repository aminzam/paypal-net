using System.Net.Http;
using System.Threading.Tasks;

namespace Paypal.Net.Sdk.Client {

  public interface IResponseReader {

    Task<T> ReadResponseAsync<T>(HttpResponseMessage response);
  }
}