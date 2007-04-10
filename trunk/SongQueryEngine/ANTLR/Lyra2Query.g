grammar Lyra2Query;
options
{
	language=CSharp;
	k=2; backtrack=true; memoize=true;	
}

@header
{
using Lyra2;
}

@namespace		{Lyra2.ANTLR}

//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
// Parser
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

lyraQuery returns [IFilter filter]
@init { $filter = null; } 
   : o=orExpr { $filter = $o.filter; }
   | i=INT { $filter = new KeywordFilter($i.Text, SearchType.NumberQuery); }
   ;

private
orExpr returns [IFilter filter]
   : a1=andExpr { $filter = $a1.filter; } ((OR)? a2=andExpr { $filter = new OrFilter($filter, $a2.filter); } )* ;

private
andExpr returns [IFilter filter]
   : s1=simpleExpr { $filter = $s1.filter; } (AND s2=simpleExpr { $filter = new AndFilter($filter, $s2.filter); } )* ;

private
simpleExpr returns [IFilter filter]
@init { $filter = null; }
   : ( LPAREN o=orExpr { $filter = $o.filter; } RPAREN ) 
   | id=IDENT { $filter = new KeywordFilter($id.Text.Trim(' '), SearchType.All); }
   | lit=LITERAL 
     { 
		string phrase = $lit.Text.Trim(' ');
        if(phrase.IndexOf(' ') == -1)
        {
            // single keyword
            $filter = new KeywordFilter(phrase, SearchType.All);
        }
        else
        {
            // phrase search
			$filter = new PhraseFilter($lit.Text, SearchType.All); 
		}
     }
   ;



//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
// LEXER
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

OR      : ',' | 'or' | 'OR' | '||' | '-' ;
AND     : '+' | 'and' | 'AND' | '&&' ;
LPAREN : '(' ;
RPAREN : ')' ;

//----------------------------------------------------------------------------------------------------------------
// "WORDS"
//----------------------------------------------------------------------------------------------------------------

// date 
DATE :  DIGIT ( DIGIT )? DOT DIGIT ( DIGIT )? DOT DIGIT DIGIT ( DIGIT DIGIT )? ;

// numbers
NUMBER : INT ( DOT ( DIGIT )+ )? ;
fragment
INT   : ( DIGIT )+ ;

// identifier
IDENT   : ( LETTER | DIGIT )+ ;

// literal
LITERAL : ( SINGLE_QUOTE_STRING | DOUBLE_QUOTE_STRING ) { Text = Text.Trim('"'); };

fragment
SINGLE_QUOTE_STRING : '\'' (~('\''))* '\'' ;
fragment
DOUBLE_QUOTE_STRING : '"' (~('"'))* '"' ;

//----------------------------------------------------------------------------------------------------------------
// BASICS
//----------------------------------------------------------------------------------------------------------------
fragment
DOT : '.' ;

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

fragment
DIGIT
    :  '0'..'9' ;

// white space
WS : (' '|'\r'|'\t'|'\u000C'|'\n') { $channel=HIDDEN; };