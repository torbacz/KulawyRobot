using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace AionBot.Presenter
{
    class MainPresenter
    {
        [DllImport("user32.dll")]
        static extern int SetWindowText(IntPtr hWnd, string text);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetActiveWindow(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SendMessage(IntPtr hwnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("user32.dll")]
        static extern uint keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        private Process process = null;
        private IntPtr openedProcessHandle;

        private string chName;
        private string chClass;
        private string chLvl;
        private int HP_cur;
        private int HP_max;
        private int MP_cur;
        private int MP_max;
        private int DP_cur;
        private int DP_max;
        private int FT_cur;
        private int FT_max;
        private float x_cur;
        private float y_cur;
        private float z_cur;
        private float rotation;

        private View.IMain view { get; set; }

        public MainPresenter(View.IMain pView)
        {
            view = pView;
            view.timerReadMemoryTick += View_timerReadMemoryTick;
            view.SetGamePath += View_SetGamePath;
            view.SaveConfigFile += View_SaveConfigFile;
            view.OpenConfigFile += View_OpenConfigFile;
            view.FindGame += View_FindGame;
        }

        private void View_FindGame()
        {
            if (!findGame())
            {
                MessageBox.Show("Game not found!");
                view.setTimers(false, false);
            }
            else
            {
                view.setTimers(true, false);
            }
        }

        private void View_OpenConfigFile()
        {
            OpenFileDialog form = new OpenFileDialog();
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                XmlSerializer serializer = new XmlSerializer(Model.Settings.Instance.GetType());
                FileStream ReadFileStream = new FileStream(form.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                XmlReader reader = XmlReader.Create(ReadFileStream);
                Model.Settings.Instance = (Model.Settings)serializer.Deserialize(reader);
                ReadFileStream.Close();
                setSettingsAfterLoadFromFile();
            }
        }

        private void View_SaveConfigFile()
        {
            SaveFileDialog form = new SaveFileDialog();
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                XmlSerializer x = new XmlSerializer(Model.Settings.Instance.GetType());
                TextWriter WriteFileStream = new StreamWriter(form.FileName);
                x.Serialize(WriteFileStream, Model.Settings.Instance);
                WriteFileStream.Close();
            }
        }

        private void View_SetGamePath()
        {
            OpenFileDialog form = new OpenFileDialog();
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                Model.Settings.Instance.gamePath = form.FileName;
                view.setTextBoxPath(Model.Settings.Instance.gamePath);
            }
        }

        private void View_timerReadMemoryTick()
        {
            chName = Repository.ReadMemory.Instance.charName(openedProcessHandle);
            chClass = Repository.ReadMemory.Instance.charClass(openedProcessHandle);
            chLvl = Repository.ReadMemory.Instance.charLvl(openedProcessHandle).ToString();

            HP_cur = Repository.ReadMemory.Instance.hp_cur(openedProcessHandle);
            HP_max = Repository.ReadMemory.Instance.hp_max(openedProcessHandle);
            MP_cur = Repository.ReadMemory.Instance.mp_cur(openedProcessHandle);
            MP_max = Repository.ReadMemory.Instance.mp_max(openedProcessHandle);
            DP_cur = Repository.ReadMemory.Instance.dp_cur(openedProcessHandle);
            DP_max = Repository.ReadMemory.Instance.dp_max(openedProcessHandle);
            FT_cur = Repository.ReadMemory.Instance.ft_cur(openedProcessHandle);
            FT_max = Repository.ReadMemory.Instance.ft_max(openedProcessHandle);

            x_cur = Repository.ReadMemory.Instance.x(openedProcessHandle);
            y_cur = Repository.ReadMemory.Instance.y(openedProcessHandle);
            z_cur = Repository.ReadMemory.Instance.z(openedProcessHandle);
            rotation = Repository.ReadMemory.Instance.rotation(openedProcessHandle);

            view.setCharacterData(chName, chClass, chLvl, HP_cur, HP_max, MP_cur, MP_max, DP_cur, DP_max, FT_cur, FT_max, x_cur, y_cur, z_cur);
        }

        private bool findGame()
        {
            foreach (Process pList in Process.GetProcesses())
            {
                if (pList.MainWindowTitle.Contains("AION Client"))
                {
                    process = pList;
                    view.setLog("Game found! ", false);
                    openedProcessHandle = OpenProcess(0x1F0FFF, false, (int)process.Id);
                    bool stopTrying = false;

                    SetWindowText(openedProcessHandle, "AION - Bot");

                    while (!stopTrying)
                    {
                        for (int i = 0; i < process.Modules.Count; i++)
                        {
                            if (process.Modules[i].ModuleName == "Game.dll")
                            {
                                Repository.ReadMemory.baseAdress = (int)process.Modules[i].BaseAddress;
                                view.setLog("Game.dll adress found!", false);
                                view.setTimers(true, false);
                                stopTrying = true;
                                return true;
                            }
                        }
                    }

                }
            }
            view.setLog("Game not foud!", true);
            return false;
        }
        private void setSettingsAfterLoadFromFile()
        {
            string _login = Model.Settings.Instance.login;
            string _password = Model.Settings.Instance.password;
            int _pin = Model.Settings.Instance.PIN;
            int _charPosition = Model.Settings.Instance.charaterPosition;
            string _path = Model.Settings.Instance.gamePath;
            bool _autoLogIn = Model.Settings.Instance.EnableAutoLogIn;

            view.setSettingsAfterLoadFromFile(_login, _password, _pin, _charPosition, _path, _autoLogIn);
        }

    }
}
