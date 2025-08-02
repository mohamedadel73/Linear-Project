using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linear_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Solve_Linear_System solve_Linear_System = new Solve_Linear_System(int.Parse(txtNumOfEquations.Text));
            this.Hide();
            solve_Linear_System.ShowDialog();
        }
    }
}
