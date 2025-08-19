using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSB_demo.Views
{
    public partial class ChoixFraisForm : Form
    {
        public ChoixFraisForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fraisForfaitForm = new NewFicheFraisForm();
            fraisForfaitForm.ShowDialog();
        }
    }
}
