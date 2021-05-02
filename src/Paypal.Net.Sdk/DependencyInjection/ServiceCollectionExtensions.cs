using System;
using Microsoft.Extensions.DependencyInjection;
using Paypal.Net.Sdk.Api;
using Paypal.Net.Sdk.Client;
using Paypal.Net.Sdk.Messages;
using Paypal.Net.Sdk.Messages.Validation;
using Paypal.Net.Sdk.Utility;
using PaypalResolver = Paypal.Net.Sdk.Utility.GenericStringTypeResolver<Paypal.Net.Sdk.Messages.IPaypalMessageHandler>;


namespace Paypal.Net.Sdk.DependencyInjection {

  public static class ServiceCollectionExtensions {

    public static IServiceCollection AddPaypalApi(this IServiceCollection services) {

      services.AddScoped<AuthenticationApi>();
      services.AddScoped<CatalogProductApi>();
      services.AddScoped<BillingPlanApi>();
      services.AddScoped<PaypalRestApiClient>();
      services.AddScoped<NotificationWebhooksApi>();
      services.AddScoped<BillingSubscriptionApi>();
      services.AddScoped<PaypalMessageProcessor>();
      services.AddScoped<IRequestBuilder, RequestBuilder>();
      services.AddScoped<IResponseReader, ResponseReader>();
      services.AddScoped<IHttpService, HttpService>();
      services.AddHttpClient<HttpService>(HttpService.PaypalHttpClientName);

      services.AddScoped<GenericTypeMapper<IPaypalMessageHandler>>(provider =>
        type => {

          var resolver = provider.GetService<PaypalResolver>();
          Type resolvedType = resolver.Resolve(type);

          if (resolvedType == null)
            return null;

          return provider.GetService(resolvedType) as IPaypalMessageHandler;
        });

      services.AddSingleton<WebHookValidator>();
      services.AddSingleton<CertificateManager>();
      services.AddSingleton<PaypalResolver>();

      return services;
    }
  }
}