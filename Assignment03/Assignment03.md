## Exercise 3.3
$\texttt{main} \Rightarrow^A$
$\texttt{Expr EOF} \Rightarrow^F$
$\texttt{LET NAME z} = \texttt{Expr IN Expr END EOF} \Rightarrow^H$
$\texttt{LET NAME z} = \texttt{Expr IN Expr PLUS Expr END EOF} \Rightarrow^G$
$\texttt{LET NAME z} = \texttt{Expr IN Expr PLUS Expr TIMES Expr END EOF} \Rightarrow^C$
$\texttt{LET NAME z} = \texttt{Expr IN Expr PLUS Expr TIMES CSTINT 3 END EOF} \Rightarrow^C$
$\texttt{LET NAME z} = \texttt{Expr IN Expr PLUS CSTINT 2 TIMES CSTINT 3 END EOF} \Rightarrow^B$
$\texttt{LET NAME z} = \texttt{Expr IN NAME z PLUS CSTINT 2 TIMES CSTINT 3 END EOF} \Rightarrow^E$
$\texttt{LET NAME z} = \texttt{(Expr) IN NAME z PLUS CSTINT 2 TIMES CSTINT 3 END EOF} \Rightarrow^C$
$\texttt{LET NAME z} = \texttt{(CSTINT 17) IN NAME z PLUS CSTINT 2 TIMES CSTINT 3 END EOF} \Rightarrow$
## Exercise 3.4

## Exercise 3.5
See files.
## Exercise 3.6
See file `Expr.fs` lines 337-342.
## Exercise 3.7
See files `ExprLex.fsl`, `ExprPar.fsy`, `Absyn.fs`.