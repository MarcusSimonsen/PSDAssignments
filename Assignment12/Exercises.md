# Assignment 12

## Exercise 13.1

### 1.

The result of running the program is 4.

### 2.

The type of the result value is `Result Int`.

### 3.

The two calls in the first line to f and g are marked as tail calls.
Because these calls are the last thing to happen in the function `f`.

### 4.

Both functions `f` and `g` has types `int->int`.

### 5.

When using the evaluator it takes 10 CPU milli-seconds, whereas with the `msmlmachine` it takes 0 CPU milli-seconds.

### 6.

Compiling with optimizations gives:
```
LABEL G_ExnVar_L2
     0: CSTI 0
     2: CSTI 0
     4: STI
LABEL G_Valdecs_L3
     5: ACLOS 1
     7: ACLOS 1
     9: PUSHLAB LabFunc_f_L4
    11: CSTI 1
    13: LDI
    14: HEAPSTI 1
    16: INCSP -1
    18: PUSHLAB LabFunc_g_L5
    20: CSTI 2
    22: LDI
    23: HEAPSTI 1
    25: INCSP -1
    27: GETSP
    28: CSTI 2
    30: SUB
    31: CALL 0 L1
    34: STI
    35: INCSP -3
    37: STOP
LABEL LabFunc_f_L4
    38: GETBP
    39: CSTI 1
    41: ADD
    42: LDI
    43: CSTI 0
    45: LT
    46: IFZERO L6
    48: CSTI 2
    50: LDI
    51: CSTI 4
    53: TCLOSCALL 1
LABEL L6
    55: GETBP
    56: LDI
    57: GETBP
    58: CSTI 1
    60: ADD
    61: LDI
    62: CSTI 1
    64: SUB
    65: TCLOSCALL 1
LABEL LabFunc_g_L5
    67: GETBP
    68: CSTI 1
    70: ADD
    71: LDI
    72: RET 2
LABEL L1
    74: CSTI 1
    76: LDI
    77: CSTI 2
    79: CLOSCALL 1
    81: PRINTI
    82: RET 0
```
A total of 53 instructions.

Compiling without optimizations gives:
```
LABEL G_ExnVar_L2
     0: CSTI 0
     2: CSTI 0
     4: STI
LABEL G_Valdecs_L3
     5: ACLOS 1
     7: ACLOS 1
     9: PUSHLAB LabFunc_f_L4
    11: CSTI 1
    13: LDI
    14: HEAPSTI 1
    16: INCSP -1
    18: PUSHLAB LabFunc_g_L5
    20: CSTI 2
    22: LDI
    23: HEAPSTI 1
    25: INCSP -1
    27: GETSP
    28: CSTI 2
    30: SUB
    31: CALL 0 L1
    34: STI
    35: INCSP -3
    37: STOP
LABEL LabFunc_f_L4
    38: GETBP
    39: CSTI 1
    41: ADD
    42: LDI
    43: CSTI 0
    45: LT
    46: IFZERO L7
    48: CSTI 2
    50: LDI
    51: CSTI 4
    53: CLOSCALL 1
    55: GOTO L6
LABEL L7
    57: GETBP
    58: CSTI 0
    60: ADD
    61: LDI
    62: GETBP
    63: CSTI 1
    65: ADD
    66: LDI
    67: CSTI 1
    69: SUB
    70: CLOSCALL 1
LABEL L6
    72: RET 2
LABEL LabFunc_g_L5
    74: GETBP
    75: CSTI 1
    77: ADD
    78: LDI
    79: RET 2
LABEL L1
    81: CSTI 1
    83: LDI
    84: CSTI 2
    86: CLOSCALL 1
    88: PRINTI
    89: RET 0
```
A total of 57 instructions.

There is a difference of 4 instructions.

