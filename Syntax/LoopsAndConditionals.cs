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

            if (!_parser.Utilities.CompareTokenType(TokenType.OpenParenthesis))
                throw new Exception("Openning parenthesis expected");
         
            ForOrForEach();
        }

        private void ForOrForEach()
        {
            _parser.Utilities.NextToken();

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

                if (!_parser.Utilities.CompareTokenType(TokenType.Identifier))
                {
                    throw new Exception("Identifier was expected");
                }

                _parser.Utilities.NextToken();

                if (!_parser.Utilities.CompareTokenType(TokenType.Colon))
                {
                    throw new Exception("Colon was expected");
                }

                _parser.Utilities.NextToken();

                if (!_parser.Utilities.CompareTokenType(TokenType.Identifier))
                {
                    throw new Exception("Identifier was expected");
                }

                _parser.Utilities.NextToken();

                if (!_parser.Utilities.CompareTokenType(TokenType.CloseParenthesis))
                {
                    throw new Exception("Closin parenthesis was expected");
                }

                BlockForLoop();
            }
            else
            {
                _parser.Expressions.Expression();

                if (!_parser.Utilities.CompareTokenType(TokenType.EndOfSentence))
                {
                    throw new Exception("Separator ; was expected");
                }
                _parser.Utilities.NextToken();

                _parser.Expressions.Expression();

                if (!_parser.Utilities.CompareTokenType(TokenType.EndOfSentence))
                {
                    throw new Exception("Separator ; was expected");
                }

                _parser.Utilities.NextToken();

                _parser.Expressions.Expression();

                if (!_parser.Utilities.CompareTokenType(TokenType.CloseParenthesis))
                {
                    throw new Exception("Closing parenthesis was expected");
                }

                BlockForLoop();
            }
         
        }
      
        private void BlockForLoop()
        {
            _parser.Utilities.NextToken();

            if (!_parser.Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
                throw new Exception("Openning curly bracket expected"); 

            _parser.Utilities.NextToken();

            _parser.ListOfSpecialSentences();

            if (!_parser.Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
            {
                throw new Exception("Close curly bracket expected");
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
            _parser.Utilities.NextToken();

            if (_parser.Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
            {
                _parser.Utilities.NextToken();

                //Considerar hacer un sentences solo para los ciclos, porque son distintos
                _parser.ListOfSpecialSentences();

                if (!_parser.Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
                {
                    throw new Exception("Close curly bracket");
                }

                _parser.Utilities.NextToken();
            }
            else
            {
                 _parser.Sentence();
            }
           
        }
    }
}