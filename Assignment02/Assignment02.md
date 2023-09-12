## PLC Exercises

### Exercise 2.4

See file `BPRD-02-FrederikGantriis-MarcusSimonsen.fs` about lines ~375-397 for implementation of this exercise.

### Exercise 2.5

See files `BPRD-02-FrederikGantriis-MarcusSimonsen.fs` & `Machine.java` about lines ~398-403 and ~35-47 for implementation of this exercise. Running the fsharp file will automatically generate the `fname` file used in this exercise.

### Exercise 3.2

```re
a|a?(b+a?)+
```

For NFA see `3-2_NFA`.

| Starting State | move(a)          | move(b)                     | States                           |
| -------------- | ---------------- | --------------------------- | -------------------------------- |
| S0             | {5,6,7,8,<u>15</u>}     | {6,7,8,9,10,11,12,13,14,<u>15</u>} | S0 = {0,1,2,3,4,5,6,7,8}         |
| S1             | {}               | {6,7,8,9,10,11,12,13,14,<u>15</u>} | S1 = {5,6,7,8,<u>15</u>}                |
| S2             | {6,7,8,13,14,<u>15</u>} | {6,7,8,9,10,11,12,13,14,<u>15</u>} | S2 = {6,7,8,9,10,11,12,13,14,<u>15</u>} |
| S3             | {}               | {6,7,8,9,10,11,12,13,14,<u>15</u>} | S3 = {6,7,8,13,14,<u>15</u>}            |

For DFA see `3-2_DFA`.

## BCD Exercises

### Exercise 2.1

### a

```re
0*42
```

### b

```re
(^[0-3]?[0-9]$)|(^4[0-13-9]$)|(^[5-9][0-9]$)|(^[0-9]*[1-9][0-9]*42$)|(^[0-9]*[0-35-9][0-9]$)|(^[0-9]*[0-9][013-9]$)
```

### c

```re
(^4[3-9]$)|(^[5-9][0-9]$)|(^[0-9]*[1-9][0-9]*42$)|(^[0-9]+[1-35-9][0-9]$)|(^[0-9]+[0-9][013-9]$)
```
