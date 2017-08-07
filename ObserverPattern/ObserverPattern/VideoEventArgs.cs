using System;

namespace ObserverPattern
{
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }
}