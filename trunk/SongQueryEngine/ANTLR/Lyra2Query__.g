lexer grammar Lyra2Query;
options {
  language=CSharp;

}

// $ANTLR src "D:\Documents\Work\Andreas\Lyra2\SongQueryEngine\ANTLR\Lyra2Query.g" 62
OR      : ',' | 'or' | 'OR' | '||' | '-' ;
// $ANTLR src "D:\Documents\Work\Andreas\Lyra2\SongQueryEngine\ANTLR\Lyra2Query.g" 63
AND     : '+' | 'and' | 'AND' | '&&' ;
// $ANTLR src "D:\Documents\Work\Andreas\Lyra2\SongQueryEngine\ANTLR\Lyra2Query.g" 64
LPAREN : '(' ;
// $ANTLR src "D:\Documents\Work\Andreas\Lyra2\SongQueryEngine\ANTLR\Lyra2Query.g" 65
RPAREN : ')' ;

//----------------------------------------------------------------------------------------------------------------
// "WORDS"
//----------------------------------------------------------------------------------------------------------------

// date 
// $ANTLR src "D:\Documents\Work\Andreas\Lyra2\SongQueryEngine\ANTLR\Lyra2Query.g" 72
DATE :  DIGIT ( DIGIT )? DOT DIGIT ( DIGIT )? DOT DIGIT DIGIT ( DIGIT DIGIT )? ;

// numbers
// $ANTLR src "D:\Documents\Work\Andreas\Lyra2\SongQueryEngine\ANTLR\Lyra2Query.g" 75
NUMBER : INT ( DOT ( DIGIT )+ )? ;
// $ANTLR src "D:\Documents\Work\Andreas\Lyra2\SongQueryEngine\ANTLR\Lyra2Query.g" 76
fragment
INT   : ( DIGIT )+ ;

// identifier
// $ANTLR src "D:\Documents\Work\Andreas\Lyra2\SongQueryEngine\ANTLR\Lyra2Query.g" 80
IDENT   : ( LETTER | DIGIT )+ ;

// literal
// $ANTLR src "D:\Documents\Work\Andreas\Lyra2\SongQueryEngine\ANTLR\Lyra2Query.g" 83
LITERAL : ( SINGLE_QUOTE_STRING | DOUBLE_QUOTE_STRING ) { Text = Text.Trim('"'); };

// $ANTLR src "D:\Documents\Work\Andreas\Lyra2\SongQueryEngine\ANTLR\Lyra2Query.g" 85
fragment
SINGLE_QUOTE_STRING : '\'' (~('\''))* '\'' ;
// $ANTLR src "D:\Documents\Work\Andreas\Lyra2\SongQueryEngine\ANTLR\Lyra2Query.g" 87
fragment
DOUBLE_QUOTE_STRING : '"' (~('"'))* '"' ;

//----------------------------------------------------------------------------------------------------------------
// BASICS
//----------------------------------------------------------------------------------------------------------------
// $ANTLR src "D:\Documents\Work\Andreas\Lyra2\SongQueryEngine\ANTLR\Lyra2Query.g" 93
fragment
DOT : '.' ;

// $ANTLR src "D:\Documents\Work\Andreas\Lyra2\SongQueryEngine\ANTLR\Lyra2Query.g" 96
fragment
LETTER // java letters
    :  '\u0024' |
       '\u0041'..'\u005a' |
       '\u005f' |
       '\u0061'..'\u007a' |
       '\u00c0'..'\u00d6' |
       '\u00d8'..'\u00f6' |
       '\u00f8'..'\u00ff' |
       '\u0100'..'\u1fff' |
       '\u3040'..'\u318f' |
       '\u3300'..'\u337f' |
       '\u3400'..'\u3d2d' |
       '\u4e00'..'\u9fff' |
       '\uf900'..'\ufaff' | 
       '.' | '*' | '?'
    ;

// $ANTLR src "D:\Documents\Work\Andreas\Lyra2\SongQueryEngine\ANTLR\Lyra2Query.g" 114
fragment
DIGIT
    :  '0'..'9' ;

// white space
// $ANTLR src "D:\Documents\Work\Andreas\Lyra2\SongQueryEngine\ANTLR\Lyra2Query.g" 119
WS : (' '|'\r'|'\t'|'\u000C'|'\n') { $channel=HIDDEN; };