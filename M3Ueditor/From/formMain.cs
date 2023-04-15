using M3Ueditor.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M3Ueditor
{
    public partial class Main : Form
    {
        #region Переменные
        string globalParams { get; set; } // Общие параметры для плейлиста
        SortableBindingList<TVChannel> channels { get; set; } // Список каналов
        List<string> groupList { get; set; }    // Список групп
        bool isChange { get; set; } = false;
        FileInfo fileName { get; set; }         // название открытого файла
        string currentSetLanguage { get; set; }
        string fileNameFilter { get; set; } = "Файлы плейлиста (*.m3u)|*.m3u"; // "Файлы плейлиста (*.m3u)|*.m3u|CSV files (*.csv)|*.csv"
        string fileNameTitleOpen { get; set; } = "Открыть плейлист";
        string fileNameTitleSave { get; set; } = "Сохранить плейлист";


        #endregion


        #region Переключатель локализации
        /// <summary>
        /// Occurs when current UI culture is changed
        /// </summary>
        [Browsable(true)]
        [Description("Occurs when current UI culture is changed")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Category("Property Changed")]
        public event EventHandler CultureChanged;

        protected CultureInfo culture;
        protected ComponentResourceManager resManager;

        /// <summary>
        /// Current culture of this form
        /// </summary>
        [Browsable(false)]
        [Description("Current culture of this form")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CultureInfo Culture
        {
            get { return this.culture; }
            set
            {
                if (this.culture != value)
                {
                    this.ApplyResources(this, value);

                    this.culture = value;
                    this.OnCultureChanged();
                }
            }
        }

        private void ApplyResources(Control parent, CultureInfo culture)
        {
            this.resManager.ApplyResources(parent, parent.Name, culture);

            foreach (Control ctl in parent.Controls)
            {
                this.ApplyResources(ctl, culture);
            }
        }

        protected void OnCultureChanged()
        {
            var temp = this.CultureChanged;
            if (temp != null)
                temp(this, EventArgs.Empty);
        }

        public static CultureInfo GlobalUICulture
        {
            get { return Thread.CurrentThread.CurrentUICulture; }
            set
            {
                if (GlobalUICulture.Equals(value) == false)
                {
                    foreach (var form in Application.OpenForms.OfType<Main>())
                    {
                        form.Culture = value;
                    }

                    Thread.CurrentThread.CurrentUICulture = value;
                }
            }
        }
        #endregion


        #region Изменение локализации меню
        private ComponentResourceManager resources { get; set; } = new ComponentResourceManager(typeof(Main));
        public string lng { get; set; } = "";


        //private void ChangeLanguage(string lang)
        //{
        //    //ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
        //    foreach (Control c in this.Controls)
        //    {
        //        resources.ApplyResources(c, c.Name, new CultureInfo(lang));
        //    }
        //    ChangeLanguage(menu.Items);
        //}

        private void ChangeLanguageMenu(ToolStripItemCollection collection)
        {
            foreach (ToolStripItem item in collection)
            {
                //ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
                resources.ApplyResources(item, item.Name, new CultureInfo(lng));
                if (item is ToolStripDropDownItem)
                    ChangeLanguageMenu(((ToolStripDropDownItem)item).DropDownItems);
            }
        }
        #endregion


        #region Main методы

        public Main()
        {
            InitializeComponent();

            this.resManager = new ComponentResourceManager(this.GetType());
            this.culture = CultureInfo.CurrentUICulture;

            this.Icon = M3Ueditor.Properties.Resources.m3u_icon;
            dgvTV.DefaultCellStyle.SelectionBackColor = Color.Silver;
            groupList = new List<string>();
            channels = new SortableBindingList<TVChannel>();
            ButtonMenuEnable();

            tsChangeLang.DropDownItems.Add("Russian", Resources.flag_rus);
            tsChangeLang.DropDownItems.Add("English", Resources.flag_usa);
            CurrentFlag.Image = Resources.flag_rus;
            tsChangeLang.DropDownItemClicked += new ToolStripItemClickedEventHandler(this.tsChangeLang_Clicked);

            textBoxGlobal.ReadOnly = true;
            textBoxGlobal.DoubleClick += TextBoxGlobal_DoubleClick;
            textBoxGlobal.KeyPress += TextBoxGlobal_KeyPress;
        }

        private void TextBoxGlobal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                textBoxGlobal.ReadOnly = true;
                this.ActiveControl = labelGlobal;
            }
        }

        private void TextBoxGlobal_DoubleClick(object sender, EventArgs e)
        {
            textBoxGlobal.ReadOnly = false;
            textBoxGlobal.Refresh();
        }

        private void tsChangeLang_Clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SetCurrentLanguage(e.ClickedItem.ToString());
        }

        private void SetCurrentLanguage(string lang)
        {
            switch (lang)
            {
                case "Russian":
                    {
                        this.Culture = CultureInfo.GetCultureInfo("ru-RU");
                        lng = "ru-RU";
                        ChangeLanguageMenu(menu.Items);
                        ChangeLanguageMenu(toolS.Items);
                        CurrentFlag.Image = Resources.flag_rus;
                        currentSetLanguage = "Russian";
                        tsChangeLang.Text = "Выбор языка";
                        tsChangeLang.ToolTipText = "Language selection";
                        break;
                    }
                case "English":
                    {
                        this.Culture = CultureInfo.GetCultureInfo("en-US");
                        lng = "en-US";
                        ChangeLanguageMenu(menu.Items);
                        ChangeLanguageMenu(toolS.Items);
                        CurrentFlag.Image = Resources.flag_usa;
                        currentSetLanguage = "English";
                        tsChangeLang.Text = "Language selection";
                        tsChangeLang.ToolTipText = "Выбор языка";
                        break;
                    }
                default: break;
            }
        }



        private void Main_Load(object sender, EventArgs e)
        {
            // загрузка параметров из файла конфигурации
            this.Left = Settings.Default.Left;
            this.Top = Settings.Default.Top;
            currentSetLanguage = Settings.Default.Language;
            SetCurrentLanguage(currentSetLanguage);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            // сохранение параметров в файл конфигурации
            Settings.Default.Left = this.Left;
            Settings.Default.Top = this.Top;
            Settings.Default.Language = currentSetLanguage;
            Settings.Default.Save();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e) => CheckChanged(e);

        #endregion


        #region Menu Button
        private void tsNew_Click(object sender, EventArgs e) => newListTV();
        private void tsOpen_Click(object sender, EventArgs e) => OpenListTV();
        private void tsSave_Click(object sender, EventArgs e) => SaveListTv();
        private void tsAdd_Click(object sender, EventArgs e) => Add();
        private void tsRemove_Click(object sender, EventArgs e) => Remove();
        private void tsUp_Click(object sender, EventArgs e) => Up();
        private void tsDown_Click(object sender, EventArgs e) => Down();
        private void btnSaveGlobal_Click(object sender, EventArgs e) => setGlobalParams();

        #endregion


        #region  Main Menu

        private void tsmNew_Click(object sender, EventArgs e) => newListTV();
        private void tsmOpen_Click(object sender, EventArgs e) => OpenListTV();
        private void tsmMerge_Click(object sender, EventArgs e) => MergeListTV();
        private void tsmScan_Click(object sender, EventArgs e) => ImportFromScan();
        private void tsmSave_Click(object sender, EventArgs e) => SaveListTv();
        private void tsmSaveAs_Click(object sender, EventArgs e) => SaveListTvAs();
        private void tsmExit_Click(object sender, EventArgs e) => Close();
        private void tsmHistory_Click(object sender, EventArgs e) => History();
        private void tsmAbout_Click(object sender, EventArgs e) => About();

        #endregion


        #region Methods

        private void newListTV()
        {
            if (!ChannelsStatus())
            {
                dgvTV.CancelEdit();

                fileName = null;
                channels.Clear();
                updateGroupListAndTree();

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

                updateGroupListAndTree();
                Changed();
            }
            else
            {
                // Далогове окно, вы уверено, что хотите перезаписать плейлист
                DialogResult result = MessageBox.Show("Выполнить удаление текущего плейлиста ?",
                    "Удаление плейлиста",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    dgvTV.DataSource = null;
                    channels.Clear();
                    updateGroupListAndTree();
                }
            }
        }

        private void OpenListTV()
        {
            if (CheckChanged())
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = fileNameFilter;
                fileDialog.Title = fileNameTitleOpen;
                fileDialog.RestoreDirectory = true;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = new FileInfo(fileDialog.FileName);

                    //using (StreamReader playlist = new StreamReader(fileName.FullName))
                    //{
                    //    channels.Clear();
                    //    switch (Path.GetExtension(fileName.FullName))
                    //    {
                    //        case ".m3u":
                    //            //channels = ParseM3U(playlist);
                    //            ParseM3Utest(playlist);
                    //            break;
                    //        case ".csv":
                    //            //ParseCSV();
                    //            break;
                    //    }
                    //}

                    globalParams = Helper.getGlobalParams(fileName.FullName);

                    Helper.getChannels(fileName.FullName);

                    channels = Helper.ParseM3U(fileName.FullName);



                    TableRefresh();
                    updateGroupListAndTree();
                }
            }
        }

        private void MergeListTV()
        {
            if (ChannelsStatus())
            {
                FileInfo currentfileName = null;
                if (fileName != null)
                {
                    currentfileName = new FileInfo(Path.GetFileNameWithoutExtension(fileName.Name) + "_Merge" + fileName.Extension);
                }

                CheckChanged();
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = fileNameFilter;
                fileDialog.Title = fileNameTitleOpen;
                fileDialog.RestoreDirectory = true;

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = new FileInfo(fileDialog.FileName);
                    //StreamReader playlist = new StreamReader(fileName.FullName);

                    //SortableBindingList<TVChannel> channelsForMerge = ParseM3U(playlist);                 

                    SortableBindingList<TVChannel> channelsForMerge = Helper.ParseM3U(fileName.FullName);

                    FormMerge form = new FormMerge(channels, channelsForMerge, lng);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (channels != null)
                        {
                            channels.Clear();
                            channels = form.ModChannels;
                        }
                    }

                    if (currentfileName != null)
                    {
                        fileName = currentfileName;
                    }
                    else if (fileName != null)
                    {
                        fileName = new FileInfo(Path.GetFileNameWithoutExtension(fileName.Name) + "_Merge" + fileName.Extension);
                    }


                    TableRefresh();

                    updateGroupListAndTree();
                    Changed();
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

        private void ImportFromScan()
        {
            formPortScan form = new formPortScan(lng);
            if (form.ShowDialog() == DialogResult.OK)
            {
                for (int x = 0; x < form.FindChannels.Count; x++)
                {
                    bool isTVC = false;
                    for (int count = 0; count < channels.Count; count++)
                    {
                        if (channels[count].Equals(form.FindChannels[x]))
                        {
                            isTVC = true;
                            break;
                        }
                    }
                    if (!isTVC)
                    {
                        channels.Add(form.FindChannels[x]);
                    }
                }

                dgvTV.DataSource = channels;
                updateGroupListAndTree();
                Changed();
            }
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
            fileDialog.Filter = fileNameFilter;
            fileDialog.Title = fileNameTitleSave;
            fileDialog.RestoreDirectory = true;

            if (fileName != null)
            {
                fileDialog.FileName = fileName.Name;
            }
            else
            {
                fileDialog.FileName = "Новый.m3u";
            }

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
                    + "," + channels[i].Name);
                file.WriteLine(channels[i].UDP);
            }
            file.Close();
        }


        /// <summary>Если элементов больше 0, вернуть true</summary>
        private bool ChannelsStatus()
        {
            //return (channels != null && channels.Count > 0) ? true : false;

            if (channels != null && channels.Count > 0)
            {
                Debug.Print("ChannelsStatus = " + true.ToString());
                return true;
            }
            else
            {
                Debug.Print("ChannelsStatus = " + false.ToString());
                return false;
            }
        }

        /// <summary>Отрисовка дерева</summary>
        private void updateGroupListAndTree()
        {
            if (ChannelsStatus())
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
                ButtonMenuEnable(true);
                tssLabel1.Text = "Количество каналов: " + channels.Count;
            }
            else
            {
                tree.Nodes.Clear();
                dgvTV.Rows.Clear();
                dgvTV.Refresh();
                ButtonMenuEnable(false);
                tssLabel1.Text = "";
            }

            FileInfoInMainFormTitle();
            updateGlobalParams();
        }

        private void updateGlobalParams()
        {
            textBoxGlobal.Text = globalParams;
        }

        private void setGlobalParams()
        {
            globalParams = textBoxGlobal.Text;
            textBoxGlobal.ReadOnly = true;
            this.ActiveControl = labelGlobal;
        }

        private void FileInfoInMainFormTitle()
        {
            if (fileName != null)
            {
                this.Text = fileName.FullName + " - M3U editor";
            }
            else
            {
                if (ChannelsStatus())
                {
                    this.Text = "Новый" + " - M3U editor";
                }
                else
                {
                    this.Text = "M3U editor";
                }
            }
        }

        private void Changed()
        {
            isChange = true;
            updateGroupListAndTree();
        }

        private bool CheckChanged(FormClosingEventArgs e = null)
        {
            if (fileName != null && ChannelsStatus())
            {
                if (isChange)
                {
                    DialogResult dialog =
                        MessageBox.Show("Файл был изменен!\nВыполнить сохранение, прежде чем продолжить?", "Предупреждение",
                        MessageBoxButtons.YesNoCancel);

                    if (dialog == DialogResult.Yes)
                    {
                        SaveListTv();
                    }
                    if (dialog == DialogResult.Cancel)
                    {
                        if (e != null)
                        {
                            e.Cancel = true;
                        }
                        return false;
                    }
                }
            }
            else
            {
                isChange = false;
            }
            return true;
        }

        private void ButtonMenuEnable(bool state = false)
        {
            tsAdd.Enabled = state;
            tsRemove.Enabled = state;
            tsUp.Enabled = state;
            tsDown.Enabled = state;
            tsSave.Enabled = state;
            splitContainer.Panel2Collapsed = !state;    // видна только tree & dgv

            tsmMerge.Enabled = state;
            tsmSave.Enabled = state;
            tsmSaveAs.Enabled = state;
        }

        #region Добавление
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

            try
            {
                dgvTV.Rows[channels.Count - 1].Selected = true;
                dgvTV.FirstDisplayedScrollingRowIndex = channels.Count - 1;
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }

            Changed();
        }
        #endregion


        #region Удаление

        private void Remove()
        {
            if (ChannelsStatus())
            {
                if (dgvTV.MultiSelect)
                {
                    RemoveMultiSelect();
                }
                else
                {
                    RemoveSingleSelect();
                }
            }

            // Нужно проверить число элементов
            // Если удаляется последний, то уничтожаем коллекцию и очищаем панели


            //if ((dgvTV.Rows.Count == 0) && (dgvTV.SelectedRows.Count == 0))
            //{
            //    return;
            //}
            //else
            //{
            //    if (dgvTV.MultiSelect)
            //    {
            //        RemoveMultiSelect();
            //    }
            //    else
            //    {
            //        RemoveSingleSelect();
            //    }
            //}
            Changed();
        }

        private void RemoveMultiSelect()
        {
            foreach (DataGridViewRow dr in dgvTV.SelectedRows)
            {
                if (!dr.IsNewRow)
                {
                    dgvTV.Rows.Remove(dr);
                }
            }
        }

        private void RemoveSingleSelect()
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

            if (channels.Count > 0)
            {
                NextRowSelect(selectedRow);
            }
            else
            {
                dgvTV.DataSource = null;
            }
        }

        private void NextRowSelect(int selectedRow)
        {
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

        #endregion

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

        private void History()
        {
            fromChangeLog formLog = new fromChangeLog(lng);
            formLog.ShowDialog();

            //string ChangeLog = "ChangeLog.txt";
            //if (File.Exists(ChangeLog))
            //{
            //    Process.Start(ChangeLog);
            //}
        }

        private void About()
        {
            formAbout about = new formAbout(lng);
            about.ShowDialog();
        }

        #endregion


        #region Таблица
        void TableRefresh(string node = "", bool refresh = false)
        {
            TVChannel tvc = GetSelected();

            if (refresh)
            {
                // SortableBindingList<TVChannel> filteredList = new SortableBindingList<TVChannel>(channels.Where(m => m.GroupTitle == node).ToList());
                //  dgvTV.DataSource = filteredList;
                //tssLabel2.Text = "В составе группы: " + filteredList.Count;

                dgvTV.DataSource = channels.Where(m => m.GroupTitle == node).ToList();
                tssLabel2.Text = "В составе группы: " + channels.Where(m => m.GroupTitle == node).ToList().Count;
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

            TVChannel tvc = GetSelectedRow();
            if (tvc != null)
            {
                tvgNameBox.Text = tvc.TvgName;
                tvglogoBox.Text = tvc.Tvglogo;
                groupTitleComboBox.Text = tvc.GroupTitle;
                UDPbox.Text = tvc.UDP;
                NameBox.Text = tvc.Name;
            }
        }

        /// <summary>Получение выбранной записи</summary>
        private TVChannel GetSelectedRow()
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

        private void dgvTV_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // left click
            {
                if (Control.ModifierKeys == Keys.Control)
                {
                    Debug.Print("CTRL + Left click!");
                    dgvTV.MultiSelect = true;
                }
                else
                {
                    Debug.Print("Left click!");
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
            try
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
            catch (Exception ex)
            {
                Debug.Print("Ошибка выполнения GetSelected()\n" + ex.Message);
                return null;
            }
        }

        private void Selected(DataGridView dgv, TVChannel tvc)
        {
            dgv.ClearSelection();
            foreach (DataGridViewRow row in dgv.Rows)
                if ((row.DataBoundItem as TVChannel).Name == tvc.Name && (row.DataBoundItem as TVChannel).GroupTitle == tvc.GroupTitle)
                {
                    row.Selected = true;
                    // dgv.FirstDisplayedScrollingRowIndex = row.Index;  // прокрутка таблицы до выбранной строки
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
        private void UserModifiedChanged(object sender, EventArgs e) => Modified(); // событие при изменении любого поля

        private void Modified()
        {
            dgvTVtreeEnabled(false);
            ButtonControlEnabled(true);
            Debug.Print("Modified");
        }

        private void UnModified()
        {
            Debug.Print("UnModified - Start");

            //return status
            tvgNameBox.Modified = false;
            tvglogoBox.Modified = false;
            UDPbox.Modified = false;
            NameBox.Modified = false;
            Debug.Print("Change status for textBox");


            dgvTVtreeEnabled(true);
            ButtonControlEnabled(false);
            Debug.Print("UnModified - Finish");
        }


        private void dgvTVtreeEnabled(bool state = false)
        {
            tree.Enabled = state;
            dgvTV.Enabled = state;
            dgvTVRowSelectColorRestore(state);
        }

        private void dgvTVRowSelectColorRestore(bool unlocked)
        {
            if (unlocked)
            {
                dgvTV.DefaultCellStyle.SelectionBackColor = Color.Silver;
            }
            else
            {
                dgvTV.DefaultCellStyle.SelectionBackColor = Color.Salmon;
            }
        }

        private void ButtonControlEnabled(bool state = false)
        {
            btnChangeApprove.Visible = state;
            btnChangeCancel.Visible = state;
        }


        private void btnChangeApprove_Click(object sender, EventArgs e) // Кнопка Применить
        {
            if (dgvTV.SelectedRows.Count == 0)
                return;

            TVChannel tvc = GetSelected();
            if (tvc != null)
            {
                if (ValidatorText(tvgNameBox.Text)) tvc.TvgName = tvgNameBox.Text;

                if (ValidatorText(tvglogoBox.Text)) tvc.Tvglogo = tvglogoBox.Text;

                if (ValidatorText(groupTitleComboBox.Text)) tvc.GroupTitle = groupTitleComboBox.Text;

                if (ValidatorUDP(UDPbox.Text)) tvc.UDP = UDPbox.Text;

                if (ValidatorText(NameBox.Text)) tvc.Name = NameBox.Text;
            }

            dgvTVtreeEnabled(true);

            TableRefresh();

            Changed();
        }

        private void btnChangeCancel_Click(object sender, EventArgs e)  // Кнопка Отмена
        {
            // dgvTVtreeEnabled(true);
            Debug.Print("btnChangeCancel - Click");

            TableRefresh();
            Debug.Print("btnChangeCancel - TableRefresh");

            //errorProvider.Clear();  //errorProvider.SetError(UDPbox, null);
            errorProvider.SetError(UDPbox, null);
            Debug.Print("btnChangeCancel - errorProvider");

            UnModified();
            Debug.Print("btnChangeCancel - UnModified");
        }

        #endregion


        #region Проверка введенных данных в карточку
        private void NameBox_Validating(object sender, CancelEventArgs e) => TextEnterValidate(NameBox, lName.Text);
        private void tvgNameBox_Validating(object sender, CancelEventArgs e) => TextEnterValidate(tvgNameBox, ltvgName.Text);
        private void tvglogoBox_Validating(object sender, CancelEventArgs e) => TextEnterValidate(tvglogoBox, ltvglogo.Text);
        private void groupTitleComboBox_Validating(object sender, CancelEventArgs e) => TextEnterValidate(groupTitleComboBox, lgroupTitle.Text);
        private void UDPbox_Validating(object sender, CancelEventArgs e) => TextEnterValidate(UDPbox, lUDPbox.Text);


        private void TextEnterValidate(Control ctrl, string lblText)
        {
            if (string.IsNullOrEmpty(ctrl.Text) || (!RunValidate(ctrl)))
            {
                errorProvider.SetError(ctrl, "Поле " + lblText + " заполнено не верно!");
            }
            else
            {
                errorProvider.SetError(ctrl, null);
            }
        }

        bool RunValidate(Control ctrl)
        {
            if (ctrl.Name == UDPbox.Name) { return ValidatorUDP(ctrl.Text); }
            else { return ValidatorText(ctrl.Text); }
        }

        #endregion


        #region Проверка введенных данных в таблицу
        private void CelleError(DataGridViewCellValidatingEventArgs e, Control edit)
        {
            try
            {
                e.Cancel = true;
                errorProvider.SetError(edit, "Неверно заполнена ячейка");
                errorProvider.SetIconAlignment(edit, ErrorIconAlignment.MiddleRight);
                errorProvider.SetIconPadding(edit, -20);
            }
            catch (Exception ex)
            {
                Debug.Print("CelleError завершилась ошибкой. \n" + ex.Message);
                e.Cancel = false;
            }
        }

        private void dgvTV_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            Control edit = dgvTV.EditingControl;

            if (e.ColumnIndex != 3 && (!ValidatorText(e.FormattedValue.ToString()))
            || (e.ColumnIndex == 3 && (!ValidatorUDP(e.FormattedValue.ToString()))))
            {
                CelleError(e, edit);
            }
        }

        private void dgvTV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            errorProvider.Clear();
            // TableRefresh();

            dgvTVtreeEnabled(true);

            TableRefresh();

            Changed();
        }

        #endregion


        #region Методы проверки

        public static bool ValidatorUDP(string UDPserver)
        {
            //udp://@224.1.1.1:6000 - шаблон для парсинга
            string re_protocl = "(udp(?!.*udp)|http(?!.*http))";
            string re_at = "(:\\/\\/@)";
            string re_IPv4 = "((?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?))(?![\\d])";
            string re7 = "(:)";
            string re_port = "(6553[0-5]|655[0-2][0-9]|65[0-4][0-9][0-9]|6[0-4][0-9][0-9][0-9]|[0-5]?[0-9][0-9][0-9][0-9]|[0-9][0-9][0-9]|[0-9][0-9]?)(?![\\d])";//string re_port = "(\\d+)";//65535

            Regex r = new Regex(re_protocl + re_at + re_IPv4 + re7 + re_port, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(UDPserver);
            if (m.Success)
            {
                String protocol = m.Groups[1].ToString();
                String c1 = m.Groups[2].ToString();
                String ipaddress1 = m.Groups[3].ToString();
                String c5 = m.Groups[4].ToString();
                String port = m.Groups[5].ToString();

                Debug.Print("(" + protocol.ToString() + ")"
                    + "(" + c1.ToString() + ")"
                    + "(" + ipaddress1.ToString() + ")"
                    + "(" + c5.ToString() + ")"
                    + "(" + port.ToString() + ")" + "\n");

                return true;
            }
            else
            {
                Debug.Print("UDP сервер не распознан!");
            }
            return false;
        }

        public static bool ValidatorText(string txt)
        {
            //string pattern = "((?:[a-z][a-z0-9_]*))";   // Шаблон
            //string pattern = "((?:[а-яА-Яa-zA-Z][а-яА-Яa-zA-Z0-9_]*))"; ;
            //string pattern = "((?:[^а-яА-Яa-zA-Z0-9_]*))";
            //string pattern = "((?:[^а-яА-Яa-zA-Z0-9]+))";
            //string pattern = @"((^[\w\s+/-]+$))";
            //string pattern = @"([\w\s]+$)";
            //string pattern = @"((?:[\w][\w\s]+$))";
            //string pattern = "((?:[^а-яА-Яa-zA-Z0-9]+$))";
            //string pattern = "([а-яА-Яa-zA-Z]|[а-яА-Яa-zA-Z0-9]?)(?![\\w])";
            //string pattern = "((?:[a-z][a-z0-9]*))";
            //string pattern = "(?:[a-z][a-z0-9_ -=]*)";
            //string pattern = "(?:[а-яА-Яa-zA-Z0-9]|^[а-яА-Яa-zA-Z0-9_]+$*)"; //^[a-zA-Z0-9_]+$
            //string pattern = "(^[а-яА-Яa-zA-Z0-9]*|^[а-яА-Яa-zA-Z0-9_]+$*)"; //^[a-zA-Z0-9_]+$
            //string pattern = "([а-яА-Яa-zA-Z0-9]*|[а-яА-Яa-zA-Z0-9_]+$*)";
            //string pattern = "([а-яА-Яa-zA-Z0-9]*|[а-яА-Яa-zA-Z0-9_]*)";
            //string pattern = "([а-яА-Яa-zA-Z0-9])(?![\\d])";
            //string pattern = "([а-яА-Яa-zA-Z0-9])(?![\\w])";
            //string pattern = "([а-яА-Яa-zA-Z])";
            //string pattern = "^[ A-Za-z0-9]$";
            //string pattern = "[a-zA-Z]^[A-Za-z0-9]$";//"(?:[^a-z0-9 ]|(?<=['\"])s)"
            //string pattern = "(?:[^a-z0-9 ]|(?<=['\"])s)";
            //string pattern = @"(^[\w\s+/-]+$)";
            //string pattern = "(^[а-яА-Яa-zA-Z0-9])";

            string pattern = "(^[а-яА-Яa-zA-Z0-9@])";

            Regex r = new Regex(pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(txt);
            if (m.Success)
            {
                String TextAfterParsing = m.Groups[1].ToString();
                Debug.Print("(" + TextAfterParsing.ToString() + ")" + "\n");
                return true;
            }
            return false;
        }

        #endregion
    }
}