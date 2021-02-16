using System;
using System.Collections.Generic;
using System.Linq;

namespace Paypal.Net.Sdk.Utility {

  public class GenericStringTypeResolver<THandler> where THandler : class {

    private readonly Dictionary<string, Type> _messageHandlers;

    public IReadOnlyList<string> RegisteredEvents => _messageHandlers.Keys.ToArray();

    public GenericStringTypeResolver() {

      _messageHandlers = new Dictionary<string, Type>();
    }

    public GenericStringTypeResolver<THandler> Register<THandlerT>(string eventType) {

      _messageHandlers.Add(eventType, typeof(THandlerT));
      return this;
    }

    public Type Resolve(string eventType) {

      if (!string.IsNullOrEmpty(eventType) && _messageHandlers.TryGetValue(eventType, out Type handlerType)) {

        return handlerType;
      }

      return null;
    }
  }
}