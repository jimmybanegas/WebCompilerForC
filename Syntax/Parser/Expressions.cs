using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Tree.Acessors;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.DataTypes;
using Syntax.Tree.Identifier;
using Syntax.Tree.LoopsAndConditions.Functions;
using Syntax.Tree.Operators.Binary;
using Syntax.Tree.Operators.Unary;

namespace Syntax.Parser
{
    public class Expressions
    {
        private readonly Parser _parser;

        public Expressions(Parser parser)
        {
            _parser = parser;
        }

        public ExpressionNode Expression()
        {
            return RelationalExpression();
        }

        private ExpressionNode RelationalExpression()       
        {
            var expression = ExpressionAddition();
            var relational = RelationalExpressionPrime(expression);

            return relational;
        }

        private ExpressionNode RelationalExpressionPrime(ExpressionNode expression)
        {
            if (_parser.Utilities.CompareTokenType(TokenType.OpLessThan)
                ||_parser.Utilities.CompareTokenType(TokenType.OpLessThanOrEqualTo)
                ||_parser.Utilities.CompareTokenType(TokenType.OpGreaterThan)
                ||_parser.Utilities.CompareTokenType(TokenType.OpGreaterThanOrEqualTo)
                ||_parser.Utilities.CompareTokenType(TokenType.OpAnd)
                ||_parser.Utilities.CompareTokenType(TokenType.OpLogicalOr)
                ||_parser.Utilities.CompareTokenType(TokenType.OpBitShiftRight)
                ||_parser.Utilities.CompareTokenType(TokenType.OpBitShiftLeft)
                ||_parser.Utilities.CompareTokenType(TokenType.OpEqualTo)
                ||_parser.Utilities.CompareTokenType(TokenType.OpBitAnd)
                ||_parser.Utilities.CompareTokenType(TokenType.OpBitOr)
                ||_parser.Utilities.CompareTokenType(TokenType.OpBitXor)
                ||_parser.Utilities.CompareTokenType(TokenType.OpNotEqualTo)
                ||_parser.Utilities.CompareTokenType(TokenType.OpAddAndAssignment)
                ||_parser.Utilities.CompareTokenType(TokenType.OpSusbtractAndAssignment)
                ||_parser.Utilities.CompareTokenType(TokenType.OpMultiplyAndAssignment)
                ||_parser.Utilities.CompareTokenType(TokenType.OpDivideAssignment)
                ||_parser.Utilities.CompareTokenType(TokenType.OpModulusAssignment)
                ||_parser.Utilities.CompareTokenType(TokenType.OpBitwiseAndAssignment)
                ||_parser.Utilities.CompareTokenType(TokenType.OpBitwiseXorAndAssignment)
                ||_parser.Utilities.CompareTokenType(TokenType.OpBitwiseInclusiveOrAndAssignment)
                ||_parser.Utilities.CompareTokenType(TokenType.OpSimpleAssignment))
            {
                var operation = RelationalOperators();
                var exprAddition = ExpressionAddition();

                operation.LeftOperand = expression;
                operation.RightOperand = exprAddition;

                return RelationalExpressionPrime(operation);
            }
            return expression;
        }

        private BinaryOperatorNode RelationalOperators()
        {
            var position = new Token { Row =  _parser.CurrentToken.Row, Column = _parser.CurrentToken.Column};

            if (_parser.Utilities.CompareTokenType(TokenType.OpLessThan))
            {
                _parser.Utilities.NextToken();
                return new LessThanOperatorNode {Position = position};
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpLessThanOrEqualTo))
            {
                _parser.Utilities.NextToken();
                return new LessThanOrEqualToOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpGreaterThan))
            {
                _parser.Utilities.NextToken();
                return new GreaterThanOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpGreaterThanOrEqualTo))
            {
                _parser.Utilities.NextToken();
                return new GreaterOrEqualOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpGreaterThanOrEqualTo))
            {
                _parser.Utilities.NextToken();
                return new GreaterOrEqualOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpAnd))
            {
                _parser.Utilities.NextToken();
                return new AndOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpLogicalOr))
            {
                _parser.Utilities.NextToken();
                return new LogicalOrOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpBitShiftRight))
            {
                _parser.Utilities.NextToken();
                return new ShiftRightOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpBitShiftLeft))
            {
                _parser.Utilities.NextToken();
                return new ShiftLeftOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpEqualTo))
            {
                _parser.Utilities.NextToken();
                return new EqualToOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpEqualTo))
            {
                _parser.Utilities.NextToken();
                return new EqualToOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpBitAnd))
            {
                _parser.Utilities.NextToken();
                return new BitwiseAndOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpBitOr))
            {
                _parser.Utilities.NextToken();
                return new BitwiseOrOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpBitXor))
            {
                _parser.Utilities.NextToken();
                return new BitBinXorOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpNotEqualTo))
            {
                _parser.Utilities.NextToken();
                return new NotEqualToOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpAddAndAssignment))
            {
                _parser.Utilities.NextToken();
                return new AddAndAssignmentOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpSusbtractAndAssignment))
            {
                _parser.Utilities.NextToken();
                return new SubstractAndAssignmentOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpMultiplyAndAssignment))
            {
                _parser.Utilities.NextToken();
                return new MultiplicationAndAssignmentOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpDivideAssignment))
            {
                _parser.Utilities.NextToken();
                return new DivisionAndAssignmentOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpModulusAssignment))
            {
                _parser.Utilities.NextToken();
                return new ModuleAndAssignmentOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpBitwiseAndAssignment))
            {
                _parser.Utilities.NextToken();
                return new BitwiseAndAssignmentOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpBitwiseXorAndAssignment))
            {
                _parser.Utilities.NextToken();
                return new BitwiseXorAndAssignmentOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpBitwiseInclusiveOrAndAssignment))
            {
                _parser.Utilities.NextToken();
                return new BitwiseInclusiveOrAndAssignmentOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpSimpleAssignment))
            {
                _parser.Utilities.NextToken();
                return new SimpleAssignmentOperatorNode { Position = position };
            }
            throw new Exception("A relational operator was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
        }

        private ExpressionNode ExpressionAddition()
        {
            var multiplication = ExpressionMultiplication();
            var addition = ExpressionAdditionPrime(multiplication);

            return addition;
        }

        private ExpressionNode ExpressionAdditionPrime(ExpressionNode multiplication)
        {
            if (_parser.Utilities.CompareTokenType(TokenType.OpAdd)
                || _parser.Utilities.CompareTokenType(TokenType.OpSubstraction))
            {
                var operation = AdditiveOperrators();
                var exprMult = ExpressionMultiplication();


                operation.LeftOperand = multiplication;
                operation.RightOperand = exprMult; 

                return ExpressionAdditionPrime(operation);
            }
            else
            {
                return multiplication;
            }
        }

        private BinaryOperatorNode AdditiveOperrators()
        {
            var position = new Token { Row = _parser.CurrentToken.Row, Column = _parser.CurrentToken.Column };

            if (_parser.Utilities.CompareTokenType(TokenType.OpAdd))
            {
                _parser.Utilities.NextToken();
                return new AdditionOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpSubstraction))
            {
                _parser.Utilities.NextToken();
                return new SubstractionOperatorNode { Position = position };
            }

            throw new Exception("An additive operator was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
        }

        private ExpressionNode ExpressionMultiplication()
        {
            var unary = ExpressionUnary();
            var multiplication = ExpressionMultiplicationPrime(unary);

            return multiplication;
        }

        private ExpressionNode ExpressionMultiplicationPrime(ExpressionNode unary)
        {
            if (_parser.Utilities.CompareTokenType(TokenType.OpDivision)
                || _parser.Utilities.CompareTokenType(TokenType.OpMultiplication)
                || _parser.Utilities.CompareTokenType(TokenType.OpModule))
            {
                var operation =  MultiplicativeOperators();
                var unaryExpre = ExpressionUnary();

                operation.LeftOperand = unary;
                operation.RightOperand = unaryExpre;

                return ExpressionMultiplicationPrime(operation);
            }
            else
            {
                return unary;
            }
        }

        private BinaryOperatorNode MultiplicativeOperators()
        {
            var position = new Token { Row = _parser.CurrentToken.Row, Column = _parser.CurrentToken.Column };

            if (_parser.Utilities.CompareTokenType(TokenType.OpMultiplication))
            {
                _parser.Utilities.NextToken();
                return new MultiplicationOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpDivision))
            {
                _parser.Utilities.NextToken();
                return new DivisionOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpModule))
            {
                _parser.Utilities.NextToken();
                return new ModuleOperatorNode { Position = position };
            }
 
            throw  new Exception("A multiplicative operator was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
        }

        private ExpressionNode ExpressionUnary()
        {
            var unaryExpression = new ExpressionUnaryNode();

            if (_parser.Utilities.CompareTokenType(TokenType.OpComplement)
                ||_parser.Utilities.CompareTokenType(TokenType.OpIncrement)
                ||_parser.Utilities.CompareTokenType(TokenType.OpDecrement)
                ||_parser.Utilities.CompareTokenType(TokenType.OpBitAnd)
                ||_parser.Utilities.CompareTokenType(TokenType.OpBitOr)
                ||_parser.Utilities.CompareTokenType(TokenType.OpNot)
                ||_parser.Utilities.CompareTokenType(TokenType.OpComplement)
                ||_parser.Utilities.CompareTokenType(TokenType.OpBitXor)
                ||_parser.Utilities.CompareTokenType(TokenType.OpMultiplication)
                ||_parser.Utilities.CompareTokenType(TokenType.OpSubstraction))
            {
                unaryExpression.UnaryOperator = UnaryOperators();
            }
     
            var factorExpression = Factor();

            unaryExpression.Factor = factorExpression;

            return unaryExpression;
        }

        private UnaryOperator UnaryOperators()
        {
            var position = new Token { Row = _parser.CurrentToken.Row, Column = _parser.CurrentToken.Column };

            if (_parser.Utilities.CompareTokenType(TokenType.OpComplement))
            {
                _parser.Utilities.NextToken();
                return new ComplementOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpIncrement))
            {
                _parser.Utilities.NextToken();
                return new PostIncrementOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpDecrement))
            {
                _parser.Utilities.NextToken();
                return new PostDecrementOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpBitAnd))
            {
                _parser.Utilities.NextToken();
                return new BitAndOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpBitOr))
            {
                _parser.Utilities.NextToken();
                return new BitOrOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpNot))
            {
                _parser.Utilities.NextToken();
                return new NotOperatorNode { Position = position };
            }
            //if (_parser.Utilities.CompareTokenType(TokenType.OpBitXor))
            //{
            //    _parser.Utilities.NextToken();
            //    return new BitXorOperatorNode();
            //}
            if (_parser.Utilities.CompareTokenType(TokenType.OpMultiplication))
            {
                _parser.Utilities.NextToken();
                return new ReferenceOperatorNode { Position = position };
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpSubstraction))
            {
                _parser.Utilities.NextToken();
                return new NegativeOperatorNode { Position = position };
            }
          
            throw new Exception("An unary operator was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
        }

        private ExpressionNode Factor()
        {
            var position = new Token { Row = _parser.CurrentToken.Row, Column =_parser.CurrentToken.Column };

            if (_parser.Utilities.CompareTokenType(TokenType.Identifier))
            {
                var value = _parser.CurrentToken.Lexeme;
                var identifier = new IdentifierExpression {Name = value, Position = position};

                _parser.Utilities.NextToken();

                if (_parser.Utilities.CompareTokenType(TokenType.OpIncrement)
                    ||_parser.Utilities.CompareTokenType(TokenType.OpDecrement))
                {

                    if (_parser.Utilities.CompareTokenType(TokenType.OpIncrement))
                    {
                        identifier = new IdentifierExpression
                        {
                            Accessors = null,
                            Name = value,
                            IncrementOrdecrement = new PostIncrementOperatorNode { Value = _parser.CurrentToken.Lexeme, Position = position},
                            Position = position
                        };
                    }
                    else if (_parser.Utilities.CompareTokenType(TokenType.OpDecrement))
                    {
                        identifier = new IdentifierExpression
                        {
                            Accessors = null,
                            Name = value,
                            IncrementOrdecrement = new PostDecrementOperatorNode { Value = _parser.CurrentToken.Lexeme,Position = position},
                            Position = position
                        };
                    }

                  
                    _parser.Utilities.NextToken();

                    return identifier;
                }

               return  FactorFunctionOrArray(value);
            }
            if (_parser.Utilities.CompareTokenType(TokenType.LiteralNumber))
            {
                var value = int.Parse(_parser.CurrentToken.Lexeme);

                _parser.Utilities.NextToken();

                return new IntegerNode {Value = value, Position = position};
            }
            if (_parser.Utilities.CompareTokenType(TokenType.LiteralDecimal))
            {
                var value = decimal.Parse(_parser.CurrentToken.Lexeme);

                _parser.Utilities.NextToken();

                return new DecimalNode { Value = value, Position = position};
            }
            if (_parser.Utilities.CompareTokenType(TokenType.LiteralChar))
            {
                var value = _parser.CurrentToken.Lexeme;

                _parser.Utilities.NextToken();

                return new CharNode { Value = value , Position = position};
            }
            if (_parser.Utilities.CompareTokenType(TokenType.LiteralDate))
            {
                var value = _parser.CurrentToken.Lexeme;

                _parser.Utilities.NextToken();

                return new DateNode { Value = value , Position = position};
            }
            if (_parser.Utilities.CompareTokenType(TokenType.LiteralFloat))
            {
                var value = float.Parse(_parser.CurrentToken.Lexeme);

                _parser.Utilities.NextToken();

                return new FloatNode { Value = value, Position = position};
            }
            if (_parser.Utilities.CompareTokenType(TokenType.LiteralHexadecimal))
            {
                var value = _parser.CurrentToken.Lexeme;

                _parser.Utilities.NextToken();

                return new HexadecimalNode { Value = value , Position = position};
            }
            if (_parser.Utilities.CompareTokenType(TokenType.LiteralOctal))
            {
                var value = _parser.CurrentToken.Lexeme;

                _parser.Utilities.NextToken();

                return new OctalNode { Value = value, Position = position};
            }
            if (_parser.Utilities.CompareTokenType(TokenType.LiteralString))
            {
                var value = _parser.CurrentToken.Lexeme;

                _parser.Utilities.NextToken();

                return new StringNode { Value = value , Position = position};
            }
            if (_parser.Utilities.CompareTokenType(TokenType.RwTrue))
            {
                var value = _parser.CurrentToken.Lexeme;

                _parser.Utilities.NextToken();

                return new BooleanNode { Value = true, Position = position};
            }
            if (_parser.Utilities.CompareTokenType(TokenType.RwFalse))
            {
                var value = _parser.CurrentToken.Lexeme;

                _parser.Utilities.NextToken();

                return new BooleanNode { Value = false , Position = position};
            }
            if (_parser.Utilities.CompareTokenType(TokenType.OpenParenthesis))
            {
                _parser.Utilities.NextToken();

                var expression = Expression();

                if (_parser.Utilities.CompareTokenType(TokenType.CloseParenthesis))
                    _parser.Utilities.NextToken();
                else
                {
                    throw new Exception("Closing parenthesis expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
                }

                return expression;
            }
            throw new Exception("Factor was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
        }

        private ExpressionNode FactorFunctionOrArray(string value)
        {
            var position = new Token { Row = _parser.CurrentToken.Row, Column = _parser.CurrentToken.Column };

            if (_parser.Utilities.CompareTokenType(TokenType.OpenParenthesis))
            { 
                var listOfExpressions = _parser.Functions.CallFunction();

                return new CallFunctionNode
                {
                    Name = value, ListOfExpressions = listOfExpressions, Position = position
                };
            }

            List<AccessorNode> listOfAccessors = new List<AccessorNode>();

            return IndexOrArrowAccess(value, listOfAccessors);
        }

        public ExpressionNode IndexOrArrowAccess(string value, List<AccessorNode> listOfAccessors)
        {
            var position = new Token { Row = _parser.CurrentToken.Row, Column = _parser.CurrentToken.Column };

            if (_parser.Utilities.CompareTokenType(TokenType.OpenSquareBracket))
            {
                _parser.Utilities.NextToken();

                var accessor = _parser.Arrays.SizeForBidArray();

                listOfAccessors.Add(accessor);

                if (!_parser.Utilities.CompareTokenType(TokenType.CloseSquareBracket))
                {
                    throw new Exception("Closing bracket expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
                }

                _parser.Utilities.NextToken();
                
                if (_parser.Utilities.CompareTokenType(TokenType.OpenSquareBracket) || _parser.Utilities.CompareTokenType(TokenType.OpPointerStructs)
                    || _parser.Utilities.CompareTokenType(TokenType.Dot))
                {
                    return IndexOrArrowAccess(value, listOfAccessors);
                }

                return new IdentifierExpression {Accessors = listOfAccessors, Name = value, Position = position};

            }

            if(_parser.Utilities.CompareTokenType(TokenType.OpPointerStructs)
               ||_parser.Utilities.CompareTokenType(TokenType.Dot))
            {
                var IsPointerStrcut = ArrowOrPointer(listOfAccessors);

                position = new Token { Row = _parser.CurrentToken.Row, Column = _parser.CurrentToken.Column };

                if (_parser.Utilities.CompareTokenType(TokenType.OpMultiplication))
                {
                    List<PointerNode> listOfPointer = new List<PointerNode>();
                    _parser.IsPointer(listOfPointer);
                }

                if (!_parser.Utilities.CompareTokenType(TokenType.Identifier))
                {
                    throw new Exception("Identifier expected )");
                }

                _parser.Utilities.NextToken();

                return IndexOrArrowAccess(value, listOfAccessors);
            }

            return new IdentifierExpression {Accessors = listOfAccessors, Name = value , Position = position};
        }

        public bool ArrowOrPointer(List<AccessorNode> listOfAccessors)
        {
            var position = new Token { Row = _parser.CurrentToken.Row, Column = _parser.CurrentToken.Column };
            if (_parser.Utilities.CompareTokenType(TokenType.OpPointerStructs))
            {
                _parser.Utilities.NextToken();
                listOfAccessors.Add(new PointerAccessorNode
                {
                    IdentifierNode = new IdentifierNode
                    {
                        Accessors = new List<AccessorNode>(),
                        Value = _parser.CurrentToken.Lexeme,
                        Position = position
                    }
                });
                return true;
            }
            if (_parser.Utilities.CompareTokenType(TokenType.Dot))
            {
                _parser.Utilities.NextToken();
                listOfAccessors.Add(new PropertyAccessorNode
                {
                    IdentifierNode =  new IdentifierNode
                    {
                        Accessors = new List<AccessorNode>(),Value = _parser.CurrentToken.Lexeme, Position = position
                    }
                });
                return false;
            }

            throw new Exception("A pointer access symbol was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
        }
    }
}