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
                throw new Exception("End od sentence expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
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
                throw new Exception("End oF sentence expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }
        }

        public void Switch()
        {
            _parser.Utilities.NextToken();

            if (!_parser.Utilities.CompareTokenType(TokenType.OpenParenthesis))
            {
                throw new Exception("Openning parenthesis expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }
            _parser.Utilities.NextToken();
            _parser.Expressions.Expression();

            if (!_parser.Utilities.CompareTokenType(TokenType.CloseParenthesis))
            {
                throw new Exception("Closing parenthesis expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }

            _parser.Utilities.NextToken();

            if (!_parser.Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
            {
                throw new Exception("Openning bracket expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }

            _parser.Utilities.NextToken();

            ListOfCase();

            if (!_parser.Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
            {
                throw new Exception("Closing bracket expectedat row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
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
           /* else */if (_parser.Utilities.CompareTokenType(TokenType.RwDefault))
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
                throw new Exception("Colon symbol expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);

            _parser.Utilities.NextToken();

            _parser.ListOfSpecialSentences();
        }

        private void Case()
        {
           _parser.Utilities.NextToken();

            _parser.Expressions.Expression();

            if (!_parser.Utilities.CompareTokenType(TokenType.Colon))
                throw new Exception("Colon symbol expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);

            _parser.Utilities.NextToken();

            _parser.ListOfSpecialSentences();

            if (_parser.Utilities.CompareTokenType(TokenType.RwBreak))
            {
                Break();
            }
            else
            {
                
            }
           
        }

        public void ForLoop()
        {
            _parser.Utilities.NextToken();

            if (!_parser.Utilities.CompareTokenType(TokenType.OpenParenthesis))
                throw new Exception("Openning parenthesis expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);

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
                    throw new Exception("Identifier was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
                }

                _parser.Utilities.NextToken();

                if (!_parser.Utilities.CompareTokenType(TokenType.Colon))
                {
                    throw new Exception("Colon was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
                }

                _parser.Utilities.NextToken();

                if (!_parser.Utilities.CompareTokenType(TokenType.Identifier))
                {
                    throw new Exception("Identifier was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
                }

                _parser.Utilities.NextToken();

                if (!_parser.Utilities.CompareTokenType(TokenType.CloseParenthesis))
                {
                    throw new Exception("Closin parenthesis was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
                }

                //BlockForLoop();
                BlockForIf();
            }
            else
            {
                _parser.Expressions.Expression();

                if (!_parser.Utilities.CompareTokenType(TokenType.EndOfSentence))
                {
                    throw new Exception("Separator ; was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
                }
                _parser.Utilities.NextToken();

                _parser.Expressions.Expression();

                if (!_parser.Utilities.CompareTokenType(TokenType.EndOfSentence))
                {
                    throw new Exception("Separator ; was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
                }

                _parser.Utilities.NextToken();

                _parser.Expressions.Expression();

                if (!_parser.Utilities.CompareTokenType(TokenType.CloseParenthesis))
                {
                    throw new Exception("Closing parenthesis was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
                }

               // BlockForLoop();
               BlockForIf();
            }
         
        }
      
        private void BlockForLoop()
        {
            _parser.Utilities.NextToken();

            if (!_parser.Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
                throw new Exception("Openning curly bracket expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);

            _parser.Utilities.NextToken();

            //_parser.ListOfSpecialSentences();
            _parser.ListOfSentences();

            if (!_parser.Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
            {
                throw new Exception("Close curly bracket expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }

            _parser.Utilities.NextToken();
        }

        public void Do()
        {
            //BlockForLoop();
            BlockForIf();

            if (!_parser.Utilities.CompareTokenType(TokenType.RwWhile))
            {
                throw new Exception("While Expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }

            _parser.Utilities.NextToken();

            if (!_parser.Utilities.CompareTokenType(TokenType.OpenParenthesis))
            {
                throw new Exception("Openning parenthesis was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }

            _parser.Utilities.NextToken();

            _parser.Expressions.Expression();


            if (!_parser.Utilities.CompareTokenType(TokenType.CloseParenthesis))
            {
                throw new Exception("Closing parenthesis was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }

            _parser.Utilities.NextToken();

            if (!_parser.Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
                throw new Exception("Closing sentence was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }

            _parser.Utilities.NextToken();
        }

        public void While()
        {
            _parser.Utilities.NextToken();

            if (!_parser.Utilities.CompareTokenType(TokenType.OpenParenthesis))
            {
                throw new Exception("Opening parenthesis was expectedat row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }
            _parser.Utilities.NextToken();

            _parser.Expressions.Expression();

            if (!_parser.Utilities.CompareTokenType(TokenType.CloseParenthesis))
            {
                throw new Exception("Closing parenthesis was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }

            //BlockForLoop();
            BlockForIf();
        }

        public void If()
        {
            _parser.Utilities.NextToken();

            if (!_parser.Utilities.CompareTokenType(TokenType.OpenParenthesis))
            {
                throw new Exception("Opening parenthesis was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }

            _parser.Utilities.NextToken();

            _parser.Expressions.Expression();

            if (!_parser.Utilities.CompareTokenType(TokenType.CloseParenthesis))
            {
                throw new Exception("Closign parenthesis was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
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
                //_parser.ListOfSpecialSentences();
                _parser.ListOfSentences();

                if (!_parser.Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
                {
                    throw new Exception("Close curly bracket at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
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