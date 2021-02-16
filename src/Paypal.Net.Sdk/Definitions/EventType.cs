using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class EventType
  {
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }
  }

}