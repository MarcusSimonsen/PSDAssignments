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









