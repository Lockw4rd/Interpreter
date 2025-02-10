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

statement
    : varDeclaration ';'
    | ioStatement ';'
    | expressionStatement ';'
    | returnStatement ';'
    | functionCall ';'
    | ifStatement
    | whileLoop
    ;

argumentList
    : expr (',' expr)*
    ;

block
    : '{' statement* '}'
    ;

expressionStatement
    : expr
    ;

functionCall
    : ID '(' argumentList? ')'
    ;

ifStatement
    : 'if' '(' expr ')' block ('else' block)?
    ;

paramList
    : param (',' param)*
    ;

param
    : type ID
    ;

returnStatement
    : 'return' expr?
    ;

whileLoop
    : 'while' '(' expr ')' block
    ;

varDeclaration
    : type ID ('=' expr)?  
    ;

ioStatement
    : 'printf' '(' STRING_LITERAL (',' expr)* ')'
    | 'scanf' '(' STRING_LITERAL (',' '&' ID)* ')'
    | 'gets' '(' ID ')'
    | 'puts' '(' STRING_LITERAL ')'
    ;

type
    : INT
    | FLOAT
    | STRING
    | CHAR
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

// Conversores de string
stringConversion
    : 'atoi' '(' ID ')'
    | 'atof' '(' ID ')'
    | 'itoa' '(' ID ',' ID ',' NUMBER ')'
    ;

// Definição de structs e unions
structDeclaration
    : 'struct' ID '{' varDeclaration* '}'
    ;

unionDeclaration
    : 'union' ID '{' varDeclaration* '}'
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
STRUCT  : 'struct' ;
UNION   : 'union' ;

ID      : [a-zA-Z_][a-zA-Z_0-9]* ;
NUMBER  : [0-9]+ ('.' [0-9]+)? ;
STRING_LITERAL : '"' (~["\r\n])* '"' ;
CHAR_LITERAL   : '\'' ~["\r\n] '\'' ;

// Ignorar espaços e comentários
WS : [ \t\r\n]+ -> skip ;
COMMENT : '//' ~[\r\n]* -> skip ;
BLOCK_COMMENT : '/*' .*? '*/' -> skip ;
