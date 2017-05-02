using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace M3Ueditor
{
    public class FormGlobal : Form
    {
        public FormGlobal()
        {

        }

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


        private void ChangeLanguage(string lang)
        {
            //ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            foreach (Control c in this.Controls)
            {
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }

            //ChangeLanguage(menu.Items);
        }

        private void ChangeLanguage(ToolStripItemCollection collection)
        {
            foreach (ToolStripItem item in collection)
            {
                //ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
                resources.ApplyResources(item, item.Name, new CultureInfo(lng));
                if (item is ToolStripDropDownItem)
                    ChangeLanguage(((ToolStripDropDownItem)item).DropDownItems);
            }
        }
        #endregion

    }
}
