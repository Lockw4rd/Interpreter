using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Grammar;

public class Compiler
{
    public static void Analyze(string input)
    {
        // Leitura do arquivo de entrada
        var inputStream = new AntlrInputStream(input);
        var lexer = new LanguageLexer(inputStream);
        var tokenStream = new CommonTokenStream(lexer);
        var parser = new LanguageParser(tokenStream);

        // Adicionar ErrorListener para capturar erros de sintaxe
        var errorListener = new ErrorListener();
        parser.RemoveErrorListeners();
        parser.AddErrorListener(new ErrorListener());

        // Executar análise sintática
        var tree = parser.program();

        // Análise semântica com SemanticListener
        var walker = new Antlr4.Runtime.Tree.ParseTreeWalker();
        var semanticListener = new SemanticListener();
        walker.Walk(semanticListener, tree);

        // Exibir árvore sintática
        Console.WriteLine();
        Console.WriteLine(tree.ToStringTree(parser));
    }
}
