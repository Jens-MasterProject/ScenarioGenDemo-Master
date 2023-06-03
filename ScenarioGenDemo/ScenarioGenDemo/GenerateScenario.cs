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
    public partial class GenerateScenario : Form
    {
        private ScenarioManager scenarioManager;
        private Scenario currentScenario;
        public GenerateScenario()
        {
            InitializeComponent();
            scenarioManager = new ScenarioManager();
            currentScenario = new Scenario("", "", "", "", "", "", "", "");
        }
        //Making the save button store the information of all the textboxes when pressed
        private void Save(object sender, EventArgs e)
        {
        Scenario scenario = new Scenario(
            titleTextBox.Text,
            mitreIdTextBox.Text,
            overviewTextBox.Text,
            objectivesTextBox.Text,
            requirementsTextBox.Text,
            stepsTextBox.Text,
            evaluationTextBox.Text,
            outcomeTextBox.Text );

            //adding scenario to the scenarioManager and giving the sucess message when saved
            scenarioManager.AddScenario(scenario);
            scenarioManager.CurrentScenario = scenario;
            MessageBox.Show("Scenario saved successfully!");

            //updating the combobox used in the load scenario form
            LoadScenario loadScenarioForm = Application.OpenForms.OfType<LoadScenario>().FirstOrDefault();
            if (loadScenarioForm != null)
            {
                loadScenarioForm.UpdateScenarioComboBox();
            }
        }
        //The return button which hides this instance and creates a new main instance
        private void Return(object sender, EventArgs e)
        {
            this.Hide();
            Main main = new Main();
            main.Show();
        }

        //makes the textboxes update the currentscenario identifers when text is changed
        private void titleTextBox_TextChanged(object sender, EventArgs e)
        { 
            currentScenario.Title = titleTextBox.Text;
        }
        private void mitreIdTextBox_TextChanged(object sender, EventArgs e)
        {
            
            currentScenario.MitreId = mitreIdTextBox.Text;
        }
        private void overviewTextBox_TextChanged(object sender, EventArgs e)
        {
           
            currentScenario.Overview = overviewTextBox.Text;
        }
        private void objectivesTextBox_TextChanged(object sender, EventArgs e)
        {
            
            currentScenario.Objectives = objectivesTextBox.Text;
        }
        private void requirementsTextBox_TextChanged(object sender, EventArgs e)
        {
            
            currentScenario.Requirements = requirementsTextBox.Text;
        }
        private void stepsTextBox_TextChanged(object sender, EventArgs e)
        {
            
            currentScenario.Steps = stepsTextBox.Text;
        }
        private void evaluationTextBox_TextChanged(object sender, EventArgs e)
        {
            
            currentScenario.Evaluation = evaluationTextBox.Text;
        }
        private void outcomeTextBox_TextChanged(object sender, EventArgs e)
        {
            
            currentScenario.Outcome = outcomeTextBox.Text;
        }

    }
}
