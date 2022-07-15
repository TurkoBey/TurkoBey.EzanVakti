using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurkoBey.EzanVakti.Forms
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e) { this.Text = Metinler.Title + " - Ayarlar"; }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPageHakkinda"]) { this.Text = Metinler.Title + " - Hakkında"; }
            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPageAyarlar"]) { this.Text = Metinler.Title + " - Ayarlar"; }
        }
    }
}
