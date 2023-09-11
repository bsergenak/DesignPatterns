using DesignPattern.Decorator.DAL;
using System;

namespace DesignPattern.Decorator.DecoratorPattern2
{
    public class EncryptByContentDecorator : Decorator
    {
        private readonly ISendMessage _sendMessage;
        Context context = new Context();
        public EncryptByContentDecorator(ISendMessage sendMessage) : base(sendMessage)
        {
            _sendMessage = sendMessage;
        }

        public void SendMessageEncryptoContent(Message message)
        {
            message.MessageSender = "Takım Lider";
            message.MessageReceiver = "Yazılım Ekibi";
            message.MessageContent = "Saat 17:00'da Publish İşlemi Yapılacak";
            message.MessageSubject = "Publish";
            string data = " ";
            data = message.MessageContent;
            char[] chars = data.ToCharArray();
            foreach (var item in chars)
            {
                message.MessageSubject += Convert.ToChar(item + 3).ToString();
            }
            context.Messages.Add(message);
            context.SaveChanges();
        }
        public override void SendMessage(Message message)
        {
            base.SendMessage(message);
            SendMessageEncryptoContent(message);
        }
    }
}
