using System;
using System.Collections.Generic;
using System.Text;
using CommonCode.Messages;
using Data.Model;
using Microsoft.EntityFrameworkCore.Internal;

namespace CommonCode.Code.Builders
{
    public class MessageBuilder<T> : IBuilder<BaseMessage<T>>
    {
        private readonly User _user;
        private readonly BaseMessage<T> _baseMessage;

        public MessageBuilder(User user, T content)
        {
            _user = user;
            _baseMessage = new BaseMessage<T>(content);
        }

        public MessageBuilder<T> SendAsEmail(string title)
        {
            _baseMessage.Recipients.Add(new EmailSendingInfo(_user.Email, title));
            return this;
        }

        public MessageBuilder<T> SendInApp()
        {
            _baseMessage.Recipients.Add(new InAppSendingInfo(_user.Id));
            return this;
        }

        public BaseMessage<T> GetInstance()
        {
            if (!_baseMessage.Recipients.Any())
            {
                throw new Exception("must have a recipient");
               
            }
            
            return _baseMessage;
        }
    }
}
