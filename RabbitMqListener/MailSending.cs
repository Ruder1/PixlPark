using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;

namespace RabbitMqListener
{
    public class MailSending
    {
        public void MessageSend(MailModel mail)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Example", "Ruder1234@yandex.ru"));
                message.To.Add(new MailboxAddress("Send", mail.Email));
                message.Subject = "Test Sending";

                message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = mail.Message
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.yandex.ru", 465, true);

                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate("Ruder1234@yandex.ru", "tcenifdqvozkkhnj");

                    client.Send(message);
                    client.Disconnect(true);
                }
                string str = "Сообщение доставлено";
                Console.WriteLine(str);
                new RabbitServer().RabbitSender(str);
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                new RabbitServer().RabbitSender(ex.Message);
            }
        }
    }
}
