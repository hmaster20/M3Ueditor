﻿using M3Ueditor.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        SortableBindingList<TVChannel> channels { get; set; } // Список каналов
        List<string> groupList { get; set; }    // Список групп
        bool isChange { get; set; } = false;
        FileInfo fileName { get; set; } // название открытого файла

        #region Main методы

        public Main()
        {
            InitializeComponent();

            this.Icon = M3Ueditor.Properties.Resources.m3u_icon;

            dgvTV.DefaultCellStyle.SelectionBackColor = Color.Silver;

            groupList = new List<string>();
            channels = new SortableBindingList<TVChannel>();

            ButtonStateChange();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            // загрузка параметров из файла конфигурации
            this.Left = Settings.Default.Left;
            this.Top = Settings.Default.Top;
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            // сохранение параметров в файл конфигурации
            Settings.Default.Left = this.Left;
            Settings.Default.Top = this.Top;
            Settings.Default.Save();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e) => CheckChanged();

        #endregion


        #region Menu Button
        private void tsNew_Click(object sender, EventArgs e) => newListTV();
        private void tsOpen_Click(object sender, EventArgs e) => OpenListTV();
        private void tsSave_Click(object sender, EventArgs e) => SaveListTv();
        private void tsAdd_Click(object sender, EventArgs e) => Add();
        private void tsRemove_Click(object sender, EventArgs e) => Remove();
        private void tsUp_Click(object sender, EventArgs e) => Up();
        private void tsDown_Click(object sender, EventArgs e) => Down();

        #endregion


        #region  Main Menu

        private void tsmNew_Click(object sender, EventArgs e) => newListTV();
        private void tsmOpen_Click(object sender, EventArgs e) => OpenListTV();
        private void tsmMerge_Click(object sender, EventArgs e) => MergeListTV();
        private void tsmSave_Click(object sender, EventArgs e) => SaveListTv();
        private void tsmSaveAs_Click(object sender, EventArgs e) => SaveListTvAs();
        private void tsmExit_Click(object sender, EventArgs e) => Close();
        private void tsmHistory_Click(object sender, EventArgs e) => History();
        private void tsmAbout_Click(object sender, EventArgs e) => About();

        #endregion


        #region Methods

        private void newListTV()
        {
            fileName = null;
            channels.Clear();
            UpdategroupListAndTree();

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

            UpdategroupListAndTree();
        }

        private void OpenListTV()
        {
            CheckChanged();
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Файлы плейлиста (*.m3u)|*.m3u|CSV files (*.csv)|*.csv";
            fileDialog.Title = "Открыть плейлист";
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = new FileInfo(fileDialog.FileName);

                using (StreamReader playlist = new StreamReader(fileName.FullName))
                {
                    channels.Clear();

                    switch (Path.GetExtension(fileName.FullName))
                    {
                        case ".m3u":
                            channels = ParseM3U(playlist);
                            break;

                        case ".csv":
                            //ParseCSV();
                            break;
                    }
                }

                TableRefresh();
                UpdategroupListAndTree();
            }
        }

        private void MergeListTV()
        {
            if (channelsCorrect())
            {
                CheckChanged();
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "Файлы плейлиста (*.m3u)|*.m3u|CSV files (*.csv)|*.csv";
                fileDialog.Title = "Открыть плейлист";
                fileDialog.RestoreDirectory = true;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = new FileInfo(fileDialog.FileName);
                    StreamReader playlist = new StreamReader(fileName.FullName);

                    SortableBindingList<TVChannel> channelsForMerge = ParseM3U(playlist);

                    FormMerge form = new FormMerge(channels, channelsForMerge);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (channels != null)
                        {
                            channels.Clear();
                            channels = form.ModChannels;
                        }
                    }

                    TableRefresh();
                    UpdategroupListAndTree();
                }
            }
        }

        private bool TVchannelExist(TVChannel tvc)
        {
            foreach (TVChannel _tvc in channels)    // проверка наличия канала в листе
            {
                if (_tvc.Equals(tvc))
                    return true;
            }
            return false;
        }


        private void SaveListTv()
        {
            if (fileName != null)
            {
                SaveToFile(fileName.FullName);
                isChange = false;
            }
            else
            {
                SaveListTvAs();
            }
        }

        private void SaveListTvAs()
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "Файлы плейлиста (*.m3u)|*.m3u|CSV files (*.csv)|*.csv";
            fileDialog.Title = "Сохранить плейлист";
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveToFile(fileDialog.FileName);
            }
            isChange = false;
        }

        private void SaveToFile(string FullName)
        {
            StreamWriter file = new StreamWriter(FullName, false, Encoding.UTF8);
            file.WriteLine("#EXTM3U");
            for (int i = 0; i < channels.Count; i++)
            {
                file.WriteLine("#EXTINF:-1 "
                    + "tvg-name=\"" + channels[i].TvgName + "\" "
                    + "tvg-logo=\"" + channels[i].Tvglogo + "\" "
                    + "group-title=\"" + channels[i].GroupTitle + "\""
                    + "," + channels[i].TvgName);
                file.WriteLine(channels[i].UDP);
            }
            file.Close();
        }


        private bool channelsCorrect()
        {
            if (channels != null && channels.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void UpdategroupListAndTree()
        {
            if (channelsCorrect())
            {
                groupList.Clear();
                for (int i = 0; i < channels.Count; i++)
                {
                    groupList.Add(channels[i].GroupTitle);
                }
                groupList = groupList.Distinct().ToList();

                groupTitleComboBox.Items.Clear();
                groupTitleComboBox.Items.AddRange(groupList.ToArray());

                tree.Nodes.Clear();
                TreeNode root = new TreeNode("Все");
                tree.Nodes.Add(root);

                if (!(groupList.Count == 1 && groupList[0] == ""))
                {
                    for (int i = 0; i < groupList.Count; i++)
                    {
                        root.Nodes.Add(groupList[i]);
                    }
                    tree.ExpandAll();
                }
                ButtonStateChange(true);
                tssLabel1.Text = "Количество каналов: " + channels.Count;
                if (fileName != null)
                {
                    this.Text = fileName.FullName + " - M3U editor";
                }
            }
            else
            {
                //channels.Clear();
                tree.Nodes.Clear();
                dgvTV.DataSource = null;
                ButtonStateChange(false);
                tssLabel1.Text = "";
                this.Text = "M3U editor";
            }
        }

        private void Changed()
        {
            isChange = true;
            UpdategroupListAndTree();
        }

        private void CheckChanged()
        {
            if (isChange)
            {
                DialogResult dialog = MessageBox.Show("Файл изменен. Выполнить сохранение?!", "Предупреждение", MessageBoxButtons.OKCancel);
                if (dialog == DialogResult.OK)
                {
                    SaveListTv();
                }
            }
        }

        private void ButtonStateChange(bool state = false)
        {
            tsAdd.Enabled = state;
            tsRemove.Enabled = state;
            tsUp.Enabled = state;
            tsDown.Enabled = state;
            tsSave.Enabled = state;
            splitContainer.Panel2Collapsed = !state;    // видна только tree & dgv
        }

        public SortableBindingList<TVChannel> ParseM3U(StreamReader playlist)
        {
            SortableBindingList<TVChannel> ListTV = new SortableBindingList<TVChannel>();

            string line = "";

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
                    ListTV.Add(new TVChannel(
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

            if (ListTV.Count == 0)
            {
                MessageBox.Show("Структура файла не распознана!", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fileName = null;
            }
            return ListTV;
        }

        private void Add()
        {
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

            dgvTV.Rows[channels.Count - 1].Selected = true;
            dgvTV.FirstDisplayedScrollingRowIndex = channels.Count - 1;
            Changed();
        }

        private void Remove()
        {
            if (dgvTV.Rows.Count > 0)
            {
                if (dgvTV.SelectedRows.Count == 0)
                {
                    return;
                }
                else
                {
                    if (dgvTV.MultiSelect)
                    {
                        foreach (DataGridViewRow dr in dgvTV.SelectedRows)
                        {
                            if (!dr.IsNewRow)
                            {
                                dgvTV.Rows.Remove(dr);
                            }
                        }
                    }
                    else
                    {
                        int selectedRow = dgvTV.SelectedRows[0].Index;

                        if (channels.Count > 0 && selectedRow - 1 > 0)
                        {
                            dgvTV.Rows[selectedRow - 1].Selected = true;
                        }
                        else if (channels.Count > 0 && selectedRow + 1 <= channels.Count - 1)
                        {
                            dgvTV.Rows[selectedRow + 1].Selected = true;
                        }

                        channels.RemoveAt(selectedRow);

                        if ((dgvTV.Rows.Count > 0) && (selectedRow - 1 > -1))
                        {
                            if (selectedRow == dgvTV.Rows.Count)
                            {
                                dgvTV.Rows[selectedRow - 1].Selected = true;
                            }
                            else
                            {
                                dgvTV.Rows[selectedRow].Selected = true;
                            }
                        }
                    }
                }
                Changed();
            }
        }

        private void Up()
        {
            if (dgvTV.RowCount > 1 && dgvTV.SelectedRows.Count != 0)
            {
                int selectedRow = dgvTV.SelectedRows[0].Index;
                if (selectedRow == 0)
                {
                    return;
                }

                TVChannel current = channels[selectedRow];
                TVChannel previous = channels[selectedRow - 1];
                channels.RemoveAt(selectedRow);

                channels.Insert(selectedRow -= 1, current);
                dgvTV.Rows[selectedRow].Selected = true;
            }
        }

        private void Down()
        {
            if (dgvTV.RowCount > 1 && dgvTV.SelectedRows.Count != 0)
            {
                int selectedRow = dgvTV.SelectedRows[0].Index;

                if (selectedRow == dgvTV.RowCount - 1)
                {
                    return;
                }

                TVChannel current = channels[selectedRow];
                TVChannel next = channels[selectedRow + 1];

                channels.RemoveAt(selectedRow);

                channels.Insert(selectedRow += 1, current);
                dgvTV.Rows[selectedRow].Selected = true;
            }
        }

        private static void History()
        {
            string ChangeLog = "ChangeLog.txt";
            if (File.Exists(ChangeLog))
            {
                Process.Start(ChangeLog);
            }
        }

        private static void About()
        {
            formAbout about = new formAbout();
            about.ShowDialog();
        }

        #endregion


        #region Таблица
        void TableRefresh(string node = "", bool refresh = false)
        {
            TVChannel tvc = GetSelected();
            if (refresh)
            {
                SortableBindingList<TVChannel> filteredList = new SortableBindingList<TVChannel>(channels.Where(m => m.GroupTitle == node).ToList());
                dgvTV.DataSource = filteredList;
                tssLabel2.Text = "В составе группы: " + filteredList.Count;
            }
            else
            {
                dgvTV.DataSource = channels;
                tssLabel2.Text = "";
            }
            if (tvc != null) Selected(dgvTV, tvc);
        }

        private void dgvTV_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTV.SelectedRows.Count == 0)
                return;

            int selectedRow = dgvTV.SelectedRows[0].Index;

            tvgNameBox.Text = channels[selectedRow].TvgName;
            tvglogoBox.Text = channels[selectedRow].Tvglogo;
            groupTitleComboBox.Text = channels[selectedRow].GroupTitle;
            UDPbox.Text = channels[selectedRow].UDP;
            NameBox.Text = channels[selectedRow].Name;
        }

        private void dgvTV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // left click
            {
                if (Control.ModifierKeys == Keys.Control)
                {
                    System.Diagnostics.Debug.Print("CTRL + Left click!");
                    dgvTV.MultiSelect = true;
                }
                else
                {
                    System.Diagnostics.Debug.Print("Left click!");
                    dgvTV.MultiSelect = false;
                    // dgvTV.ReadOnly = true;
                }
            }
        }


        private void dgvTV_KeyDown(object sender, KeyEventArgs e)
        {
            // редактирование ячейки при нажатии F2
            if (e.KeyCode == Keys.F2)
            {
                dgvTV.ReadOnly = false;
                e.Handled = true;
                dgvTV.BeginEdit(true);
            }
        }

        private void dgvTV_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)   // Порядок 1
        {
            //TableDragDrop(e);

            // разрешено редактирование при двойном клике
            if (e.Clicks == 2)
            {
                dgvTV.ReadOnly = false;
                dgvTV.BeginEdit(true);
            }
            if (!dgvTV.IsCurrentCellInEditMode)
            {
                TableDragDrop(e);
            }

        }

        private void dgvTV_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {

        }

        private void dgvTV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                TableRefresh();
                Changed();
            }
        }

        private void TableDragDrop(DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView dgv = dgvTV;
                if (dgv != null && dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].Index > -1)
                    if (dgv.SelectedRows[0].Index == e.RowIndex) dgv.DoDragDrop(e.RowIndex, DragDropEffects.Copy);
            }
        }

        private void tree_DragDrop(object sender, DragEventArgs e)// здесь функционал DragDrop
        {
            Point pt = tree.PointToClient(new Point(e.X, e.Y));
            TreeNode destinationNode = tree.GetNodeAt(pt);
            TVChannel tvc = GetSelected();

            if (tvc != null)
            {
                try
                {
                    if (destinationNode != tree.TopNode)
                    {
                        tvc.GroupTitle = destinationNode.Text;
                        TableRefresh();
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void tree_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private TVChannel GetSelected()
        {
            DataGridView dgv = dgvTV;
            if (dgv != null && dgv.SelectedRows.Count > 0 && dgv.SelectedRows[0].Index > -1)
            {
                TVChannel tvc = null;
                if (dgv.SelectedRows[0].DataBoundItem is TVChannel) tvc = dgv.SelectedRows[0].DataBoundItem as TVChannel;
                if (tvc != null) return tvc;
            }
            return null;
        }

        private void Selected(DataGridView dgv, TVChannel tvc)
        {
            dgv.ClearSelection();
            foreach (DataGridViewRow row in dgv.Rows)
                if ((row.DataBoundItem as TVChannel).Name == tvc.Name)
                {
                    row.Selected = true;
                    dgv.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
        }
        #endregion


        #region Дерево
        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == tree.TopNode)
            {
                TableRefresh(e.Node.Text, false);
            }
            else
            {
                TableRefresh(e.Node.Text, true);
            }
        }

        #endregion


        #region Панель редактирования
        private void UserModifiedChanged(object sender, EventArgs e) => Modified(); // событие при измнении любого поля
        private void Modified()
        {
            dgvTV.DefaultCellStyle.SelectionBackColor = Color.Salmon; // подсветка редактируемой строки в таблице
            dgvTV.Enabled = false;   // блокировка таблицы
            tree.Enabled = false; // блокировка дерева
        }

        private void btnChangeApprove_Click(object sender, EventArgs e) // Кнопка Применить
        {
            if (dgvTV.SelectedRows.Count == 0)
                return;

            TVChannel tvc = GetSelected();
            if (tvc != null)
            {
                tvc.TvgName = tvgNameBox.Text;
                tvc.Tvglogo = tvglogoBox.Text;
                tvc.GroupTitle = groupTitleComboBox.Text;
                tvc.UDP = UDPbox.Text;
                tvc.Name = NameBox.Text;
            }


            //int selectedRow = dgvTV.SelectedRows[0].Index;

            //channels[selectedRow].tvgName = tvgNameBox.Text;
            //channels[selectedRow].tvglogo = tvglogoBox.Text;
            //channels[selectedRow].groupTitle = groupTitleComboBox.Text;
            //channels[selectedRow].UDP = UDPbox.Text;
            //channels[selectedRow].Name = NameBox.Text;

            tree.Enabled = true;      // Разблокировка дерева
            dgvTV.Enabled = true;     // Разблокировка таблицы
            dgvTV.DefaultCellStyle.SelectionBackColor = Color.Silver;    // Восстановления цвета селектора таблицы

            TableRefresh();

            Changed();
        }

        private void btnChangeCancel_Click(object sender, EventArgs e)  // Кнопка Отмена
        {
            tree.Enabled = true;      // Разблокировка дерева
            dgvTV.Enabled = true;     // Разблокировка таблицы
            dgvTV.DefaultCellStyle.SelectionBackColor = Color.Silver;    // Восстановления цвета селектора таблицы
        }


        #endregion


    }
}
