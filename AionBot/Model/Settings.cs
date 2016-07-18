namespace AionBot.Model
{
    public class Settings
    {
        private static Settings GetInstance = null;
        public static Settings Instance
        {
            get
            {
                if (GetInstance == null)
                {
                    GetInstance = new Settings();
                }
                return GetInstance;
            }

            set
            {
                GetInstance = value;
            }

        }

        public string login;
        public string password;
        public bool EnableAutoLogIn;
        public string PIN;
        public int charaterPosition;
        public string gamePath;
    }
}
