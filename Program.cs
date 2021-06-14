using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Homework.Agents;
using Homework.Floors;

namespace Homework
{
    class Program
    {
        static List<Agent> agents = new List<Agent>();
        static Elevator elevator = new Elevator();
        private static List<Floor> floors = new List<Floor>() {new GFloor(), new SFloor(), new T1Floor(), new T2Floor()};
        private static List<string> agentTypes = new List<string>() {"Confidential", "Secret", "Top-Secret"};
        static void Main(string[] args)
        {
            
            while (true)
            {
                Console.WriteLine("Current Floor-> " + elevator.CurrentFloor);
                Console.WriteLine("1. Move Agent To Floor");
                Console.WriteLine("2. Make New Agent");

                var input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Agent agent = GetAgent();
                        MoveAgent(agent);
                        break;
                    case 2:
                        MakeAgent();
                        break;
                }
            }



        }

        private static void MakeAgent()
        {
            Console.WriteLine("Please give a name to your agent");
            var name = Console.ReadLine();
            Console.WriteLine("Please select agent access to floors");
            foreach (var pr in name)
            {
                Console.WriteLine(agentTypes);
            }

            var typeAgent = Console.ReadLine();
            switch (typeAgent)
            {
                case "Confidential":
                    agents.Add(new Confidential(name));
                    break;
                case "Secret":
                    agents.Add(new Confidential(name));
                    break;
                case "Top-Secret":
                    agents.Add(new Confidential(name));
                    break;
            }

            Console.WriteLine("Agent Added");
        }

        private static  Agent GetAgent()
        {
            Console.WriteLine("Select Agent Name");
            foreach (var agent in agents)
            {
                Console.WriteLine(agent.Name);
            }
            string name = Console.ReadLine();
            Agent foundAgent = agents.FirstOrDefault(x => x.Name == name);
            if (foundAgent == null)
            {
                Console.WriteLine("Invalid name");
                return null;
            }
            else
            {
                return foundAgent;
            }


        }

        private static void MoveAgent(Agent agent)
        {
            Console.WriteLine("Select Floor");
            Console.WriteLine(string.Join("\n", elevator.floors));
            string name = Console.ReadLine();
            if (elevator.floors.Contains(name))
            {
                var floorFound = floors.FirstOrDefault(x => x.Name == name);
                if (floorFound.AccessTo.Contains(agent.SecurityLevel))
                {
                    Console.WriteLine("Moving");
                    elevator.ChangeElevatorPosition(name);
                }
                else
                {
                    Console.WriteLine("This agent is not allowed to access that floor");
                }
            }
        }
    }
}
