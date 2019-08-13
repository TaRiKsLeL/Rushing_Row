using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rushing_Row
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TitleLabel.Parent = pictureBox1;
            TitleLabel.BackColor = Color.Transparent;
            // label1.Parent = this;
            // label1.Location = new Point(79, 128);
            TitleLabel.BringToFront();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (textTB.Text != "")
            {
                new RowForm(textTB.Text, Convert.ToInt32(speedNUD.Value)).ShowDialog();
            }
            else
            {
                MessageBox.Show("Set text!");
            }
        }
    }
}
