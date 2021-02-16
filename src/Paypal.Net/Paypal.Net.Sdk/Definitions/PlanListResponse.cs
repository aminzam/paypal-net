using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class PlanListResponse {
    [JsonProperty("total_items")]
    public long TotalItems { get; set; }

    [JsonProperty("total_pages")]
    public long TotalPages { get; set; }

    [JsonProperty("plans")]
    public Plan[] Plans { get; set; }

    [JsonProperty("links")]
    public Link[] Links { get; set; }
  }

}