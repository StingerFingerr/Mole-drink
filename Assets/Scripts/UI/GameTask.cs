using System;

namespace UI
{
    [Serializable]
    public class GameTask
    {
        public string description;

        public GameTask (string description)
        {
            this.description = description;
        }
    }
}