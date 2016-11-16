using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Lexer
{
    public class Lexer
    {
        private SourceCode SourceCode { get; }
        public Symbol CurrentSymbol { get; set; }
        public ReserverdWords ReservedWords { get; set; }  
      //  private bool CMode { get; set; }  
        private bool HtmlMode { get; set; }
        
        public Lexer(SourceCode sourceCode)
        {
            SourceCode = sourceCode;
            ReservedWords = new ReserverdWords();
            CurrentSymbol = SourceCode.GetNextSymbol();

            HtmlMode = true;
           // CMode = false;
        }

        public Token GetNextToken()
        {
            var lexeme = string.Empty;
            var tokenRow = 0;
            var tokenColumn = 0;

            if (HtmlMode)
            {
               do
                {
                    if (CurrentSymbol.CurrentSymbol == '<')
                    {
                        lexeme += CurrentSymbol.CurrentSymbol;
                        tokenColumn = CurrentSymbol.Column;
                        tokenRow = CurrentSymbol.Row;

                        CurrentSymbol = SourceCode.GetNextSymbol();

                        if (CurrentSymbol.CurrentSymbol == '%')
                        {
                            lexeme += CurrentSymbol.CurrentSymbol;
                            tokenColumn = CurrentSymbol.Column;
                            tokenRow = CurrentSymbol.Row;
                            // CMode = true;
                            HtmlMode = false;
                            CurrentSymbol = SourceCode.GetNextSymbol();
                        }
                    }
                    else
                    {
                        lexeme += CurrentSymbol.CurrentSymbol;
                        tokenColumn = CurrentSymbol.Column;
                        tokenRow = CurrentSymbol.Row;
                        CurrentSymbol = SourceCode.GetNextSymbol();

                        if (CurrentSymbol.CurrentSymbol == '\0')
                        {
                            HtmlMode = false;
                        }
                    }

                }while(HtmlMode);

                return new Token
                {
                    TokenType = TokenType.HTMLContent,
                    Lexeme = lexeme,
                    Row = tokenRow,
                    Column = tokenColumn
                };
            }

            while (char.IsWhiteSpace(CurrentSymbol.CurrentSymbol) )
            {
                CurrentSymbol = SourceCode.GetNextSymbol();
            }
              
            if (CurrentSymbol.CurrentSymbol == '\0')
            {
                return new Token
                {
                    TokenType = TokenType.EndOfFile,
                    Row = tokenRow,
                    Column = tokenColumn
                };
            }

            if (char.IsLetter(CurrentSymbol.CurrentSymbol) || CurrentSymbol.CurrentSymbol == '_')
            {
                lexeme += CurrentSymbol.CurrentSymbol;
                tokenColumn = CurrentSymbol.Column;
                tokenRow = CurrentSymbol.Row;

                return GetIdentifier(lexeme, tokenColumn, tokenRow);
            }

            //For octal and hexadecimal literals
            if (char.IsDigit(CurrentSymbol.CurrentSymbol) && (CurrentSymbol.CurrentSymbol) == '0')
            {
                lexeme += CurrentSymbol.CurrentSymbol;
                tokenColumn = CurrentSymbol.Column;
                tokenRow = CurrentSymbol.Row;

                CurrentSymbol = SourceCode.GetNextSymbol();

                if (CurrentSymbol.CurrentSymbol == 'x')
                {
                    lexeme += CurrentSymbol.CurrentSymbol;
                    return GetLiteralHexadecimal(lexeme, tokenColumn, tokenRow);
                }

                if (!char.IsDigit(CurrentSymbol.CurrentSymbol))
                {
                    //this applies for a single zero
                    if (lexeme.Length == 1 && lexeme == "0")
                    {
                        return new Token
                        {
                            TokenType = TokenType.LiteralNumber,
                            Lexeme = lexeme,
                            Column = tokenColumn,
                            Row = tokenRow
                        };
                    }
                }
                lexeme += CurrentSymbol.CurrentSymbol;
                return GetLiteralOctal(lexeme, tokenColumn, tokenRow);
            }

            if (char.IsDigit(CurrentSymbol.CurrentSymbol))
            {
                lexeme += CurrentSymbol.CurrentSymbol;
                tokenColumn = CurrentSymbol.Column;
                tokenRow = CurrentSymbol.Row;

                return GetLiteralNumber(lexeme, tokenColumn, tokenRow);
            }


            if (ReservedWords._separators.ContainsKey(CurrentSymbol.CurrentSymbol.ToString()))
            {
                lexeme += CurrentSymbol.CurrentSymbol;
                tokenColumn = CurrentSymbol.Column;
                tokenRow = CurrentSymbol.Row;

                return GetSeparator(lexeme, tokenColumn, tokenRow);
            }

            if (ReservedWords._operators.ContainsKey(CurrentSymbol.CurrentSymbol.ToString()))
            {
                lexeme += CurrentSymbol.CurrentSymbol;
                tokenColumn = CurrentSymbol.Column;
                tokenRow = CurrentSymbol.Row;

                return GetOperator(lexeme, tokenColumn, tokenRow);
            }

            //Get Literals char
            if (CurrentSymbol.CurrentSymbol == '\'')
            {
                tokenColumn = CurrentSymbol.Column;
                tokenRow = CurrentSymbol.Row;
                //lexeme += _currentSymbol.CurrentSymbol;

                CurrentSymbol = SourceCode.GetNextSymbol();

                if (CurrentSymbol.CurrentSymbol == '\\')
                {
                    lexeme += CurrentSymbol.CurrentSymbol;
                    CurrentSymbol = SourceCode.GetNextSymbol();
                    lexeme += CurrentSymbol.CurrentSymbol;
                    CurrentSymbol = SourceCode.GetNextSymbol();
                }

                lexeme = GetLiteralStringOrChar(lexeme, '\'');

                if (lexeme.Length == 1 || lexeme.StartsWith('\\'.ToString()))
                {
                    return new Token
                    {
                        TokenType = TokenType.LiteralChar,
                        Lexeme = lexeme,
                        Column = tokenColumn,
                        Row = tokenRow
                    };
                }
            }

            //Literals string
            if (CurrentSymbol.CurrentSymbol == '"')
            {
                tokenColumn = CurrentSymbol.Column;
                tokenRow = CurrentSymbol.Row;
                CurrentSymbol = SourceCode.GetNextSymbol();

                lexeme = GetLiteralStringOrChar(lexeme, '"');


                //Check if the string has escape characters, this is for special strings with a \
                /*like :   cout << "Line 4 - a is either less than \
                                     or euqal to  b" << endl ;*/
                //for a multiline string to be accepted, I split the lexeme into separate lines, it's required
                //for each line except the last to have the character \, if not, it's not a valid multiline string

                string[] lines = lexeme.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

                for (int i = 0; i < lines.Length - 1; i++)
                {

                    if (!lines[i].Contains("\\"))
                    {
                        throw new LexicalException($"Symbol {CurrentSymbol.CurrentSymbol} not recognized at Row:{CurrentSymbol.Row} Col: {CurrentSymbol.Column}");
                    }
                }

                return new Token
                {
                    TokenType = TokenType.LiteralString,
                    Lexeme = lexeme,
                    Column = tokenColumn,
                    Row = tokenRow
                };
            }

            //This one is used for #include and for date format #dd-MM-yyyy#
            if (CurrentSymbol.CurrentSymbol == '#')
            {
                lexeme += CurrentSymbol.CurrentSymbol;

                CurrentSymbol = SourceCode.GetNextSymbol();

                //Fisrt option applies for #include, its a reserved word
                if (char.IsLetter(CurrentSymbol.CurrentSymbol))
                {
                    lexeme += CurrentSymbol.CurrentSymbol;
                    tokenColumn = CurrentSymbol.Column;
                    tokenRow = CurrentSymbol.Row;

                    return GetIdentifier(lexeme, tokenColumn, tokenRow);
                }

                //For dates
                if (char.IsDigit(CurrentSymbol.CurrentSymbol))
                {
                    tokenColumn = CurrentSymbol.Column;
                    tokenRow = CurrentSymbol.Row;
                    lexeme = string.Empty;

                    lexeme = GetLiteralStringOrChar(lexeme, '#');
                }

                DateTime dt;

                bool isValid = DateTime.TryParseExact(lexeme.Replace('#', ' '), "dd-MM-yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out dt);

                if (isValid)
                {
                    return new Token
                    {
                        TokenType = TokenType.LiteralDate,
                        Lexeme = lexeme,
                        Column = tokenColumn,
                        Row = tokenRow
                    };
                }
            }

            throw new LexicalException($"Symbol {CurrentSymbol.CurrentSymbol} not recognized at Row:{CurrentSymbol.Row} Col: {CurrentSymbol.Column}");
        }

        private Token GetLiteralOctal(string lexeme, int tokenColumn, int tokenRow)
        {
            CurrentSymbol = SourceCode.GetNextSymbol();

            if (!char.IsLetter(CurrentSymbol.CurrentSymbol))
            {
                //Octal numbers
                while (char.IsDigit(CurrentSymbol.CurrentSymbol))
                {
                    lexeme += CurrentSymbol.CurrentSymbol;
                    CurrentSymbol = SourceCode.GetNextSymbol();
                }

                if (Regex.IsMatch(lexeme, "^[0-7]+$"))
                {
                    return new Token
                    {
                        TokenType = TokenType.LiteralOctal,
                        Lexeme = lexeme,
                        Column = tokenColumn,
                        Row = tokenRow
                    };
                }
            }

            throw new LexicalException($"Symbol {CurrentSymbol.CurrentSymbol} not recognized at Row:{CurrentSymbol.Row} Col: {CurrentSymbol.Column}");
        }

        private Token GetLiteralHexadecimal(string lexeme, int tokenColumn, int tokenRow)
        {
            CurrentSymbol = SourceCode.GetNextSymbol();

           //Hexadecimal literal
            while (char.IsLetterOrDigit(CurrentSymbol.CurrentSymbol))
            {
                lexeme += CurrentSymbol.CurrentSymbol;
                CurrentSymbol = SourceCode.GetNextSymbol();
            }

            if (Regex.IsMatch(lexeme, @"\A\b(0[xX])?[0-9a-fA-F]+\b\Z"))
            {
                return new Token
                {
                    TokenType = TokenType.LiteralHexadecimal,
                    Lexeme = lexeme,
                    Column = tokenColumn,
                    Row = tokenRow
                };
            }

            throw new LexicalException($"Symbol {CurrentSymbol.CurrentSymbol} not recognized at Row:{CurrentSymbol.Row} Col: {CurrentSymbol.Column}");
        }

        private Token GetOperator(string lexeme, int tokenColumn, int tokenRow)
        {
            CurrentSymbol = SourceCode.GetNextSymbol();

            if (ReservedWords._specialSymbols.Contains(CurrentSymbol.CurrentSymbol.ToString()) && 
                !(lexeme.Equals(">") && CurrentSymbol.CurrentSymbol=='/') &&
                  !(lexeme.Equals("*") && CurrentSymbol.CurrentSymbol == '*'))
            {
                lexeme += CurrentSymbol.CurrentSymbol;
                CurrentSymbol = SourceCode.GetNextSymbol();

                if (lexeme == "%>")
                {
                   // CMode = false;
                    HtmlMode = true;
                    CurrentSymbol = SourceCode.GetNextSymbol();
                    return new Token
                    {
                        TokenType = ReservedWords._operators[lexeme.Substring(0, 2)],
                        Lexeme = lexeme,
                        Column = tokenColumn,
                        Row = tokenRow
                    };

                }

                //Special case for comments, we've got to get the line(S) of the comments
                if (lexeme == "//")
                {
                    string str = string.Empty;
                    GetLineComment(str);
                    return GetNextToken();
                }

                //For block comments
                if (lexeme == "/*")
                {
                    string str = string.Empty;
                    GetBlockComment(str);
                    return GetNextToken();
                }

                //special operators like >>= and <<=
                if (ReservedWords._specialSymbols.Contains(lexeme.Substring(0, 2)))
                {
                    if (CurrentSymbol.CurrentSymbol == '=')
                    {
                        lexeme += CurrentSymbol.CurrentSymbol;

                        if (lexeme == ">>=" || lexeme== "<<=")
                        {
                            CurrentSymbol = SourceCode.GetNextSymbol();
                        }

                        return new Token
                        {
                            TokenType = ReservedWords._operators[lexeme.Substring(0, 3)],
                            Lexeme = lexeme,
                            Column = tokenColumn,
                            Row = tokenRow
                        };
                    }
                }

                return new Token
                {
                    TokenType = ReservedWords._operators[lexeme.Substring(0,2)],
                    Lexeme = lexeme,
                    Column = tokenColumn,
                    Row = tokenRow
                };
            }

            return new Token
            {
                TokenType = ReservedWords._operators[lexeme],
                Lexeme = lexeme,
                Column = tokenColumn,
                Row = tokenRow
            };
        }
        
        private Token GetSeparator(string lexeme, int tokenColumn, int tokenRow)
        {
            CurrentSymbol = SourceCode.GetNextSymbol();

            return new Token
            {
                TokenType = ReservedWords._separators[lexeme],
                Lexeme = lexeme,
                Column = tokenColumn,
                Row = tokenRow
            };
        }

        private Token GetLiteralNumber(string lexeme,int tokenColumn, int tokenRow)
        {
            CurrentSymbol = SourceCode.GetNextSymbol();

            //case score=(float)countr/countq*100-difftime(finaltime,initialtime)/3;
            //  if (lexeme.Contains("e") || lexeme.Contains("E"))

            while (char.IsLetterOrDigit(CurrentSymbol.CurrentSymbol) || CurrentSymbol.CurrentSymbol == '.'
               || CurrentSymbol.CurrentSymbol == 'e' || CurrentSymbol.CurrentSymbol == 'E' || CurrentSymbol.CurrentSymbol == '-')
                {
                    if (!lexeme.Contains("e") && !lexeme.Contains("E") && CurrentSymbol.CurrentSymbol == '-')
                    {
                        break;
                    }

                     lexeme += CurrentSymbol.CurrentSymbol;
                    CurrentSymbol = SourceCode.GetNextSymbol();
            }

            if (Regex.IsMatch(lexeme, @"^[0-9]*(?:\.[0-9]*)?$") )
            {
                if (lexeme.Contains("."))
                {
                    return new Token
                    {
                        TokenType = TokenType.LiteralDecimal,
                        Lexeme = lexeme,
                        Column = tokenColumn,
                        Row = tokenRow
                    };
                }

                return new Token
                {
                    TokenType = TokenType.LiteralNumber,
                    Lexeme = lexeme,
                    Column = tokenColumn,
                    Row = tokenRow
                };
            }

            //Floating point numbers
            if (Regex.IsMatch(lexeme, @"^[-]?(0|[1-9][0-9]*)(\.[0-9]+)?([eE][+-]?[0-9]+)?$"))
            {
                return new Token
                {
                    TokenType = TokenType.LiteralFloat,
                    Lexeme = lexeme,
                    Column = tokenColumn,
                    Row = tokenRow
                };
            }

            throw new LexicalException($"Symbol {CurrentSymbol.CurrentSymbol} not recognized at Row:{CurrentSymbol.Row} Col: {CurrentSymbol.Column}");
        }

        private Token GetIdentifier(string lexeme,int tokenColumn, int tokenRow)
        {
            CurrentSymbol = SourceCode.GetNextSymbol();

            while (char.IsLetterOrDigit(CurrentSymbol.CurrentSymbol) || CurrentSymbol.CurrentSymbol == '_')
            {
                lexeme += CurrentSymbol.CurrentSymbol;
                CurrentSymbol = SourceCode.GetNextSymbol();
            }

            if(ReservedWords._keywords.ContainsKey(lexeme)){
                return new Token
                {
                    TokenType = ReservedWords._keywords[lexeme],
                    Lexeme = lexeme,
                    Column = tokenColumn,
                    Row = tokenRow
                };
            }

            return new Token
            {
                TokenType = TokenType.Identifier,
                Lexeme = lexeme,
                Column = tokenColumn,
                Row = tokenRow
            };
        }

        private string GetBlockComment(string lexeme)
        {
            while (CurrentSymbol.CurrentSymbol != '*')
            {
                lexeme += CurrentSymbol.CurrentSymbol;
                CurrentSymbol = SourceCode.GetNextSymbol();
            }

            //Adding the * to the lexeme string
            lexeme += CurrentSymbol.CurrentSymbol;

            //Get the char right after the *, to check if it's a / so we can close the comment
            CurrentSymbol = SourceCode.GetNextSymbol();

            if (CurrentSymbol.CurrentSymbol == '/')
            {
                lexeme += CurrentSymbol.CurrentSymbol;
                CurrentSymbol = SourceCode.GetNextSymbol();
                return lexeme;
            }

            return GetBlockComment(lexeme);
        }

        private void GetLineComment(string lexeme)
        {
            while (CurrentSymbol.CurrentSymbol != '\n')
            {
                lexeme += CurrentSymbol.CurrentSymbol;
                CurrentSymbol = SourceCode.GetNextSymbol();
            }

            CurrentSymbol = SourceCode.GetNextSymbol();
        }

        private string GetLiteralStringOrChar(string lexeme, char breakSymbol)
        {
            while (CurrentSymbol.CurrentSymbol != breakSymbol)
            {
                lexeme += CurrentSymbol.CurrentSymbol;
                CurrentSymbol = SourceCode.GetNextSymbol();

                if (CurrentSymbol.CurrentSymbol == '\\')
                {
                    lexeme += CurrentSymbol.CurrentSymbol;
                    lexeme += ConsumeQuotationMark();
                }
            }

            CurrentSymbol = SourceCode.GetNextSymbol();

            if (CurrentSymbol.CurrentSymbol == '\r')
            {
                CurrentSymbol = SourceCode.GetNextSymbol();

                while (char.IsWhiteSpace(CurrentSymbol.CurrentSymbol))
                {
                    CurrentSymbol = SourceCode.GetNextSymbol();
                }

                if (CurrentSymbol.CurrentSymbol == '"')
                {
                    CurrentSymbol = SourceCode.GetNextSymbol();

                    return GetLiteralStringOrChar(lexeme, '"');
                }
            }
            
            return lexeme;
        }

        private string ConsumeQuotationMark()
        {
            string lex = string.Empty;
            CurrentSymbol = SourceCode.GetNextSymbol();

            if (CurrentSymbol.CurrentSymbol == '"')
            {
                lex += CurrentSymbol.CurrentSymbol;
                CurrentSymbol = SourceCode.GetNextSymbol();
            }
            else
            {
                if (CurrentSymbol.CurrentSymbol == '\\')
                {
                    CurrentSymbol = SourceCode.GetNextSymbol();
                    lex += CurrentSymbol.CurrentSymbol;
                    CurrentSymbol = SourceCode.GetNextSymbol();
                }
            }

            return lex;
        }
    }
}
