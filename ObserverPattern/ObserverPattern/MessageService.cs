using System;

namespace ObserverPattern
{

    class MessageService
    {
        public void onVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("MessageService:Enviando mensaje..."+e.Video.Title);
        }
    }
}