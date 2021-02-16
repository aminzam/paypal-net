namespace Paypal.Net.Sdk.Utility {

  public delegate T GenericTypeMapper<out T>(string eventType);
}