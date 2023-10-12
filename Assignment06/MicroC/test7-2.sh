echo "open ParseAndRun;; run (fromFile \"7-2.c\") [];;" | dotnet fsi -r ~/bin/fsharp/FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Interp.fs ParseAndRun.fs
