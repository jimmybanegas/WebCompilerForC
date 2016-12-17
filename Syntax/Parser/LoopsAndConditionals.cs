using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Semantic;
using Syntax.Tree;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.GeneralSentences;
using Syntax.Tree.Identifier;
using Syntax.Tree.LoopsAndConditions;

namespace Syntax.Parser
{
    public class LoopsAndConditionals
    {
        private Parser _parser;

        public LoopsAndConditionals(Parser parser)
        {
            _parser = parser;
        }

        public StatementNode Continue()
        {
            _parser.Utilities.NextToken();

            if (_parser.Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
                _parser.Utilities.NextToken();
            }
            else
            {
                throw new Exception("End of sentence expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }

            return new ContinueNode();
        }

        public StatementNode Break()
        {
            _parser.Utilities.NextToken();

            if (_parser.Utilities.CompareTokenType(TokenType.EndOfSentence))
            {
                _parser.Utilities.NextToken();
            }
            else
            {
                throw new Exception("End of sentence expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }

            return new BreakNode();
        }

        public SwitchNode Switch()
        {
            bool insideFunction = StackContext.Context.CanDeclareReturn;

            StackContext.Context.CanDeclareBreak = true;
            StackContext.Context.CanDeclareReturn = true;
            StackContext.Context.CanDeclareContinue = true;

            _parser.Utilities.NextToken();

            if (!_parser.Utilities.CompareTokenType(TokenType.OpenParenthesis))
            {
                throw new Exception("Openning parenthesis expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }

            _parser.Utilities.NextToken();
            var expression = _parser.Expressions.Expression();

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

            List<CaseStatement> list = new List<CaseStatement>();
            List<CaseStatement> caseList = ListOfCase(list);

            if (!_parser.Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
            {
                throw new Exception("Closing bracket expectedat row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }

            _parser.Utilities.NextToken();


            if (!insideFunction)
            {
                StackContext.Context.CanDeclareReturn = false;
            }
            StackContext.Context.CanDeclareContinue = false;
            StackContext.Context.CanDeclareBreak = false;

            return new SwitchNode
            {
                CaseStatements = caseList, Expression = expression
            };

        }

        private List<CaseStatement> ListOfCase(List<CaseStatement> list)
        {
       
            if (_parser.Utilities.CompareTokenType(TokenType.RwCase))
            {
                var caseStatement = Case();

                list.Add(caseStatement);

                list = ListOfCase(list);
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.RwDefault))
            {
                var defaultCase = DefaultCase();

                list.Add(defaultCase);
            }
            else
            {
                
            }

            return list;
        }

        public CaseStatement DefaultCase()
        {
            _parser.Utilities.NextToken();

            if (!_parser.Utilities.CompareTokenType(TokenType.Colon))
                throw new Exception("Colon symbol expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);

            _parser.Utilities.NextToken();

            var sentences = _parser.ListOfSpecialSentences();

            if (_parser.Utilities.CompareTokenType(TokenType.RwBreak))
            {
                Break();
            }

            return new CaseStatement {Sentences = sentences};

        }

        private CaseStatement Case()
        {
           _parser.Utilities.NextToken();

            var expression = _parser.Expressions.Expression();

            if (!_parser.Utilities.CompareTokenType(TokenType.Colon))
                throw new Exception("Colon symbol expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);

            _parser.Utilities.NextToken();

            var sentences = _parser.ListOfSpecialSentences();
            
            if (_parser.Utilities.CompareTokenType(TokenType.RwBreak))
            {
                var breakSentence = Break();
                sentences.Add(breakSentence);
            }
            else
            {
                
            }
            return new CaseStatement
            {
                Expression = expression, Sentences = sentences
            };

        }

        public ForLoopNode ForLoop()
        {
            _parser.Utilities.NextToken();

            if (!_parser.Utilities.CompareTokenType(TokenType.OpenParenthesis))
                throw new Exception("Openning parenthesis expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);

            return ForOrForEach();
        }

        private ForLoopNode ForOrForEach()
        {
            //if true, it's inside a function
            bool insideFunction = StackContext.Context.CanDeclareReturn;

            StackContext.Context.CanDeclareBreak = true;
            StackContext.Context.CanDeclareReturn = true;
            StackContext.Context.CanDeclareContinue = true;

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
                var dataType = new IdentifierNode {Accessors = null, Value = _parser.CurrentToken.Lexeme};

                _parser.Utilities.NextToken();

                if (!_parser.Utilities.CompareTokenType(TokenType.Identifier))
                {
                    throw new Exception("Identifier was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
                }

                var itemIdentifier = new IdentifierNode { Accessors = null, Value = _parser.CurrentToken.Lexeme };

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

                var sentences = BlockForLoops();

                return new ForEachNode
                {
                    DataType = dataType, Item = itemIdentifier, Sentences = sentences
                };

            }
            else
            {
                var firstExpression = _parser.Expressions.Expression();

                if (!_parser.Utilities.CompareTokenType(TokenType.EndOfSentence))
                {
                    throw new Exception("Separator ; was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
                }
                _parser.Utilities.NextToken();

                var secondExpression = _parser.Expressions.Expression();

                if (!_parser.Utilities.CompareTokenType(TokenType.EndOfSentence))
                {
                    throw new Exception("Separator ; was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
                }

                _parser.Utilities.NextToken();

                var thirdExpression = _parser.Expressions.Expression();

                if (!_parser.Utilities.CompareTokenType(TokenType.CloseParenthesis))
                {
                    throw new Exception("Closing parenthesis was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
                }
             
               var sentences = BlockForLoops();

                if (!insideFunction)
                {
                    StackContext.Context.CanDeclareReturn = false;
                }
                StackContext.Context.CanDeclareContinue = false;
                StackContext.Context.CanDeclareBreak = false;

                return new ForNode
                {
                    FirstCondition = firstExpression,
                    SecondCondition = secondExpression,
                    ThirdCondition = thirdExpression,
                    Sentences = sentences
                };
            }
        }

        public DoWhileNode Do()
        {
            bool insideFunction = StackContext.Context.CanDeclareReturn;

            StackContext.Context.CanDeclareBreak = true;
            StackContext.Context.CanDeclareReturn = true;
            StackContext.Context.CanDeclareContinue = true;

            var sentences = BlockForLoops();

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

            var expression = _parser.Expressions.Expression();


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

            if (!insideFunction)
            {
                StackContext.Context.CanDeclareReturn = false;
            }
            StackContext.Context.CanDeclareContinue = false;
            StackContext.Context.CanDeclareBreak = false;

            return new DoWhileNode
            {
                Sentences = sentences, WhileCondition = expression
            };

        }

        public WhileNode While()
        {
            bool insideFunction = StackContext.Context.CanDeclareReturn;

            StackContext.Context.CanDeclareBreak = true;
            StackContext.Context.CanDeclareReturn = true;
            StackContext.Context.CanDeclareContinue = true;

            _parser.Utilities.NextToken();

            if (!_parser.Utilities.CompareTokenType(TokenType.OpenParenthesis))
            {
                throw new Exception("Opening parenthesis was expectedat row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }
            _parser.Utilities.NextToken();

            var expression = _parser.Expressions.Expression();

            if (!_parser.Utilities.CompareTokenType(TokenType.CloseParenthesis))
            {
                throw new Exception("Closing parenthesis was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }

            var sentences = BlockForLoops();

            if (!insideFunction)
            {
                StackContext.Context.CanDeclareReturn = false;
            }
            StackContext.Context.CanDeclareContinue = false;
            StackContext.Context.CanDeclareBreak = false;


            return new WhileNode
            {
                Sentences = sentences, WhileCondition = expression
            };
        }

        public IfNode If()
        {
            bool insideFunction = StackContext.Context.CanDeclareReturn;
            StackContext.Context.CanDeclareBreak = true;
            StackContext.Context.CanDeclareReturn = true;
            StackContext.Context.CanDeclareContinue = true;

            var trueBlock = new List<StatementNode>();
            var falseBlock = new List<StatementNode>();

            _parser.Utilities.NextToken();

            if (!_parser.Utilities.CompareTokenType(TokenType.OpenParenthesis))
            {
                throw new Exception("Opening parenthesis was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }

            _parser.Utilities.NextToken();

            var expression = _parser.Expressions.Expression();

            if (!_parser.Utilities.CompareTokenType(TokenType.CloseParenthesis))
            {
                throw new Exception("Closing parenthesis was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }

            var trueB = BlockForLoops();
            trueBlock.AddRange(trueB);

            var falseB = Else();
            falseBlock.AddRange(falseB);

            if (!insideFunction)
            {
                StackContext.Context.CanDeclareReturn = false;
            }
            StackContext.Context.CanDeclareContinue = false;
            StackContext.Context.CanDeclareBreak = false;


            return new IfNode
            {
                FalseBlock = falseBlock, IfCondition = expression, TrueBlock = trueBlock
            };
        }

        private List<StatementNode> Else()
        {
            if (_parser.Utilities.CompareTokenType(TokenType.RwElse))
            {
               var sentences = BlockForLoops();

               return sentences;
            }
            else
            {
                return new List<StatementNode>();
            }

        }

        private List<StatementNode> BlockForLoops()
        {
            List<StatementNode> list = new List<StatementNode>();

            _parser.Utilities.NextToken();

            if (_parser.Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
            {
                _parser.Utilities.NextToken();

                //Considerar hacer un sentences solo para los ciclos, porque son distintos
                //_parser.ListOfSpecialSentences();
                var sentences = _parser.ListOfSentences();

                if (sentences != null)
                {
                    list.AddRange(sentences);
                }

                if (!_parser.Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
                {
                    throw new Exception("Close curly bracket at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
                }

                _parser.Utilities.NextToken();
            }
            else
            {
                if (!_parser.Utilities.CompareTokenType(TokenType.EndOfSentence))
                {
                    var sentence = _parser.Sentence();
                    list.Add(sentence);
                }
                else
                {
                    throw new Exception("Unexpected token at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
                }
            }

            return list;
        }
    }
}