using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class Details
  {
    [JsonProperty("subtotal")]
    public string Subtotal { get; set; }
  }

}