﻿using System;

namespace AionBot.View
{
    public interface IMain
    {
        event Action timerReadMemoryTick;
        event Action SetGamePath;
        event Action SaveConfigFile;
        event Action OpenConfigFile;
        event Action FindGame;

        void setCharacterData(string chName, string chClass, string chLvl, int HP_cur, int HP_max, int MP_cur, int MP_max, int DP_cur, int DP_max, int FT_cur, int FT_max, float x_cur, float y_cur, float z_cur);
        void setSettingsAfterLoadFromFile(string login, string password, int pin, int charPostion, string gamePath,bool autoLogIn);
        void setLog(string text, bool isError);
        void setTextBoxPath(string path);
        void setTimers(bool ReadMemory, bool AutoLogIn);
    }
}
