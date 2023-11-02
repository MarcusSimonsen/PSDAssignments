echo "open ParseAndComp;; fromFile \"$1\";; compileToFile it \"$2\";;" | dotnet fsi -r FsLexYacc.Runtime.dll Absyn.fs CPar.fs CLex.fs Parse.fs Machine.fs Comp.fs ParseAndComp.fs
