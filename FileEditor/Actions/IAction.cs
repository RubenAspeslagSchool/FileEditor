using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEditor.Actions
{
    public interface IAction
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public string Verb {  get; init; }
        public void Execute(string[] args);

    }
}
