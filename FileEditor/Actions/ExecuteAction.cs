using FileEditor.Actions.pdf;
using System;
using System.Linq;

namespace FileEditor.Actions
{
    public class ExecuteAction
    {
        public List<IAction> actions { get; init; }

        public ExecuteAction()
        {
            // Register available actions
            actions = new List<IAction>
            {
                new Help(),
                new CreateFile(),
                new DeleteFile(),
                new ConcatenatePdf(),
                new SplitPdf(),
            };
        }

        // Main Execute method: either handles interactive mode or direct execution from args
        public void Execute(string[] args)
        {
            if (args.Length == 0)
            {
                EnterInteractiveMode();
            }
            else
            {
                ExecuteCommand(args);
            }
        }

        // Handles the interactive mode where the user inputs commands
        private void EnterInteractiveMode()
        {
            Console.WriteLine("Welcome to FileEditor! Enter a command (type 'exit' to quit):");
            string command = null;

            while (command != "exit")
            {
                command = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(command))
                {
                    string[] argsCommand = command.Split(' ');
                    ExecuteCommand(argsCommand);
                }
            }
        }

        // Finds the appropriate action and executes it
        private void ExecuteCommand(string[] args)
        {
            string actionVerb = args[0].ToLower();
            IAction action = FindActionByVerb(actionVerb);

            if (action != null)
            {
                // Special handling for Help action to pass the actions list
                if (action is Help helpAction)
                {
                    helpAction.Execute(args, actions);
                }
                else
                {
                    action.Execute(args);
                }
            }
            else
            {
                Console.WriteLine($"Unknown action: {actionVerb}");
            }
        }

        // Finds the action based on the verb provided
        private IAction FindActionByVerb(string verb)
        {
            return actions.FirstOrDefault(a => a.Verb.Equals(verb, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
