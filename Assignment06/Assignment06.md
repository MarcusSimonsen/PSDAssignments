# Assignment 06

This assignment is completed by the students Frederik Gantriis Møller and Marcus Henrik Simonsen.

## Exercise 7.1

Abstract syntax tree of `ex1.c`:
Prog
    [Fundec
       (None, "main", [(TypI, "n")],
        Block
          [Stmt
             (While
                (Prim2 (">", Access (AccVar "n"), CstI 0),
                 Block
                   [Stmt (Expr (Prim1 ("printi", Access (AccVar "n"))));
                    Stmt
                      (Expr
                         (Assign
                            (AccVar "n",
                             Prim2 ("-", Access (AccVar "n"), CstI 1))))]));
           Stmt (Expr (Prim1 ("printc", CstI 10)))])]

For drawing, see `Exercise7-1.jpg`.

## Exercise 7.2

See file `7-2.c` for the MicroC implementations.
Run file `test7-2.sh` to parse and run the MicroC file.

## Exercise 7.3

See file `7-3.c`.
Run file `test7-3.sh` to test.

## Exercise 7.4

See files `MicroC/Absyn.fs` and `MicroC/Interp.fs`.

## Exercise 7.5

See files `CLex.fsl` and `CPar.fsy` for code written.
Run file `test7-5.sh` to see example of use.

