using System.Threading.Tasks;

namespace Paypal.Net.Sdk.Client {

  public interface IAuthenticationApi {

    Task<string> GetAccessTokenAsync();
  }
}