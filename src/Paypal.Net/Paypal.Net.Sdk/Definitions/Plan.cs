using System;
using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class Plan {
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("product_id")]
    public string ProductId { get; set; }

    [JsonProperty("status")]
    public string Status { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("create_time")]
    public DateTimeOffset CreateTime { get; set; }

    [JsonProperty("links")]
    public Link[] Links { get; set; }
  }

}