run (Every(Write(Prim("*", CstI 2, FromTo(1, 4)))))

printf "Exercise 8 (i)\n"

(* Exercise 11.8 (i) *)

run (Every(Write(Prim("+", Prim("*", CstI 2, FromTo(1, 4)), CstI 1))))

printf "\n"

run (Every(Write(Prim("+", Prim("*", CstI 10, FromTo(2, 4)), FromTo(1, 2)))))
