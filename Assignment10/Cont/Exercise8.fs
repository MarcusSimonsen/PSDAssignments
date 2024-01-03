run (Every(Write(Prim("*", CstI 2, FromTo(1, 4)))))

(* Exercise 11.8 (i) *)
printf "Exercise 8 (i)\n"

run (Every(Write(Prim("+", Prim("*", CstI 2, FromTo(1, 4)), CstI 1))))

printf "\n"

run (Every(Write(Prim("+", Prim("*", CstI 10, FromTo(2, 4)), FromTo(1, 2)))))

(* Exercise 11.8 (ii) *)
printf "Exercise 8 (ii)\n"

run (Write(Prim("<", CstI 50, Prim("*", CstI 7, FromTo(1, 1000)))))

(* Exercise 11.8 (iii) *)
printf "Exercise 8 (iii)\n"

run (Every(Write(Prim1("sqr", FromTo(3, 6)))))
printf "\n"
run (Every(Write(Prim1("even", FromTo(1, 7)))))
