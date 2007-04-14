@set LYRA=D:\Documents\Work\Andreas\Lyra2
rem @set LYRA=D:\Work\Lyra2
@set PROJPATH=%LYRA%\SongQueryEngine
@set LIB=%LYRA%\lib\ANTLRv3
@set CP=%LIB%\antlr-2.7.7.jar;%LIB%\antlr-3.0b7.jar;%LIB%\stringtemplate-3.0.jar
@set GFILE=%PROJPATH%\ANTLR\Lyra2Query.g
@set OUTDIR=%PROJPATH%\ANTLR
java -cp %CP% org.antlr.Tool -o %OUTDIR% %GFILE%
pause