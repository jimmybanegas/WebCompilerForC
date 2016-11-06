using System;
using System.CodeDom;
using System.ComponentModel;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Lexer;

namespace Syntax
{
    public class Parser
    {
        public readonly Lexer.Lexer Lexer;

        public Token CurrentToken;
        private readonly Arrays _arrays;
        public readonly LoopsAndConditionals LoopsAndConditionals;
        private readonly Utilities _utilities;
        public readonly Functions Functions;
        public readonly Expressions Expressions;

        public Parser(Lexer.Lexer lexer)
        {
            Lexer = lexer;
            CurrentToken = lexer.GetNextToken();
            _arrays = new Arrays(this);
            LoopsAndConditionals = new LoopsAndConditionals(this);
            _utilities = new Utilities(this);
            Functions = new Functions(this);
            Expressions = new Expressions(this);
        }

        public Utilities Utilities
        {
            get { return _utilities; }
        }

        public void Parse()
        {
            Ccode();

            if (CurrentToken.TokenType != TokenType.EndOfFile)
                throw new Exception("End of file expected");
        }

        private void Ccode()
        {
            ListOfSentences();
        }

        public void ListOfSentences()
        {
            //Lista_Sentencias->Sentence Lista_Sentencias
            if (Enum.IsDefined(typeof(TokenType), CurrentToken.TokenType))
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
                 || Utilities.CompareTokenType(TokenType.RwLong) || Utilities.CompareTokenType(TokenType.RwFloat))
            {
                SpecialDeclaration();
            }
            else if (Utilities.CompareTokenType(TokenType.RwIf))
            {
                LoopsAndConditionals.If();
            }
            else if (Utilities.CompareTokenType(TokenType.RwWhile))
            {
                LoopsAndConditionals.While();
            }
            else if (Utilities.CompareTokenType(TokenType.RwDo))
            {
                LoopsAndConditionals.Do();
            }
            else if (Utilities.CompareTokenType(TokenType.RwFor))
            {
                LoopsAndConditionals.ChooseForType();
            }
            else if (Utilities.CompareTokenType(TokenType.RwSwitch))
            {
                LoopsAndConditionals.Switch();
            }
            else if (Utilities.CompareTokenType(TokenType.RwBreak))
            {
                LoopsAndConditionals.Break();
            }
            else if (Utilities.CompareTokenType(TokenType.RwContinue))
            {
                LoopsAndConditionals.Continue();
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

        public void Sentence()
        {
            if (Utilities.CompareTokenType(TokenType.RwChar) || Utilities.CompareTokenType(TokenType.RwString)
                  || Utilities.CompareTokenType(TokenType.RwInt) || Utilities.CompareTokenType(TokenType.RwDate)
                  || Utilities.CompareTokenType(TokenType.RwDouble) || Utilities.CompareTokenType(TokenType.RwBool)
                  || Utilities.CompareTokenType(TokenType.RwLong) || Utilities.CompareTokenType(TokenType.RwVoid)
                  || Utilities.CompareTokenType(TokenType.RwFloat))
            {
                Declaration();
            }
            else if (Utilities.CompareTokenType(TokenType.RwIf))
            {
                LoopsAndConditionals.If();
            }
            else if (Utilities.CompareTokenType(TokenType.RwWhile))
            {
                LoopsAndConditionals.While();
            }
            else if (Utilities.CompareTokenType(TokenType.RwDo))
            {
                LoopsAndConditionals.Do();
            }
            else if (Utilities.CompareTokenType(TokenType.RwFor))
            {
                LoopsAndConditionals.ChooseForType();
            }
            else if (Utilities.CompareTokenType(TokenType.RwSwitch))
            {
                LoopsAndConditionals.Switch();
            }
            else if (Utilities.CompareTokenType(TokenType.RwBreak))
            {
                LoopsAndConditionals.Break();
            }
            else if (Utilities.CompareTokenType(TokenType.RwContinue))
            {
                LoopsAndConditionals.Continue();
            }
            else if (Utilities.CompareTokenType(TokenType.Identifier))
            {
                PreId();
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
            else if (Utilities.CompareTokenType(TokenType.RwEnum))
            {
                Enumeration();
            }
        }

        private void Enumeration()
        {
            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.Identifier))
                throw new Exception("Identifier was expected");

            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
                throw new Exception("Openning bracket was expected");

            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
            {
                EnumeratorList();
            }

            if (!Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
                throw new Exception("Closing bracket was expected");
            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.EndOfSentence))
                throw new Exception("End of sentence was expected");

            Utilities.NextToken();
        }

        private void EnumeratorList()
        {
            EnumItem();

            if (Utilities.CompareTokenType(TokenType.Comma))
            {
                OptionalEnumItem();
            }

        }

        private void OptionalEnumItem()
        {
            Utilities.NextToken();
            EnumeratorList();
        }

        private void EnumItem()
        {
            if (!Utilities.CompareTokenType(TokenType.Identifier))
            {
                throw new Exception("Identifier was expected");
            }

            Utilities.NextToken();

            OptionalIndexPosition();
        }

        private void OptionalIndexPosition()
        {
            if (Utilities.CompareTokenType(TokenType.OpSimpleAssingment))
            {
                Utilities.NextToken();
                if (!Utilities.CompareTokenType(TokenType.LiteralNumber))
                    throw new Exception("Literal number was expected");
                Utilities.NextToken();
            }
            else
            {
                
            } 
        }

        private void PreId()
        {
            Utilities.NextToken();

            ValueForPreId();

            if (Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
                Utilities.NextToken();
            }
            else
            {
                throw new Exception("End of sentence symbol ; expected");
            }
        }

        private void ValueForPreId()
        {
            if (Utilities.CompareTokenType(TokenType.OpSimpleAssingment))
            {
                Utilities.NextToken();
                Expressions.Expression();
            }
            else if (Utilities.CompareTokenType(TokenType.OpenParenthesis))
            {
                Functions.CallFunction();
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
             Utilities.NextToken();

             DataType();

            if (!Utilities.CompareTokenType(TokenType.Identifier))
            {
                throw new Exception("Identifier expected");
            }

            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.OpSimpleAssingment))
            {
                throw new Exception("Assignment expected");
            }

            Expressions.Expression();

            if (!Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
                throw new Exception("End Of Sentence expected");
            }
            Expressions.Expression();
        }

        public void DataType()
        {
           if (Utilities.CompareTokenType(TokenType.RwChar))
            {
                Utilities.NextToken();
            }
           else if (Utilities.CompareTokenType(TokenType.RwString))
           {
                Utilities.NextToken();
            }
           else if(Utilities.CompareTokenType(TokenType.RwInt))
           {
                Utilities.NextToken();
            }
           else if (Utilities.CompareTokenType(TokenType.RwDate))
           {
                Utilities.NextToken();
            }
           else if (Utilities.CompareTokenType(TokenType.RwDouble))
           {
                Utilities.NextToken();
            }
           else if (Utilities.CompareTokenType(TokenType.RwBool))
           {
                Utilities.NextToken();
            }
           else if (Utilities.CompareTokenType(TokenType.RwLong))
           {
                Utilities.NextToken();
            }
           else if(Utilities.CompareTokenType(TokenType.RwFloat))
           {
                Utilities.NextToken();
            }
           else if (Utilities.CompareTokenType(TokenType.RwVoid))
           {
               Utilities.NextToken();
           }
           else
           {
                throw new Exception("A Data Type was expected");
            }
        }

        private void Struct()
        {
            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.Identifier))
                throw new Exception("Identifier was expected"); 

            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
                throw new Exception("Openning bracket was expected");

            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
            {
                DeclarationOfStruct();
            }

            if (!Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
                throw new Exception("Closing bracket was expected");
            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.EndOfSentence))
                throw new Exception("End of sentence was expected");

            Utilities.NextToken();
        }

        private void DeclarationOfStruct()
        {
            if (!Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
            {
                GeneralDeclaration();

                if (Utilities.CompareTokenType(TokenType.OpenSquareBracket))
                {
                    Utilities.NextToken();
                    _arrays.ArrayIdentifier();
                }
                else if (Utilities.CompareTokenType(TokenType.EndOfSentence))
                {
                    Utilities.NextToken();
                    DeclarationOfStruct();
                }
                else
                {
                    throw new Exception("End of sentence symbol ; expected");
                }
            }
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
            if (Utilities.CompareTokenType(TokenType.OpSimpleAssingment))
            {
              //  Utilities.NextToken();

                ValueForId();
            }
            else if (Utilities.CompareTokenType(TokenType.Comma))
            {
                Functions.MultiDeclaration();
            }
            else if (Utilities.CompareTokenType(TokenType.OpenSquareBracket))
            {
                _arrays.IsArrayDeclaration();
            }
            else if (Utilities.CompareTokenType(TokenType.OpenParenthesis))
            {
                Functions.IsFunctionDeclaration();
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
            Expressions.Expression();
            OptionalExpression();
        }

        private void OptionalExpression()
        {
            if (Utilities.CompareTokenType(TokenType.Comma))
            {
                ListOfExpressions();
            }
            else
            {
                
            }
        }

        private void ValueForId()
        {
            if (Utilities.CompareTokenType(TokenType.OpSimpleAssingment))
            {
                Expressions.Expression();
            }
            else
            {
                
            }
        }

        public void ListOfId()
        {
            Utilities.NextToken();

            if (Utilities.CompareTokenType(TokenType.Identifier))
            {
                Utilities.NextToken();
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
            Functions.OptionalId();
        }

        private void GeneralDeclaration()
        {
            DataType();

            //Utilities.NextToken();

            if (Utilities.CompareTokenType(TokenType.OpMultiplication))
            {
                IsPointer();
            }

            if (Utilities.CompareTokenType(TokenType.Identifier))
            {
                Utilities.NextToken();
            }
        }

        private void IsPointer()
        {
            Utilities.NextToken();

            if (Utilities.CompareTokenType(TokenType.OpMultiplication))
            {
                IsPointer();
              // Utilities.NextToken();
            }
            else
            {
                
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
                Functions.MultiDeclaration();
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
