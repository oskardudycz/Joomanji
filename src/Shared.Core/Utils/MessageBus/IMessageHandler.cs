using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shared.Core.Utils.MessageBus
{
    public interface IMessageHandler<TMessage> where TMessage : class, IMessage, new()
    {
        void HandleMessage(TMessage message);
    }
}
