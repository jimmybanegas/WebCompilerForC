using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Lexer
{
    public class Lexer
    {
        private SourceCode _sourceCode { get; }
        public Symbol _currentSymbol { get; set; }
        public ReserverdWords _reservedWords { get; set; }      
        
        public Lexer(SourceCode sourceCode)
        {
            _sourceCode = sourceCode;
            _reservedWords = new ReserverdWords();
            _currentSymbol = _sourceCode.GetNextSymbol();           
        }

        public Token GetNextToken()
        {
            var lexeme = string.Empty;
            var tokenRow = 0;
            var tokenColumn = 0;

            while (char.IsWhiteSpace(_currentSymbol.CurrentSymbol))
            {
                _currentSymbol = _sourceCode.GetNextSymbol();
            }

            if (_currentSymbol.CurrentSymbol == '\0')
            {
                return new Token
                {
                    TokenType = TokenType.EndOfFile,
                    Row = tokenRow,
                    Column = tokenColumn
                };
            }

            if (char.IsLetter(_currentSymbol.CurrentSymbol) || _currentSymbol.CurrentSymbol == '_')
            {
                lexeme += _currentSymbol.CurrentSymbol;
                tokenColumn = _currentSymbol.Column;
                tokenRow = _currentSymbol.Row;
          
                return GetIdentifier(lexeme,tokenColumn,tokenRow);
            }

            //For octal and hexadecimal literals
            if(char.IsDigit(_currentSymbol.CurrentSymbol) && (_currentSymbol.CurrentSymbol) == '0')
            {
                lexeme += _currentSymbol.CurrentSymbol;
                tokenColumn = _currentSymbol.Column;
                tokenRow = _currentSymbol.Row;

                _currentSymbol = _sourceCode.GetNextSymbol();

                if (_currentSymbol.CurrentSymbol == 'x')
                {
                    lexeme += _currentSymbol.CurrentSymbol;
                    return GetLiteralHexadecimal(lexeme, tokenColumn, tokenRow);
                }

                if (!char.IsDigit(_currentSymbol.CurrentSymbol))
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
                lexeme += _currentSymbol.CurrentSymbol;
                return GetLiteralOctal(lexeme, tokenColumn, tokenRow);
            }

            if (char.IsDigit(_currentSymbol.CurrentSymbol))
            {
                lexeme += _currentSymbol.CurrentSymbol;
                tokenColumn = _currentSymbol.Column;
                tokenRow = _currentSymbol.Row;

                return GetLiteralNumber(lexeme,tokenColumn,tokenRow);
            }
          
            if (_reservedWords._separators.ContainsKey(_currentSymbol.CurrentSymbol.ToString()))
            {
                lexeme += _currentSymbol.CurrentSymbol;
                tokenColumn = _currentSymbol.Column;
                tokenRow = _currentSymbol.Row;

                return GetSeparator(lexeme, tokenColumn, tokenRow);
            }

            if (_reservedWords._operators.ContainsKey(_currentSymbol.CurrentSymbol.ToString()))
            {
                lexeme += _currentSymbol.CurrentSymbol;
                tokenColumn = _currentSymbol.Column;
                tokenRow = _currentSymbol.Row;
                
                return GetOperator(lexeme, tokenColumn, tokenRow);
            }

            //Get Literals char
            if (_currentSymbol.CurrentSymbol == '\'')
            {
                tokenColumn = _currentSymbol.Column;
                tokenRow = _currentSymbol.Row;
                //lexeme += _currentSymbol.CurrentSymbol;

                _currentSymbol = _sourceCode.GetNextSymbol();

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
            if (_currentSymbol.CurrentSymbol == '"' )
            {
                tokenColumn = _currentSymbol.Column;
                tokenRow = _currentSymbol.Row;
                _currentSymbol = _sourceCode.GetNextSymbol();

                lexeme = GetLiteralStringOrChar(lexeme, '"');

                //Check if the string has escape characters, this is for special strings with a \
                /*like :   cout << "Line 4 - a is either less than \
                                 or euqal to  b" << endl ;*/

                if (lexeme.Contains('\\'+Environment.NewLine))
                {
                    return new Token
                    {
                        TokenType = TokenType.LiteralString,
                        Lexeme = lexeme,
                        Column = tokenColumn,
                        Row = tokenRow
                    };
                }

                //Check if the string has escape characters
                if (!lexeme.Contains(Environment.NewLine))
                {
                    return new Token
                    {
                        TokenType = TokenType.LiteralString,
                        Lexeme = lexeme,
                        Column = tokenColumn,
                        Row = tokenRow
                    };
                }
            }

            //This one is used for #include and for date format #dd-MM-yyyy#
            if (_currentSymbol.CurrentSymbol == '#')
            {
                lexeme += _currentSymbol.CurrentSymbol;

                _currentSymbol = _sourceCode.GetNextSymbol();

                //Fisrt option applies for #include, its a reserved word
                if (char.IsLetter(_currentSymbol.CurrentSymbol) )
                {
                    lexeme += _currentSymbol.CurrentSymbol;
                    tokenColumn = _currentSymbol.Column;
                    tokenRow = _currentSymbol.Row;

                    return GetIdentifier(lexeme, tokenColumn, tokenRow);
                }

                //For dates
                if (char.IsDigit(_currentSymbol.CurrentSymbol))
                {
                    tokenColumn = _currentSymbol.Column;
                    tokenRow = _currentSymbol.Row;
                    lexeme = string.Empty;

                    lexeme = GetLiteralStringOrChar(lexeme,'#');
                }

                DateTime dt;

                bool isValid = DateTime.TryParseExact(lexeme.Replace('#',' '),"dd-MM-yyyy",CultureInfo.InvariantCulture,
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

            throw new LexicalException($"Symbol {_currentSymbol.CurrentSymbol} not recognized at Row:{_currentSymbol.Row} Col: {_currentSymbol.Column}");
        }

        private Token GetLiteralOctal(string lexeme, int tokenColumn, int tokenRow)
        {
            _currentSymbol = _sourceCode.GetNextSymbol();

            if (!char.IsLetter(_currentSymbol.CurrentSymbol))
            {
                //Octal numbers
                while (char.IsDigit(_currentSymbol.CurrentSymbol))
                {
                    lexeme += _currentSymbol.CurrentSymbol;
                    _currentSymbol = _sourceCode.GetNextSymbol();
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

            throw new LexicalException($"Symbol {_currentSymbol.CurrentSymbol} not recognized at Row:{_currentSymbol.Row} Col: {_currentSymbol.Column}");
        }

        private Token GetLiteralHexadecimal(string lexeme, int tokenColumn, int tokenRow)
        {
            _currentSymbol = _sourceCode.GetNextSymbol();

           //Hexadecimal literal
            while (char.IsLetterOrDigit(_currentSymbol.CurrentSymbol))
            {
                lexeme += _currentSymbol.CurrentSymbol;
                _currentSymbol = _sourceCode.GetNextSymbol();
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

            throw new LexicalException($"Symbol {_currentSymbol.CurrentSymbol} not recognized at Row:{_currentSymbol.Row} Col: {_currentSymbol.Column}");
        }

        private Token GetOperator(string lexeme, int tokenColumn, int tokenRow)
        {
            _currentSymbol = _sourceCode.GetNextSymbol();

            if (_reservedWords._specialSymbols.Contains(_currentSymbol.CurrentSymbol.ToString()))
            {
                lexeme += _currentSymbol.CurrentSymbol;
                _currentSymbol = _sourceCode.GetNextSymbol();

                //Special case for comments, we've got to get the line(S) of the comments
                if (lexeme == "//")
                {
                    lexeme = GetLineComment(lexeme);
                }

                //For block comments
                if (lexeme == "/*")
                {
                    lexeme = GetBlockComment(lexeme);
                }

                //special operators like >>= and <<=
                if (_reservedWords._specialSymbols.Contains(lexeme.Substring(0, 2)))
                {
                  //  lexeme += _currentSymbol.CurrentSymbol;
                   // _currentSymbol = _sourceCode.GetNextSymbol();

                    if (_currentSymbol.CurrentSymbol == '=')
                    {
                        lexeme += _currentSymbol.CurrentSymbol;
                        return new Token
                        {
                            TokenType = _reservedWords._operators[lexeme.Substring(0, 3)],
                            Lexeme = lexeme,
                            Column = tokenColumn,
                            Row = tokenRow
                        };
                    }
                }

                return new Token
                {
                    TokenType = _reservedWords._operators[lexeme.Substring(0,2)],
                    Lexeme = lexeme,
                    Column = tokenColumn,
                    Row = tokenRow
                };
            }

            return new Token
            {
                TokenType = _reservedWords._operators[lexeme],
                Lexeme = lexeme,
                Column = tokenColumn,
                Row = tokenRow
            };
        }
        
        private Token GetSeparator(string lexeme, int tokenColumn, int tokenRow)
        {
            _currentSymbol = _sourceCode.GetNextSymbol();

            return new Token
            {
                TokenType = _reservedWords._separators[lexeme],
                Lexeme = lexeme,
                Column = tokenColumn,
                Row = tokenRow
            };
        }

        private Token GetLiteralNumber(string lexeme,int tokenColumn, int tokenRow)
        {
            _currentSymbol = _sourceCode.GetNextSymbol();

            while (char.IsLetterOrDigit(_currentSymbol.CurrentSymbol) || _currentSymbol.CurrentSymbol == '.' 
                || _currentSymbol.CurrentSymbol == 'e' || _currentSymbol.CurrentSymbol == 'E' || _currentSymbol.CurrentSymbol== '-')
            {
                lexeme += _currentSymbol.CurrentSymbol;
                _currentSymbol = _sourceCode.GetNextSymbol();
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

            throw new LexicalException($"Symbol {_currentSymbol.CurrentSymbol} not recognized at Row:{_currentSymbol.Row} Col: {_currentSymbol.Column}");
        }

        private Token GetIdentifier(string lexeme,int tokenColumn, int tokenRow)
        {
            _currentSymbol = _sourceCode.GetNextSymbol();

            while (char.IsLetterOrDigit(_currentSymbol.CurrentSymbol) || _currentSymbol.CurrentSymbol == '_')
            {
                lexeme += _currentSymbol.CurrentSymbol;
                _currentSymbol = _sourceCode.GetNextSymbol();
            }

            if(_reservedWords._keywords.ContainsKey(lexeme)){
                return new Token
                {
                    TokenType = _reservedWords._keywords[lexeme],
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
            while (_currentSymbol.CurrentSymbol != '*')
            {
                lexeme += _currentSymbol.CurrentSymbol;
                _currentSymbol = _sourceCode.GetNextSymbol();
            }

            //Adding the * to the lexeme string
            lexeme += _currentSymbol.CurrentSymbol;

            //Get the char right after the *, to check if it's a / so we can close the comment
            _currentSymbol = _sourceCode.GetNextSymbol();

            if (_currentSymbol.CurrentSymbol == '/')
            {
                lexeme += _currentSymbol.CurrentSymbol;
                _currentSymbol = _sourceCode.GetNextSymbol();
                return lexeme;
            }

            return GetBlockComment(lexeme);
        }

        private string GetLineComment(string lexeme)
        {
            while (_currentSymbol.CurrentSymbol != '\n')
            {
                lexeme += _currentSymbol.CurrentSymbol;
                _currentSymbol = _sourceCode.GetNextSymbol();
            }

            _currentSymbol = _sourceCode.GetNextSymbol();


            return lexeme;
        }

        private string GetLiteralStringOrChar(string lexeme, char breakSymbol)
        {
          while (_currentSymbol.CurrentSymbol != breakSymbol)
            {
                lexeme += _currentSymbol.CurrentSymbol;
                _currentSymbol = _sourceCode.GetNextSymbol();

                if (_currentSymbol.CurrentSymbol == '\\')
                {
                    lexeme += _currentSymbol.CurrentSymbol;
                    lexeme += ConsumeQuotationMark();
                }
            }

            _currentSymbol = _sourceCode.GetNextSymbol();

            if (_currentSymbol.CurrentSymbol == '\r')
            {
                return lexeme;
            }


            return lexeme;
        }

        private string ConsumeQuotationMark()
        {
            string lex = string.Empty;
            _currentSymbol = _sourceCode.GetNextSymbol();

            if (_currentSymbol.CurrentSymbol == '"')
            {
                lex += _currentSymbol.CurrentSymbol;
                _currentSymbol = _sourceCode.GetNextSymbol();
            }
            else
            {
                if (_currentSymbol.CurrentSymbol == '\\')
                {
                    _currentSymbol = _sourceCode.GetNextSymbol();
                    lex += _currentSymbol.CurrentSymbol;
                    _currentSymbol = _sourceCode.GetNextSymbol();
                }
            }

            return lex;
        }
    }
}
