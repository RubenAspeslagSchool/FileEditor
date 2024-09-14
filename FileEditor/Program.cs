using FileEditor.Actions;
using System;
using System.IO;

class Program
// debug at C:\Users\ruben\Desktop\files\code projects\FileEditor\FileEditor\bin\Debug\net8.0
{
    static void Main(string[] args)
    {
        ExecuteAction executor = new ExecuteAction();
        executor.Execute(args);
    }

   
}
