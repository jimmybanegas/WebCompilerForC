using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Tree;
using Syntax.Tree.Nodes.BaseNodes;
using Syntax.Tree.Nodes.DataTypes;
using Syntax.Tree.Nodes.Declarations;

namespace Syntax.Parser
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

        public List<StatementNode> Parse()
        {
           var code = Ccode();

            if (CurrentToken.TokenType != TokenType.EndOfFile)
                    throw new Exception("End of file expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
     
            return code;
        }

        private List<StatementNode> Ccode()
        {
            return ListOfSentences();
        }

        public List<StatementNode> ListOfSentences()
        {
            if (Utilities.CompareTokenType(TokenType.EndOfFile))
            {
                return new List<StatementNode>(); 
            }

            if (Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
            {
                return new List<StatementNode>();
            }

            //Lista_Sentencias->Sentence Lista_Sentencias
            // if (Enum.IsDefined(typeof(TokenType), CurrentToken.TokenType))
            if (!Utilities.CompareTokenType(TokenType.EndOfFile))
            {
                Console.WriteLine();

                var statement = Sentence();
                var statementList = ListOfSentences();

                statementList.Insert(0, statement);
                return statementList;

            }
            //Lista_Sentencia->Epsilon
            else
            {
                return new List<StatementNode>();
            }
        }

        public List<StatementNode> ListOfSpecialSentences()
        {
            //Lista_Sentencias->Sentence Lista_Sentencias
            while (!Utilities.CompareTokenType(TokenType.CloseCurlyBracket)
                && !Utilities.CompareTokenType(TokenType.RwBreak)
                && !Utilities.CompareTokenType(TokenType.RwCase))
            {
                var statement = SpecialSentence();
                var statementList = ListOfSpecialSentences();
                statementList.Insert(0, statement);
                return statementList;
            }

            return new List<StatementNode>();
        }

        public StatementNode SpecialSentence()
        {
            if (Utilities.CompareTokenType(TokenType.HTMLContent) || Utilities.CompareTokenType(TokenType.CloseCCode))
            {
                Utilities.NextToken();
            }

            if (Utilities.CompareTokenType(TokenType.EndOfFile))
            {
                //return;
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
                return LoopsAndConditionals.If();
            }
            else if (Utilities.CompareTokenType(TokenType.RwWhile))
            {
                return LoopsAndConditionals.While();
            }
            else if (Utilities.CompareTokenType(TokenType.RwDo))
            {
                return LoopsAndConditionals.Do();
            }
            else if (Utilities.CompareTokenType(TokenType.RwFor))
            {
                return LoopsAndConditionals.ForLoop();
            }
            else if (Utilities.CompareTokenType(TokenType.RwSwitch))
            {
                return LoopsAndConditionals.Switch();
            }
            else if (Utilities.CompareTokenType(TokenType.RwBreak))
            {
                return LoopsAndConditionals.Break();
            }
            else if (Utilities.CompareTokenType(TokenType.RwDefault))
            {
                return LoopsAndConditionals.DefaultCase();
            }
            else if (Utilities.CompareTokenType(TokenType.RwContinue))
            {
                return LoopsAndConditionals.Continue();
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
                return Const();
            }
            else if (Utilities.CompareTokenType(TokenType.RwInclude))
            {
                return Include();
            }
            else if (Utilities.CompareTokenType(TokenType.RwReturn))
            {
                return ReturnStatement();
            }
            else if (Utilities.CompareTokenType(TokenType.RwStruct)
                || Utilities.CompareTokenType(TokenType.RwTypedef))
            {
                throw new Exception("Not a valid sentence at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            }
            else
            {
                try
                {

                }
                catch (Exception)
                {

                    throw new Exception("Not a valid sentence at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
                }

            }
            return null;
        }

        private StatementNode ReturnStatement()
        {
            var returnStatement = new ReturnStatementNode();

            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
               returnStatement.ReturnExpression = Expressions.Expression();
            }

            if (!Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
                throw new Exception("End of sentence expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            }

            Utilities.NextToken();

            return returnStatement;
        }

        public StatementNode Sentence()
        {
          
            if (Utilities.CompareTokenType(TokenType.HTMLContent) || Utilities.CompareTokenType(TokenType.CloseCCode))
            {
                Utilities.NextToken();
            }

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
                return LoopsAndConditionals.If();
            }
            else if (Utilities.CompareTokenType(TokenType.RwWhile))
            {
                return LoopsAndConditionals.While();
            }
            else if (Utilities.CompareTokenType(TokenType.RwDo))
            {
                return LoopsAndConditionals.Do();
            }
            else if (Utilities.CompareTokenType(TokenType.RwFor))
            {
                return LoopsAndConditionals.ForLoop();
            }
            else if (Utilities.CompareTokenType(TokenType.RwSwitch))
            {
                return LoopsAndConditionals.Switch();
            }
            else if (Utilities.CompareTokenType(TokenType.RwBreak))
            {
                return LoopsAndConditionals.Break();
              //  throw new Exception("Not a valid sentence at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            }
            else if (Utilities.CompareTokenType(TokenType.RwDefault))
            {
                return LoopsAndConditionals.DefaultCase();
                //throw new Exception("Not a valid sentence at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            }
            else if (Utilities.CompareTokenType(TokenType.RwContinue))
            {
                return LoopsAndConditionals.Continue();
                //throw new Exception("Not a valid sentence at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
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
                        throw new Exception("Identifier expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
                    }

                    Utilities.NextToken();

                    if (!Utilities.CompareTokenType(TokenType.CloseParenthesis))
                    {
                        throw new Exception("Closing parenthesis required at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
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

                return Struct();
            }
            else if (Utilities.CompareTokenType(TokenType.RwConst))
            {
                return Const();
            }
            else if (Utilities.CompareTokenType(TokenType.RwInclude))
            {
                return Include();
            }
            else if (Utilities.CompareTokenType(TokenType.RwEnum))
            {
                return Enumeration();
            }
            //Return no debería estar aquí porque no es una sentence
            else if (Utilities.CompareTokenType(TokenType.RwReturn))
            {
                return ReturnStatement();
            }
            else
            {
                try
                {

                }
                catch (Exception)
                {

                    throw new Exception("Not a valid sentence at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
                }
               
            }

            return null;
        }

        private StatementNode Enumeration()
        {
            var enumerationNode = new EnumerationNode();

            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.Identifier))
                throw new Exception("Identifier was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);

            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
                throw new Exception("Openning bracket was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);

            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
            {
                List<StatementNode> items = new List<StatementNode>();
                enumerationNode.EnumItems = EnumeratorList(items);
            }

            if (!Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
                throw new Exception("Closing bracket was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.EndOfSentence))
                throw new Exception("End of sentence was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);

            Utilities.NextToken();

            return enumerationNode;
        }

        private List<StatementNode> EnumeratorList(List<StatementNode> items)
        {
            var item = EnumItem();
            items.Add(item);

            if (Utilities.CompareTokenType(TokenType.Comma))
            {
                OptionalEnumItem(items);
            }

            return items;
        }

        private void OptionalEnumItem(List<StatementNode> items)
        {
            Utilities.NextToken();
            EnumeratorList(items);
        }

        private StatementNode EnumItem()
        {
            if (!Utilities.CompareTokenType(TokenType.Identifier))
            {
                throw new Exception("Identifier was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            }
            var value = CurrentToken.Lexeme;

            var name = new IdentifierNode {Accessors = null, Value = value};

            Utilities.NextToken();

            var position = OptionalIndexPosition();

            return new EnumItemNode
            {
                ItemName = name, OptionalPosition = position
            };
        }

        private IntegerNode OptionalIndexPosition()
        {
            var integerNode = new IntegerNode();

            if (Utilities.CompareTokenType(TokenType.OpSimpleAssignment))
            {
                Utilities.NextToken();
                if (!Utilities.CompareTokenType(TokenType.LiteralNumber))
                    throw new Exception("Literal number was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);

                integerNode.Value = int.Parse(CurrentToken.Lexeme);

                Utilities.NextToken();

                return integerNode;
            }
            else
            {
                
            }

            return new IntegerNode();
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

            Expressions.IndexOrArrowAccess(" ");

            if (Utilities.CompareTokenType(TokenType.OpIncrement)
                  || Utilities.CompareTokenType(TokenType.OpDecrement))
            {
                Utilities.NextToken();
            }

            //if (Utilities.CompareTokenType(TokenType.OpPointerStructs) 
            //    || Utilities.CompareTokenType(TokenType.Dot))
            //{
            //    Expressions.ArrowOrPointer();

            //    if (!Utilities.CompareTokenType(TokenType.Identifier))
            //    {
            //        throw new Exception("Identifier expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            //    }

            //    Utilities.NextToken();

            //    if (Utilities.CompareTokenType(TokenType.OpIncrement)
            //      || Utilities.CompareTokenType(TokenType.OpDecrement))
            //    {
            //        Utilities.NextToken();
            //    }
            //}

            //if (Utilities.CompareTokenType(TokenType.OpenSquareBracket))
            //{
            //    bool x;
            //    Arrays.BidArray(out x);

            //    if (Utilities.CompareTokenType(TokenType.OpenSquareBracket))
            //    {
            //        Arrays.BidArray(out x);
            //    }

            //    // body[i].x=0;
            //        if (Utilities.CompareTokenType(TokenType.OpPointerStructs)
            //        || Utilities.CompareTokenType(TokenType.Dot))
            //    {
            //        Expressions.ArrowOrPointer();

            //        if (!Utilities.CompareTokenType(TokenType.Identifier))
            //        {
            //            throw new Exception("Identifier expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            //        }

            //        Utilities.NextToken();
            //    }
            //}

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

        private StatementNode Include()
        {   
            string reference;
            Utilities.NextToken();

            //Literal strings as a parameter for includes
            if (Utilities.CompareTokenType(TokenType.LiteralString))
            {
                reference = CurrentToken.Lexeme;
                Utilities.NextToken();
            }
            else
            {
                throw new Exception("Literal string expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            }

            return new IncludeNode {ReferencedClass = reference};
        }

        private StatementNode Const()
        {
            Utilities.NextToken();

            StatementNode dataType = DataType();

            var typeNode = new IdentifierNode
            {
                Accessors = new List<AccessorNode>(), Value = ((IdentifierNode)dataType).Value
            };


            if (!Utilities.CompareTokenType(TokenType.Identifier))
            {
                throw new Exception("Identifier expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            }

            var name = CurrentToken.Lexeme;

            var nameNode = new IdentifierNode {Accessors = new List<AccessorNode>(), Value = name};

            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.OpSimpleAssignment))
            {
                throw new Exception("Assignment expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            }

            Utilities.NextToken();

            var expression = Expressions.Expression();

            if (!Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
                throw new Exception("End Of Sentence expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            }
            Utilities.NextToken();

            return new ConstantNode {ConstName = nameNode, ExpressionConst = expression, TypeOfConst = typeNode };
        }

        public StatementNode DataType()
        {
            //if (Utilities.CompareTokenType(TokenType.RwChar))
            //{
            //    Utilities.NextToken();
            //    return new IdentifierNode {Accessors = new List<AccessorNode>(), Value = CurrentToken.Lexeme} ;
            //}
            if (Utilities.CompareTokenType(TokenType.RwChar)
                 || Utilities.CompareTokenType(TokenType.RwString)
                 || Utilities.CompareTokenType(TokenType.RwInt)
                 || Utilities.CompareTokenType(TokenType.RwDate)
                 || Utilities.CompareTokenType(TokenType.RwDouble)
                 || Utilities.CompareTokenType(TokenType.RwBool)
                 || Utilities.CompareTokenType(TokenType.RwLong)
                 || Utilities.CompareTokenType(TokenType.RwFloat)
                 || Utilities.CompareTokenType(TokenType.RwVoid))
            {
                var type = CurrentToken.Lexeme;

                Utilities.NextToken();
                return new IdentifierNode { Accessors = new List<AccessorNode>(), Value = type};
            }
            else
            {
                throw new Exception("A Data Type was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            }
        }

        private StatementNode Struct()
        {
            var structItem = new StructNode(); 

            Utilities.NextToken();

            if (!Utilities.CompareTokenType(TokenType.Identifier))
                throw new Exception("Identifier was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);

            Utilities.NextToken();

            StructDeclarationOrInitialization();

            if (!Utilities.CompareTokenType(TokenType.EndOfSentence))
                throw new Exception("End of sentence was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);

            Utilities.NextToken();

            return structItem;
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
                    DeclarationOfStruct(false);
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
            List<ExpressionNode> list = new List<ExpressionNode>();
            ListOfExpressions(list);
            if (Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
                Utilities.NextToken();
        }

        private void DeclarationOfStruct(bool isMultideclaration)
        {
            if (!Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
            {
                if (!isMultideclaration)
                {
                    GeneralDeclaration();
                }
                else
                {
                    if (Utilities.CompareTokenType(TokenType.OpMultiplication))
                    {
                        IsPointer();
                    }

                    if (!Utilities.CompareTokenType(TokenType.Identifier))
                    {
                        throw new Exception("Identifier was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
                    }
                    Utilities.NextToken();
                }

                if (Utilities.CompareTokenType(TokenType.OpenSquareBracket))
                {
                    Utilities.NextToken();
                    Arrays.ArrayIdentifier();

                    if (!Utilities.CompareTokenType(TokenType.CloseSquareBracket))
                        throw new Exception("Closing bracket was expected at row: " + CurrentToken.Row + " , column: " +
                                            CurrentToken.Column);

                    Utilities.NextToken();

                    if (Utilities.CompareTokenType(TokenType.OpenSquareBracket))
                    {
                        Utilities.NextToken();
                        Arrays.ArrayIdentifier();

                        if (!Utilities.CompareTokenType(TokenType.CloseSquareBracket))
                            throw new Exception("Closing bracket was expected at row: " + CurrentToken.Row + " , column: " +
                                                CurrentToken.Column);

                        Utilities.NextToken();
                    }
                }

                if (Utilities.CompareTokenType(TokenType.Comma))
                {
                    Utilities.NextToken();
                    DeclarationOfStruct(true);
                }
                else if (Utilities.CompareTokenType(TokenType.EndOfSentence))
                {
                    Utilities.NextToken();
                    DeclarationOfStruct(false);
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

                if (Utilities.CompareTokenType(TokenType.OpMultiplication))
                {
                    //Structs as parameters for function
                    IsPointer();
                   // Utilities.NextToken();

                    //if (Utilities.CompareTokenType(TokenType.Identifier))
                    //{
                    //    Utilities.NextToken();
                    //}
                }
                if (Utilities.CompareTokenType(TokenType.Identifier))
                {
                    //Structs as parameters for function
                    Utilities.NextToken();
                }
            }
            else
            {
                throw new Exception("An Identifier was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
            }
        }

        private void Declaration()
        {
            GeneralDeclaration();
            TypeOfDeclaration();
        }

        public void TypeOfDeclaration()
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

                    if (Utilities.CompareTokenType(TokenType.EndOfSentence))
                    {
                        Utilities.NextToken();
                    }
                    else
                    {
                        throw new Exception("An End of sentence ; symbol was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
                    }
                }
                else
                {
                    throw new Exception("An End of sentence ; symbol was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
                }
            }
            else if (Utilities.CompareTokenType(TokenType.Comma))
            {
                Functions.MultiDeclaration();

                if (Utilities.CompareTokenType(TokenType.EndOfSentence))
                {
                    Utilities.NextToken();
                }
                else
                {
                    throw new Exception("An End of sentence ; symbol was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
                }
            }
            else if (Utilities.CompareTokenType(TokenType.OpenSquareBracket))
            {
                bool isInMultideclaration = false;
                Arrays.IsArrayDeclaration(isInMultideclaration);
                //Arrays.ArrayMultiDeclaration(isInMultideclaration);

                if (Utilities.CompareTokenType(TokenType.Comma))
                    Functions.MultiDeclaration(); 

                if (Utilities.CompareTokenType(TokenType.EndOfSentence))
                {
                    Utilities.NextToken();
                }
                else
                {
                    throw new Exception("An End of sentence ; symbol was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
                }
            }
            else if (Utilities.CompareTokenType(TokenType.OpenParenthesis))
            {
                Functions.IsFunctionDeclaration();
              //  Utilities.NextToken();
              //  return;
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

        public void ListOfExpressions(List<ExpressionNode> list)
        {
            var expression = Expressions.Expression();
            list.Add(expression);

            if (Utilities.CompareTokenType(TokenType.Comma))
            {
                OptionalExpression(list);
            }
        }

        public void OptionalExpression(List<ExpressionNode> list)
        {
            if (Utilities.CompareTokenType(TokenType.Comma))
            {
                Utilities.NextToken();
                ListOfExpressions(list);
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

                //if (Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
                //{
                //    Arrays.OptionalInitOfArray(true);
                //}else
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
                  //Arrays.ArrayMultiDeclaration(isInMultiDeclaration);
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

                    if (Utilities.CompareTokenType(TokenType.EndOfSentence))
                    {
                        Utilities.NextToken();
                    }
                    else
                    {
                        throw new Exception("An End of sentence ; symbol was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
                    }
                }
                else
                {
                    throw new Exception("An End of sentence ; symbol was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
                }
            }
            else if (Utilities.CompareTokenType(TokenType.Comma))
            {
                Functions.MultiDeclaration();

                if (Utilities.CompareTokenType(TokenType.EndOfSentence))
                {
                    Utilities.NextToken();
                }
                else
                {
                    throw new Exception("An End of sentence ; symbol was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
                }
            }
            else if (Utilities.CompareTokenType(TokenType.OpenSquareBracket))
            {
                bool isInMultideclaration = true;

                Arrays.IsArrayDeclaration(isInMultideclaration);

                if (Utilities.CompareTokenType(TokenType.Comma))
                    Functions.MultiDeclaration();

                if (Utilities.CompareTokenType(TokenType.EndOfSentence))
                {
                    Utilities.NextToken();
                }
                else
                {
                    throw new Exception("An End of sentence ; symbol was expected at row: " + CurrentToken.Row + " , column: " + CurrentToken.Column);
                }
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
