using System;
using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class NotificationMessage {

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("create_time")]
    public DateTime CreateTime { get; set; }

    [JsonProperty("event_type")]
    public string EventType { get; set; }

    [JsonProperty("event_version")]
    public string EventVersion { get; set; }

    [JsonProperty("resource_type")]
    public string ResourceType { get; set; }

    [JsonProperty("resource_version")]
    public string ResourceVersion { get; set; }

    [JsonProperty("summary")]
    public string Summary { get; set; }

    [JsonProperty("resource")]
    public Resource Resource { get; set; }

    [JsonProperty("links")]
    public Link[] Links { get; set; }
  }

}