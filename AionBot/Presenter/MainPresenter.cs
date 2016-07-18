using System;
using System.Collections.Generic;
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
            view.saveWaypointGrid += View_saveWaypointGrid;
            view.openWaypointFile += View_openWaypointFile;
        }

        private void View_openWaypointFile()
        {
            try
            {
                using (OpenFileDialog openFile = new OpenFileDialog())
                {
                    openFile.Filter = "XML files(.xml)|*.xml";
                    openFile.ShowDialog();

                    List<Model.WaypointModel> listWaypoint = new List<Model.WaypointModel>();
                    Model.WaypointModel item = new Model.WaypointModel();

                    using (XmlReader reader = XmlReader.Create(openFile.FileName))
                    {
                        while (reader.Read())
                        {
                            if (reader.NodeType == XmlNodeType.Element)
                            {
                                switch (reader.Name)
                                {
                                    case "waypoint":
                                        item = new Model.WaypointModel();
                                        break;
                                    case "ID":
                                        reader.Read();
                                        item._id = reader.Value.Trim();
                                        break;
                                    case "X":
                                        reader.Read();
                                        item._x = reader.Value.Trim();
                                        break;
                                    case "Y":
                                        reader.Read();
                                        item._y = reader.Value.Trim();
                                        break;
                                    case "Z":
                                        reader.Read();
                                        item._z = reader.Value.Trim();
                                        break;
                                    case "Collect":
                                        reader.Read();
                                        item._collect = reader.Value.Trim();
                                        break;
                                    case "Fly":
                                        reader.Read();
                                        item._fly_to = reader.Value.Trim();
                                        break;
                                    case "Rest":
                                        reader.Read();
                                        item._rest = reader.Value.Trim();
                                        break;
                                    case "Rest_for":
                                        reader.Read();
                                        item._rest_for = reader.Value.Trim();
                                        break;
                                }
                            }

                            if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "waypoint")
                            {
                                listWaypoint.Add(item);
                            }
                        }
                        view.fillWaypointGrid(listWaypoint);
                    }
                }
                
            }
            catch
            {
                view.setLog("Błąd podczas otwierania pliku z waypointami", true);
            }
        }

        private void View_saveWaypointGrid(DataGridView dataGridwaypoint)
        {
            List<Model.WaypointModel> waypointToSave = new List<Model.WaypointModel>();

            for (int i = 0; i < dataGridwaypoint.Rows.Count; i++)
            {
                Model.WaypointModel cur_waypoint = new Model.WaypointModel(
                    dataGridwaypoint.Rows[i].Cells[0].Value.ToString(),
                    dataGridwaypoint.Rows[i].Cells[1].Value.ToString(),
                    dataGridwaypoint.Rows[i].Cells[2].Value.ToString(),
                    dataGridwaypoint.Rows[i].Cells[3].Value.ToString(),
                    dataGridwaypoint.Rows[i].Cells[4].Value.ToString(),
                    dataGridwaypoint.Rows[i].Cells[5].Value.ToString(),
                    dataGridwaypoint.Rows[i].Cells[6].Value.ToString(),
                    dataGridwaypoint.Rows[i].Cells[7].Value.ToString());
                waypointToSave.Add(cur_waypoint);
            }
            using (SaveFileDialog saveFile = new SaveFileDialog())
            {
                saveFile.Filter = "XML files(.xml)|*.xml";
                saveFile.ShowDialog();
                using (XmlWriter writer = XmlWriter.Create(saveFile.FileName))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Waypoints");

                    foreach (Model.WaypointModel item in waypointToSave)
                    {
                        writer.WriteStartElement("waypoint");

                        writer.WriteElementString("ID", item._id);
                        writer.WriteElementString("X", item._x);
                        writer.WriteElementString("Y", item._y);
                        writer.WriteElementString("Z", item._z);
                        writer.WriteElementString("Collect", item._collect);
                        writer.WriteElementString("Fly", item._fly_to);
                        writer.WriteElementString("Rest", item._rest);
                        writer.WriteElementString("Rest_for", item._rest_for);

                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
            view.setLog("Waypoint file saved", false);
            dataGridwaypoint.Rows.Clear();
        }

        private void View_FindGame()
        {
            try
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
            catch
            {
                view.setLog("Błąd podczas szukanai gry", true);
            }

        }

        private void View_OpenConfigFile()
        {
            try
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
            catch
            {
                view.setLog("Błąd podczas wczytywania pliku", true);
            }
        }

        private void View_SaveConfigFile()
        {
            try {
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
            catch
            {
                view.setLog("Błąd podczas zapisywania pliku", true);
            }
        }

        private void View_SetGamePath()
        {
            try {
                OpenFileDialog form = new OpenFileDialog();
                DialogResult result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Model.Settings.Instance.gamePath = form.FileName;
                    view.setTextBoxPath(Model.Settings.Instance.gamePath);
                }
            }
            catch
            {
                view.setLog("Błąd podczas ustawiania ścieżki do gry", true);
            }
        }

        private void View_timerReadMemoryTick()
        {
            try
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
            catch
            {
                view.setLog("Błąd podczas odczytu pamięci", true);
            }
        }

        private bool findGame()
        {
            try {
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
            }
            catch
            {
                view.setLog("Błąd podczas wyszukiwania gry", true);
            }
            view.setLog("Game not foud!", true);
            return false;
        }
        private void setSettingsAfterLoadFromFile()
        {
            try
            {
                string _login = Model.Settings.Instance.login;
                string _password = Model.Settings.Instance.password;
                string _pin = Model.Settings.Instance.PIN;
                int _charPosition = Model.Settings.Instance.charaterPosition;
                string _path = Model.Settings.Instance.gamePath;
                bool _autoLogIn = Model.Settings.Instance.EnableAutoLogIn;

                view.setSettingsAfterLoadFromFile(_login, _password, _pin, _charPosition, _path, _autoLogIn);
            }
            catch
            {
                view.setLog("Błąd podczas ustawiania ustawień", true);
            }
        }

    }
}
