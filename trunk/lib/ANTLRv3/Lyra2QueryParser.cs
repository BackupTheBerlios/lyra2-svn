// $ANTLR 3.0b5 D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g 2007-04-10 16:47:52

namespace Lyra2;


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
		get { return "D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g"; }
	}


    
    // $ANTLR start lyraQuery
    // D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g:18:1: lyraQuery : ( ( orExpr )=> orExpr | INT );
    public void lyraQuery() // throws RecognitionException [1]
    {   
        int lyraQuery_StartIndex = input.Index();
        try 
    	{
    	    if ( (backtracking > 0) && AlreadyParsedRule(input, 1) ) 
    	    {
    	    	return ; 
    	    }
            // D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g:18:13: ( ( orExpr )=> orExpr | INT )
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
                if ( backtracking > 0 ) {failed = true; return ;}
                NoViableAltException nvae_d1s0 =
                    new NoViableAltException("18:1: lyraQuery : ( ( orExpr )=> orExpr | INT );", 1, 0, input);
            
                throw nvae_d1s0;
            }
            switch (alt1) 
            {
                case 1 :
                    // D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g:18:13: ( orExpr )=> orExpr
                    {
                    	PushFollow(FOLLOW_orExpr_in_lyraQuery48);
                    	orExpr();
                    	followingStackPointer_--;
                    	if (failed) return ;
                    
                    }
                    break;
                case 2 :
                    // D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g:18:22: INT
                    {
                    	Match(input,INT,FOLLOW_INT_in_lyraQuery52); if (failed) return ;
                    
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
        return ;
    }
    // $ANTLR end lyraQuery

    
    // $ANTLR start orExpr
    // D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g:20:1: private orExpr : andExpr ( ( ( ( OR )=> OR )? andExpr )=> ( ( OR )=> OR )? andExpr )* ;
    public void orExpr() // throws RecognitionException [1]
    {   
        int orExpr_StartIndex = input.Index();
        try 
    	{
    	    if ( (backtracking > 0) && AlreadyParsedRule(input, 2) ) 
    	    {
    	    	return ; 
    	    }
            // D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g:21:10: ( andExpr ( ( ( ( OR )=> OR )? andExpr )=> ( ( OR )=> OR )? andExpr )* )
            // D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g:21:10: andExpr ( ( ( ( OR )=> OR )? andExpr )=> ( ( OR )=> OR )? andExpr )*
            {
            	PushFollow(FOLLOW_andExpr_in_orExpr63);
            	andExpr();
            	followingStackPointer_--;
            	if (failed) return ;
            	// D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g:21:18: ( ( ( ( OR )=> OR )? andExpr )=> ( ( OR )=> OR )? andExpr )*
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
            			    // D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g:21:19: ( ( ( OR )=> OR )? andExpr )=> ( ( OR )=> OR )? andExpr
            			    {
            			    	// D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g:21:19: ( ( OR )=> OR )?
            			    	int alt2 = 2;
            			    	int LA2_0 = input.LA(1);
            			    	if ( (LA2_0 == OR) )
            			    	{
            			    	    alt2 = 1;
            			    	}
            			    	switch (alt2) 
            			    	{
            			    	    case 1 :
            			    	        // D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g:21:20: ( OR )=> OR
            			    	        {
            			    	        	Match(input,OR,FOLLOW_OR_in_orExpr67); if (failed) return ;
            			    	        
            			    	        }
            			    	        break;
            			    	
            			    	}

            			    	PushFollow(FOLLOW_andExpr_in_orExpr71);
            			    	andExpr();
            			    	followingStackPointer_--;
            			    	if (failed) return ;
            			    
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
        return ;
    }
    // $ANTLR end orExpr

    
    // $ANTLR start andExpr
    // D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g:23:1: private andExpr : simpleExpr ( ( AND simpleExpr )=> AND simpleExpr )* ;
    public void andExpr() // throws RecognitionException [1]
    {   
        int andExpr_StartIndex = input.Index();
        try 
    	{
    	    if ( (backtracking > 0) && AlreadyParsedRule(input, 3) ) 
    	    {
    	    	return ; 
    	    }
            // D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g:24:11: ( simpleExpr ( ( AND simpleExpr )=> AND simpleExpr )* )
            // D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g:24:11: simpleExpr ( ( AND simpleExpr )=> AND simpleExpr )*
            {
            	PushFollow(FOLLOW_simpleExpr_in_andExpr84);
            	simpleExpr();
            	followingStackPointer_--;
            	if (failed) return ;
            	// D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g:24:22: ( ( AND simpleExpr )=> AND simpleExpr )*
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
            			    // D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g:24:23: ( AND simpleExpr )=> AND simpleExpr
            			    {
            			    	Match(input,AND,FOLLOW_AND_in_andExpr87); if (failed) return ;
            			    	PushFollow(FOLLOW_simpleExpr_in_andExpr89);
            			    	simpleExpr();
            			    	followingStackPointer_--;
            			    	if (failed) return ;
            			    
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
        return ;
    }
    // $ANTLR end andExpr

    
    // $ANTLR start simpleExpr
    // D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g:26:1: private simpleExpr : ( ( ( LPAREN orExpr RPAREN ) )=> ( LPAREN orExpr RPAREN ) | ( IDENT )=> IDENT | LITERAL );
    public void simpleExpr() // throws RecognitionException [1]
    {   
        int simpleExpr_StartIndex = input.Index();
        try 
    	{
    	    if ( (backtracking > 0) && AlreadyParsedRule(input, 4) ) 
    	    {
    	    	return ; 
    	    }
            // D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g:27:14: ( ( ( LPAREN orExpr RPAREN ) )=> ( LPAREN orExpr RPAREN ) | ( IDENT )=> IDENT | LITERAL )
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
            	    if ( backtracking > 0 ) {failed = true; return ;}
            	    NoViableAltException nvae_d5s0 =
            	        new NoViableAltException("26:1: private simpleExpr : ( ( ( LPAREN orExpr RPAREN ) )=> ( LPAREN orExpr RPAREN ) | ( IDENT )=> IDENT | LITERAL );", 5, 0, input);
            
            	    throw nvae_d5s0;
            }
            
            switch (alt5) 
            {
                case 1 :
                    // D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g:27:14: ( ( LPAREN orExpr RPAREN ) )=> ( LPAREN orExpr RPAREN )
                    {
                    	// D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g:27:14: ( LPAREN orExpr RPAREN )
                    	// D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g:27:16: LPAREN orExpr RPAREN
                    	{
                    		Match(input,LPAREN,FOLLOW_LPAREN_in_simpleExpr104); if (failed) return ;
                    		PushFollow(FOLLOW_orExpr_in_simpleExpr106);
                    		orExpr();
                    		followingStackPointer_--;
                    		if (failed) return ;
                    		Match(input,RPAREN,FOLLOW_RPAREN_in_simpleExpr108); if (failed) return ;
                    	
                    	}

                    
                    }
                    break;
                case 2 :
                    // D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g:27:41: ( IDENT )=> IDENT
                    {
                    	Match(input,IDENT,FOLLOW_IDENT_in_simpleExpr114); if (failed) return ;
                    
                    }
                    break;
                case 3 :
                    // D:\\Work\\Lyra2\\SongQueryEngine\\Lyra2Query.g:27:49: LITERAL
                    {
                    	Match(input,LITERAL,FOLLOW_LITERAL_in_simpleExpr118); if (failed) return ;
                    
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
        return ;
    }
    // $ANTLR end simpleExpr


	private void InitializeCyclicDFAs()
	{
	}

 

    public static readonly BitSet FOLLOW_orExpr_in_lyraQuery48 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_INT_in_lyraQuery52 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_andExpr_in_orExpr63 = new BitSet(new ulong[]{0x00000000000006A2UL});
    public static readonly BitSet FOLLOW_OR_in_orExpr67 = new BitSet(new ulong[]{0x0000000000000680UL});
    public static readonly BitSet FOLLOW_andExpr_in_orExpr71 = new BitSet(new ulong[]{0x00000000000006A2UL});
    public static readonly BitSet FOLLOW_simpleExpr_in_andExpr84 = new BitSet(new ulong[]{0x0000000000000042UL});
    public static readonly BitSet FOLLOW_AND_in_andExpr87 = new BitSet(new ulong[]{0x0000000000000680UL});
    public static readonly BitSet FOLLOW_simpleExpr_in_andExpr89 = new BitSet(new ulong[]{0x0000000000000042UL});
    public static readonly BitSet FOLLOW_LPAREN_in_simpleExpr104 = new BitSet(new ulong[]{0x0000000000000680UL});
    public static readonly BitSet FOLLOW_orExpr_in_simpleExpr106 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_RPAREN_in_simpleExpr108 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_IDENT_in_simpleExpr114 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LITERAL_in_simpleExpr118 = new BitSet(new ulong[]{0x0000000000000002UL});

}
