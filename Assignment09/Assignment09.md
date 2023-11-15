# Assignment 09

This assignment is completed by the students Frederik Gantriis Møller and
Marcus Henrik Simonsen.

## Exercise 10.1

### (i)

For the sake of keeping things brief, the tagging and untagging of values is
assumed implicit and is therefore not specified in the following descriptions.
It is important to note though, that this is specified and used in the C code
implementations of the instructions.

#### ADD

The abstract machine pops two values from the top of the stack, adds them
together and then pushes the result to the stack.
More concretely the `listmachine.c` implementations simply sets the value at the
stackpointer minus one to the result of adding the values at the stackpointer
and the stackpointer minus 1.

#### CSTI i

The abstract machine pushes the value `i` to the stack.
More specifically, the value at the stack pointer plus 1 is set to the value at
the program counter plus one. Both the stack pointer and the program counters
are both increased.

#### NIL

The abstract machine pushes the `NIL` value to the stack.
The value at the stack pointer plus one in the stack is set to the value 0
(untagged, which allows the differentiation between `NIL` and `CSTI 0`). The
stack pointer is increased by one.

#### IFZERO

The abstract machine first pops a value from the stack. If this value is 0, jump
to the value stored in program at the program counter index. If not, just
continue as usual.
More specifically the machine first saves a local variable which is the value
stored in the stack at index stack pointer. Then it decreases the stack pointer.
Afther this it checks whether the value popped is an int or not. This is in
order to determine whether the value needs to be untagged. After this the value
is compared to 0 and if it is, the program counter `pc` is set to `p[pc]` i.e.
the value stored in the program at the program counter. If not, the program
counter `pc` is set to `pc + 1`;

#### CONS

The abstract machine first allocates space in the heap for the cons cell with
space for the two words. Then it pops two values from the stack and puts these
values into the cons cell. After this the reference to the cons cell is pushed
to the stack.
More specifically the machine first uses the `allocate` function to attempt to
allocate space in the heap for the cons cell. The reference returned by allocate
is saved in a local variable. The top two values are then popped from the stack
and written into the cons cell. Lastly the reference to the cons cell is set on
the stack and the stack pointer is updated by subtracting one (since two value
are popped and one is pushed).

#### CAR

The first thing the abstract machine does is pop the top value from the stack
and check that this reference is not pointing to null. If it is, return -1; If
not, then it pushes the value stored in the first word of the cons cell to the
stack.
More specifically, it first reads the value from the stack at the index `sp` and
(stack pointer) and then checks if this reference is 0 with an if statement. If
so, print an error message and return -1. If not, then set the value of the
stack at index `sp` to the value of `p[1]` where `p` is a reference to the first
word of the cons cell. The value of the stack pointer `sp` is unchanged since
one value is popped and one value is pushed.

#### SETCAR

First the abstract machine pop a value from the stack and saves it in a local
variable. This is the value to be set in the cons cell. Second, another value is
popped from the stack, that is the refence to the cons cell. The `CAR` word in
the cons cell is now set to the value of `v`.
More specifically, a local variable is set to the value of the top element in
the stack (pointed to by `sp`) and then the stack pointer is decreased. A second
local variable is then declared as a reference to a word which is again set to
the value of the top element from the stack (the element below the first element
popped). This time the stack pointer isn't decreased. This is so that the
reference to the cons cell is not lost when this instruction is run. Now the CAR
element is set by running `p[1] = v` where `p` is the local variable reference to
the cons cell and `v` is the local variable holding the value to be set in the
cons cell.

### (ii)

