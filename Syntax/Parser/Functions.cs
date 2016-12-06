using System;
using System.Collections.Generic;
using Lexer;
using Syntax.Tree;
using Syntax.Tree.Acessors;
using Syntax.Tree.BaseNodes;
using Syntax.Tree.Declarations;
using Syntax.Tree.Identifier;
using Syntax.Tree.LoopsAndConditions.Functions;

namespace Syntax.Parser
{
    public class Functions
    {
        private readonly Parser _parser;
        public Functions(Parser parser)
        {
            _parser = parser;
        }

        public FunctionDeclarationNode IsFunctionDeclaration(GeneralDeclarationNode generalDecla)
        {
            var functionNode = new FunctionDeclarationNode {Identifier = generalDecla};

            if (!_parser.Utilities.CompareTokenType(TokenType.OpenParenthesis))
                throw new Exception("Open parenthesis expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);

            _parser.Utilities.NextToken();

            List<GeneralDeclarationNode> parameters = new List<GeneralDeclarationNode>();

            ParameterList(parameters);

            functionNode.Parameters = parameters;

            if (!_parser.Utilities.CompareTokenType(TokenType.CloseParenthesis))
                throw new Exception("Close parenthesis expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);

            _parser.Utilities.NextToken();

            if (_parser.Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
            {
                _parser.Utilities.NextToken();

               var sentences =  _parser.ListOfSpecialSentences();
               functionNode.Sentences = sentences;
            }

            if (_parser.Utilities.CompareTokenType(TokenType.CloseCurlyBracket) )
            {
                _parser.Utilities.NextToken();
            }
            else
            {
                throw new Exception("Close function body symbol expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }

            functionNode.Position = _parser.CurrentToken;

            return functionNode;
        }

        private void ParameterList(List<GeneralDeclarationNode> parameters)
        {
            if (_parser.Utilities.CompareTokenType(TokenType.RwChar) 
                || _parser.Utilities.CompareTokenType(TokenType.RwString)
                || _parser.Utilities.CompareTokenType(TokenType.RwInt) 
                || _parser.Utilities.CompareTokenType(TokenType.RwDate)
                || _parser.Utilities.CompareTokenType(TokenType.RwDouble) 
                || _parser.Utilities.CompareTokenType(TokenType.RwBool)
                || _parser.Utilities.CompareTokenType(TokenType.RwLong)
                || _parser.Utilities.CompareTokenType(TokenType.RwFloat)
                || _parser.Utilities.CompareTokenType(TokenType.RwVoid)
                || _parser.Utilities.CompareTokenType(TokenType.RwStruct))//Structs as parameter of function
            {
                var name = _parser.CurrentToken.Lexeme;
                _parser.Utilities.NextToken();

                var param =  _parser.ChooseIdType(name);
                parameters.Add(param);
                
                OptionaListOfParams(parameters);
            }
            else
            {
                
            }
        }

        public void OptionaListOfParams(List<GeneralDeclarationNode> parameters)
        {
            if (_parser.Utilities.CompareTokenType(TokenType.Comma))
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
                    || _parser.Utilities.CompareTokenType(TokenType.RwVoid)
                    || _parser.Utilities.CompareTokenType(TokenType.RwStruct))
                {
                    var name = _parser.CurrentToken.Lexeme;
                    _parser.Utilities.NextToken();

                    var identifier = _parser.ChooseIdType(name);
                    parameters.Add(identifier);

                    OptionaListOfParams(parameters);
                }
                else
                {
                    
                }
            }
            else
            {
                //throw new Exception("A comma was expected");
            }
         
        }
        public void OptionalId(List<IdentifierNode> listOptional)
        {
           // var list = new List<IdentifierNode>();
            if (_parser.Utilities.CompareTokenType(TokenType.Comma))
            {
                _parser.ListOfId(listOptional);
            }
            else
            {
                
            }
           // return list;
        }

        public List<ExpressionNode> CallFunction()
        {
            List<ExpressionNode> listOfExpressions = new List<ExpressionNode>();

            if (!_parser.Utilities.CompareTokenType(TokenType.OpenParenthesis))
            {
                throw new Exception("Open parenthesis ( symbol was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }

            _parser.Utilities.NextToken();

            if (_parser.Utilities.CompareTokenType(TokenType.CloseParenthesis))
            {
                _parser.Utilities.NextToken();
            }
            else
            {
                return ListOfExpressions(listOfExpressions);
            }

            return listOfExpressions;

        }
        private List<ExpressionNode> ListOfExpressions(List<ExpressionNode> listOfExpressions)
        {
            if (_parser.Utilities.CompareTokenType(TokenType.OpMultiplication))
            {
                List<PointerNode> listOfPointer = new List<PointerNode>();
                _parser.IsPointer(listOfPointer);
            }

            var expression = _parser.Expressions.Expression();

            listOfExpressions.Add(expression);

            if (_parser.Utilities.CompareTokenType(TokenType.Comma))
            {
                _parser.Utilities.NextToken();

                OptionalListOfExpressions(listOfExpressions);
            }
            else
            {
                _parser.Utilities.NextToken();
            }

            return listOfExpressions;
        }
        private void OptionalListOfExpressions(List<ExpressionNode> listOfExpressions)
        {
            ListOfExpressions(listOfExpressions);
        }
    }
}