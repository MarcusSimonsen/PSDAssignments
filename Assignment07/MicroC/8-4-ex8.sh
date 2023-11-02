echo "open ParseAndComp;; compileToFile (fromFile \"ex8.c\") \"ex8.out\";; #q;; " | dotnet fsi -r FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Comp.fs ParseAndComp.fs
