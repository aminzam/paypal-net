using System.Globalization;
using Newtonsoft.Json;

namespace Paypal.Net.Sdk.Definitions {

  public partial class Money {

    [JsonIgnore]
    public double ValueDouble {

      get => double.Parse(Value);
      set => Value = value.ToString(CultureInfo.InvariantCulture);
    }

    [JsonProperty("value")]
    public string Value { get; set; }

    [JsonProperty("currency_code")]
    public string CurrencyCode { get; set; }
  }
}