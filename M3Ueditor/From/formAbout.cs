using M3Ueditor.Class;
using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace M3Ueditor
{
    public partial class formAbout : Form
    {
        public formAbout(string lng)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lng);

            InitializeComponent();

            //// Объявите экземпляр диспетчера ресурсов. 
            //ResourceManager LocRM = new ResourceManager("formAbout.formAbout", typeof(formAbout).Assembly);
            //// Назначьте строку для ключа "strMessage" в окне сообщения.
            //MessageBox.Show(LocRM.GetString("lName.Text"));

            if (lng == "ru-RU")
            {
                this.Text = String.Format("О программе");
                lVersion.Text = String.Format("Версия {0}", About.AssemblyVersion);
                lName.Text = About.AssemblyTitle;
            }
            if (lng == "en-US")
            {
                this.Text = String.Format("About");
                lVersion.Text = String.Format("Version {0}", About.AssemblyVersion);
                lName.Text = About.AssemblyProduct;
            }

            lCopyright.Text = About.AssemblyCopyright;

            textBoxDescription.Text = About.AssemblyDescription;
        }


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
