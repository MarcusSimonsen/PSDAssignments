let xs = [2; 5; 7]

printf "Exercise 11.1\n"

(* Exercises 11.1 (i) *)
let rec lenc xs cont =
    match xs with
    | [] -> cont 0
    | _ :: xs' -> lenc xs' (fun n -> cont (n + 1))

lenc xs id |> (printf "The answer is '%d'\n")

(* Exercises 11.1 (ii) *)
lenc xs (fun v -> 2 * v) |> (printf "The answer is '%d'\n")


(* Exercises 11.1 (iii) *)
let rec leni xs acc =
    match xs with
    | [] -> acc
    | _ :: xs' -> leni xs' (acc + 1)

leni xs 0 |> (printf "The answer is '%d'\n")


printf "Exercise 11.2\n"

(* Exercises 11.2 (i) *)
let rec revc xs cont =
    match xs with
    | [] -> cont []
    | x :: xs' -> revc xs' (fun xs'' -> cont (xs'' @ [x]))

revc xs id |> (printf "The answer is '%A'\n")

(* Exercises 11.2 (ii) *)
revc xs (fun v -> v @ v) |> (printf "The answer is '%A'\n")

(* Exercises 11.2 (iii) *)
let rec revi xs acc =
    match xs with
    | [] -> acc
    | x :: xs' -> revi xs' (x :: acc)

revi xs [] |> (printf "The answer is '%A'\n")


printf "Exercise 11.3\n"

(* Exercises 11.3 *)
let rec prodc xs cont =
    match xs with
    | [] -> cont 1
    | x :: xs' -> prodc xs' (fun v -> cont (x * v))

prodc xs id |> (printf "The answer is '%d'\n")


printf "Exercise 11.4\n"

(* Exercises 11.4 *)
let rec prodi xs acc =
    match xs with
    | [] -> acc
    | x :: xs' ->
        match x with
        | 0 -> 0
        | x -> prodi xs' (x * acc)

prodi xs 1 |> (printf "The answer is '%d'\n")

let ys = [2; 5; 7; 0; 3]

prodi ys 1 |> (printf "The answer is '%d'\n")
