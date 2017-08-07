using System;

namespace ObserverPattern
{

    public class MailService
    {
        public void onVideoEncoded(object source, VideoEventArgs e)
        {
            var videoEncoder = source as VideoEncoder;
            Console.WriteLine("EmailService:Sending an email..."+e.Video.Title);
        }
    }
}