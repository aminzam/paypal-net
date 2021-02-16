using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class TransactionFee
  {
    [JsonProperty("currency")]
    public string Currency { get; set; }

    [JsonProperty("value")]
    public string Value { get; set; }
  }

}