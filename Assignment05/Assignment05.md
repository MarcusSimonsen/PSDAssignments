# Assignment 05

This assignment is completed by the students Frederik Gantriis Møller and Marcus Henrik Simonsen.

## Exercise 5.1

See `Assignment05.fs` and `Exercises.java`.

## Exercise 5.7

See `TypedFun/TypedFun.fs`.

## Exercise 6.1

### Is the result of the third one as expected?

Yes, since the inner binding of x to 77 is never used and therefore is never passed to any function.

### Explain the result of the last one

Since `y` isn't bound to any value, it cannot compute a final value and a function is therefore returned instead of a value.

## Exercise 6.2

See files `Fun/Absyn.fs` and `Fun/HigherFun.fs`.

## Exercise 6.3

See files `Fun/FunPar.fsy` and `Fun/FunLex.fsl`.

## Exercise 6.4

### (i)

See file `6-4_i.jpg`.

### (ii)

See file `6-4_ii.jpg`.

## Exercise 6.5

### (1)

```
let f x = 1
in f f end
```
Type: `int`

```
let f g = g g
in f end
```
Type error: circularity

```
let f x =
    let g y = y
    in g false end
in f 42 end
```
Type: bool

```
let f x =
    let g y = if true then y else x
    in g false end
in f 42 end
```
Type error: bool and int

```
let f x =
    let g y = if true then y else x
    in g false end
in f true end
```
Type: bool

### (2)

#### bool -> bool

```
let f x = if x then true else false
in f end
```

#### int -> int

```
let f x = x + 1
in f end
```

#### int -> int -> int

```
let f x =
    let g y = x + y
    in g end
in f end
```

#### 'a -> 'b -> 'a

```
let f x =
    let g y = x
    in g end
in f end
```

#### 'a -> 'b -> 'b

```
let f x =
    let g y = y
    in g end
in f end
```

#### ('a -> 'b) -> ('b -> 'c) -> ('a -> 'c)

```
let f x =
    let g y =
        let h z = y (x z)
        in h end
    in g end
in f end
```

#### 'a -> 'b

```
```


#### 'a

```
```

