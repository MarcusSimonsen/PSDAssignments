(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)

module Intro2

(* Association lists map object language variables to their values *)

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

let e1 = CstI 17;;

let e2 = Prim("+", CstI 3, Var "a");;

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a");;


(* Evaluation within an environment *)
let rec eval e (env : (string * int) list) : int =
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


let rec eval2 e (env : (string * int) list) : int =
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

let e1v  = eval e1 env;;
let e2v1 = eval e2 env;;
let e2v2 = eval e2 [("a", 314)];;
let e3v  = eval e3 env;;

let eMin1 = Prim("min", CstI 3, CstI 4);;
let eMin2 = Prim("min", CstI 4, CstI 3);;
let eMin3 = Prim("min", Prim("+", CstI 2, CstI 2), CstI 3);;
let eMax1 = Prim("max", CstI 3, CstI 4);;
let eMax2 = Prim("max", CstI 4, CstI 3);;
let eMax3 = Prim("max", Prim("+", CstI 2, CstI 2), CstI 3);;
let eEq1 = Prim("==", CstI 3, CstI 4);;
let eEq2 = Prim("==", CstI 4, CstI 4);;
let eEq3 = Prim("==", Prim("+", CstI 2, CstI 2), CstI 3);;


let printInt h = printfn "%A" h

printInt e1v
printInt e2v1
printInt e2v2
printInt e3v

let eMin1v = eval eMin1 env;;
let eMin2v = eval eMin2 env;;
let eMin3v = eval eMin3 env;;
let eMax1v = eval eMax1 env;;
let eMax2v = eval eMax2 env;;
let eMax3v = eval eMax3 env;;
let eEq1v = eval eEq1 env;;
let eEq2v = eval eEq2 env;;
let eEq3v = eval eEq3 env;;

let eIf1 = If(Var "a", CstI 11, CstI 22);;

let eIf1v = eval eIf1 env;;

printInt eMin1v
printInt eMin2v
printInt eMin3v
printInt eMax1v
printInt eMax2v
printInt eMax3v
printInt eEq1v
printInt eEq2v
printInt eEq3v

printInt eIf1v

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

printfn "%s" aexpr1s
printfn "%s" aexpr2s
printfn "%s" aexpr3s

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
        | Var x, CstI 0 | CstI 0, Var x -> CstI 0
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

printfn "%A" aexprTest1s

printfn "%A" aexprTest2s

printfn "%A" aexprTest3s

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