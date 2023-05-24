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
    }
}
