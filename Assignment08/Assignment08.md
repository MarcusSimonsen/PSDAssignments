# Assignment 05

This assignment is completed by the students Frederik Gantriis Møller and Marcus Henrik Simonsen.

## Exercise 9.1

See file `/virtual/Selsort.il` for description and translation of C# bytecode.
See file `/virtual/Selsort.jvmbytecode` for description and translation of Java bytecode.

## Exercise 9.3

The problem exists in the get method of the `SentinelQueue` class.
Here, the references to the "removed" `Node` instances are never actually removed, meaning that
there is a constantly growing amount of unreachable instances of `Node` objects in memory, causing
a memory leak.
By adding the line: `first.next = null;`, we remove the refence to the nodes, thereby making them
eligible for garbage collection.
See file `/QueueWithMistake.java` for the corrected code, which runs to completion.

