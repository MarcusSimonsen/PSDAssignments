# Assignment 7

## 8.1

### 8.1.ii
[LDARGS;
CALL (1, "L1"); STOP;
Label "L1"; INCSP 1; GETBP; CSTI 1;         int i; i=0;
    ADD; CSTI 0; STI; INCSP -1;
GOTO "L3";
Label "L2"; GETBP; CSTI 1; ADD; LDI;       print i; i=i+1;
    PRINTI; INCSP -1; GETBP; CSTI 1;
    ADD; GETBP; CSTI 1; ADD; LDI; CSTI 1;
    ADD; STI; INCSP -1; INCSP 0;
Label "L3"; GETBP; CSTI 1; ADD; LDI;        while
    GETBP; CSTI 0; ADD; LDI; LT;
IFNZRO "L2"; INCSP -1; RET 0]               (i<n)

see file `ex3trace.md`

## 8.3

See files `Absyn.fs`, `CLex.fsl`, `CPar.fsy`, `Comp.fs` & `Contcomp.fs` for implementation of PreInc and PreDec.
See files `8-3.c` for MicroC test code of PreInc and PreDec.
Run file `8-3.sh` to run MicroC test code of PreInc and PreDec.

## 8.4

## 8.5

## 8.6
