using System;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var video = new Video { Title = "Jurassic Park" };
            var videoEncoder = new VideoEncoder();//publisher
            var mailService = new MailService(); //Suscriber
            var messageService = new MessageService(); //Suscriber
            videoEncoder.VideoEncoded += mailService.onVideoEncoded;
            videoEncoder.VideoEncoded += messageService.onVideoEncoded;
            videoEncoder.Encode(video);
            Console.ReadLine();
        }
    }
}
