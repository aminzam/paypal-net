using System;
using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class Link {
    [JsonProperty("href")]
    public Uri Href { get; set; }

    [JsonProperty("rel")]
    public string Rel { get; set; }

    [JsonProperty("method")]
    public string Method { get; set; }
  }

}