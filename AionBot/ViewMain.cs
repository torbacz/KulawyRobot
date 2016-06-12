using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace AionBot
{
    public partial class ViewMain : Form, IMain
    {
        [DllImport("user32.dll")] static extern int SetWindowText(IntPtr hWnd, string text);
        [DllImport("user32.dll", SetLastError = true)] public static extern IntPtr SetActiveWindow(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)] private static extern IntPtr SendMessage(IntPtr hwnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("kernel32.dll")] public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll")] public static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("user32.dll")] static extern uint keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        [DllImport("USER32.DLL")] public static extern bool SetForegroundWindow(IntPtr hWnd);

        IntPtr openedProcessHandle;
        Process process = null;
        public ViewMain()
        {
            InitializeComponent();
            AutoLogIn.setView(this);
        }

        private void setSettings()
        {
            int i;
            tbLogin.Text = Settings.Instance.login;
            tbPassword.Text = Settings.Instance.password;
            tbPin.Text = Settings.Instance.PIN;
            Int32.TryParse(Settings.Instance.charaterPosition, out i);
            cBCharacterPosition.SelectedIndex = i - 1;
            tBGamePath.Text = Settings.Instance.gamePath;
            cbEnableAutoPin.Checked = Settings.Instance.EnableAutoPin;
            cbAutoLogIn.Checked = Settings.Instance.EnableAutoLogIn;
        }

        bool findGame()
        {
            string wName = "AION Client";

            foreach (Process pList in Process.GetProcesses())
            {
                if (pList.MainWindowTitle.Contains(wName))
                {
                    process = pList;
                    setLog("Game found! ", false);
                    openedProcessHandle = OpenProcess(0x1F0FFF, false, (int)process.Id);
                    bool stopTrying = false;
                    DateTime time = DateTime.Now;

                    SetWindowText(openedProcessHandle, "AION - Bot");

                    while (!stopTrying)
                    {
                        for (int i = 0; i < process.Modules.Count; i++)
                        {
                            if (process.Modules[i].ModuleName == "Game.dll")
                            {
                                ReadMemory.baseAdress = (int)process.Modules[i].BaseAddress;
                                setLog("Game.dll adress found!", false);
                                timerReadMemory.Enabled = true;
                                stopTrying = true;
                                return true;
                            }
                        }
                    }

                }
            }
            setLog("Game not foud!", true);
            return false;            
        }
        public void setCharacterData()
        {
            CharacterControl.rotateCharacterToZero(ReadMemory.Instance.rotation(openedProcessHandle));
            string chName = ReadMemory.Instance.charName(openedProcessHandle);
            string chClass = ReadMemory.Instance.charClass(openedProcessHandle);
            string chLvl = ReadMemory.Instance.charLvl(openedProcessHandle).ToString();

            int HP_cur = ReadMemory.Instance.hp_cur(openedProcessHandle);
            int HP_max = ReadMemory.Instance.hp_max(openedProcessHandle);
            int MP_cur = ReadMemory.Instance.mp_cur(openedProcessHandle);
            int MP_max = ReadMemory.Instance.mp_max(openedProcessHandle);
            int DP_cur = ReadMemory.Instance.dp_cur(openedProcessHandle);
            int DP_max = ReadMemory.Instance.dp_max(openedProcessHandle);
            int FT_cur = ReadMemory.Instance.ft_cur(openedProcessHandle);
            int FT_max = ReadMemory.Instance.ft_max(openedProcessHandle);
            float x_cur = ReadMemory.Instance.x(openedProcessHandle);
            float y_cur = ReadMemory.Instance.y(openedProcessHandle);
            float z_cur = ReadMemory.Instance.z(openedProcessHandle);

            tbCharacterName.Text = chName;
            tbClass.Text = chClass;
            tbLvl.Text = chLvl;

            pbHP.Maximum = HP_max;
            pbHP.Value = HP_cur;
            pbHP.Step = 1;
            string value = pbHP.Value + "/" + pbHP.Maximum;
            using (Graphics gr = pbHP.CreateGraphics())
            {
                gr.DrawString(value, SystemFonts.DefaultFont, Brushes.Black,
                    new PointF(pbHP.Width / 2 - (gr.MeasureString(value,
                        SystemFonts.DefaultFont).Width / 2.0F), pbHP.Height / 2 - (gr.MeasureString(value, SystemFonts.DefaultFont).Height / 2.0F)));
            }

            pbMP.Maximum = MP_max;
            pbMP.Value = MP_cur;
            pbMP.Step = 1;
            pbMP.CreateGraphics().DrawString(MP_cur + "/" + MP_max, new Font("Arial", (float)9, FontStyle.Regular), Brushes.Black, new PointF(pbMP.Width / 2 - 25, pbMP.Height / 2 - 7));

            pbDP.Maximum = DP_max;
            pbDP.Value = DP_cur;
            pbDP.Step = 1;
            pbDP.CreateGraphics().DrawString(DP_cur + "/" + DP_max, new Font("Arial", (float)9, FontStyle.Regular), Brushes.Black, new PointF(pbDP.Width / 2 - 25, pbDP.Height / 2 - 7));

            pbFT.Maximum = FT_max;
            pbFT.Value = FT_cur;
            pbFT.Step = 1;
            pbFT.CreateGraphics().DrawString(FT_cur + "/" + FT_max, new Font("Arial", (float)9, FontStyle.Regular), Brushes.Black, new PointF(pbFT.Width / 2 - 25, pbFT.Height / 2 - 7));

            textBoxX.Text = x_cur.ToString();
            textBoxY.Text = y_cur.ToString();
            textBoxZ.Text = z_cur.ToString();

        }
        public void drawTriangle()
        {
            float x_cur = ReadMemory.Instance.x(openedProcessHandle)/10;
            float y_cur = ReadMemory.Instance.y(openedProcessHandle)/10;
            float rotation = ReadMemory.Instance.rotation(openedProcessHandle);

            float x_to = x_cur + 30;
            float y_to = y_cur + 20;

            Graphics drawaarea = pictureDrawing.CreateGraphics();
            Pen pen = new Pen(Color.Black);
            Pen penRotation = new Pen(Color.Red);

            drawaarea.DrawLine(pen, x_cur, y_cur, x_to, y_to);
            drawaarea.DrawLine(pen, x_cur, y_cur, x_cur, y_to);
            drawaarea.DrawLine(pen, x_cur, y_to, x_to, y_to);

            drawaarea.DrawLine(penRotation, x_cur, y_cur, 10, 10);
        }

        public void setLog(string text, bool isError)
        {
            DateTime data = DateTime.Now;
            string message = data.ToString() +": " + text + Environment.NewLine;

            if (isError)
            {
                rtbLogs.SelectionColor = System.Drawing.Color.Red;
                rtbLogs.AppendText(message);
            }
            else
            {
                rtbLogs.SelectionColor = System.Drawing.Color.Black;
                rtbLogs.AppendText(message);
            }
        }

        private void timerReadMemory_Tick(object sender, EventArgs e)
        {
            setCharacterData();
        }

        private void btnAddWaypoint_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dGVWaypoints);
            row.Cells[0].Value = dGVWaypoints.Rows.Count + 1;
            row.Cells[1].Value = textBoxX.Text;
            row.Cells[2].Value = textBoxY.Text;
            row.Cells[3].Value = textBoxZ.Text;
            row.Cells[4].Value = checkBoxCollect.Checked;
            row.Cells[5].Value = checkBoxFly.Checked;
            row.Cells[6].Value = checkBoxRest.Checked;
            row.Cells[7].Value = textBoxRestFor.Text;
            dGVWaypoints.Rows.Add(row);
        }

        private void btnRemoveWaypoint_Click(object sender, EventArgs e)
        {
            dGVWaypoints.Rows.RemoveAt(dGVWaypoints.Rows.Count-1);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dGVWaypoints.RowCount == 0)
            {
                MessageBox.Show("No data to save.");
                return;
            }

            try
            {
                List <Waypoint> waypointToSave = new List<Waypoint>();

                for (int i = 0; i < dGVWaypoints.Rows.Count; i++)
                {
                    Waypoint cur_waypoint = new Waypoint(
                        dGVWaypoints.Rows[i].Cells[0].Value.ToString(),
                        dGVWaypoints.Rows[i].Cells[1].Value.ToString(),
                        dGVWaypoints.Rows[i].Cells[2].Value.ToString(),
                        dGVWaypoints.Rows[i].Cells[3].Value.ToString(),
                        dGVWaypoints.Rows[i].Cells[4].Value.ToString(),
                        dGVWaypoints.Rows[i].Cells[5].Value.ToString(),
                        dGVWaypoints.Rows[i].Cells[6].Value.ToString(),
                        dGVWaypoints.Rows[i].Cells[7].Value.ToString());
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

                        foreach (Waypoint item in waypointToSave)
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
                setLog("Waypoint file saved", false);
                dGVWaypoints.Rows.Clear();
            }
            catch
            {
                setLog("Waypoint file not saved", true);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();

        }

        private void btnShowPathDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog form = new OpenFileDialog();
            DialogResult result= form.ShowDialog();
            if(result == DialogResult.OK)
            {
                tBGamePath.Text = form.FileName;
                Settings.Instance.gamePath = form.FileName;
            }
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            SaveFileDialog form = new SaveFileDialog();
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                XmlSerializer x = new System.Xml.Serialization.XmlSerializer(Settings.Instance.GetType());
                TextWriter WriteFileStream = new StreamWriter(form.FileName);
                x.Serialize(WriteFileStream, Settings.Instance);
                WriteFileStream.Close();
            }
            

        }

        private void btnOpenConfig_Click(object sender, EventArgs e)
        {
            OpenFileDialog form = new OpenFileDialog();
            DialogResult result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                XmlSerializer serializer = new XmlSerializer(Settings.Instance.GetType());

                FileStream ReadFileStream = new FileStream(form.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                XmlReader reader = XmlReader.Create(ReadFileStream);
                Settings.Instance = (Settings)serializer.Deserialize(reader);
                setSettings();
                ReadFileStream.Close();
            }
        }


        private void tbLogin_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.login = tbLogin.Text;
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.password = tbPassword.Text;
        }

        private void tbPin_TextChanged(object sender, EventArgs e)
        {
            Settings.Instance.PIN = tbPin.Text;
        }

        private void cbAutoLogIn_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Instance.EnableAutoLogIn = cbAutoLogIn.Checked;
            timerAutoLogIn.Enabled = cbAutoLogIn.Checked;
        }

        private void cbEnableAutoPin_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Instance.EnableAutoPin = cbEnableAutoPin.Checked;
        }

        private void cBCharacterPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Instance.charaterPosition = cBCharacterPosition.SelectedItem.ToString();
        }

        private void btnFindGame_Click(object sender, EventArgs e)
        {
            if (!findGame())
            {
                MessageBox.Show("Game not found!");
                timerReadMemory.Enabled = false;
            }
            else
            {
                timerReadMemory.Enabled = true;
            }
        }

        private void timerAutoLogIn_Tick(object sender, EventArgs e)
        {
            AutoLogIn.startGame(tBGamePath.Text);
            timerAutoLogIn.Enabled = false;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (true)
            {
                //jeżeli weryfikacja uzytkowniak sie powiedzie
                gbGameLogin.Enabled = true;
                gbWaypoints.Enabled = true;
            }
            else
            {
                //MessageBox.Show("Username or password invalid");
            }
        }

        private void cbAutoLogIn_CheckedChanged_1(object sender, EventArgs e)
        {
            timerAutoLogIn.Enabled = cbAutoLogIn.Checked;
            btnFindGame.Enabled = !cbAutoLogIn.Checked;
        }

        public void setGameWindow()
        {
            System.Threading.Thread.Sleep(60000);
            if (!findGame())
                timerAutoLogIn.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AutoLogIn.inputLoginInfo(tbLogin.Text, tbPassword.Text, 1, tbPin.Text, process.MainWindowHandle);
        }
    }
}
