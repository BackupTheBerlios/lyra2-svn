// $ANTLR 3.0b5 D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g 2007-04-10 18:00:54
namespace Lyra2.ANTLR
{

using Lyra2;


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;

using IDictionary	= System.Collections.IDictionary;
using Hashtable 	= System.Collections.Hashtable;


public class Lyra2QueryParser : Parser 
{
    public static readonly string[] tokenNames = new string[] 
	{
        "<invalid>", 
		"<EOR>", 
		"<DOWN>", 
		"<UP>", 
		"INT", 
		"OR", 
		"AND", 
		"LPAREN", 
		"RPAREN", 
		"IDENT", 
		"LITERAL", 
		"DIGIT", 
		"DOT", 
		"DATE", 
		"NUMBER", 
		"LETTER", 
		"SINGLE_QUOTE_STRING", 
		"DOUBLE_QUOTE_STRING", 
		"WS"
    };

    public const int LETTER = 15;
    public const int AND = 6;
    public const int LITERAL = 10;
    public const int IDENT = 9;
    public const int INT = 4;
    public const int WS = 18;
    public const int NUMBER = 14;
    public const int EOF = -1;
    public const int DATE = 13;
    public const int RPAREN = 8;
    public const int DOUBLE_QUOTE_STRING = 17;
    public const int LPAREN = 7;
    public const int DIGIT = 11;
    public const int SINGLE_QUOTE_STRING = 16;
    public const int OR = 5;
    public const int DOT = 12;
    
    
        public Lyra2QueryParser(ITokenStream input) 
    		: base(input)
    	{
    		InitializeCyclicDFAs();
            ruleMemo = new IDictionary[10+1];
         }
        

    override public string[] TokenNames
	{
		get { return tokenNames; }
	}

    override public string GrammarFileName
	{
		get { return "D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g"; }
	}


    
    // $ANTLR start lyraQuery
    // D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g:20:1: lyraQuery returns [IFilter filter] : ( ( orExpr )=>o= orExpr | i= INT );
    public IFilter lyraQuery() // throws RecognitionException [1]
    {   

        IFilter filter = null;
        int lyraQuery_StartIndex = input.Index();
        IToken i = null;
        IFilter o = null;
        
    
         filter =  null; 
        try 
    	{
    	    if ( (backtracking > 0) && AlreadyParsedRule(input, 1) ) 
    	    {
    	    	return filter; 
    	    }
            // D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g:22:6: ( ( orExpr )=>o= orExpr | i= INT )
            int alt1 = 2;
            int LA1_0 = input.LA(1);
            if ( (LA1_0 == LPAREN || (LA1_0 >= IDENT && LA1_0 <= LITERAL)) )
            {
                alt1 = 1;
            }
            else if ( (LA1_0 == INT) )
            {
                alt1 = 2;
            }
            else 
            {
                if ( backtracking > 0 ) {failed = true; return filter;}
                NoViableAltException nvae_d1s0 =
                    new NoViableAltException("20:1: lyraQuery returns [IFilter filter] : ( ( orExpr )=>o= orExpr | i= INT );", 1, 0, input);
            
                throw nvae_d1s0;
            }
            switch (alt1) 
            {
                case 1 :
                    // D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g:22:6: ( orExpr )=>o= orExpr
                    {
                    	PushFollow(FOLLOW_orExpr_in_lyraQuery70);
                    	o = orExpr();
                    	followingStackPointer_--;
                    	if (failed) return filter;
                    	if ( backtracking == 0 ) 
                    	{
                    	   filter =  o; 
                    	}
                    
                    }
                    break;
                case 2 :
                    // D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g:23:6: i= INT
                    {
                    	i = (IToken)input.LT(1);
                    	Match(input,INT,FOLLOW_INT_in_lyraQuery81); if (failed) return filter;
                    	if ( backtracking == 0 ) 
                    	{
                    	   filter =  new KeywordFilter(i.Text, SearchType.NumberQuery); 
                    	}
                    
                    }
                    break;
            
            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
            if ( backtracking > 0 ) 
            {
            	Memoize(input, 1, lyraQuery_StartIndex); 
            }
        }
        return filter;
    }
    // $ANTLR end lyraQuery

    
    // $ANTLR start orExpr
    // D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g:26:1: private orExpr returns [IFilter filter] : a1= andExpr ( ( ( ( OR )=> OR )? andExpr )=> ( ( OR )=> OR )? a2= andExpr )* ;
    public IFilter orExpr() // throws RecognitionException [1]
    {   

        IFilter filter = null;
        int orExpr_StartIndex = input.Index();
        IFilter a1 = null;

        IFilter a2 = null;
        
    
        try 
    	{
    	    if ( (backtracking > 0) && AlreadyParsedRule(input, 2) ) 
    	    {
    	    	return filter; 
    	    }
            // D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g:28:6: (a1= andExpr ( ( ( ( OR )=> OR )? andExpr )=> ( ( OR )=> OR )? a2= andExpr )* )
            // D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g:28:6: a1= andExpr ( ( ( ( OR )=> OR )? andExpr )=> ( ( OR )=> OR )? a2= andExpr )*
            {
            	PushFollow(FOLLOW_andExpr_in_orExpr106);
            	a1 = andExpr();
            	followingStackPointer_--;
            	if (failed) return filter;
            	if ( backtracking == 0 ) 
            	{
            	   filter =  a1; 
            	}
            	// D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g:28:43: ( ( ( ( OR )=> OR )? andExpr )=> ( ( OR )=> OR )? a2= andExpr )*
            	do 
            	{
            	    int alt3 = 2;
            	    int LA3_0 = input.LA(1);
            	    if ( (LA3_0 == OR || LA3_0 == LPAREN || (LA3_0 >= IDENT && LA3_0 <= LITERAL)) )
            	    {
            	        alt3 = 1;
            	    }
            	    
            	
            	    switch (alt3) 
            		{
            			case 1 :
            			    // D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g:28:44: ( ( ( OR )=> OR )? andExpr )=> ( ( OR )=> OR )? a2= andExpr
            			    {
            			    	// D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g:28:44: ( ( OR )=> OR )?
            			    	int alt2 = 2;
            			    	int LA2_0 = input.LA(1);
            			    	if ( (LA2_0 == OR) )
            			    	{
            			    	    alt2 = 1;
            			    	}
            			    	switch (alt2) 
            			    	{
            			    	    case 1 :
            			    	        // D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g:28:45: ( OR )=> OR
            			    	        {
            			    	        	Match(input,OR,FOLLOW_OR_in_orExpr112); if (failed) return filter;
            			    	        
            			    	        }
            			    	        break;
            			    	
            			    	}

            			    	PushFollow(FOLLOW_andExpr_in_orExpr118);
            			    	a2 = andExpr();
            			    	followingStackPointer_--;
            			    	if (failed) return filter;
            			    	if ( backtracking == 0 ) 
            			    	{
            			    	   filter =  new OrFilter(filter, a2); 
            			    	}
            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop3;
            	    }
            	} while (true);
            	
            	loop3:
            		;	// Stops C# compiler whinging that label 'loop3' has no statements

            
            }
    
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
            if ( backtracking > 0 ) 
            {
            	Memoize(input, 2, orExpr_StartIndex); 
            }
        }
        return filter;
    }
    // $ANTLR end orExpr

    
    // $ANTLR start andExpr
    // D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g:30:1: private andExpr returns [IFilter filter] : s1= simpleExpr ( ( AND simpleExpr )=> AND s2= simpleExpr )* ;
    public IFilter andExpr() // throws RecognitionException [1]
    {   

        IFilter filter = null;
        int andExpr_StartIndex = input.Index();
        IFilter s1 = null;

        IFilter s2 = null;
        
    
        try 
    	{
    	    if ( (backtracking > 0) && AlreadyParsedRule(input, 3) ) 
    	    {
    	    	return filter; 
    	    }
            // D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g:32:6: (s1= simpleExpr ( ( AND simpleExpr )=> AND s2= simpleExpr )* )
            // D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g:32:6: s1= simpleExpr ( ( AND simpleExpr )=> AND s2= simpleExpr )*
            {
            	PushFollow(FOLLOW_simpleExpr_in_andExpr143);
            	s1 = simpleExpr();
            	followingStackPointer_--;
            	if (failed) return filter;
            	if ( backtracking == 0 ) 
            	{
            	   filter =  s1; 
            	}
            	// D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g:32:46: ( ( AND simpleExpr )=> AND s2= simpleExpr )*
            	do 
            	{
            	    int alt4 = 2;
            	    int LA4_0 = input.LA(1);
            	    if ( (LA4_0 == AND) )
            	    {
            	        alt4 = 1;
            	    }
            	    
            	
            	    switch (alt4) 
            		{
            			case 1 :
            			    // D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g:32:47: ( AND simpleExpr )=> AND s2= simpleExpr
            			    {
            			    	Match(input,AND,FOLLOW_AND_in_andExpr148); if (failed) return filter;
            			    	PushFollow(FOLLOW_simpleExpr_in_andExpr152);
            			    	s2 = simpleExpr();
            			    	followingStackPointer_--;
            			    	if (failed) return filter;
            			    	if ( backtracking == 0 ) 
            			    	{
            			    	   filter =  new AndFilter(filter, s2); 
            			    	}
            			    
            			    }
            			    break;
            	
            			default:
            			    goto loop4;
            	    }
            	} while (true);
            	
            	loop4:
            		;	// Stops C# compiler whinging that label 'loop4' has no statements

            
            }
    
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
            if ( backtracking > 0 ) 
            {
            	Memoize(input, 3, andExpr_StartIndex); 
            }
        }
        return filter;
    }
    // $ANTLR end andExpr

    
    // $ANTLR start simpleExpr
    // D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g:34:1: private simpleExpr returns [IFilter filter] : ( ( ( LPAREN orExpr RPAREN ) )=> ( LPAREN o= orExpr RPAREN ) | ( IDENT )=>id= IDENT | lit= LITERAL );
    public IFilter simpleExpr() // throws RecognitionException [1]
    {   

        IFilter filter = null;
        int simpleExpr_StartIndex = input.Index();
        IToken id = null;
        IToken lit = null;
        IFilter o = null;
        
    
         filter =  null; 
        try 
    	{
    	    if ( (backtracking > 0) && AlreadyParsedRule(input, 4) ) 
    	    {
    	    	return filter; 
    	    }
            // D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g:37:6: ( ( ( LPAREN orExpr RPAREN ) )=> ( LPAREN o= orExpr RPAREN ) | ( IDENT )=>id= IDENT | lit= LITERAL )
            int alt5 = 3;
            switch ( input.LA(1) ) 
            {
            case LPAREN:
                alt5 = 1;
                break;
            case IDENT:
                alt5 = 2;
                break;
            case LITERAL:
                alt5 = 3;
                break;
            	default:
            	    if ( backtracking > 0 ) {failed = true; return filter;}
            	    NoViableAltException nvae_d5s0 =
            	        new NoViableAltException("34:1: private simpleExpr returns [IFilter filter] : ( ( ( LPAREN orExpr RPAREN ) )=> ( LPAREN o= orExpr RPAREN ) | ( IDENT )=>id= IDENT | lit= LITERAL );", 5, 0, input);
            
            	    throw nvae_d5s0;
            }
            
            switch (alt5) 
            {
                case 1 :
                    // D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g:37:6: ( ( LPAREN orExpr RPAREN ) )=> ( LPAREN o= orExpr RPAREN )
                    {
                    	// D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g:37:6: ( LPAREN o= orExpr RPAREN )
                    	// D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g:37:8: LPAREN o= orExpr RPAREN
                    	{
                    		Match(input,LPAREN,FOLLOW_LPAREN_in_simpleExpr182); if (failed) return filter;
                    		PushFollow(FOLLOW_orExpr_in_simpleExpr186);
                    		o = orExpr();
                    		followingStackPointer_--;
                    		if (failed) return filter;
                    		if ( backtracking == 0 ) 
                    		{
                    		   filter =  o; 
                    		}
                    		Match(input,RPAREN,FOLLOW_RPAREN_in_simpleExpr190); if (failed) return filter;
                    	
                    	}

                    
                    }
                    break;
                case 2 :
                    // D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g:38:6: ( IDENT )=>id= IDENT
                    {
                    	id = (IToken)input.LT(1);
                    	Match(input,IDENT,FOLLOW_IDENT_in_simpleExpr202); if (failed) return filter;
                    	if ( backtracking == 0 ) 
                    	{
                    	   filter =  new KeywordFilter(id.Text.Trim(' '), SearchType.All); 
                    	}
                    
                    }
                    break;
                case 3 :
                    // D:\\Work\\Lyra2\\SongQueryEngine\\ANTLR\\Lyra2Query.g:39:6: lit= LITERAL
                    {
                    	lit = (IToken)input.LT(1);
                    	Match(input,LITERAL,FOLLOW_LITERAL_in_simpleExpr213); if (failed) return filter;
                    	if ( backtracking == 0 ) 
                    	{
                    	   
                    	  		string phrase = lit.Text.Trim(' ');
                    	          if(phrase.IndexOf(' ') == -1)
                    	          {
                    	              // single keyword
                    	              filter =  new KeywordFilter(phrase, SearchType.All);
                    	          }
                    	          else
                    	          {
                    	              // phrase search
                    	  			filter =  new PhraseFilter(lit.Text, SearchType.All); 
                    	  		}
                    	       
                    	}
                    
                    }
                    break;
            
            }
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
        }
        finally 
    	{
            if ( backtracking > 0 ) 
            {
            	Memoize(input, 4, simpleExpr_StartIndex); 
            }
        }
        return filter;
    }
    // $ANTLR end simpleExpr


	private void InitializeCyclicDFAs()
	{
	}

 

    public static readonly BitSet FOLLOW_orExpr_in_lyraQuery70 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INT_in_lyraQuery81 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_andExpr_in_orExpr106 = new BitSet(new ulong[]{0x00000000000006A2UL});
    public static readonly BitSet FOLLOW_OR_in_orExpr112 = new BitSet(new ulong[]{0x0000000000000680UL});
    public static readonly BitSet FOLLOW_andExpr_in_orExpr118 = new BitSet(new ulong[]{0x00000000000006A2UL});
    public static readonly BitSet FOLLOW_simpleExpr_in_andExpr143 = new BitSet(new ulong[]{0x0000000000000042UL});
    public static readonly BitSet FOLLOW_AND_in_andExpr148 = new BitSet(new ulong[]{0x0000000000000680UL});
    public static readonly BitSet FOLLOW_simpleExpr_in_andExpr152 = new BitSet(new ulong[]{0x0000000000000042UL});
    public static readonly BitSet FOLLOW_LPAREN_in_simpleExpr182 = new BitSet(new ulong[]{0x0000000000000680UL});
    public static readonly BitSet FOLLOW_orExpr_in_simpleExpr186 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_RPAREN_in_simpleExpr190 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IDENT_in_simpleExpr202 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LITERAL_in_simpleExpr213 = new BitSet(new ulong[]{0x0000000000000002UL});

}
}