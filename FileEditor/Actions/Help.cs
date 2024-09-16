using System;
using System.Collections.Generic;

namespace FileEditor.Actions
{
    internal class Help : IAction
    {
        public string Name { get; init; } = "Help";
        public string Description { get; init; } = "Lists all commands";
        public string Verb { get; init; } = "Help";

        // The actions are passed as an argument so the Help action can list them
        public void Execute(string[] args, List<IAction> actions)
        {
            actions.ForEach(action =>
            {
                Console.WriteLine($"Name: {action.Name}, Verb: {action.Verb}");
                Console.WriteLine($"Description: {action.Description}");
                Console.WriteLine();
            });
        }

        // Default IAction.Execute method, in case you don't want to pass actions (but needed for the interface)
        public void Execute(string[] args)
        {
            Console.WriteLine("Help action called but no actions provided.");
        }
    }
}
