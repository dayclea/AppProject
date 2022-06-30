using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamProjectFrontEnd.Screen
{
    public partial class ManagerScreen : UserControl
    {
        public ManagerScreen()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SolutionPage2 solPage = new SolutionPage2();
            solPage.Tag = this;
            solPage.Show();
            this.Hide();
        }
    }
}
