using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M3Ueditor
{
    public partial class Main : Form
    {
        private SortableBindingList<TVChannel> channels = new SortableBindingList<TVChannel>();

        public Main()
        {
            InitializeComponent();
        }

 
        private void tsNew_Click(object sender, EventArgs e)
        {
            channels.Clear();

            string tvgName = "New Channel";
            string tvglogo = "New Logo";
            string groupTitle = "New Group";
            string Name = "New Channel";
            string udp = "udp://@224.1.1.1:6000";

            channels.Add(new TVChannel(
                        _tvgName: tvgName.Trim(),
                        _tvglogo: tvglogo.Trim(),
                        _groupTitle: groupTitle.Trim(),
                        _udp: udp.Trim(),
                        _Name: Name.Trim()
                        ));

            dgvTV.DataSource = channels;
        }

        private void tsOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Файлы плейлиста (*.m3u)|*.m3u|CSV files (*.csv)|*.csv";
            fileDialog.Title = "Открыть плейлист";
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;

                StreamReader playlist = new StreamReader(file);
                channels.Clear();
                dgvTV.DataSource = channels;
                switch (Path.GetExtension(file))
                {
                    case ".m3u":
                        ParseM3U(playlist);
                        //updateboolean = true;
                        break;

                    case ".csv":
                        //ParseCSV();
                        //updateboolean = true;
                        break;
                }
            }
        }

        private void tsSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Файлы плейлиста (*.m3u)|*.m3u|CSV files (*.csv)|*.csv";
            fileDialog.Title = "Сохранить плейлист";
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter file = new StreamWriter(fileDialog.FileName, false, Encoding.UTF8);
                file.WriteLine("#EXTM3U");
                for (int i = 0; i < channels.Count; i++)
                {
                    file.WriteLine("#EXTINF:-1 "
                        + "tvg-name=\"" + channels[i].tvgName + "\" "
                        + "tvg-logo=\"" + channels[i].tvglogo + "\" "
                        + "group-title=\"" + channels[i].groupTitle + "\""
                        + "," + channels[i].tvgName);
                    file.WriteLine(channels[i].UDP);
                }
                file.Close();
            }
        }


        public void ParseM3U(StreamReader playlist)
        {
            //updateboolean = false;
            string line = "";
            List<string> data = new List<string>();

            string tvgName = "N/A";
            string tvglogo = "N/A";
            string groupTitle = "N/A";
            string Name = "N/A";
            string udp = "N/A";

            while ((line = playlist.ReadLine()) != null)
            {
                if (line.StartsWith("#EXTINF"))
                {
                    tvgName = stringOperations.Between(line, "tvg-name=\"", "\"");
                    tvglogo = stringOperations.Between(line, "tvg-logo=\"", "\"");
                    groupTitle = stringOperations.Between(line, "group-title=\"", "\"");
                    Name = line.Split(',').Last();
                    continue;
                }
                else if (line.Contains("//"))
                {
                    udp = line;
                }
                else
                {
                    continue;
                }

                try
                {
                    channels.Add(new TVChannel(
                        _tvgName: tvgName.Trim(),
                        _tvglogo: tvglogo.Trim(),
                        _groupTitle: groupTitle.Trim(),
                        _udp: udp.Trim(),
                        _Name: Name.Trim()
                        ));
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("A channel has been omitted due to its incorrect format");
                    continue;
                }
            }
            playlist.Close();

            if (channels.Count == 0)
            {
                MessageBox.Show("Структура файла не распознана!", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                splitContainer1.Panel2Collapsed = false;
                //enableEditing();
            }
        }

        private void dgvTV_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTV.SelectedRows.Count == 0)
                return;

            int selectedRow = dgvTV.SelectedRows[0].Index;

            tvgNameBox.Text = channels[selectedRow].tvgName;
            tvglogoBox.Text = channels[selectedRow].tvglogo;
            groupTitleBox.Text = channels[selectedRow].groupTitle;
            UDPbox.Text = channels[selectedRow].UDP;
            NameBox.Text = channels[selectedRow].Name;
        }
    }
}
