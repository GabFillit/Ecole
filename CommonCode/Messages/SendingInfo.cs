namespace CommonCode.Messages
{
    public abstract class SendingInfo
    {
        public MessageType MessageType { get; protected set; }

        protected SendingInfo(MessageType messageType)
        {
            MessageType = messageType;
        }
    }
}