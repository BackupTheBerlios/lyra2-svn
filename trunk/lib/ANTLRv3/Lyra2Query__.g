lexer grammar Lyra2Query;
options {
  language=CSharp;

}

// $ANTLR src "D:\Work\Lyra2\SongQueryEngine\Lyra2Query.g" 36
OR      : ',' | 'or' | 'OR' | '||' | '-' ;
// $ANTLR src "D:\Work\Lyra2\SongQueryEngine\Lyra2Query.g" 37
AND     : '+' | 'and' | 'AND' | '&&' ;
// $ANTLR src "D:\Work\Lyra2\SongQueryEngine\Lyra2Query.g" 38
LPAREN : '(' ;
// $ANTLR src "D:\Work\Lyra2\SongQueryEngine\Lyra2Query.g" 39
RPAREN : ')' ;

//----------------------------------------------------------------------------------------------------------------
// "WORDS"
//----------------------------------------------------------------------------------------------------------------

// date 
// $ANTLR src "D:\Work\Lyra2\SongQueryEngine\Lyra2Query.g" 46
DATE :  DIGIT ( DIGIT )? DOT DIGIT ( DIGIT )? DOT DIGIT DIGIT ( DIGIT DIGIT )? ;

// numbers
// $ANTLR src "D:\Work\Lyra2\SongQueryEngine\Lyra2Query.g" 49
NUMBER : INT ( DOT ( DIGIT )+ )? ;
// $ANTLR src "D:\Work\Lyra2\SongQueryEngine\Lyra2Query.g" 50
fragment
INT   : ( DIGIT )+ ;

// identifier
// $ANTLR src "D:\Work\Lyra2\SongQueryEngine\Lyra2Query.g" 54
IDENT   : ( LETTER | DIGIT )+ ;

// literal
// $ANTLR src "D:\Work\Lyra2\SongQueryEngine\Lyra2Query.g" 57
LITERAL : ( SINGLE_QUOTE_STRING | DOUBLE_QUOTE_STRING ) { setText(getText().substring(1, getText().length()-1)); };

// $ANTLR src "D:\Work\Lyra2\SongQueryEngine\Lyra2Query.g" 59
fragment
SINGLE_QUOTE_STRING : '\'' (~('\''))* '\'' ;
// $ANTLR src "D:\Work\Lyra2\SongQueryEngine\Lyra2Query.g" 61
fragment
DOUBLE_QUOTE_STRING : '"' (~('"'))* '"' ;

//----------------------------------------------------------------------------------------------------------------
// BASICS
//----------------------------------------------------------------------------------------------------------------
// $ANTLR src "D:\Work\Lyra2\SongQueryEngine\Lyra2Query.g" 67
fragment
DOT : '.' ;

// $ANTLR src "D:\Work\Lyra2\SongQueryEngine\Lyra2Query.g" 70
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

// $ANTLR src "D:\Work\Lyra2\SongQueryEngine\Lyra2Query.g" 88
fragment
DIGIT
    :  '0'..'9' ;

// white space
// $ANTLR src "D:\Work\Lyra2\SongQueryEngine\Lyra2Query.g" 93
WS : (' '|'\r'|'\t'|'\u000C'|'\n') { $channel=HIDDEN; };