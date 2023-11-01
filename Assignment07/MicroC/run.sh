echo "open ParseAndRun;; run (fromFile \"ex1.c\") [17];; run (fromFile \"ex11.c\") [8];;" | dotnet fsi -r FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Interp.fs ParseAndRun.fs
