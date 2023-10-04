let rec merge (xs: int list) (ys: int list) : int list =
    match xs, ys with
    | [], [] -> []
    | [], ys -> ys
    | xs, [] -> xs
    | x::xs, y::ys -> if x < y then x::(merge xs (y::ys)) else y::(merge (x::xs) ys)

/* Version that doesn't overflow the stack */
let mergeAux (xs: int list) (ys: int list) : int list =
    let rec aux xs ys acc =
        match xs, ys with
        | [], [] -> acc
        | [], ys -> ys @ acc
        | xs, [] -> xs @ acc
        | x::xs, y::ys -> if x < y then aux xs (y::ys) (x::acc) else aux (x::xs) ys (y::acc)
    aux xs ys []

/* Test code */
/*
let a = [0..1000000]
let b = [0..1000000]

let c = merge a b
*/
