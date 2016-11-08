using System;
using Lexer;

namespace Syntax
{
    public class LoopsAndConditionals
    {
        private Parser _parser;

        public LoopsAndConditionals(Parser parser)
        {
            _parser = parser;
        }

        public void Continue()
        {
            _parser.Utilities.NextToken();

            if (_parser.Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
                _parser.Utilities.NextToken();
            }
            else
            {
                throw new Exception("End od sentence expected");
            }
        }

        public void Break()
        {
            _parser.Utilities.NextToken();

            if (_parser.Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
                _parser.Utilities.NextToken();
            }
            else
            {
                throw new Exception("End od sentence expected");
            }
        }

        public void Switch()
        {
            _parser.Utilities.NextToken();

            if (!_parser.Utilities.CompareTokenType(TokenType.OpenParenthesis))
            {
                throw new Exception("Openning parenthesis expected");
            }

            _parser.Expressions.Expression();

            if (!_parser.Utilities.CompareTokenType(TokenType.CloseParenthesis))
            {
                throw new Exception("Closing parenthesis expected");
            }

            _parser.Utilities.NextToken();

            if (!_parser.Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
            {
                throw new Exception("Openning bracket expected");
            }

            ListOfCase();

            if (!_parser.Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
            {
                throw new Exception("Closing bracket expected");
            }

            _parser.Utilities.NextToken();

        }

        private void ListOfCase()
        {
            if (_parser.Utilities.CompareTokenType(TokenType.RwCase))
            {
                Case();

                ListOfCase();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.RwDefault))
            {
                DefaultCase();
            }
            else
            {
                
            }
        }

        private void DefaultCase()
        {
            _parser.Utilities.NextToken();

            if (!_parser.Utilities.CompareTokenType(TokenType.Colon))
                throw new Exception("Colon symbol expected");

            _parser.ListOfSpecialSentences();

            if (_parser.Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
                _parser.Utilities.NextToken();
            }
            else
            {
                throw new Exception("End of sentence expected");
            }
        }

        private void Case()
        {
           _parser.Utilities.NextToken();

            _parser.Expressions.Expression();

            if (!_parser.Utilities.CompareTokenType(TokenType.Colon))
                throw new Exception("Colon symbol expected");

            _parser.Utilities.NextToken();

            _parser.ListOfSpecialSentences();

            Break();

            if (_parser.Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
                _parser.Utilities.NextToken();
            }
            else
            {
                throw new Exception("End of sentence expected");
            }
        }

        public void ForLoop()
        {
            _parser.Utilities.NextToken();

            if (_parser.Utilities.CompareTokenType(TokenType.OpenParenthesis))
            {
                ForOrForEach();
            }
            else
            {
                throw new Exception("Openning parenthesis expected");
            }

        }

        private void ForOrForEach()
        {
            _parser.DataType();

            if (_parser.Utilities.CompareTokenType(TokenType.Identifier))
            {
                _parser.Utilities.NextToken();
            }

            if (_parser.Utilities.CompareTokenType(TokenType.Colon))
            {
                _parser.Utilities.NextToken();
            }

            if (_parser.Utilities.CompareTokenType(TokenType.Identifier))
            {
                _parser.Utilities.NextToken();
            }

            if (_parser.Utilities.CompareTokenType(TokenType.OpenParenthesis))
            {
                _parser.Utilities.NextToken();

                BlockForLoop();
            }

            _parser.Expressions.Expression();

            if (_parser.Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
                _parser.Utilities.NextToken();
            }

            _parser.Expressions.Expression();

            if (_parser.Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
                _parser.Utilities.NextToken();
            }

            _parser.Expressions.Expression();

            if (_parser.Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
                _parser.Utilities.NextToken();
            }

            BlockForLoop();
        }

        private void BlockForLoop()
        {
            if (!_parser.Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
            {
                throw new Exception("Open curly bracket was expected");
            }

            _parser.ListOfSentences();

            if (!_parser.Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
            {
                throw new Exception("Open curly bracket was expected");
            }

            _parser.Utilities.NextToken();
        }

        public void Do()
        {
            _parser.Utilities.NextToken();

            BlockForLoop();

            if (!_parser.Utilities.CompareTokenType(TokenType.RwWhile))
            {
                throw new Exception("While Expected");
            }

            _parser.Utilities.NextToken();

            if (!_parser.Utilities.CompareTokenType(TokenType.OpenParenthesis))
            {
                throw new Exception("Openning parenthesis was expected");
            }

            _parser.Utilities.NextToken();

            _parser.Expressions.Expression();


            if (!_parser.Utilities.CompareTokenType(TokenType.CloseParenthesis))
            {
                throw new Exception("Closing parenthesis was expected");
            }


            if (!_parser.Utilities.CompareTokenType(TokenType.CloseParenthesis))
            {
                throw new Exception("Closing parenthesis was expected");
            }

            _parser.Utilities.NextToken();
        }

        public void While()
        {
            _parser.Utilities.NextToken();

            if (!_parser.Utilities.CompareTokenType(TokenType.OpenParenthesis))
            {
                throw new Exception("Opening parenthesis was expected");
            }

            _parser.Expressions.Expression();

            if (!_parser.Utilities.CompareTokenType(TokenType.CloseParenthesis))
            {
                throw new Exception("Closing parenthesis was expected");
            }


            BlockForLoop();

            _parser.Utilities.NextToken();

        }

        public void If()
        {
            _parser.Utilities.NextToken();

            if (!_parser.Utilities.CompareTokenType(TokenType.OpenParenthesis))
            {
                throw new Exception("Opening parenthesis was expected");
            }
            _parser.Utilities.NextToken();

            _parser.Expressions.Expression();

            _parser.Utilities.NextToken();

            if (!_parser.Utilities.CompareTokenType(TokenType.CloseParenthesis))
            {
                throw new Exception("Closign parenthesis was expected");
            }

            BlockForIf();

            Else();

        }

        private void Else()
        {
            if (_parser.Utilities.CompareTokenType(TokenType.RwElse))
            {
                BlockForIf();
            }
            else
            {
                
            }

        }

        private void BlockForIf()
        {
            if (_parser.Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
            {
                _parser.ListOfSentences();
                //_parser.ListOfSpecialSentences();

                if (!_parser.Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
                {
                    throw new Exception("Close curly bracket");
                }

                _parser.Utilities.NextToken();
            }
            else
            {
                 _parser.Sentence();
                //_parser.SpecialSentence();
            }

            _parser.Utilities.NextToken();
        }
    }
}