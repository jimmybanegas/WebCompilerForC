using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Tree;
using Syntax.Tree.Nodes.Acessors;
using Syntax.Tree.Nodes.BaseNodes;
using Syntax.Tree.Nodes.DataTypes;
using Syntax.Tree.Nodes.Declarations;

namespace Syntax.Parser
{
    public class Arrays
    {
        private readonly Parser _parser;

        public Arrays(Parser parser)
        {
            _parser = parser;
        }

        public List<AccessorNode> ArrayForFunctionsParameter()
        {
            List<AccessorNode> accesorNodes = new List<AccessorNode>(); 

            if (!_parser.Utilities.CompareTokenType(TokenType.OpenSquareBracket))
                throw new Exception("An openning bracket [ symbol was expected");

            _parser.Utilities.NextToken();

            bool hasSize;
            bool isUnidimensional = true;

            var accessor = SizeForArray(out hasSize);

            accesorNodes.Add((ArrayAccessorNode)accessor);

            if (!_parser.Utilities.CompareTokenType(TokenType.CloseSquareBracket))
                throw new Exception("An closing bracket ] symbol was expected");

            _parser.Utilities.NextToken();

            if (_parser.Utilities.CompareTokenType(TokenType.OpenSquareBracket))
            {
                var accessor2 = BidArray(out isUnidimensional);
                accesorNodes.Add(accessor2);
            }
            if (_parser.Utilities.CompareTokenType(TokenType.EndOfSentence) && hasSize && isUnidimensional)
            {
                _parser.Utilities.NextToken();
            }
            else if (_parser.Utilities.CompareTokenType(TokenType.EndOfSentence) && !isUnidimensional)
            {
                _parser.Utilities.NextToken();
            }
            //Cuando hay una multideclaracion de variables que lleva arreglos en ese conjunto
            else if (_parser.Utilities.CompareTokenType(TokenType.Comma))
            {
                List<GeneralDeclarationNode> list = new List<GeneralDeclarationNode>();
                _parser.Functions.OptionaListOfParams(list);
            }

            return accesorNodes;
        }

        public List<AccessorNode> IsArrayDeclaration(bool isInMultiDeclaration)
        {
            List<AccessorNode> accesorNodes = new List<AccessorNode>();

            if (!_parser.Utilities.CompareTokenType(TokenType.OpenSquareBracket))
                throw new Exception("An openning bracket [ symbol was expected");

            _parser.Utilities.NextToken();

            bool hasSize;
            bool isUnidimensional = true;

            var accessor = SizeForArray(out hasSize);
            accesorNodes.Add((ArrayAccessorNode)accessor);

            if (!_parser.Utilities.CompareTokenType(TokenType.CloseSquareBracket))
                throw new Exception("An closing bracket ] symbol was expected");

            _parser.Utilities.NextToken();

            if (_parser.Utilities.CompareTokenType(TokenType.OpenSquareBracket))
            {
               var accessor2 = BidArray(out isUnidimensional);
               accesorNodes.Add((ArrayAccessorNode)accessor2);
            }

            OptionalInitOfArray(true);
            //OptionalInitOfArray(true);
          
            if (_parser.Utilities.CompareTokenType(TokenType.Comma))
            {
               _parser.Functions.OptionalId();
            }

            if (_parser.Utilities.CompareTokenType(TokenType.OpSimpleAssignment))
            {
                _parser.Utilities.NextToken();
                OptionalInitOfArray(true);
            }
            else
            {

            }

            return accesorNodes;
        }

        public void OptionalInitOfArray(bool isInMultiDeclaration)
        {
            //_parser.Utilities.NextToken();
            if (_parser.Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
            {
                _parser.Utilities.NextToken();

                List<ExpressionNode> list = new List<ExpressionNode>();
                _parser.ListOfExpressions(list);

                if (_parser.Utilities.CompareTokenType(TokenType.CloseCurlyBracket))
                    _parser.Utilities.NextToken();
            }

            if (!isInMultiDeclaration)
            {
                if (!_parser.Utilities.CompareTokenType(TokenType.EndOfSentence))
                {
                    throw new Exception("End of sentence was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
                }
                _parser.Utilities.NextToken();
            }
        }

        public AccessorNode BidArray(out bool isUnidimensional)
        {
            if (!_parser.Utilities.CompareTokenType(TokenType.OpenSquareBracket))
                throw new Exception("An openning bracket [ symbol was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);

            _parser.Utilities.NextToken();

            var accessor = SizeForBidArray();

            if (_parser.Utilities.CompareTokenType(TokenType.CloseSquareBracket))
            {
                _parser.Utilities.NextToken();
            }
            else
            {
                throw new Exception("An closing bracket ] symbol was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }

            isUnidimensional = false;

            return accessor;
        }

        public AccessorNode SizeForBidArray()
        {
            if (_parser.Utilities.CompareTokenType(TokenType.LiteralNumber) 
                ||_parser.Utilities.CompareTokenType(TokenType.LiteralOctal)
                || _parser.Utilities.CompareTokenType(TokenType.LiteralHexadecimal) 
                ||_parser.Utilities.CompareTokenType(TokenType.Identifier))
            {
                //Para casos como  sum += arr[i++];   
                if (_parser.Utilities.CompareTokenType(TokenType.Identifier)    )
                {
                   var expression = _parser.Expressions.Expression();

                    return new ArrayAccessorNode
                    {
                        IndexExpression = expression
                    };
                }
                else
                {
                    _parser.Utilities.NextToken();
                }
              
            }
            else
            {
                throw new Exception("Initialization of array is required at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }

            return new ArrayAccessorNode();
        }

        private ExpressionNode SizeForArray(out bool hasSize)
        {
            ExpressionNode expression = new ArrayAccessorNode();

            if (_parser.Utilities.CompareTokenType(TokenType.LiteralNumber) 
                || _parser.Utilities.CompareTokenType(TokenType.LiteralOctal)
                || _parser.Utilities.CompareTokenType(TokenType.LiteralHexadecimal) 
                || _parser.Utilities.CompareTokenType(TokenType.Identifier))
            {
                //_parser.Utilities.NextToken();
                hasSize = true;

                expression = _parser.Expressions.Expression();
                //_parser.Utilities.NextToken();
                return new ArrayAccessorNode { IndexExpression = expression };
            }
            else
            {
                hasSize = false;
            }
            return expression;
        }

        public AccessorNode ArrayIdentifier()
        {
            var size = SizeForArray();

            if (!_parser.Utilities.CompareTokenType(TokenType.CloseSquareBracket))
            {
                throw new Exception("An closing bracket ] symbol was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }
            else
            {
                
            }
            return size;
        }

        private AccessorNode SizeForArray()
        {
            //    if (_parser.Utilities.CompareTokenType(TokenType.LiteralNumber))
            //    {
            //        _parser.Utilities.NextToken();
            //       // return  new IntegerNode { Value = Convert.ToInt32(_parser.CurrentToken.Lexeme) };
            //       //return new ArrayAccessorNode { IndexExpression =  }
            //    }
            //    if (_parser.Utilities.CompareTokenType(TokenType.LiteralOctal))
            //    {
            //        _parser.Utilities.NextToken();
            //        //return new OctalNode() { Value = _parser.CurrentToken.Lexeme };
            //    }
            //    if (_parser.Utilities.CompareTokenType(TokenType.LiteralHexadecimal))
            //    {
            //        _parser.Utilities.NextToken();
            //       // return new HexadecimalNode { Value = _parser.CurrentToken.Lexeme };
            //    }
            //    if (_parser.Utilities.CompareTokenType(TokenType.Identifier))
            //    {
            //        _parser.Utilities.NextToken();
            //        //return new IdentifierExpression { Value = _parser.CurrentToken.Lexeme };
      //    }
            if (_parser.Utilities.CompareTokenType(TokenType.LiteralNumber)
                || _parser.Utilities.CompareTokenType(TokenType.LiteralOctal)
                || _parser.Utilities.CompareTokenType(TokenType.LiteralHexadecimal) 
                || _parser.Utilities.CompareTokenType(TokenType.Identifier))
            {

                var expression = _parser.Expressions.Expression();
                //_parser.Utilities.NextToken();

                return new ArrayAccessorNode {IndexExpression = expression};
            }
            else
            {
                return null;
            }
        }
    }
}