using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Grammar;
using System;
using System.IO;

namespace Interpreter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Uso: dotnet run <arquivo.lang>");
                return;
            }

            string filePath = args[0];

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Erro: O arquivo {filePath} não foi encontrado.");
                return;
            }

            string code = File.ReadAllText(filePath);
            Compiler.Analyze(code);
        }
    }
}




/*

using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Uso: dotnet run <arquivo.c>");
            return;
        }

        string filePath = args[0];

        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Erro: O arquivo {filePath} não foi encontrado.");
            return;
        }

        string code = File.ReadAllText(filePath);
        Compiler.Analyze(code);
    }
}

*/

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
