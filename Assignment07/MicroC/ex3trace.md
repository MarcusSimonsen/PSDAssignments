```bash
[ ]{0: LDARGS}
[ 4 ]{1: CALL 1 5}                  # Call function 1 at 5
[ 4 -999 4 ]{5: INCSP 1}            # Grow the stack by 1
[ 4 -999 4 0 ]{7: GETBP}            # Get Base Pointer
[ 4 -999 4 0 2 ]{8: CSTI 1}         # Push i to stack
[ 4 -999 4 0 2 1 ]{10: ADD}         # Add
[ 4 -999 4 0 3 ]{11: CSTI 0}        # Push i to stack
[ 4 -999 4 0 3 0 ]{13: STI}         # store indirect
[ 4 -999 4 0 0 ]{14: INCSP -1}      # Shrink stack by one
[ 4 -999 4 0 ]{16: GOTO 43}         # Go to 43
[ 4 -999 4 0 ]{43: GETBP}           # Get Base Pointer 
[ 4 -999 4 0 2 ]{44: CSTI 1}        # Push i to stack
[ 4 -999 4 0 2 1 ]{46: ADD}         # Add
[ 4 -999 4 0 3 ]{47: LDI}
[ 4 -999 4 0 0 ]{48: GETBP}         # Get Base Pointer
[ 4 -999 4 0 0 2 ]{49: CSTI 0}
[ 4 -999 4 0 0 2 0 ]{51: ADD}       # Add
[ 4 -999 4 0 0 2 ]{52: LDI}
[ 4 -999 4 0 0 4 ]{53: LT}
[ 4 -999 4 0 1 ]{54: IFNZRO 18}     # Jump to 18 if not 0
[ 4 -999 4 0 ]{18: GETBP}           # Get Base Pointer
[ 4 -999 4 0 2 ]{19: CSTI 1}        # Push i to stack
[ 4 -999 4 0 2 1 ]{21: ADD}         # Add
[ 4 -999 4 0 3 ]{22: LDI}
[ 4 -999 4 0 0 ]{23: PRINTI}
0 [ 4 -999 4 0 0 ]{24: INCSP -1}    # Shrink the stack by 1
[ 4 -999 4 0 ]{26: GETBP}           # Get Base Pointer
[ 4 -999 4 0 2 ]{27: CSTI 1}        # Push i to stack
[ 4 -999 4 0 2 1 ]{29: ADD}         # Add
[ 4 -999 4 0 3 ]{30: GETBP}         # Get Base Pointer
[ 4 -999 4 0 3 2 ]{31: CSTI 1}      # Push i to stack
[ 4 -999 4 0 3 2 1 ]{33: ADD}       # Add
[ 4 -999 4 0 3 3 ]{34: LDI}
[ 4 -999 4 0 3 0 ]{35: CSTI 1}      # Push i to stack
[ 4 -999 4 0 3 0 1 ]{37: ADD}       # Add
[ 4 -999 4 0 3 1 ]{38: STI}
[ 4 -999 4 1 1 ]{39: INCSP -1}      # Shrink the stack by 1
[ 4 -999 4 1 ]{41: INCSP 0}         # Grow the stack by 1
[ 4 -999 4 1 ]{43: GETBP}           # Get Base Pointer
[ 4 -999 4 1 2 ]{44: CSTI 1}        # Push i to stack
[ 4 -999 4 1 2 1 ]{46: ADD}         # Add
[ 4 -999 4 1 3 ]{47: LDI}
[ 4 -999 4 1 1 ]{48: GETBP}         # Get Base Pointer
[ 4 -999 4 1 1 2 ]{49: CSTI 0}      # Push i to stack
[ 4 -999 4 1 1 2 0 ]{51: ADD}       # Add
[ 4 -999 4 1 1 2 ]{52: LDI}
[ 4 -999 4 1 1 4 ]{53: LT}
[ 4 -999 4 1 1 ]{54: IFNZRO 18}
[ 4 -999 4 1 ]{18: GETBP}           # Get Base Pointer
[ 4 -999 4 1 2 ]{19: CSTI 1}        # Push i to stack
[ 4 -999 4 1 2 1 ]{21: ADD}         # Add
[ 4 -999 4 1 3 ]{22: LDI}
[ 4 -999 4 1 1 ]{23: PRINTI}
1 [ 4 -999 4 1 1 ]{24: INCSP -1}    # Shrink the stack by 1
[ 4 -999 4 1 ]{26: GETBP}           # Get Base Pointer
[ 4 -999 4 1 2 ]{27: CSTI 1}        # Push i to stack
[ 4 -999 4 1 2 1 ]{29: ADD}         # Add
[ 4 -999 4 1 3 ]{30: GETBP}         # Get Base Pointer
[ 4 -999 4 1 3 2 ]{31: CSTI 1}      # Push i to stack
[ 4 -999 4 1 3 2 1 ]{33: ADD}       # Add
[ 4 -999 4 1 3 3 ]{34: LDI}
[ 4 -999 4 1 3 1 ]{35: CSTI 1}      # Push i to stack
[ 4 -999 4 1 3 1 1 ]{37: ADD}       # Add
[ 4 -999 4 1 3 2 ]{38: STI}
[ 4 -999 4 2 2 ]{39: INCSP -1}      # Shrink the stack by 1
[ 4 -999 4 2 ]{41: INCSP 0}         # Grow the stack by 1
[ 4 -999 4 2 ]{43: GETBP}           # Get Base Pointer
[ 4 -999 4 2 2 ]{44: CSTI 1}        # Push i to stack
[ 4 -999 4 2 2 1 ]{46: ADD}         # Add
[ 4 -999 4 2 3 ]{47: LDI}
[ 4 -999 4 2 2 ]{48: GETBP}         # Get Base Pointer
[ 4 -999 4 2 2 2 ]{49: CSTI 0}      # Push i to stack
[ 4 -999 4 2 2 2 0 ]{51: ADD}       # Add
[ 4 -999 4 2 2 2 ]{52: LDI}
[ 4 -999 4 2 2 4 ]{53: LT}
[ 4 -999 4 2 1 ]{54: IFNZRO 18}     # If not 0, jump to 18
[ 4 -999 4 2 ]{18: GETBP}           # Get Base Pointer
[ 4 -999 4 2 2 ]{19: CSTI 1}        # Push i to stack
[ 4 -999 4 2 2 1 ]{21: ADD}         # Add
[ 4 -999 4 2 3 ]{22: LDI}
[ 4 -999 4 2 2 ]{23: PRINTI}
2 [ 4 -999 4 2 2 ]{24: INCSP -1}    # Shrink the stack by 1
[ 4 -999 4 2 ]{26: GETBP}           # Get Base Pointer
[ 4 -999 4 2 2 ]{27: CSTI 1}        # Push i to stack
[ 4 -999 4 2 2 1 ]{29: ADD}         # Add
[ 4 -999 4 2 3 ]{30: GETBP}         # Get Base Pointer
[ 4 -999 4 2 3 2 ]{31: CSTI 1}      # Push i to stack
[ 4 -999 4 2 3 2 1 ]{33: ADD}       # Add
[ 4 -999 4 2 3 3 ]{34: LDI}
[ 4 -999 4 2 3 2 ]{35: CSTI 1}      # Push i to stack
[ 4 -999 4 2 3 2 1 ]{37: ADD}       # Add
[ 4 -999 4 2 3 3 ]{38: STI}
[ 4 -999 4 3 3 ]{39: INCSP -1}      # Shrink the stack by 1
[ 4 -999 4 3 ]{41: INCSP 0}         # Grow the stack by 1
[ 4 -999 4 3 ]{43: GETBP}           # Get Base Pointer
[ 4 -999 4 3 2 ]{44: CSTI 1}        # Push i to stack
[ 4 -999 4 3 2 1 ]{46: ADD}         # Add
[ 4 -999 4 3 3 ]{47: LDI}
[ 4 -999 4 3 3 ]{48: GETBP}         # Get Base Pointer
[ 4 -999 4 3 3 2 ]{49: CSTI 0}      # Push i to stack
[ 4 -999 4 3 3 2 0 ]{51: ADD}       # Add
[ 4 -999 4 3 3 2 ]{52: LDI}
[ 4 -999 4 3 3 4 ]{53: LT}
[ 4 -999 4 3 1 ]{54: IFNZRO 18}
[ 4 -999 4 3 ]{18: GETBP}           # Get Base Pointer
[ 4 -999 4 3 2 ]{19: CSTI 1}        # Push i to stack
[ 4 -999 4 3 2 1 ]{21: ADD}         # Add
[ 4 -999 4 3 3 ]{22: LDI}
[ 4 -999 4 3 3 ]{23: PRINTI}
3 [ 4 -999 4 3 3 ]{24: INCSP -1}    # Shrink the stack by 1
[ 4 -999 4 3 ]{26: GETBP}           # Get Base Pointer
[ 4 -999 4 3 2 ]{27: CSTI 1}        # Push i to stack
[ 4 -999 4 3 2 1 ]{29: ADD}         # Add
[ 4 -999 4 3 3 ]{30: GETBP}         # Get Base Pointer
[ 4 -999 4 3 3 2 ]{31: CSTI 1}      # Push i to stack
[ 4 -999 4 3 3 2 1 ]{33: ADD}       # Add
[ 4 -999 4 3 3 3 ]{34: LDI} 
[ 4 -999 4 3 3 3 ]{35: CSTI 1}      # Push i to stack
[ 4 -999 4 3 3 3 1 ]{37: ADD}       # Add
[ 4 -999 4 3 3 4 ]{38: STI} 
[ 4 -999 4 4 4 ]{39: INCSP -1}      # Shrink the stack by 1
[ 4 -999 4 4 ]{41: INCSP 0}         # Grow the stack by 1
[ 4 -999 4 4 ]{43: GETBP}           # Get Base Pointer
[ 4 -999 4 4 2 ]{44: CSTI 1}        # Push i to stack
[ 4 -999 4 4 2 1 ]{46: ADD}         # Add
[ 4 -999 4 4 3 ]{47: LDI}   
[ 4 -999 4 4 4 ]{48: GETBP}         # Get Base Pointer
[ 4 -999 4 4 4 2 ]{49: CSTI 0}      # Push i to stack
[ 4 -999 4 4 4 2 0 ]{51: ADD}       # Add
[ 4 -999 4 4 4 2 ]{52: LDI} 
[ 4 -999 4 4 4 4 ]{53: LT}  
[ 4 -999 4 4 0 ]{54: IFNZRO 18} 
[ 4 -999 4 4 ]{56: INCSP -1}        # Shrink the stack by 1
[ 4 -999 4 ]{58: RET 0}
[ 4 ]{4: STOP}