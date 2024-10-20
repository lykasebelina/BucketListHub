using MailKit.Net.Smtp;
using MimeKit;



namespace BucketListDestination
{
    public class MailService
    {
        private readonly string smtpServer = "sandbox.smtp.mailtrap.io";
        private readonly int smtpPort = 2525;
        private readonly string smtpUsername = "68b41fc119d90e";
        private readonly string smtpPassword = "f9274f89766648";
        private readonly string fromEmail = "do-not-reply@bucketlist.com";
        private readonly string toEmail = "your-email@example.com";

        public void SendEmail(string subject, string messageBody)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("BucketList App", fromEmail));
            message.To.Add(new MailboxAddress("User", toEmail));
            message.Subject = subject;


            message.Body = new TextPart("html")
            {

                Text = "<h1>BucketList Notification</h1>" + $"<p>{messageBody}</p>"



            };

            using (var client = new SmtpClient())
            {
                try
                {

                    client.Connect(smtpServer, smtpPort, MailKit.Security.SecureSocketOptions.StartTls);


                    client.Authenticate(smtpUsername, smtpPassword);


                    client.Send(message);
                    Console.WriteLine("Email sent successfully through Mailtrap.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
                finally
                {

                    client.Disconnect(true);
                }
            }
        }
    }
}



