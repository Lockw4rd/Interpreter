using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Grammar;
using System;
using Antlr4.Runtime;

public class Compiler
{
    public static void Analyze(string input)
    {
        var inputStream = new AntlrInputStream(input);
        var lexer = new LanguageLexer(inputStream);
        var tokenStream = new CommonTokenStream(lexer);
        var parser = new LanguageParser(tokenStream);

        // Adicionar ErrorListener para capturar erros de sintaxe
        var errorListener = new ErrorListener();
        parser.RemoveErrorListeners();
        parser.AddErrorListener(new ErrorListener());
        parser.ErrorHandler = new DefaultErrorStrategy();

        // Executar análise sintática
        var tree = parser.program();

        // Análise semântica com o SemanticListener
        var walker = new Antlr4.Runtime.Tree.ParseTreeWalker();
        var semanticListener = new SemanticListener();
        walker.Walk(semanticListener, tree);

        // Exibir árvore sintática
        Console.WriteLine(tree.ToStringTree(parser));
    }
}



/*

using System;
using Antlr4.Runtime;

public class Compiler
{
    public static void Analyze(string input)
    {
        var inputStream = new AntlrInputStream(input);
        var lexer = new LanguageLexer(inputStream);
        var tokenStream = new CommonTokenStream(lexer);
        var parser = new LanguageParser(tokenStream);

        // Adicionar ErrorListener para capturar erros de sintaxe
        parser.RemoveErrorListeners();
        parser.AddErrorListener(new ErrorListener());

        // Executar análise sintática
        var tree = parser.program();

        // Análise semântica com o SemanticListener
        var walker = new Antlr4.Runtime.Tree.ParseTreeWalker();
        var semanticListener = new SemanticListener();
        walker.Walk(semanticListener, tree);

        // Exibir árvore sintática
        Console.WriteLine(tree.ToStringTree(parser));
    }
}

*/