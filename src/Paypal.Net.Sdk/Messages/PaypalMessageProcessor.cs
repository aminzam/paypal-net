using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Paypal.Net.Sdk.Definitions;
using Paypal.Net.Sdk.Utility;

namespace Paypal.Net.Sdk.Messages {

  public class PaypalMessageProcessor {

    private readonly IServiceProvider _serviceProvider;

    public PaypalMessageProcessor(IServiceProvider serviceProvider) {

      _serviceProvider = serviceProvider;
    }

    public async Task<bool> ParseAndProcessMessageAsync(string notificationMessageJson) {

      var notificationMessage =
        JsonConvert.DeserializeObject<NotificationMessage>(notificationMessageJson, new JsonSerializerSettings {
          DateFormatString = "yyyy-MM-ddTHH:mm:ss.fffK"
        });

      var map = _serviceProvider.GetRequiredService<GenericTypeMapper<IPaypalMessageHandler>>();
      IPaypalMessageHandler handler = map(notificationMessage?.EventType);

      if (handler == null)
        return false;

      await handler.ProcessMessageAsync(notificationMessage);
      return true;
    }
  }
}