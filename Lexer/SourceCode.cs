using System.Linq.Expressions;

namespace Lexer
{
    public class SourceCode
    {
        private readonly string _sourceCode;
        private int _currentIndex;
        private int _row;
        private int _column;

        public SourceCode(string sourceCode)
        {
            _sourceCode = sourceCode;
            _currentIndex = 0;
            _row = 0;
            _column = 0;
        }

        public Symbol GetNextSymbol()
        {
            if (_currentIndex >= _sourceCode.Length)
                return new Symbol { Row = _row, Column = _column, CurrentSymbol = '\0' };

            Symbol symbol = new Symbol
            {
                Row = _row,
                Column = _column,
                CurrentSymbol = _sourceCode[_currentIndex++]
            };

            if (symbol.CurrentSymbol.Equals('\n'))
            {
                _column = 0;
                _row += 1;
            }
            else
            {
                _column += 1;
            }

            return symbol;
        }
    }
}