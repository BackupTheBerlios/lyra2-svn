@set CP=D:\Work\Lyra2\SongQueryEngine\ANTLR\antlr-2.7.7.jar;D:\Work\Lyra2\SongQueryEngine\ANTLR\antlr-3.0b5.jar;D:\Work\Lyra2\SongQueryEngine\ANTLR\stringtemplate-3.0.jar
@set GFILE=D:\Work\Lyra2\SongQueryEngine\ANTLR\Lyra2Query.g
@set OUTDIR=D:\Work\Lyra2\SongQueryEngine\ANTLR
java -cp %CP% org.antlr.Tool -o %OUTDIR% %GFILE%
pause