using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class BillingCycle {
    [JsonProperty("frequency")]
    public Frequency Frequency { get; set; }

    [JsonProperty("tenure_type")]
    public string TenureType { get; set; }

    [JsonProperty("sequence")]
    public long Sequence { get; set; }

    [JsonProperty("total_cycles")]
    public long TotalCycles { get; set; }

    [JsonProperty("pricing_scheme")]
    public PricingScheme PricingScheme { get; set; }
  }

}