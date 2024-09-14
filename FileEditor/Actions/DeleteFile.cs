using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEditor.Actions
{
    public class DeleteFile : IAction
    {
        public string Name { get; init; } = "delete file";
        public string Description { get; init; } = "deletes an existing file";
        public string Verb { get; init; } = "deleteFile";

        public void Execute(string[] args)
        {
            string? fileName = args.Length > 1 ? args[1] : null;
            if (File.Exists(fileName)) 
            { 
                File.Delete(fileName);
            }
        }
    }
}
