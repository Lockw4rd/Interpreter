# Interpreter

Neste repositório, estão armazenados os arquivos do projeto final da disciplina de Compiladores em ciência da computação. O projeto foi desenvolvido utilizando a linguagem C# junto a ferramenta Antlr4 com o objetivo de criar um modelo de compilador capaz de processar uma versão parcial da linguagem C. E por aqui, será relatado o processo de implementação do projeto com explicações do que cada elemento compõe e suas funcionalidades.

**1. A Gramática**

Com o auxílio da extensão do Antlr4 para o VS Code, temos a ferramenta capaz de informar com precisão a declaração da nossa gramática para o projeto. Através dela, é possível especificar os diferentes elementos no qual gostaríamos de trabalhar para que o compilador possa processar e nos informar se o código é válido ou não. Para a nossa gramática, determinanos a implementação das seguintes funcionalidades:

Declaração e Inicialização de Variáveis (int, float, string...);
Estruturas de Controle (if, else, while...);
Entrada e Saída (printf, scanf, gets...);
Operadores (lógicos e matemáticos);
Funções (com/sem declaração);
Estructs e Unions;
Diretivas de compilação e comentários.

**2. Programa**

Após a criação da nossa gramática, executamos o comando "java -jar antlr-4.13.2-complete.jar  -Dlanguage=CSharp -o Grammar -listener -visitor -package Grammar Language.g4", que gera os arquivos do Antlr4 na pasta Grammar através do arquivo Language.g4, onde podemos prosseguir com as implementações do projeto.

**3. Implementção**

Em seguida, definimos o arquivo Program.cs para ler o código de entrada, que será processado pelo arquivo Compiler.cs, onde as funções de Lexer e Parser do Antlr4 vão processar nossa entrada. Com o auxílio do arquivo ErrorListener.cs, que vai coletar os erros encontrados no código, e do arquivo SemanticListener.cs, que faz a análise semântica do código, armazenamos os erros encontrados que serão exibidos no terminal. No fim, declaramos para que o projeto imprima no terminal o resultado da árvore de derivação gerada da análise.

**4. Conclusão**

Neste projeto, desenvolvemos um modelo de compilador capaz de processa uma versão parcial da linguagem C, com seus diversos recursos que podem ser testados ateavés da ferramenta. Encontramos algumas dificuldades durante a implementação, configurando a ferramenta Antlr4 e fazer ela gerar os arquivos, mas que foram sanadas durante o processo. De forma geral, podemos concluir que o projeto prático foi essencial para entendermos de forma mais profunda os conceitos da discplina de compiladores, seus diferentes desafios e suas diversas possibilidades de tornar códigos mais eficientes. 

**Referências Bibliográficas**

https://www.antlr.org/
https://tomassetti.me/antlr-mega-tutorial/
