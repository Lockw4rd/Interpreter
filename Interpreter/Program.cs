using System;
using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Grammar;

namespace Interpreter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Uso: dotnet run <arquivo.txt>");
                return;
            }

            string filePath = args[0];

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Erro: O arquivo {filePath} não foi encontrado.");
                return;
            }

            // Analisar o código de entrada
            string code = File.ReadAllText(filePath);
            Compiler.Analyze(code);
        }
    }
}
