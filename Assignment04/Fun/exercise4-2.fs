open ParseAndRun;;

let rec sum =
    function
    | 1 -> 1
    | x -> x + sum (x - 1);;

sum 1000;;

let rec power root =
    function
    | 0 -> 1
    | x -> root * power root (x - 1);;

power 3 8;;

let rec sumpow root =
    function
    | 1 -> 1
    | x -> power root x + sumpow root (x - 1);;

sumpow 3 11;;

let rec powsum pow =
    function
    | 1 -> 1
    | x -> power x pow + powsum pow (x - 1);;

powsum 8 10;;
