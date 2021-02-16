using System;
using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public class WebhookCreateRequest {

    [JsonProperty("url")]
    public Uri Url { get; set; }

    [JsonProperty("event_types")]
    public EventType[] EventTypes { get; set; }
  }
}