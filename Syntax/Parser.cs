using System;
using System.CodeDom;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Lexer;

namespace Syntax
{
    public class Parser
    {
        private readonly Lexer.Lexer _lexer;

        private Token _currentToken;

        public Parser(Lexer.Lexer lexer)
        {
            _lexer = lexer;
            _currentToken = lexer.GetNextToken();
        }


        public void Parse()
        {
            Ccode();

            if (_currentToken.TokenType != TokenType.EndOfFile)
                throw new Exception("End of file expected");
        }

        private void Ccode()
        {
            ListOfSentences();
        }

        private void ListOfSentences()
        {
            //Lista_Sentencias->Sentence Lista_Sentencias
            if (Enum.IsDefined(typeof(TokenType), _currentToken.TokenType))
           /* if (_currentToken.TokenType == TokenType.Identifier || _currentToken.TokenType == TokenType.RwInclude 
                || _currentToken.TokenType == TokenType.RwIf || _currentToken.TokenType == TokenType.RwWhile
                || _currentToken.TokenType == TokenType.RwDo || _currentToken.TokenType == TokenType.RwFor 
                || _currentToken.TokenType == TokenType.RwSwitch || _currentToken.TokenType == TokenType.RwStruct 
                || _currentToken.TokenType == TokenType.RwConst || _currentToken.TokenType== TokenType.RwBreak
                || _currentToken.TokenType == TokenType.RwContinue)*/
            {
                Console.WriteLine();

                Sentence();
                ListOfSentences();
            }
            //Lista_Sentencia->Epsilon
            else
            {

            }
        }

        private void ListOfSpecialSentences()
        {
            //Lista_Sentencias->Sentence Lista_Sentencias
            if (_currentToken.TokenType == TokenType.Identifier)
            {
                SpecialSentence();
                ListOfSpecialSentences();
            }
            //Lista_Sentencia->Epsilon
            else
            {

            }
        }

        private void SpecialSentence()
        {
            If();
            While();
            Do();
            ChooseForType();
            ChooseIdType();
            Const();
            Switch();
            SpecialDeclaration();
            Break();
            Continue();
            Include();
        }

        private void Sentence()
        {

            if (CompareTokenType(TokenType.RwChar) || CompareTokenType(TokenType.RwString)
                  || CompareTokenType(TokenType.RwInt) || CompareTokenType(TokenType.RwDate)
                  || CompareTokenType(TokenType.RwDouble) || CompareTokenType(TokenType.RwBool)
                  || CompareTokenType(TokenType.RwLong) || CompareTokenType(TokenType.RwVoid))
            {
                Declaration();
            }
            else if (CompareTokenType(TokenType.RwIf))
            {
                If();
            }
            else if (CompareTokenType(TokenType.RwWhile))
            {
                While();
            }
            else if (CompareTokenType(TokenType.RwDo))
            {
                Do();
            }
            else if (CompareTokenType(TokenType.RwFor))
            {
                ChooseForType();
            }
            else if (CompareTokenType(TokenType.RwSwitch))
            {
                Switch();
            }
            else if (CompareTokenType(TokenType.RwStruct))
            {
                Struct();
            }
            else if (CompareTokenType(TokenType.RwConst))
            {
                Const();
            }
            else if (CompareTokenType(TokenType.RwBreak))
            {
                Break();
            }
            else if (CompareTokenType(TokenType.RwContinue))
            {
                Continue();
            }
            else if (CompareTokenType(TokenType.RwInclude))
            {
                Include();
            }
               
            //If();
            //While();
            //Do();
            //ChooseForType();
            //Switch();
            //ChooseIdType();
            //Struct();
            //Const();
            //Break();
            //Continue();
            //Include();
        }

        private bool CompareTokenType(TokenType type)
        {
            if (_currentToken.TokenType == type)
                return true;
            return false;
        }

        private void Include()
        {
            NextToken();

            //Literal strings as a parameter for includes
            if (CompareTokenType(TokenType.LiteralString))
            {
                NextToken();
            }
            else
            {
                throw new Exception("Literal string expected");
            }
        }

        private void NextToken()
        {
            Console.Write(" " + _currentToken.Lexeme + " ");
            _currentToken = _lexer.GetNextToken();
        }

        private void Continue()
        {
            throw new NotImplementedException();
        }

        private void Break()
        {
            throw new NotImplementedException();
        }

        private void Const()
        {
            throw new NotImplementedException();
        }

        private void Struct()
        {
            throw new NotImplementedException();
        }

        private void ChooseIdType()
        {
            if (CompareTokenType(TokenType.OpBitAnd))
            {
               NextToken();

                if (CompareTokenType(TokenType.Identifier))
                {
                   NextToken();
                }
                else
                {
                    throw new Exception("An Identifier was expected");
                }
            }
            else if (CompareTokenType(TokenType.OpMultiplication))
            {
               NextToken();

                IsPointer();

                NextToken();

                if (CompareTokenType(TokenType.Identifier))
                {
                    NextToken();
                }
                else
                {
                    throw new Exception("An Identifier was expected");
                }
            }
            else if (CompareTokenType(TokenType.Identifier))
            {
               NextToken();
            }
            else
            {
                throw new Exception("An Identifier was expected");
            }
        }

        private void Switch()
        {
            throw new NotImplementedException();
        }

        private void ChooseForType()
        {
            throw new NotImplementedException();
        }

        private void Do()
        {
            throw new NotImplementedException();
        }

        private void While()
        {
            throw new NotImplementedException();
        }

        private void If()
        {
            throw new NotImplementedException();
        }

        private void Declaration()
        {
          //  _currentToken = _lexer.GetNextToken();
            GeneralDeclaration();
            TypeOfDeclaration();
        }

        private void TypeOfDeclaration()
        {
            if (CompareTokenType(TokenType.OpEqualTo))
            {
               NextToken();

                ValueForId();
                MultiDeclaration();
            }
            else if (CompareTokenType(TokenType.OpenSquareBracket))
            {
                IsArrayDeclaration();
            }
            else if (CompareTokenType(TokenType.OpenParenthesis))
            {
                IsFunctionDeclaration();
            }
            else if (CompareTokenType(TokenType.EndOfSentence))
            {
              NextToken();
            }
            else
            {
                throw new Exception("An End of sentence ; symbol was expected");
            }
        }

        private void IsFunctionDeclaration()
        {
            if (!CompareTokenType(TokenType.OpenParenthesis))
                throw new Exception("Open parenthesis expected");

            NextToken();

            ParameterList();

            if (!CompareTokenType(TokenType.CloseParenthesis))
                throw new Exception("Close parenthesis expected");

            NextToken();

            if (!CompareTokenType(TokenType.OpenCurlyBracket))
                throw new Exception("Open function body symbol expected");

            ListOfSpecialSentences();

            NextToken();

            if (CompareTokenType(TokenType.CloseCurlyBracket) )
            {
                NextToken();
            }
            else
            {
                throw new Exception("Close function body symbol expected");
            }
        }

        private void ParameterList()
        {
            if (CompareTokenType(TokenType.RwChar) || CompareTokenType(TokenType.RwString)
                || CompareTokenType(TokenType.RwInt) || CompareTokenType(TokenType.RwDate)
                || CompareTokenType(TokenType.RwDouble) || CompareTokenType(TokenType.RwBool)
                || CompareTokenType(TokenType.RwLong))
            {
                NextToken();

                ChooseIdType();

                NextToken();

                OptionaListOfParams();
            }
            else
            {
                
            }
        }

        private void OptionaListOfParams()
        {
            throw new NotImplementedException();
        }

        private void IsArrayDeclaration()
        {
            if (!CompareTokenType(TokenType.OpenSquareBracket))
                throw new Exception("An openning bracket [ symbol was expected");

            NextToken();

            SizeForArray();

            //NextToken();

            if (!CompareTokenType(TokenType.CloseSquareBracket))
                throw new Exception("An closing bracket ] symbol was expected");

            NextToken();

            BidArray();

            NextToken();

            OptionalInitOfArray();

           NextToken();

            if (CompareTokenType(TokenType.EndOfSentence))
            {
                NextToken();
            }
            else
            {
                throw new Exception("An End of sentence ; symbol was expected");
            }
        }

        private void OptionalInitOfArray()
        {
            throw new NotImplementedException();
        }

        private void BidArray()
        {
            if (!CompareTokenType(TokenType.OpenSquareBracket))
                throw new Exception("An openning bracket [ symbol was expected");

            NextToken();

            SizeForBidArray();

            NextToken();

            if (CompareTokenType(TokenType.CloseSquareBracket))
            {
                NextToken();
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
            if (CompareTokenType(TokenType.LiteralNumber) || CompareTokenType(TokenType.LiteralOctal)
                || CompareTokenType(TokenType.LiteralHexadecimal) || CompareTokenType(TokenType.Identifier))
            {
                NextToken();
            }
            else
            {
                
            }
        }

        private void ValueForId()
        {
            if (CompareTokenType(TokenType.OpEqualTo))
            {
                Expresion();
            }
            else
            {
                
            }
        }

        private void MultiDeclaration()
        {
            OptionalId();

            if (CompareTokenType(TokenType.EndOfSentence))
            {
                NextToken();
            }
            else
            {
                throw new Exception("An End of sentence ; symbol was expected");
            }
        }

        private void OptionalId()
        {
            if (CompareTokenType(TokenType.Comma))
            {
                ListOfId();
            }
            else
            {
                
            }
        }

        private void ListOfId()
        {
            if (CompareTokenType(TokenType.Identifier))
            {
                OtherIdOrValue();
            }
            else
            {
                throw new Exception("An Identifier was expected");
            }
        }

        private void OtherIdOrValue()
        {
            ValueForId();
            OptionalId();
        }

        private void GeneralDeclaration()
        {
            if (CompareTokenType(TokenType.RwChar) || CompareTokenType(TokenType.RwString)
                || CompareTokenType(TokenType.RwInt) || CompareTokenType(TokenType.RwDate)
                || CompareTokenType(TokenType.RwDouble) || CompareTokenType(TokenType.RwBool)
                || CompareTokenType(TokenType.RwLong) || CompareTokenType(TokenType.RwVoid))
            {
                NextToken();

                IsPointer();

                if (CompareTokenType(TokenType.Identifier))
                {
                    NextToken();
                }
            }
            else
            {
                throw new Exception("A datatyope was expected");
            }
        }

        private void IsPointer()
        {
            if (CompareTokenType(TokenType.OpMultiplication))
            {
               NextToken();
            }
            if (CompareTokenType(TokenType.OpMultiplication))
            {
                IsPointer();
            }
        }

        private void SpecialDeclaration()
        {
            throw new NotImplementedException();
        }

        private void Expresion()
        {
            Term();
            ExpresionP();
        }

        private void ExpresionP()
        {
            //+term ExpresionP
            if (_currentToken.TokenType == TokenType.OpAdd)
            {
                NextToken();
                Term();
                ExpresionP();
            }
            //-term ExpresionP
            else if (_currentToken.TokenType == TokenType.OpSubstraction)
            {
                NextToken();
                Term();
                ExpresionP();
            }
            // Epsilon
            else
            {

            }
        }

        private void Term()
        {
            Factor();
            TermP();
        }
        private void TermP()
        {
            //*Factor TermP
            if (_currentToken.TokenType == TokenType.OpMultiplication)
            {
                _currentToken = _lexer.GetNextToken();
                Factor();
                TermP();
            }
            // / Factor TermP
            else if (_currentToken.TokenType == TokenType.OpDivision)
            {
                _currentToken = _lexer.GetNextToken();
                Factor();
                TermP();
            }
            // Epsilon
            else
            {

            }
        }

        private void Factor()
        {
            if (_currentToken.TokenType == TokenType.Identifier)
            {
                _currentToken = _lexer.GetNextToken();

            }
            else if (_currentToken.TokenType == TokenType.LiteralNumber)
            {
                _currentToken = _lexer.GetNextToken();

            }
            else if (_currentToken.TokenType == TokenType.OpenParenthesis)
            {
                _currentToken = _lexer.GetNextToken();
                Expresion();
                if (_currentToken.TokenType == TokenType.CloseParenthesis)
                    _currentToken = _lexer.GetNextToken();
                else
                {
                    throw new Exception("Se esperaba )");
                }
            }
            else
            {
                throw new Exception("Se esperaba un Factor");
            }
        }


    }
}
