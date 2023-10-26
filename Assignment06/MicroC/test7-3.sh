echo "open ParseAndRun;; run (fromFile \"7-3.c\") [];;" | dotnet fsi -r FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Interp.fs ParseAndRun.fs
