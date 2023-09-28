let rec merge (xs: int list) (ys: int list) : int list =
    match xs, ys with
    | [], [] -> []
    | [], ys -> ys
    | xs, [] -> xs
    | x::xs, y::ys -> if x < y then x::(merge xs (y::ys)) else y::(merge (x::xs) ys)
