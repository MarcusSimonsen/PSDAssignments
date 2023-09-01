let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)];;

let emptyenv = []; (* the empty environment *)

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

let cvalue = lookup env "c";;


(* Object language expressions with variables *)

type expr = 
  | CstI of int
  | Var of string
  | Prim of string * expr * expr
  | If of expr * expr * expr


(* Evaluation within an environment *)
let rec eval e (env : (string * int) list) : int = //Edited
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x 
    | Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim("min", e1, e2) -> (if eval e1 env < eval e2 env then eval e1 env else eval e2 env)
    | Prim("max", e1, e2) -> (if eval e1 env > eval e2 env then eval e1 env else eval e2 env)
    | Prim("==", e1, e2) -> (if eval e1 env = eval e2 env then 1 else 0)
    | If(e1, e2, e3) -> (if eval e1 env <> 0 then eval e2 env else eval e3 env)
    | Prim _            -> failwith "unknown primitive"


let rec eval2 e (env : (string * int) list) : int = //Created
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x 
    | Prim(opr, e1, e2) -> 
        let i1 = eval2 e1 env
        let i2 = eval2 e2 env
        match opr with
        | "+" -> i1 + i2
        | "*" -> i1 * i2
        | "-" -> i1 - i2
        | "min" -> (if i1 < i2 then i1 else i2)
        | "max" -> (if i1 > i2 then i1 else i2)
        | "==" -> (if i1 = i2 then 1 else 0)
        | _   -> failwith "unknown primitive"
    | _   -> failwith "unknown type"
    

let eMin1 = Prim("min", CstI 3, CstI 4);;
let eMin2 = Prim("min", CstI 4, CstI 3);;
let eMin3 = Prim("min", Prim("+", CstI 2, CstI 2), CstI 3);;
let eMax1 = Prim("max", CstI 3, CstI 4);;
let eMax2 = Prim("max", CstI 4, CstI 3);;
let eMax3 = Prim("max", Prim("+", CstI 2, CstI 2), CstI 3);;
let eEq1 = Prim("==", CstI 3, CstI 4);;
let eEq2 = Prim("==", CstI 4, CstI 4);;
let eEq3 = Prim("==", Prim("+", CstI 2, CstI 2), CstI 3);;

(* Test Cases for eval for min, max, equal *)
let printInt h = printfn "%A" h
let eMin1v = eval eMin1 env;;
let eMin2v = eval eMin2 env;;
let eMin3v = eval eMin3 env;;
let eMax1v = eval eMax1 env;;
let eMax2v = eval eMax2 env;;
let eMax3v = eval eMax3 env;;
let eEq1v = eval eEq1 env;;
let eEq2v = eval eEq2 env;;
let eEq3v = eval eEq3 env;;


printfn "Test cases for exercise 1.1 i - iii"

printInt eMin1v
printInt eMin2v
printInt eMin3v
printInt eMax1v
printInt eMax2v
printInt eMax3v
printInt eEq1v
printInt eEq2v
printInt eEq3v

(* Test cases for If-then-else *)

printfn "Test cases for exercise 1.1 iv and v"
let eIf1 = If(Var "a", CstI 11, CstI 22);;
let eIf1v = eval eIf1 env;;
printInt eIf1v


(* Arithmetic Expressions *)

type aexpr =
    | CstI of int
    | Var of string
    | Add of aexpr * aexpr
    | Mul of aexpr * aexpr
    | Sub of aexpr * aexpr

let aexpr1 = Sub(Var "v", Add(Var "w", Var "z"))
let aexpr2 = Mul(CstI 2, Sub(Var "v", Add(Var "w", Var "z")))
let aexpr3 = Add(Add(Add(Var "x", Var "y"), Var "z"), Var "v")
let rec fmt : aexpr -> string = function
    | CstI i -> sprintf "%d" i
    | Var x -> x
    | Add(e1, e2) -> sprintf "(%s + %s)" (fmt e1) (fmt e2)
    | Mul(e1, e2) -> sprintf "(%s * %s)" (fmt e1) (fmt e2)
    | Sub(e1, e2) -> sprintf "(%s - %s)" (fmt e1) (fmt e2)

let aexpr1s = fmt aexpr1
let aexpr2s = fmt aexpr2
let aexpr3s = fmt aexpr3

printfn "Test cases for exercise 1.2 i - iii"

printfn "%s" aexpr1s
printfn "%s" aexpr2s
printfn "%s" aexpr3s

(* Simplification of arithmetic expressions *)
let rec simplify: aexpr -> aexpr = function
    | CstI i -> CstI i
    | Var x -> Var x
    | Add(e1, e2) -> 
        let e1v = simplify e1
        let e2v = simplify e2
        match e1v, e2v with
        | CstI x, CstI y when x = 0 || y = 0 -> CstI (x ||| y)
        | CstI x, CstI y -> CstI (x + y)
        | Var x, CstI 0 | CstI 0, Var x -> Var x
        | _ -> Add(e1v, e2v)
    | Sub(e1, e2) ->
        let e1v = simplify e1
        let e2v = simplify e2
        match e1v, e2v with
        | _, CstI 0 -> e1v
        | CstI x, CstI y when x = y -> CstI 0
        | CstI x, CstI y -> CstI (x - y)
        | _ -> Sub(e1v, e2v)
    | Mul(e1, e2) -> 
        let e1v = simplify e1
        let e2v = simplify e2
        match e1v, e2v with
        | CstI x, CstI y when x = 0 || y = 0 -> CstI 0
        | Var _, CstI 0 | CstI 0, Var _ -> CstI 0
        | CstI x, CstI y when x = 1 -> CstI y
        | CstI x, CstI y when y = 1 -> CstI x
        | Var x, CstI 1 | CstI 1, Var x -> Var x
        | CstI x, CstI y -> CstI (x * y)
        | _ -> Mul(e1v, e2v)

let aexprTest1 = Add(CstI 1, Mul(CstI 2, CstI 0))
let aexprTest2= Sub(CstI 4, Sub(CstI 23, CstI 23))
let aexprTest3 = Mul(Add(CstI 1, CstI 0),Add(Var "x", CstI 0))

let aexprTest1s = simplify aexprTest1
let aexprTest2s = simplify aexprTest2
let aexprTest3s = simplify aexprTest3

printfn "Test cases for exercise 1.2 iv"

printfn "%A" aexprTest1s

printfn "%A" aexprTest2s

printfn "%A" aexprTest3s

(* Symbolic differentiation of arithmetic expressions *)
let rec symbDiff (e:aexpr) x : aexpr =
    match e with
    | CstI _ -> CstI 0
    | Var y when x=y -> CstI 1
    | Var _ -> CstI 0
    | Add(e1, e2) -> Add(symbDiff e1 x, symbDiff e2 x)
    | Sub(e1, e2) -> Sub(symbDiff e1 x, symbDiff e2 x)
    | Mul(e1, e2) -> Add(Mul(symbDiff e1 x, e2), Mul(e1, symbDiff e2 x))

let diffTest1 = symbDiff (CstI 1) "x" // 0
let diffTest2 = symbDiff (Var "x") "x" // 1
let diffTest3 = symbDiff (Var "y") "x" // 0
let diffTest4 = symbDiff (Add(Var "x", Var "y")) "x" // 1
let diffTest5 = symbDiff (Add(Var "x", Var "y")) "y" // 1
let diffTest6 = symbDiff (Add(Var "x", Var "x")) "x" // 2
let diffTest7 = symbDiff (Sub(Var "x", Var "y")) "x" // 1
let diffTest8 = symbDiff (Sub(Var "x", Var "y")) "y" // -1
let diffTest9 = symbDiff (Sub(Var "x", Var "x")) "x" // 0
let diffTest10 = symbDiff (Mul(Var "x", Var "y")) "x" // y
let diffTest11 = symbDiff (Mul(Var "x", Var "y")) "y" // x
let diffTest12 = symbDiff (Mul(Var "x", Var "x")) "x" // 2x

printfn "Test cases for exercise 1.2 v"

printfn "%A should be 0" (diffTest1 |> simplify)
printfn "%A should be 1" (diffTest2 |> simplify)
printfn "%A should be 0" (diffTest3 |> simplify)
printfn "%A should be 1" (diffTest4 |> simplify)
printfn "%A should be 1" (diffTest5 |> simplify)
printfn "%A should be 2" (diffTest6 |> simplify)
printfn "%A should be 1" (diffTest7 |> simplify)
printfn "%A should be -1" (diffTest8 |> simplify)
printfn "%A should be 0" (diffTest9 |> simplify)
printfn "%A should be y" (diffTest10 |> simplify)
printfn "%A should be x" (diffTest11 |> simplify)
printfn "%A should be 2x" (diffTest12 |> simplify)



(* Part Two *)

type expr2 = 
  | CstI of int
  | Var of string
  | Let of (string * expr2) list * expr2
  | Prim of string * expr2 * expr2;;


let rec eval3 e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x 
    | Let(xs, ebody) -> eval3 ebody (List.fold (fun acc (x, y) -> (x, eval3 y acc) :: acc) env xs)
    | Prim("+", e1, e2) -> eval3 e1 env + eval3 e2 env
    | Prim("*", e1, e2) -> eval3 e1 env * eval3 e2 env
    | Prim("-", e1, e2) -> eval3 e1 env - eval3 e2 env
    | Prim _            -> failwith "unknown primitive";;

let run e = eval3 e [];;

printfn "Test cases for exercise 2.1"
let exp1 = Let([("x1", Prim("+", CstI 5, CstI 7)); ("x2", Prim("*", Var "x1", CstI 2))], Prim("+", Var "x1", Var "x2"))

let res2 = List.map run [exp1]

List.fold (fun acc x -> printfn "%A" x |> ignore; acc) res2 res2

let rec mem x vs = 
    match vs with
    | []      -> false
    | v :: vr -> x=v || mem x vr;;

let rec union (xs, ys) = 
    match xs with 
    | []    -> ys
    | x::xr -> if mem x ys then union(xr, ys)
               else x :: union(xr, ys);;

let rec minus (xs, ys) = 
    match xs with 
    | []    -> []
    | x::xr -> if mem x ys then minus(xr, ys)
               else x :: minus (xr, ys);;

let rec freevars e : string list =
    match e with
    | CstI _ -> []
    | Var x  -> [x]
    | Let(xs, ebody) -> List.fold (fun _ (x, y) -> union (freevars y, minus (freevars ebody, [x]))) [] xs 
    | Prim(_, e1, e2) -> union (freevars e1, freevars e2);;

printfn "Test cases for exercise 2.2"

printfn "%A" (freevars (Let([("x1", Prim("+", Var "x1", CstI 7))], Prim("+", Var "x1", CstI 8))))

type texpr =                            (* target expressions *)
  | TCstI of int
  | TVar of int                         (* index into runtime environment *)
  | TLet of texpr * texpr               (* erhs and ebody                 *)
  | TPrim of string * texpr * texpr;;

let rec getindex vs x = 
    match vs with 
    | []    -> failwith "Variable not found"
    | y::yr -> if x=y then 0 else 1 + getindex yr x;;

(* Compiling from expr to texpr *)

let rec tcomp (e : expr2) (cenv : string list) : texpr =
    match e with
    | CstI i -> TCstI i
    | Var x  -> TVar (getindex cenv x)
    | Let(xs, ebody) -> 
        let cenv1 = List.fold (fun (acc1,acc2)  (x, y) -> (x :: acc1, y :: acc2)) (cenv, []) xs
        let exp = Let(xs, ebody)
        TLet(tcomp exp cenv, tcomp ebody (fst cenv1))
    | Prim(ope, e1, e2) -> TPrim(ope, tcomp e1 cenv, tcomp e2 cenv);;

let rec teval (e : texpr) (renv : int list) : int =
    match e with
    | TCstI i -> i
    | TVar n  -> List.item n renv
    | TLet(erhs, ebody) -> 
      let xval = teval erhs renv
      let renv1 = xval :: renv 
      teval ebody renv1 
    | TPrim("+", e1, e2) -> teval e1 renv + teval e2 renv
    | TPrim("*", e1, e2) -> teval e1 renv * teval e2 renv
    | TPrim("-", e1, e2) -> teval e1 renv - teval e2 renv
    | TPrim _            -> failwith "unknown primitive";;