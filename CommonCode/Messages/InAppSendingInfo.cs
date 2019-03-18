namespace CommonCode.Messages
{
    public class InAppSendingInfo : SendingInfo
    {
        public long UserId { get; set; }
        
        public InAppSendingInfo(long userId) : base(MessageType.InApp)
        {
            UserId = userId;
        }
    }
}