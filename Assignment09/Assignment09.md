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
More specifically the machine first uses the `allocate(...)` function to attempt
to allocate space in the heap for the cons cell. The reference returned by
`allocate(...)` is saved in a local variable. The top two values are then popped
from the stack and written into the cons cell. Lastly the reference to the cons
cell is set on the stack and the stack pointer is updated by subtracting one
(since two value are popped and one is pushed).

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

A block header is a word of 32 bits where each bit has the following meanings:
`ttttttttnnnnnnnnnnnnnnnnnnnnnngg`
`t` means it is a tag bit, `n` means it is a length bit, and `g` means it is a
garbage collection bit.

#### Length

The `Length` returns all the `n` bits from the header, shifted to the right and
fills all other bits with zeros. I.e. `ttttttttnnnnnnnnnnnnnnnnnnnnnngg` becomes
`0000000000nnnnnnnnnnnnnnnnnnnnnn`. The way this is achieved is by first
bit-shifting the bits two to the right meaning that the header becomes
`00ttttttttnnnnnnnnnnnnnnnnnnnnnn`. Then a bitwise and `&` operation is used
with the fixed value `0x003FFFFF`, so that `00ttttttttnnnnnnnnnnnnnnnnnnnnnn`
becomes `0000000000nnnnnnnnnnnnnnnnnnnnnn`. This makes more sense if we write
the constant in the bit format instead of the hexadecimal format:
`00000000001111111111111111111111`. Here the 22 least significant bits are all
1, thereby meaning that when this is used in the bitwise and operation, the 22
least significant bits from the header is kept as is.

#### Color

The `Color` macro returns the color of the header, i.e. the two least
significant bits from the header (the two `g` bits). This is done by simply
using a bitwise and `&` operation between the header and the constant `3`. The
reason for using the constant 3 becomes apparent when we write the constant 3 in
its bitwise form: `00000000000000000000000000000011`. When doing a bitwise and
operation with this constant and any word `n`, the two least significant bits of
`n` is kept as is and the rest is set to zeros.

#### Paint

The `Paint` macro takes a header and a color and sets the color bits `g` of the
header to the color specified by the color. This is done by first setting the
two color bits in the header to 0 by doing a bitwise and `&` between the header
and the constant `~3`. The `~3` is used to get a constant with all zeros except
the two least significant bits, which are the color bits. Then a bitwise or `|`
is used to get all the header bits except the colors which are set to zero from
the header and the two color bits from the color parameter.
A small note here is that incorrect usage of this macro can lead to problem,
since if the color parsed to this macro has bits other than the two color bits
set to 1, then this will change the other parts of the header.

### (iii)

The `allocate(...)` function is called when the abstract machine executes the
`CONS` instruction. Here it is used to allocate space on the heap for a cons
cell.

### (iv)

The garbage collector's `collect(...)` function is called when the
`allocate(...)` function is called and no large enough space is found.

