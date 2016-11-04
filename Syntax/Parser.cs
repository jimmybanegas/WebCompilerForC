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
        public readonly Lexer.Lexer _lexer;

        public Token _currentToken;
        private readonly Arrays _arrays;
        private readonly LoopsAndConditionals _loopsAndConditionals;
        private readonly Utilities _utilities;
        private readonly Functions _functions;
        private readonly Expressions _expressions;

        public Parser(Lexer.Lexer lexer)
        {
            _lexer = lexer;
            _currentToken = lexer.GetNextToken();
            _arrays = new Arrays(this);
            _loopsAndConditionals = new LoopsAndConditionals();
            _utilities = new Utilities(this);
            _functions = new Functions(this);
            _expressions = new Expressions(this);
        }

        public Utilities Utilities
        {
            get { return _utilities; }
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

        public void ListOfSpecialSentences()
        {
            //Lista_Sentencias->Sentence Lista_Sentencias
            while (!Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
            {
                SpecialSentence();
                ListOfSpecialSentences();
            }
         
        }

        private void SpecialSentence()
        {
            //_loopsAndConditionals.If(); --
            //_loopsAndConditionals.While(); --
            //_loopsAndConditionals.Do(); --
            //_loopsAndConditionals.ChooseForType(); --
            //ChooseIdType();
            //Const(); -- 
            //_loopsAndConditionals.Switch(); --
            //SpecialDeclaration(); --
            //_loopsAndConditionals.Break(); --
            //_loopsAndConditionals.Continue(); --
            //Include(); --

            if (Utilities.CompareTokenType(TokenType.RwChar) || Utilities.CompareTokenType(TokenType.RwString)
                 || Utilities.CompareTokenType(TokenType.RwInt) || Utilities.CompareTokenType(TokenType.RwDate)
                 || Utilities.CompareTokenType(TokenType.RwDouble) || Utilities.CompareTokenType(TokenType.RwBool)
                 || Utilities.CompareTokenType(TokenType.RwLong))
            {
                SpecialDeclaration();
            }
            else if (Utilities.CompareTokenType(TokenType.RwIf))
            {
                _loopsAndConditionals.If();
            }
            else if (Utilities.CompareTokenType(TokenType.RwWhile))
            {
                _loopsAndConditionals.While();
            }
            else if (Utilities.CompareTokenType(TokenType.RwDo))
            {
                _loopsAndConditionals.Do();
            }
            else if (Utilities.CompareTokenType(TokenType.RwFor))
            {
                _loopsAndConditionals.ChooseForType();
            }
            else if (Utilities.CompareTokenType(TokenType.RwSwitch))
            {
                _loopsAndConditionals.Switch();
            }
            else if (Utilities.CompareTokenType(TokenType.RwBreak))
            {
                _loopsAndConditionals.Break();
            }
            else if (Utilities.CompareTokenType(TokenType.RwContinue))
            {
                _loopsAndConditionals.Continue();
            }
            else if (Utilities.CompareTokenType(TokenType.RwConst))
            {
                Const();
            }
            else if (Utilities.CompareTokenType(TokenType.RwInclude))
            {
                Include();
            }
        }

        private void Sentence()
        {
            if (Utilities.CompareTokenType(TokenType.RwChar) || Utilities.CompareTokenType(TokenType.RwString)
                  || Utilities.CompareTokenType(TokenType.RwInt) || Utilities.CompareTokenType(TokenType.RwDate)
                  || Utilities.CompareTokenType(TokenType.RwDouble) || Utilities.CompareTokenType(TokenType.RwBool)
                  || Utilities.CompareTokenType(TokenType.RwLong) || Utilities.CompareTokenType(TokenType.RwVoid))
            {
                Declaration();
            }
            else if (Utilities.CompareTokenType(TokenType.RwIf))
            {
                _loopsAndConditionals.If();
            }
            else if (Utilities.CompareTokenType(TokenType.RwWhile))
            {
                _loopsAndConditionals.While();
            }
            else if (Utilities.CompareTokenType(TokenType.RwDo))
            {
                _loopsAndConditionals.Do();
            }
            else if (Utilities.CompareTokenType(TokenType.RwFor))
            {
                _loopsAndConditionals.ChooseForType();
            }
            else if (Utilities.CompareTokenType(TokenType.RwSwitch))
            {
                _loopsAndConditionals.Switch();
            }
            else if (Utilities.CompareTokenType(TokenType.RwBreak))
            {
                _loopsAndConditionals.Break();
            }
            else if (Utilities.CompareTokenType(TokenType.RwContinue))
            {
                _loopsAndConditionals.Continue();
            }
            else if (Utilities.CompareTokenType(TokenType.RwStruct))
            {
                Struct();
            }
            else if (Utilities.CompareTokenType(TokenType.RwConst))
            {
                Const();
            }
            else if (Utilities.CompareTokenType(TokenType.RwInclude))
            {
                Include();
            }
        }

        private void Include()
        {
            Utilities.NextToken();

            //Literal strings as a parameter for includes
            if (Utilities.CompareTokenType(TokenType.LiteralString))
            {
                Utilities.NextToken();
            }
            else
            {
                throw new Exception("Literal string expected");
            }
        }

        private void Const()
        {
            throw new NotImplementedException();
        }

        private void Struct()
        {
            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.Identifier))
                throw new Exception("Identifier expected"); 

            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
                throw new Exception("Open bracket expected");

            Utilities.NextToken();

            MembersList();
        }

        public void MembersList()
        {
            DeclarationOfStruct();
          //  MembersList();
        }

        private void DeclarationOfStruct()
        {
            GeneralDeclaration();

            if (!Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
                Utilities.NextToken();
                _arrays.ArrayIdentifier();

                OptionalMember();
            }

         

            //if (!_utilities.CompareTokenType(TokenType.EndOfSentence))
            //{
            //    throw new Exception("End of sentence symbol ; expected");
            //}
           
        }

        private void OptionalMember()
        {
            _utilities.NextToken();
          //  while (!_utilities.CompareTokenType(TokenType.CloseCurlyBracket))
           // {
            if (!_utilities.CompareTokenType(TokenType.CloseCurlyBracket))
            {
                DeclarationOfStruct();
            }
            else
            {
                
            }
               
          //  }
           
        }

        public void ChooseIdType()
        {
            if (Utilities.CompareTokenType(TokenType.OpBitAnd))
            {
                Utilities.NextToken();

                if (Utilities.CompareTokenType(TokenType.Identifier))
                {
                    Utilities.NextToken();
                }
                else
                {
                    throw new Exception("An Identifier was expected");
                }
            }
            else if (Utilities.CompareTokenType(TokenType.OpMultiplication))
            {
                Utilities.NextToken();

                IsPointer();

                Utilities.NextToken();

                if (Utilities.CompareTokenType(TokenType.Identifier))
                {
                    Utilities.NextToken();
                }
                else
                {
                    throw new Exception("An Identifier was expected");
                }
            }
            else if (Utilities.CompareTokenType(TokenType.Identifier))
            {
                Utilities.NextToken();
            }
            else
            {
                throw new Exception("An Identifier was expected");
            }
        }

        private void Declaration()
        {
            GeneralDeclaration();
            TypeOfDeclaration();
        }

        private void TypeOfDeclaration()
        {
            if (Utilities.CompareTokenType(TokenType.OpEqualTo))
            {
                Utilities.NextToken();

                ValueForId();
                _functions.MultiDeclaration();
            }
            else if (Utilities.CompareTokenType(TokenType.OpenSquareBracket))
            {
                _arrays.IsArrayDeclaration();
            }
            else if (Utilities.CompareTokenType(TokenType.OpenParenthesis))
            {
                _functions.IsFunctionDeclaration();
            }
            else if (Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
                Utilities.NextToken();
            }
            else
            {
                throw new Exception("An End of sentence ; symbol was expected");
            }
        }

        public void ListOfExpressions()
        {
            _expressions.Expresion();
            OptionalExpression();
        }

        private void OptionalExpression()
        {
            throw new NotImplementedException();
        }

        private void ValueForId()
        {
            if (Utilities.CompareTokenType(TokenType.OpEqualTo))
            {
                _expressions.Expresion();
            }
            else
            {
                
            }
        }

        public void ListOfId()
        {
            if (Utilities.CompareTokenType(TokenType.Identifier))
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
            _functions.OptionalId();
        }

        private void GeneralDeclaration()
        {
            if (Utilities.CompareTokenType(TokenType.RwChar) || Utilities.CompareTokenType(TokenType.RwString)
                || Utilities.CompareTokenType(TokenType.RwInt) || Utilities.CompareTokenType(TokenType.RwDate)
                || Utilities.CompareTokenType(TokenType.RwDouble) || Utilities.CompareTokenType(TokenType.RwBool)
                || Utilities.CompareTokenType(TokenType.RwLong) || Utilities.CompareTokenType(TokenType.RwVoid))
            {
                Utilities.NextToken();

                IsPointer();

                if (Utilities.CompareTokenType(TokenType.Identifier))
                {
                    Utilities.NextToken();
                }
            }
            else
            {
                throw new Exception("A datatyope was expected");
            }
        }

        private void IsPointer()
        {
            if (Utilities.CompareTokenType(TokenType.OpMultiplication))
            {
                Utilities.NextToken();
            }
            if (Utilities.CompareTokenType(TokenType.OpMultiplication))
            {
                IsPointer();
            }
        }

        private void SpecialDeclaration()
        {
            GeneralDeclaration();
            TypeOfDeclarationForFunction();
        }

        private void TypeOfDeclarationForFunction()
        {
            if (Utilities.CompareTokenType(TokenType.OpEqualTo))
            {
                Utilities.NextToken();

                ValueForId();
                _functions.MultiDeclaration();
            }
            else if (Utilities.CompareTokenType(TokenType.OpenSquareBracket))
            {
                _arrays.IsArrayDeclaration();
            }
            else if (Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
                Utilities.NextToken();
            }
            else
            {
                throw new Exception("An End of sentence ; symbol was expected");
            }
        }
    }
}
