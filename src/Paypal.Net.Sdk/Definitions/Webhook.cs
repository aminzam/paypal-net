using System;
using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class Webhook
  {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("url")]
    public Uri Url { get; set; }

    [JsonProperty("event_types")]
    public EventType[] EventTypes { get; set; }

    [JsonProperty("links")]
    public Link[] Links { get; set; }
  }

}