using System.Threading.Tasks;
using Paypal.Net.Sdk.Definitions;

namespace Paypal.Net.Sdk.Messages {

  public interface IPaypalMessageHandler {

    Task ProcessMessageAsync(NotificationMessage notificationMessage);
  }
}