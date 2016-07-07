using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

//Otwieranie waypointów z pliku
//Sprawdzanie przy autologowaniu czy dane zostały wprowadzone
//Ulepszenie wyświetlania wartości na/obok progress barów
//showpath dialog filtrowanie do aion'a
//dokonczyc MVP

namespace AionBot.View
{
    public partial class ViewMain : Form, IMain
    {
        public event Action timerReadMemoryTick;
        public event Action SetGamePath;
        public event Action SaveConfigFile;
        public event Action OpenConfigFile;
        public event Action FindGame;

        public ViewMain()
        {
            InitializeComponent();
            new Presenter.MainPresenter(this);
        }

        public void setCharacterData(string chName, string chClass, string chLvl, int HP_cur, int HP_max, int MP_cur, int MP_max, int DP_cur, int DP_max, int FT_cur, int FT_max, float x_cur, float y_cur, float z_cur)
        {
            tbCharacterName.Text = chName;
            tbClass.Text = chClass;
            tbLvl.Text = chLvl;

            pbHP.Maximum = HP_max;
            pbHP.Value = HP_cur;
            pbHP.Step = 1;

            pbMP.Maximum = MP_max;
            pbMP.Value = MP_cur;
            pbMP.Step = 1;


            pbDP.Maximum = DP_max;
            pbDP.Value = DP_cur;
            pbDP.Step = 1;

            pbFT.Maximum = FT_max;
            pbFT.Value = FT_cur;
            pbFT.Step = 1;

            textBoxX.Text = x_cur.ToString();
            textBoxY.Text = y_cur.ToString();
            textBoxZ.Text = z_cur.ToString();
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
            timerReadMemoryTick();
        }
        private void btnRemoveWaypoint_Click(object sender, EventArgs e)
        {
            dGVWaypoints.Rows.RemoveAt(dGVWaypoints.Rows.Count - 1);
        }
        private void btnShowPathDialog_Click(object sender, EventArgs e)
        {
            SetGamePath();
        }
        public void setTextBoxPath(string path)
        {
            tBGamePath.Text = path;
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




        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dGVWaypoints.RowCount == 0)
            {
                MessageBox.Show("No data to save.");
                return;
            }

            try
            {
                List <Model.WaypointModel> waypointToSave = new List<Model.WaypointModel>();

                for (int i = 0; i < dGVWaypoints.Rows.Count; i++)
                {
                    Model.WaypointModel cur_waypoint = new Model.WaypointModel(
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



        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            SaveConfigFile();
        }

        private void btnOpenConfig_Click(object sender, EventArgs e)
        {
            OpenConfigFile();
        }


        private void tbLogin_TextChanged(object sender, EventArgs e)
        {
            Model.Settings.Instance.login = tbLogin.Text;
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            Model.Settings.Instance.password = tbPassword.Text;
        }

        private void tbPin_TextChanged(object sender, EventArgs e)
        {
            Model.Settings.Instance.PIN = Int32.Parse(tbPin.Text);
        }

        private void cbAutoLogIn_CheckedChanged(object sender, EventArgs e)
        {
            Model.Settings.Instance.EnableAutoLogIn = cbAutoLogIn.Checked;
            timerAutoLogIn.Enabled = cbAutoLogIn.Checked;
        }


        private void cBCharacterPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.Settings.Instance.charaterPosition = cBCharacterPosition.SelectedIndex;
        }

        private void btnFindGame_Click(object sender, EventArgs e)
        {
            FindGame();
        }

        private void timerAutoLogIn_Tick(object sender, EventArgs e)
        {
            AionBot.Control.AutoLogIn.startGame(tBGamePath.Text);
            timerAutoLogIn.Enabled = false;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (true)
            {
                //jeżeli weryfikacja uzytkowniak sie powiedzie
                gbGameLogin.Enabled = true;
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

        public void setTimers(bool ReadMemory, bool AutoLogIn)
        {
            timerAutoLogIn.Enabled = AutoLogIn;
            timerReadMemory.Enabled = ReadMemory;
        }

        public void setSettingsAfterLoadFromFile(string login, string password, int pin, int charPostion, string gamePath, bool autoLogIn)
        {
            tbLogin.Text = login;
            tbPassword.Text = password;
            tbPin.Text = pin.ToString();
            cBCharacterPosition.SelectedIndex = charPostion;
            tBGamePath.Text = gamePath;
            cbAutoLogIn.Checked = autoLogIn;
        }
    }
}
