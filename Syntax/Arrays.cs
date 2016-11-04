using System;
using Lexer;

namespace Syntax
{
    public class Arrays
    {
        private Parser _parser;

        public Arrays(Parser parser)
        {
            _parser = parser;
        }

        public void IsArrayDeclaration()
        {
            if (!_parser.Utilities.CompareTokenType(TokenType.OpenSquareBracket))
                throw new Exception("An openning bracket [ symbol was expected");

            _parser.Utilities.NextToken();

            SizeForArray();

            if (!_parser.Utilities.CompareTokenType(TokenType.CloseSquareBracket))
                throw new Exception("An closing bracket ] symbol was expected");

            _parser.Utilities.NextToken();

            if (_parser.Utilities.CompareTokenType(TokenType.OpenSquareBracket))
            {
                BidArray();
            }
        
            if (_parser.Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
            {
                OptionalInitOfArray();
            }
            
            if (_parser.Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
                _parser.Utilities.NextToken();
            }
            else
            {
                throw new Exception("An End of sentence ; symbol was expected");
            }
        }

        private void OptionalInitOfArray()
        {
            if (!_parser.Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
                throw new Exception("An openning bracket { symbol was expected");

            _parser.ListOfExpressions();

            if (_parser.Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
            {
                _parser.Utilities.NextToken(); 
            }
            else
            {
                
            }
        }

        private void BidArray()
        {
            if (!_parser.Utilities.CompareTokenType(TokenType.OpenSquareBracket))
                throw new Exception("An openning bracket [ symbol was expected");

            _parser.Utilities.NextToken();

            SizeForBidArray();

            _parser.Utilities.NextToken();

            if (_parser.Utilities.CompareTokenType(TokenType.CloseSquareBracket))
            {
                _parser.Utilities.NextToken();
            }
            else
            {
                throw new Exception("An closing bracket ] symbol was expected");
            }
        }

        private void SizeForBidArray()
        {
            throw new NotImplementedException();
        }

        private void SizeForArray()
        {
            if (_parser.Utilities.CompareTokenType(TokenType.LiteralNumber) || _parser.Utilities.CompareTokenType(TokenType.LiteralOctal)
                || _parser.Utilities.CompareTokenType(TokenType.LiteralHexadecimal) || _parser.Utilities.CompareTokenType(TokenType.Identifier))
            {
                _parser.Utilities.NextToken();
            }
            else
            {
                
            }
        }

        public void ArrayIdentifier()
        {
            if (!_parser.Utilities.CompareTokenType(TokenType.OpenSquareBracket))
                throw new Exception("An openning bracket [ symbol was expected");

            _parser.Utilities.NextToken();

            SizeForArray();
        }
    }
}