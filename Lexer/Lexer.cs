using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _currentSymbol = sourceCode.GetNextSymbol();
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

            if (char.IsLetter(_currentSymbol.CurrentSymbol))
            {
                lexeme += _currentSymbol.CurrentSymbol;
                tokenColumn = _currentSymbol.Column;
                tokenRow = _currentSymbol.Row;
          
                return GetIdentifier(lexeme,tokenColumn,tokenRow);
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
                _currentSymbol = _sourceCode.GetNextSymbol();

                lexeme = GetLiteralStringOrChar(lexeme, '\'');

                if (lexeme.Length == 1)
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

                return new Token
                {
                    TokenType = TokenType.LiteralString,
                    Lexeme = lexeme,
                    Column = tokenColumn,
                    Row = tokenRow
                };
            }

            //Special one used because of exception when reading code from .c file
            //if (_currentSymbol.CurrentSymbol == '\n')
            //{
            //    return new Token
            //    {
            //        TokenType = TokenType.EndOfSentence,
            //        Lexeme = lexeme,
            //        Column = tokenColumn,
            //        Row = tokenRow
            //    };
            //}

            throw new LexicalException($"Symbol {_currentSymbol.CurrentSymbol} not recognized at Row:{_currentSymbol.Row} Col: {_currentSymbol.Column}");
        }

        private string GetLiteralStringOrChar(string lexeme, char breakSymbol)
        {
            while (_currentSymbol.CurrentSymbol != breakSymbol)
            {
                lexeme += _currentSymbol.CurrentSymbol;
                _currentSymbol = _sourceCode.GetNextSymbol();
            }

            _currentSymbol = _sourceCode.GetNextSymbol();
            return lexeme;
        }

        private Token GetOperator(string lexeme, int tokenColumn, int tokenRow)
        {
            _currentSymbol = _sourceCode.GetNextSymbol();

            if (_reservedWords._specialSymbols.Contains(_currentSymbol.CurrentSymbol))
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

            while (char.IsDigit(_currentSymbol.CurrentSymbol))
            {
                lexeme += _currentSymbol.CurrentSymbol;
                _currentSymbol = _sourceCode.GetNextSymbol();
            }
            
            return new Token
            {
                TokenType = TokenType.LiteralNumber,
                Lexeme = lexeme,
                Column = tokenColumn,
                Row = tokenRow
            };
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
    }
}
