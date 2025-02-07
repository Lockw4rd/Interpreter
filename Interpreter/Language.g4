grammar Language;

program : preprocessorDirective* functionDeclaration* statement+ ;

preprocessorDirective
    : '#include' STRING_LITERAL
    | '#define' ID expr
    ;

functionDeclaration
    : type ID '(' paramList? ')' block
    | 'void' ID '(' paramList? ')' block
    ;

paramList
    : param (',' param)*
    ;

param
    : type ID
    ;

block
    : '{' statement* '}'
    ;

statement
    : varDeclaration ';'
    | ioStatement ';'
    | expressionStatement ';'
    | returnStatement ';'
    | functionCall ';'
    | ifStatement
    | whileLoop
    ;

returnStatement
    : 'return' expr?
    ;

functionCall
    : ID '(' argumentList? ')'
    ;

argumentList
    : expr (',' expr)*
    ;

ifStatement
    : 'if' '(' expr ')' block ('else' block)?
    ;

varDeclaration
    : type ID ('=' expr)?  // Tipo, nome e possível inicialização
    ;

ioStatement
    : 'printf' '(' STRING_LITERAL (',' expr)* ')'
    | 'scanf' '(' STRING_LITERAL (',' '&' ID)* ')'
    | 'gets' '(' ID ')'
    | 'puts' '(' STRING_LITERAL ')'
    ;

expressionStatement
    : expr
    ;

type
    : INT
    | FLOAT
    | STRING
    | CHAR
    ;

whileLoop
    : 'while' '(' expr ')' block
    ;

expr
    : expr op=( '*' | '/' | '%' ) expr     # MulDivExpr
    | expr op=( '+' | '-' ) expr           # AddSubExpr
    | expr op=( '==' | '!=' | '<' | '<=' | '>' | '>=' ) expr # RelExpr
    | expr op=( '&&' | '||' ) expr         # LogicalExpr
    | '(' expr ')'                         # ParenExpr
    | '-' expr                             # NegateExpr
    | ID                                   # IdExpr
    | functionCall                         # FuncCallExpr
    | NUMBER                               # NumberExpr
    | STRING_LITERAL                       # StringExpr
    | CHAR_LITERAL                         # CharExpr
    ;

// Tokens
INT     : 'int' ;
FLOAT   : 'float' ;
STRING  : 'string' ;
CHAR    : 'char' ;
VOID    : 'void' ;
RETURN  : 'return' ;
IF      : 'if' ;
ELSE    : 'else' ;
WHILE   : 'while' ;

ID      : [a-zA-Z_][a-zA-Z_0-9]* ;
NUMBER  : [0-9]+ ('.' [0-9]+)? ;
STRING_LITERAL : '"' (~["\r\n])* '"' ;
CHAR_LITERAL   : '\'' ~["\r\n] '\'' ;

// Ignorar espaços e comentários
WS : [ \t\r\n]+ -> skip ;
COMMENT : '//' ~[\r\n]* -> skip ;
BLOCK_COMMENT : '/*' .*? '*/' -> skip ;
