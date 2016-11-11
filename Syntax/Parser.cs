using System;
using Lexer;

namespace Syntax
{
    public class Parser
    {
        public readonly Lexer.Lexer Lexer;

        public Token CurrentToken;
        public readonly Arrays Arrays;
        public readonly LoopsAndConditionals LoopsAndConditionals;
        public readonly Functions Functions;
        public readonly Expressions Expressions;
        private readonly Utilities _utilities;

        public Parser(Lexer.Lexer lexer)
        {
            Lexer = lexer;
            CurrentToken = lexer.GetNextToken();
            Arrays = new Arrays(this);
            LoopsAndConditionals = new LoopsAndConditionals(this);
            Functions = new Functions(this);
            Expressions = new Expressions(this);

            _utilities = new Utilities(this);
        }

        public Utilities Utilities
        {
            get { return _utilities; }
        }

        public void Parse()
        {
            //try
            //{
                Ccode();

                if (CurrentToken.TokenType != TokenType.EndOfFile)
                    throw new Exception("End of file expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            //}
            //catch (Exception e)
            //{
            //   Console.WriteLine( "\n" +e.Message);
            //}
          
        }

        private void Ccode()
        {
            ListOfSentences();
        }

        public void ListOfSentences()
        {
            if (Utilities.CompareTokenType(TokenType.EndOfFile))
            {
                return;
            }

            if (Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
            {
                return;
            }
            
            //Lista_Sentencias->Sentence Lista_Sentencias
            if (Enum.IsDefined(typeof(TokenType), CurrentToken.TokenType))
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
            while (!Utilities.CompareTokenType(TokenType.CloseCurlyBracket)
                && !Utilities.CompareTokenType(TokenType.RwBreak)
                && !Utilities.CompareTokenType(TokenType.RwCase))
            {
                SpecialSentence();
                ListOfSpecialSentences();
            }
         
        }

        public void SpecialSentence()
        {
            if (Utilities.CompareTokenType(TokenType.EndOfFile))
            {
                return;
            }

            if (Utilities.CompareTokenType(TokenType.RwChar) || Utilities.CompareTokenType(TokenType.RwString)
                 || Utilities.CompareTokenType(TokenType.RwInt) || Utilities.CompareTokenType(TokenType.RwDate)
                 || Utilities.CompareTokenType(TokenType.RwDouble) || Utilities.CompareTokenType(TokenType.RwBool)
                 || Utilities.CompareTokenType(TokenType.RwLong) || Utilities.CompareTokenType(TokenType.RwFloat)
                 || Utilities.CompareTokenType(TokenType.RwExtern))
            {
                if (Utilities.CompareTokenType(TokenType.RwExtern))
                {
                    Utilities.NextToken();
                }
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
                LoopsAndConditionals.ForLoop();
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
            else if (Utilities.CompareTokenType(TokenType.Identifier)
                || Utilities.CompareTokenType(TokenType.OpMultiplication) 
                || Utilities.CompareTokenType(TokenType.OpenParenthesis))
            {
                if (Utilities.CompareTokenType(TokenType.OpMultiplication))
                {
                    IsPointer();
                }
                AssignmentOrFunctionCall();
            }
            else if (Utilities.CompareTokenType(TokenType.RwConst))
            {
                Const();
            }
            else if (Utilities.CompareTokenType(TokenType.RwInclude))
            {
                Include();
            }
            else if (Utilities.CompareTokenType(TokenType.RwReturn))
            {
                ReturnStatement();
            }
            else
            {
                try
                {

                }
                catch (Exception)
                {

                    throw new Exception("Not a valid sentence");
                }

            }
        }

        private void ReturnStatement()
        {
            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
                Expressions.Expression();
            }

            if (!Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
                throw new Exception("End of sentence expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            }

            Utilities.NextToken();
        }

        public void Sentence()
        {
          
            if (Utilities.CompareTokenType(TokenType.RwChar) || Utilities.CompareTokenType(TokenType.RwString)
                  || Utilities.CompareTokenType(TokenType.RwInt) || Utilities.CompareTokenType(TokenType.RwDate)
                  || Utilities.CompareTokenType(TokenType.RwDouble) || Utilities.CompareTokenType(TokenType.RwBool)
                  || Utilities.CompareTokenType(TokenType.RwLong) || Utilities.CompareTokenType(TokenType.RwVoid)
                  || Utilities.CompareTokenType(TokenType.RwFloat) || Utilities.CompareTokenType(TokenType.RwExtern))
            {
                if (Utilities.CompareTokenType(TokenType.RwExtern))
                {
                    Utilities.NextToken();
                }
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
                LoopsAndConditionals.ForLoop();
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
            else if (Utilities.CompareTokenType(TokenType.Identifier)
                || Utilities.CompareTokenType(TokenType.OpMultiplication)
                || Utilities.CompareTokenType(TokenType.OpenParenthesis))
            {
                if (Utilities.CompareTokenType(TokenType.OpenParenthesis))
                {
                    Utilities.NextToken();
                    if (Utilities.CompareTokenType(TokenType.OpMultiplication))
                    {
                        IsPointer();
                    }

                    if (!Utilities.CompareTokenType(TokenType.Identifier))
                    {
                        throw new Exception("Identifier expected");
                    }

                    Utilities.NextToken();

                    if (!Utilities.CompareTokenType(TokenType.CloseParenthesis))
                    {
                        throw new Exception("Closing parenthesis");
                    }
                    
                    AssignmentOrFunctionCall();
                }

                if (Utilities.CompareTokenType(TokenType.OpMultiplication))
                {
                    IsPointer();
                }
                AssignmentOrFunctionCall();
            }
            else if (Utilities.CompareTokenType(TokenType.RwStruct)
                ||Utilities.CompareTokenType(TokenType.RwTypedef))
            {
                if (Utilities.CompareTokenType(TokenType.RwTypedef))
                {
                    Utilities.NextToken();
                }

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
            //Return no debería estar aquí porque no es una sentence
            else if (Utilities.CompareTokenType(TokenType.RwReturn))
            {
                ReturnStatement();
            }
            else
            {
                try
                {

                }
                catch (Exception)
                {

                    throw new Exception("Not a valid sentence");
                }
               
            }

        }

        private void Enumeration()
        {
            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.Identifier))
                throw new Exception("Identifier was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);

            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
                throw new Exception("Openning bracket was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);

            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
            {
                EnumeratorList();
            }

            if (!Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
                throw new Exception("Closing bracket was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.EndOfSentence))
                throw new Exception("End of sentence was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);

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
                throw new Exception("Identifier was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            }

            Utilities.NextToken();

            OptionalIndexPosition();
        }

        private void OptionalIndexPosition()
        {
            if (Utilities.CompareTokenType(TokenType.OpSimpleAssignment))
            {
                Utilities.NextToken();
                if (!Utilities.CompareTokenType(TokenType.LiteralNumber))
                    throw new Exception("Literal number was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
                Utilities.NextToken();
            }
            else
            {
                
            } 
        }

        private void AssignmentOrFunctionCall()
        {
            Utilities.NextToken();

            if (Utilities.CompareTokenType(TokenType.OpIncrement)
                   || Utilities.CompareTokenType(TokenType.OpDecrement))
            {
                Utilities.NextToken();

                if (Utilities.CompareTokenType(TokenType.OpSimpleAssignment))
                {
                    Utilities.NextToken();
                    Expressions.Expression();
                }

                if (!Utilities.CompareTokenType(TokenType.EndOfSentence))
                {
                    throw new Exception("End of sentence ; expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
                }
            }

            if (Utilities.CompareTokenType(TokenType.OpPointerStructs) 
                || Utilities.CompareTokenType(TokenType.Dot))
            {
                Expressions.ArrowOrPointer();

                if (!Utilities.CompareTokenType(TokenType.Identifier))
                {
                    throw new Exception("Identifier expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
                }

                Utilities.NextToken();

                if (Utilities.CompareTokenType(TokenType.OpIncrement)
                  || Utilities.CompareTokenType(TokenType.OpDecrement))
                {
                    Utilities.NextToken();
                }
            }

            if (Utilities.CompareTokenType(TokenType.OpenSquareBracket))
            {
                bool x;
                Arrays.BidArray(out x);

                if (Utilities.CompareTokenType(TokenType.OpenSquareBracket))
                {
                    Arrays.BidArray(out x);
                }

                // body[i].x=0;
                    if (Utilities.CompareTokenType(TokenType.OpPointerStructs)
                    || Utilities.CompareTokenType(TokenType.Dot))
                {
                    Expressions.ArrowOrPointer();

                    if (!Utilities.CompareTokenType(TokenType.Identifier))
                    {
                        throw new Exception("Identifier expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
                    }

                    Utilities.NextToken();
                }
            }

            ValueForPreId();

            if (Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
                Utilities.NextToken();
            }
            else
            {
                throw new Exception("End of sentence symbol ; expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            }
        }

        private void ValueForPreId()
        {
            if (Utilities.CompareTokenType(TokenType.OpSimpleAssignment)
                ||Utilities.CompareTokenType(TokenType.OpAddAndAssignment)
                ||Utilities.CompareTokenType(TokenType.OpSusbtractAndAssignment)
                ||Utilities.CompareTokenType(TokenType.OpMultiplyAndAssignment)
                ||Utilities.CompareTokenType(TokenType.OpDivideAssignment)
                ||Utilities.CompareTokenType(TokenType.OpModulusAssignment)
                ||Utilities.CompareTokenType(TokenType.OpBitShiftLeftAndAssignment)
                ||Utilities.CompareTokenType(TokenType.OpBitShiftRightAndAssignment)
                ||Utilities.CompareTokenType(TokenType.OpBitwiseAndAssignment)
                ||Utilities.CompareTokenType(TokenType.OpBitwiseXorAndAssignment)
                ||Utilities.CompareTokenType(TokenType.OpBitwiseInclusiveOrAndAssignment))
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
                throw new Exception("Literal string expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            }
        }

        private void Const()
        {
             Utilities.NextToken();

             DataType();

            if (!Utilities.CompareTokenType(TokenType.Identifier))
            {
                throw new Exception("Identifier expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            }

            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.OpSimpleAssignment))
            {
                throw new Exception("Assignment expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            }

            Utilities.NextToken();

            Expressions.Expression();

            if (!Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
                throw new Exception("End Of Sentence expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            }
            Utilities.NextToken();
        }

        public void DataType()
        {
           if (Utilities.CompareTokenType(TokenType.RwChar) 
                ||Utilities.CompareTokenType(TokenType.RwString)
                ||Utilities.CompareTokenType(TokenType.RwInt)
                ||Utilities.CompareTokenType(TokenType.RwDate)
                ||Utilities.CompareTokenType(TokenType.RwDouble)
                ||Utilities.CompareTokenType(TokenType.RwBool)
                ||Utilities.CompareTokenType(TokenType.RwLong)
                ||Utilities.CompareTokenType(TokenType.RwFloat)
                ||Utilities.CompareTokenType(TokenType.RwVoid))
           {
               Utilities.NextToken();
           }
           else
           {
                throw new Exception("A Data Type was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            }
        }

        private void Struct()
        {
            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.Identifier))
                throw new Exception("Identifier was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);

            Utilities.NextToken();

            StructDeclarationOrInitialization();

            if (!Utilities.CompareTokenType(TokenType.EndOfSentence))
                throw new Exception("End of sentence was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);

            Utilities.NextToken();
        }

        private void StructDeclarationOrInitialization()
        {
            if (Utilities.CompareTokenType(TokenType.Identifier) || Utilities.CompareTokenType(TokenType.OpMultiplication))
            {
                if (Utilities.CompareTokenType(TokenType.OpMultiplication))
                {
                    IsPointer();
                }
                Utilities.NextToken();

                //Posible inicializacion de los valores, así como se inicializa un arreglo
                //struct point my_point = { 3, 7 };
                //struct point *p = &my_point;
                if (Utilities.CompareTokenType(TokenType.Comma))
                {
                    Functions.OptionalId();
                }

                if (Utilities.CompareTokenType(TokenType.OpSimpleAssignment))
                {
                    InitializationForStruct();
                }

                if (!Utilities.CompareTokenType(TokenType.EndOfSentence))
                {
                    throw new Exception("Openning bracket was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
                }
            }
            else
            {
                if (!Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
                    throw new Exception("Openning bracket was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);

                Utilities.NextToken();

                if (!Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
                {
                    DeclarationOfStruct();
                }

                if (!Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
                    throw new Exception("Closing bracket was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
                Utilities.NextToken();

                if (Utilities.CompareTokenType(TokenType.Identifier))
                {
                    Utilities.NextToken();
                }
            }
          
        }

        private void InitializationForStruct()
        {
            Utilities.NextToken();
            if (Utilities.CompareTokenType(TokenType.OpBitAnd))
            {
                ChooseIdType();
            }
            else if (Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
            {
                InitElementsOfStruct();
            }
        }

        private void InitElementsOfStruct()
        {
            if (!Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
                throw new Exception("Openning bracket was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);

            Utilities.NextToken();
            ListOfExpressions();
            if (Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
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
                    Arrays.ArrayIdentifier();

                    if (!Utilities.CompareTokenType(TokenType.CloseSquareBracket))
                        throw new Exception("Closing bracket was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
                    Utilities.NextToken();
                }
                if (Utilities.CompareTokenType(TokenType.EndOfSentence))
                {
                    Utilities.NextToken();
                    DeclarationOfStruct();
                }
                else
                {
                    throw new Exception("End of sentence symbol ; expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
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
                    throw new Exception("An Identifier was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
                }
            }
            else if (Utilities.CompareTokenType(TokenType.OpMultiplication))
            {
                Utilities.NextToken();

                if (Utilities.CompareTokenType(TokenType.OpMultiplication))
                {
                    IsPointer();
                    Utilities.NextToken();
                }

                if (Utilities.CompareTokenType(TokenType.Identifier))
                {
                    Utilities.NextToken();
                }
                else
                {
                    throw new Exception("An Identifier was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
                }
            }
            else if (Utilities.CompareTokenType(TokenType.Identifier))
            {
                Utilities.NextToken();

                if (Utilities.CompareTokenType(TokenType.OpenSquareBracket))
                {
                    Arrays.ArrayForFunctionsParameter();
                }
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
            if (Utilities.CompareTokenType(TokenType.OpSimpleAssignment))
            {
                ValueForId();
                if (Utilities.CompareTokenType(TokenType.EndOfSentence))
                {
                    Utilities.NextToken();
                }
                else if (Utilities.CompareTokenType(TokenType.Comma))
                {
                    Functions.MultiDeclaration();
                }
                else
                {
                    throw new Exception("An End of sentence ; symbol was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
                }
            }
            else if (Utilities.CompareTokenType(TokenType.Comma))
            {
                Functions.MultiDeclaration();
            }
            else if (Utilities.CompareTokenType(TokenType.OpenSquareBracket))
            {
                bool isInMultideclaration = false;
                Arrays.IsArrayDeclaration(isInMultideclaration);
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
                throw new Exception("An End of sentence ; symbol was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            }
        }

        public void ListOfExpressions()
        {
            Expressions.Expression();

            if (Utilities.CompareTokenType(TokenType.Comma))
            {
                OptionalExpression();
            }
        }

        public void OptionalExpression()
        {
            if (Utilities.CompareTokenType(TokenType.Comma))
            {
                Utilities.NextToken();
                ListOfExpressions();
            }
            else
            {
                
            }
        }

        private void ValueForId()
        {
            if (Utilities.CompareTokenType(TokenType.OpSimpleAssignment))
            {
                Utilities.NextToken();
                Expressions.Expression();
            }
            else
            {
                
            }
        }

        public void ListOfId()
        {
            Utilities.NextToken();

            if (Utilities.CompareTokenType(TokenType.Identifier) 
                || Utilities.CompareTokenType(TokenType.OpMultiplication))
            {
                if (Utilities.CompareTokenType(TokenType.OpMultiplication))
                {
                    IsPointer();
                }

                Utilities.NextToken();

                if (Utilities.CompareTokenType(TokenType.OpenSquareBracket))
                {
                    bool isInMultiDeclaration = true;

                    Arrays.IsArrayDeclaration(isInMultiDeclaration);
                }

                OtherIdOrValue();
            }
            else
            {
                throw new Exception("An Identifier was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
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

            if (Utilities.CompareTokenType(TokenType.OpMultiplication))
            {
                IsPointer();
            }

            if (Utilities.CompareTokenType(TokenType.Identifier))
            {
                Utilities.NextToken();
            }
        }

        public void IsPointer()
        {
            Utilities.NextToken();

            if (Utilities.CompareTokenType(TokenType.OpMultiplication))
            {
                IsPointer();
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
            if (Utilities.CompareTokenType(TokenType.OpSimpleAssignment))
            {
                ValueForId();
                if (Utilities.CompareTokenType(TokenType.EndOfSentence))
                {
                    Utilities.NextToken();
                }
                else if (Utilities.CompareTokenType(TokenType.Comma))
                {
                    Functions.MultiDeclaration();
                }
                else
                {
                    throw new Exception("An End of sentence ; symbol was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
                }
            }
            else if (Utilities.CompareTokenType(TokenType.Comma))
            {
                Functions.MultiDeclaration();
            }
            else if (Utilities.CompareTokenType(TokenType.OpenSquareBracket))
            {
                bool isInMultideclaration = false;

                Arrays.IsArrayDeclaration(isInMultideclaration);
            }
            else if (Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
                Utilities.NextToken();
            }
            else
            {
                throw new Exception("An End of sentence ; symbol was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            }
        }
    }
}
