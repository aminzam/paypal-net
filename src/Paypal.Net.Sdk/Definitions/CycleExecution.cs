using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class CycleExecution {
    [JsonProperty("tenure_type")]
    public string TenureType { get; set; }

    [JsonProperty("sequence")]
    public long Sequence { get; set; }

    [JsonProperty("cycles_completed")]
    public long CyclesCompleted { get; set; }

    [JsonProperty("cycles_remaining")]
    public long CyclesRemaining { get; set; }

    [JsonProperty("current_pricing_scheme_version")]
    public long CurrentPricingSchemeVersion { get; set; }
    
    [JsonProperty("total_cycles")]
    public long TotalCycles { get; set; }
  }

}