using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TongItsGame.Forms
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            this.Size = new Size(1000, 800); // Set the form size
            this.StartPosition = FormStartPosition.CenterScreen; // Center form on screen
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hides the StartForm
            var mainForm = new MainForm(); // Assuming MainForm is the name of your main game form

            // Set the size of MainForm to match StartForm
            mainForm.Size = this.Size;
            // Center MainForm on screen
            mainForm.StartPosition = FormStartPosition.CenterScreen;

            mainForm.Closed += (s, args) => this.Close(); // Ensures StartForm closes when MainForm is closed
            mainForm.Show();
        }
    }
}
