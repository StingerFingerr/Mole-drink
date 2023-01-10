using System;

namespace UI
{
    [Serializable]
    public class GameMessage
    {
        public MessageType type;
        public string message;
        public float messageDuration = 3f;
    }
}