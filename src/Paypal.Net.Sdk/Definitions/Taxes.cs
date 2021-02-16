using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class Taxes {
    [JsonProperty("percentage")]
    public double Percentage { get; set; }

    [JsonProperty("inclusive")]
    public bool Inclusive { get; set; }
  }

}