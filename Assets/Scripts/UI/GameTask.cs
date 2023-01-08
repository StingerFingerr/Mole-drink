using System;

namespace UI
{
    [Serializable]
    public class GameTask
    {
        public string title;
        public string description;

        public GameTask (string title, string description)
        {
            this.title = title;
            this.description = description;
        }
    }
}