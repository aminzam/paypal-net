using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Paypal.Net.Sdk.Client {

  internal class ResponseReader : IResponseReader {

    public async Task<T> ReadResponseAsync<T>(HttpResponseMessage response) {

      string responseJson = await response.Content.ReadAsStringAsync();
      return JsonConvert.DeserializeObject<T>(responseJson, new JsonSerializerSettings {
        DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffK"
      });
    }
  }
}
