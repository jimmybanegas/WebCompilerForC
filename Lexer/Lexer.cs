using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexer
{
    public class Lexer
    {
        private SourceCode _sourceCode { get; set; }
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
                return GetNumber(lexeme,tokenColumn,tokenRow);
            }

            if (_reservedWords._operators.ContainsKey(_currentSymbol.CurrentSymbol.ToString()))
            {
               //state = 5;
                tokenColumn = _currentSymbol.Column;
                tokenRow = _currentSymbol.Row;
                lexeme += _currentSymbol.CurrentSymbol;
               // _currentSymbol = Content.nextSymbol();

            }

            throw new LexicalException($"Symbol {_currentSymbol.CurrentSymbol} not recognized at Row:{_currentSymbol.Row} Col: {_currentSymbol.Column}");
        }

        private Token GetNumber(string lexeme,int tokenColumn, int tokenRow)
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

            while (char.IsLetterOrDigit(_currentSymbol.CurrentSymbol))
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
