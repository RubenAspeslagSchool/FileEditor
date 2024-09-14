using System;
using System.Linq;

namespace FileEditor.Actions
{
    public class ExecuteAction
    {
        private IAction[] actions;

        public ExecuteAction()
        {
            // Register available actions
            actions = new IAction[]
            {
                new CreateFile(),
                new DeleteFile(),
            };
        }

        public void Execute(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No action specified.");
                return;
            }

            string actionVerb = args[0].ToLower();
            IAction action = actions.FirstOrDefault(a => a.Verb.ToLower() == actionVerb);

            if (action != null)
            {
                action.Execute(args);
            }
            else
            {
                Console.WriteLine($"Unknown action: {actionVerb}");
            }
        }
    }
}
