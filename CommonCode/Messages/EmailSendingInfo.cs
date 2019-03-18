using System;
using System.Collections.Generic;
using System.Text;

namespace CommonCode.Messages
{
    public class EmailSendingInfo : SendingInfo
    {
        public string Email { get; set; }
        public string Title { get; set; }

        public EmailSendingInfo(string email, string title) : base(MessageType.Email)
        {
            Email = email;
            Title = title;
        }
    }
}
