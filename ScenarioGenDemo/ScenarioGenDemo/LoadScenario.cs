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
    public partial class LoadScenario : Form
    {
        private ScenarioManager scenarioManager;

        public LoadScenario()
        {
            InitializeComponent();
            scenarioManager = new ScenarioManager();

            //Test Scenario Template 
            scenarioManager.AddScenario(new Scenario(
                 "Scenario 1",
                 "MITREID 1",
                 "This is an overview of scenario 1",
                 "These are the objectives of scenario 1",
                 "These are the requirements for scenario 1",
                 "These are the steps for scenario 1",
                 "This is how we evaluate scenario 1",
                 "This is the expected outcome for scenario 1"
 ));
            //Test Scenario 1 
            scenarioManager.AddScenario(new Scenario(
                     "Initial Access-Spearphishing attachment",
                     "TA001-T1566.001",
                     "For this scenario, the students will learn the identification and response process to spearphishing attacks, which are commonly used in the initial access phase of an attack where The adversary is trying to get into the network. The scenario will focus on a spearphishing attachment and how it can be used to gain access to a network. As read on the MITRE ATT\\&CK site, spearfishing attachment is a specific variant of spear phishing that employs the use of malware attached to an email",
                     "Identify the stages of a spearphishing attack, Identify a spearphishing attachment, Learn how to use different tools for spearphishing analysis, Develop strategies for the prevention and mitigation of spearphishing attacks",
                     "Virtual machine, Phishing analysis tools, Sample spearphishing email with a malicious attachment",
                     "These are the steps for scenario 2",
                     "Identifying the spearphishing email and its attachment, Analyze the attachment using the tools provided and determine if it is malicious, Assess the impact of the attachment, Develop strategies for the prevention and mitigation of spearphishing attacks",
                     "This is the expected outcome for scenario 2"
));            //Test Scenario 2 
            scenarioManager.AddScenario(new Scenario(
                     "Privilege Escalation-Sudo Caching",
                     "T1548.003",
                     "The second test scenario focuses on the Privilege escalation tactic of the MITRE ATT\\&ACK enterprise section. Where the goal is to gain a higher level of access to a system utilizing different methods documented in the MITRE framework. The technique of Sudo caching was chosen to be used for this example as this is something that is familiar through previous work. Sudo caching involves abusing weaknesses in the sudo file to elevate  access to a Superuser role and allows users to  perform commands from terminals with elevated privileges and to control who can perform these commands on the system",
                     "understand the concept of privilege escalation and Sudo Caching, learn ways to identify exploit vulnerabilities in  the Sudo config file, Understand how to mitigate Certain Privilege escalation techniques ",
                     "Virtual machine, Kali Linux, Target system with sudo enabled, Configuration: Sudo su disabled, adding a group with sudo permission for student to access ",
                     "Distribute VM`s with Kali Linux and target system attached, Instruct students to perform a reconnaissance of the target and identify the Sudo configuration file as well as potential vulnerabilities., Instruct students to utilize the Sudo Caching technique on the target system, Ask students to write a report identifying security measures to mitigate the vulnerabilities associated with the Sudo caching technique",
                     "Identify the vulnerability in the sudo config file, Using the Sudo caching method to exploit to escalate their privileges in the target system, Identify countermeasures against this technique",
                     "After this scenario is complete, students should have gained some practical experience with identifying, executing, and also preventing the Privilege escalation techniques Sudo caching. "
));
            //update Scenario list
            foreach (var scenario in scenarioManager.Scenarios)
            {
                ScenarioComboBox.Items.Add(scenario.Title);
            }
        }
        //Return Button
        private void Return_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main main = new Main();
            main.Show();
        }
        //load selected scenario
        private void LoadScenario_Load(object sender, EventArgs e)
        {
            foreach (Scenario scenario in scenarioManager.Scenarios)
            {
                ScenarioComboBox.Items.Add(scenario.Title);
            }
            ScenarioComboBox.DisplayMember = "Title";
            ScenarioComboBox.SelectedIndexChanged += ScenarioComboBox_SelectedIndexChanged;

        }
        //updates the list
        public void UpdateScenarioComboBox()
        {
            ScenarioComboBox.Items.Clear(); // clear all existing items in the ComboBox
            foreach (var scenario in scenarioManager.Scenarios)
            {
                ScenarioComboBox.Items.Add(scenario.Title);
            }
        }
        //changed between viewed scenarios in the list
        private void ScenarioComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedScenario = scenarioManager.Scenarios.FirstOrDefault(s => s.Title == ScenarioComboBox.SelectedItem.ToString());
         
            if (selectedScenario != null)
            {   scenarioManager.CurrentScenario = selectedScenario;
                scenarioTitleTextBox.Text = selectedScenario.Title;
                mitreIdTextBox.Text = selectedScenario.MitreId;
                overviewTextBox.Text = selectedScenario.Overview;
                objectivesTextBox.Text = selectedScenario.Objectives;
                requirementsTextBox.Text = selectedScenario.Requirements;
                stepsTextBox.Text = selectedScenario.Steps;
                evaluationTextBox.Text = selectedScenario.Evaluation;
                outcomeTextBox.Text = selectedScenario.Outcome;
            }
        }
        //Button to update edited scenario
        private void btn_update_scenario(object sender, EventArgs e)
        {

            // Display a confirmation `prompt to ensure it was correctly pressed
            DialogResult result = MessageBox.Show("Update Scenario? This will overwrite previous save", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                Scenario scenario = new Scenario(
          scenarioTitleTextBox.Text,
          mitreIdTextBox.Text,
          overviewTextBox.Text,
          objectivesTextBox.Text,
          requirementsTextBox.Text,
          stepsTextBox.Text,
          evaluationTextBox.Text,
          outcomeTextBox.Text);
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
        }
        //Delete scenario Button
        private void deleteScenarioButton_Click(object sender, EventArgs e)
        {

            // Display a confirmation `prompt to ensure it was correctly pressed
            DialogResult result = MessageBox.Show("Delete Scenario? This Can not be reversed", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {

                // Get the selected scenario from the combo box
                Scenario selectedScenario = (Scenario)ScenarioComboBox.SelectedItem;
                // Remove the selected scenario from the scenario manager
                scenarioManager.RemoveScenario(selectedScenario);
                // Update the combo box with the updated list of scenarios
                UpdateScenarioComboBox();
            }
        }
    }
}

    