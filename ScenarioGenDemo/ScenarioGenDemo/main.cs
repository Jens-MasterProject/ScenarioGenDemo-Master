using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScenarioGenDemo
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

       //Load Scenario Button
        private void Btn_ViewScenario(object sender, EventArgs e)
        {
            this.Hide();
            LoadScenario loadsc = new LoadScenario();
            loadsc.Show();

        }

        //Generate Scenario Button
        private void btn_GenScenario(object sender, EventArgs e)
        {
            this.Hide();
            GenerateScenario gensc = new GenerateScenario();
            gensc.Show();
        }

        //Exit button
        private void btn_exit(object sender, EventArgs e)
        {
            // Display a confirmation `prompt to ensure it was correctly pressed
            DialogResult result = MessageBox.Show("Exit the Application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
            
                Application.Exit();
            }
        }
    }
}
