using System;
using Lexer;

namespace Syntax
{
    public class Functions
    {
        private Parser _parser;

        public Functions(Parser parser)
        {
            _parser = parser;
        }

        public void IsFunctionDeclaration()
        {
            if (!_parser.Utilities.CompareTokenType(TokenType.OpenParenthesis))
                throw new Exception("Open parenthesis expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);

            _parser.Utilities.NextToken();

            ParameterList();

            if (!_parser.Utilities.CompareTokenType(TokenType.CloseParenthesis))
                throw new Exception("Close parenthesis expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);

            _parser.Utilities.NextToken();

            if (_parser.Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
            {
                _parser.Utilities.NextToken();
                _parser.ListOfSpecialSentences();
            }

            if (_parser.Utilities.CompareTokenType(TokenType.CloseCurlyBracket) )
            {
                _parser.Utilities.NextToken();
            }
            else
            {
                throw new Exception("Close function body symbol expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }
        }

        private void ParameterList()
        {
            if (_parser.Utilities.CompareTokenType(TokenType.RwChar) 
                || _parser.Utilities.CompareTokenType(TokenType.RwString)
                || _parser.Utilities.CompareTokenType(TokenType.RwInt) 
                || _parser.Utilities.CompareTokenType(TokenType.RwDate)
                || _parser.Utilities.CompareTokenType(TokenType.RwDouble) 
                || _parser.Utilities.CompareTokenType(TokenType.RwBool)
                || _parser.Utilities.CompareTokenType(TokenType.RwLong)
                || _parser.Utilities.CompareTokenType(TokenType.RwFloat)
                || _parser.Utilities.CompareTokenType(TokenType.RwVoid))
            {
                _parser.Utilities.NextToken();

                _parser.ChooseIdType();
                
                OptionaListOfParams();
            }
            else
            {
                
            }
        }

        public void OptionaListOfParams()
        {
            if (_parser.Utilities.CompareTokenType(TokenType.Comma))
            {
                _parser.Utilities.NextToken();
                if (_parser.Utilities.CompareTokenType(TokenType.RwChar) 
                    || _parser.Utilities.CompareTokenType(TokenType.RwString)
                    || _parser.Utilities.CompareTokenType(TokenType.RwInt) 
                    || _parser.Utilities.CompareTokenType(TokenType.RwDate)
                    || _parser.Utilities.CompareTokenType(TokenType.RwDouble) 
                    || _parser.Utilities.CompareTokenType(TokenType.RwBool)
                    || _parser.Utilities.CompareTokenType(TokenType.RwLong)
                    ||_parser.Utilities.CompareTokenType(TokenType.RwFloat)
                    ||_parser.Utilities.CompareTokenType(TokenType.RwVoid))
                {
                    _parser.Utilities.NextToken();

                    _parser.ChooseIdType();

                    OptionaListOfParams();
                }
                else
                {
                    
                }
            }
            else
            {
                //throw new Exception("A comma was expected");
            }
         
        }

        public void MultiDeclaration()
        {
            OptionalId();

            if (_parser.Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
                _parser.Utilities.NextToken();
            }
            else
            {
                throw new Exception("An End of sentence ; symbol was expectedat row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }
        }

        public void OptionalId()
        {
            if (_parser.Utilities.CompareTokenType(TokenType.Comma))
            {
                _parser.ListOfId();
            }
            else
            {
                
            }
        }

        public void CallFunction()
        {
            if (!_parser.Utilities.CompareTokenType(TokenType.OpenParenthesis))
            {
                throw new Exception("Open parenthesis ( symbol was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }

            _parser.Utilities.NextToken();

            if (_parser.Utilities.CompareTokenType(TokenType.CloseParenthesis))
            {
                _parser.Utilities.NextToken();
            }
            else
            {
                ListOfExpressions();
            }

        }

        private void ListOfExpressions()
        {
            if (_parser.Utilities.CompareTokenType(TokenType.OpMultiplication))
            {
                _parser.IsPointer();
            }

            _parser.Expressions.Expression();

            if (_parser.Utilities.CompareTokenType(TokenType.Comma))
            {
                _parser.Utilities.NextToken();
                OptionalListOfExpressions();
            }
            else
            {
                _parser.Utilities.NextToken();
            }
           
        }

        private void OptionalListOfExpressions()
        {
            ListOfExpressions();
        }
    }
}