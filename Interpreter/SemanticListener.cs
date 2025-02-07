using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using Grammar;

public class SemanticListener : LanguageBaseListener
{
    public override void ExitVarDeclaration(LanguageParser.VarDeclarationContext context)
    {
        string varName = context.ID().GetText();
        string varType = context.type().GetText();

        if (varType == "union" && context.expr() != null)
        {
            Console.WriteLine($"Erro semântico: Unions não podem ser inicializadas diretamente. Variável: {varName}");
        }
    }

    public override void ExitExpressionStatement(LanguageParser.ExpressionStatementContext context)
    {
        Console.WriteLine($"Expressão avaliada: {context.expr().GetText()}");
    }

//    public override void ExitStructDeclaration(LanguageParser.StructDeclarationContext context)
//    {
//        Console.WriteLine($"Struct declarada: {context.ID().GetText()}");
//    }

//    public override void ExitUnionDeclaration(LanguageParser.UnionDeclarationContext context)
//    {
//        Console.WriteLine($"Union declarada: {context.ID().GetText()}");
//    }

    private Dictionary<string, bool> functions = new Dictionary<string, bool>();

    public override void ExitFunctionDeclaration(LanguageParser.FunctionDeclarationContext context)
    {
        string funcName = context.ID().GetText();
        if (functions.ContainsKey(funcName))
        {
            Console.WriteLine($"Erro: A função '{funcName}' já foi definida.");
        }
        else
        {
            functions[funcName] = true;
            Console.WriteLine($"Função declarada: {funcName}");
        }
    }

    public override void ExitFunctionCall(LanguageParser.FunctionCallContext context)
    {
        string funcName = context.ID().GetText();
        if (!functions.ContainsKey(funcName))
        {
            Console.WriteLine($"Erro: A função '{funcName}' não foi definida antes da chamada.");
        }
        else
        {
            Console.WriteLine($"Função chamada: {funcName}");
        }
    }

    public override void ExitPreprocessorDirective(LanguageParser.PreprocessorDirectiveContext context)
    {
        if (context.STRING_LITERAL() != null)
        {
            Console.WriteLine($"Include detectado: {context.STRING_LITERAL().GetText()}");
        }
        else if (context.ID() != null)
        {
            Console.WriteLine($"Define detectado: {context.ID().GetText()} = {context.expr().GetText()}");
        }
    }

}

/*

using System;
using Antlr4.Runtime.Tree;

public class SemanticListener : LanguageBaseListener
{
    public override void ExitVarDeclaration(LanguageParser.VarDeclarationContext context)
    {
        string varName = context.ID().GetText();
        string varType = context.type().GetText();

        if (varType == "union" && context.expr() != null)
        {
            Console.WriteLine($"Erro semântico: Unions não podem ser inicializadas diretamente. Variável: {varName}");
        }
    }

    public override void ExitExpressionStatement(LanguageParser.ExpressionStatementContext context)
    {
        Console.WriteLine($"Expressão avaliada: {context.expr().GetText()}");
    }

    public override void ExitStructDeclaration(LanguageParser.StructDeclarationContext context)
    {
        Console.WriteLine($"Struct declarada: {context.ID().GetText()}");
    }

    public override void ExitUnionDeclaration(LanguageParser.UnionDeclarationContext context)
    {
        Console.WriteLine($"Union declarada: {context.ID().GetText()}");
    }
}


*/

/*

using System;
using System.Collections.Generic;
using Antlr4.Runtime.Tree;

public class SemanticListener : LanguageBaseListener
{
    private Dictionary<string, bool> functions = new Dictionary<string, bool>();

    public override void ExitFunctionDeclaration(LanguageParser.FunctionDeclarationContext context)
    {
        string funcName = context.ID().GetText();
        if (functions.ContainsKey(funcName))
        {
            Console.WriteLine($"Erro: A função '{funcName}' já foi definida.");
        }
        else
        {
            functions[funcName] = true;
            Console.WriteLine($"Função declarada: {funcName}");
        }
    }

    public override void ExitFunctionCall(LanguageParser.FunctionCallContext context)
    {
        string funcName = context.ID().GetText();
        if (!functions.ContainsKey(funcName))
        {
            Console.WriteLine($"Erro: A função '{funcName}' não foi definida antes da chamada.");
        }
        else
        {
            Console.WriteLine($"Função chamada: {funcName}");
        }
    }

    public override void ExitPreprocessorDirective(LanguageParser.PreprocessorDirectiveContext context)
    {
        if (context.STRING_LITERAL() != null)
        {
            Console.WriteLine($"Include detectado: {context.STRING_LITERAL().GetText()}");
        }
        else if (context.ID() != null)
        {
            Console.WriteLine($"Define detectado: {context.ID().GetText()} = {context.expr().GetText()}");
        }
    }
}


*/

