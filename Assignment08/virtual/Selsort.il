    // method line 2
    .method public static hidebysig 
           default void SelectionSort (int32[] arr)  cil managed 
    {
        // Method begins at RVA 0x20b4
	// Code size 57 (0x39)
	.maxstack 4
	.locals init (
		int32	V_0,
		int32	V_1,
		int32	V_2,
		int32	V_3)
	IL_0000:  ldc.i4.0          // Push constant 0 onto stack as int32
	IL_0001:  stloc.0           // Pop value from stack and store in local variable 0 - Local variable 0 is 'i'
	IL_0002:  br.s IL_0032      // Branch to IL_0032

	IL_0004:  ldloc.0           // Push local variable 0 onto stack
	IL_0005:  stloc.1           // Pop value from stack and store in local variable 1 - Local variable 1 is 'least'
	IL_0006:  ldloc.0           // Push local variable 0 onto stack - From here to IL_000a is 'int j = i + 1'
	IL_0007:  ldc.i4.1          // Push constant 1 onto stack as int32
	IL_0008:  add               // Pop top two values from stack, add together and push result to stack
	IL_0009:  stloc.3           // Pop value from stack and store in local variable 3
	IL_000a:  br.s IL_001a      // Branch to IL_001a

	IL_000c:  ldarg.0           // Push argument 0 onto stack - From here to IL_0012 is 'if (arr[j] < arr[least])'
	IL_000d:  ldloc.3           // Push local variable 3 onto stack
	IL_000e:  ldelem.i4         // Load the element with type int32 at index onto the top of the stack as an int32
	IL_000f:  ldarg.0           // Push argument 0 onto stack
	IL_0010:  ldloc.1           // Push local variable 1 onto stack
	IL_0011:  ldelem.i4         // Load the element with type int32 at index onto the top of the stack as an int32
	IL_0012:  bge.s IL_0016     // Branch to IL_0016 if greater than or equal to

	IL_0014:  ldloc.3           // Push local variable 3 onto stack - From here to IL_0015 is 'least = j'
	IL_0015:  stloc.1           // Pop value from stack and store in local variable 1
	IL_0016:  ldloc.3           // Push local variable 3 onto stack - From here to IL_0019 is 'j++'
	IL_0017:  ldc.i4.1          // Push constant 1 onto stack as int32
	IL_0018:  add               // Pop top two values from stack, add together and push result to stack
	IL_0019:  stloc.3           // Pop value from stack and store in local variable 3
	IL_001a:  ldloc.3           // Push local variable 3 onto stack - From here to IL_001e is condition for inner for loop
	IL_001b:  ldarg.0           // Push argument 0 onto stack
	IL_001c:  ldlen             // Push the length of array on stack
	IL_001d:  conv.i4           // Convert to int32 and push to stack
	IL_001e:  blt.s IL_000c     // Branch to IL_000c if less than (compare top two values on stack)

	IL_0020:  ldarg.0           // Push argument 0 onto stack - From here to IL_0023 is 'int tmp = arr[i]'
	IL_0021:  ldloc.0           // Push local variable 0 onto stack
	IL_0022:  ldelem.i4         // Load the element with type int32 at index onto the top of the stack as an int32
	IL_0023:  stloc.2           // Pop value from stack and store in local variable 2
	IL_0024:  ldarg.0           // Push argument 0 onto stack - From here to IL_0029 is 'arr[i] = arr[least]'
	IL_0025:  ldloc.0           // Push local variable 0 onto stack
	IL_0026:  ldarg.0           // Push argument 0 onto stack
	IL_0027:  ldloc.1           // Push local variable 1 onto stack
	IL_0028:  ldelem.i4         // Load the element with type int32 at index onto the top of the stack as an int32
	IL_0029:  stelem.i4         // Replace array element at index with the int32 value on the stack
	IL_002a:  ldarg.0           // Push argument 0 onto stack - From here to IL_002d is 'arr[least] = tmp'
	IL_002b:  ldloc.1           // Push local variable 1 onto stack
	IL_002c:  ldloc.2           // Push local variable 2 onto stack
	IL_002d:  stelem.i4         // Replace array element at index with the int32 value on the stack
	IL_002e:  ldloc.0           // Push local variable 0 onto stack - From here to IL_0031 is 'i++'
	IL_002f:  ldc.i4.1          // Push constant 1 onto stack as int32
	IL_0030:  add               // Pop top two values from stack, add together and push result to stack
	IL_0031:  stloc.0           // Pop value from stack and store in local variable 0
	IL_0032:  ldloc.0           // Push local variable 0 onto stack - From here to IL_0036 is condition for outer for loop
	IL_0033:  ldarg.0           // Push argument 0 onto stack
	IL_0034:  ldlen             // Push the length of array on stack
	IL_0035:  conv.i4           // Convert to int32 and push to stack
	IL_0036:  blt.s IL_0004     // Branch to IL_0004 if less than (compare top two values on stack)

	IL_0038:  ret               // Return
    } // end of method Selsort::SelectionSort
