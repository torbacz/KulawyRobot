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
        public int PIN;
        public int charaterPosition;
        public string gamePath;

        public int login_textBox_x;
        public int login_textBox_y;

        public int password_textBox_x;
        public int password_textBox_y;

        public int character_position_x;
        public int character_position_y;

    }
}
