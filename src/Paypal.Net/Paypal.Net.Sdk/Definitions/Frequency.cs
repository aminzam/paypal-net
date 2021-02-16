using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class Frequency {
    [JsonProperty("interval_unit")]
    public string IntervalUnit { get; set; }

    [JsonProperty("interval_count")]
    public int IntervalCount { get; set; }
  }

}