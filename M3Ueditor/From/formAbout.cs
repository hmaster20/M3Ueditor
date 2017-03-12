using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace M3Ueditor
{
    public partial class formAbout : Form
    {
        public bool isDebugMode { get; set; } =
#if DEBUG
            true;
#else
            false;
#endif

        public formAbout()
        {
            InitializeComponent();

            this.Text = String.Format("О программе {0}", AssemblyTitle);

            lName.Text = AssemblyTitle;
            lVersion.Text = String.Format("Версия {0}", AssemblyVersion);
            lCopyright.Text = AssemblyCopyright;

            textBoxDescription.Text = AssemblyDescription;
        }


        #region Методы доступа к атрибутам сборки

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                if (isDebugMode)
                {
                    return Assembly.GetExecutingAssembly().GetName().Version.ToString();
                }
                else
                {
                    return Assembly.GetExecutingAssembly().GetName().Version.Major.ToString()
                        + "."
                        + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();
                }

            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        #endregion


        private void linkLabelHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(linkLabelHome.Text);
        }

        private void btnLicense_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.gnu.org/licenses/gpl-2.0.html");
        }
    }
}
