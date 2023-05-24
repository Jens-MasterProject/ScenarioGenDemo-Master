using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScenarioGenDemo
{
    public class Scenario
    {
        // Properties
        public string Title { get; set; }
        public string MitreId { get; set; }
        public string Overview { get; set; }
        public string Objectives { get; set; }
        public string Requirements { get; set; }
        public string Steps { get; set; }
        public string Evaluation { get; set; }
        public string Outcome { get; set; }

        // Constructor
        public Scenario(string title, string mitreId, string overview, string objectives, string requirements, string steps, string evaluation, string outcome)
        {
            Title = title;
            MitreId = mitreId;
            Overview = overview;
            Objectives = objectives;
            Requirements = requirements;
            Steps = steps;
            Evaluation = evaluation;
            Outcome = outcome;
        }

    }

    // ScenarioManager class
    public class ScenarioManager
    {
        // Fields
        private List<Scenario> scenarios = new List<Scenario>();
        private Scenario currentScenario;

        // Properties
        public IReadOnlyList<Scenario> Scenarios => scenarios;
        public Scenario CurrentScenario
        {
            get => currentScenario;
            set => currentScenario = value;
        }
        // Methods
        public void AddScenario(Scenario scenario)
        {
            scenarios.Add(scenario);
            Console.WriteLine("Scenario added:");
            Console.WriteLine(scenario.ToString());
        }

        public void RemoveScenario(Scenario scenario)
        {
            scenarios.Remove(scenario);
            Console.WriteLine("Scenario removed:");
            Console.WriteLine(scenario.ToString());
        }
    }
}
