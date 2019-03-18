using System.Collections.Generic;

namespace CommonCode.Messages
{
    public class BaseMessage<T>
    {
        public ICollection<SendingInfo> Recipients { get; set; }
        public T Content { get; set; }

        public BaseMessage(T content)
        {
            Content = content;
            
            Recipients = new List<SendingInfo>();
        }
    }
}