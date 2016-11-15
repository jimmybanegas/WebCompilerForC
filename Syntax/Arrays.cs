using System;
using Lexer;

namespace Syntax
{
    public class Arrays
    {
        private readonly Parser _parser;

        public Arrays(Parser parser)
        {
            _parser = parser;
        }

        public void ArrayForFunctionsParameter()
        {
            if (!_parser.Utilities.CompareTokenType(TokenType.OpenSquareBracket))
                throw new Exception("An openning bracket [ symbol was expected");

            _parser.Utilities.NextToken();

            bool hasSize;
            bool isUnidimensional = true;

            SizeForArray(out hasSize);

            if (!_parser.Utilities.CompareTokenType(TokenType.CloseSquareBracket))
                throw new Exception("An closing bracket ] symbol was expected");

            _parser.Utilities.NextToken();

            if (_parser.Utilities.CompareTokenType(TokenType.OpenSquareBracket))
            {
                BidArray(out isUnidimensional);
            }
            if ((_parser.Utilities.CompareTokenType(TokenType.EndOfSentence) && hasSize && isUnidimensional))
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
                _parser.Functions.OptionaListOfParams();
            }
        }

        public void IsArrayDeclaration(bool isInMultiDeclaration)
        {
            //if (!_parser.Utilities.CompareTokenType(TokenType.OpenSquareBracket))
            //    throw new Exception("An openning bracket [ symbol was expected");

            //_parser.Utilities.NextToken();

            //bool hasSize;
            //bool isUnidimensional = true;

            //SizeForArray(out hasSize);

            //if (!_parser.Utilities.CompareTokenType(TokenType.CloseSquareBracket))
            //    throw new Exception("An closing bracket ] symbol was expected");

            //_parser.Utilities.NextToken();

            //if (_parser.Utilities.CompareTokenType(TokenType.OpenSquareBracket))
            //{
            //    BidArray(out isUnidimensional);
            //}

            //if (_parser.Utilities.CompareTokenType(TokenType.OpSimpleAssignment) && !isUnidimensional)
            //{
            //    OptionalInitOfArray(isInMultiDeclaration);
            //}

            //if ((_parser.Utilities.CompareTokenType(TokenType.EndOfSentence) && hasSize && isUnidimensional))
            //{
            //    _parser.Utilities.NextToken();
            //}
            //else if (_parser.Utilities.CompareTokenType(TokenType.EndOfSentence) && !isUnidimensional)
            //{
            //    _parser.Utilities.NextToken();
            //}
            //else if (isUnidimensional && _parser.Utilities.CompareTokenType(TokenType.OpSimpleAssignment))
            //{
            //    if (!_parser.Utilities.CompareTokenType(TokenType.OpSimpleAssignment))
            //    {
            //        throw new Exception("An assignment symbol was expected");
            //    }

            //    OptionalInitOfArray(isInMultiDeclaration);
            //}
            //else if (isUnidimensional && !hasSize)
            //{
            //    if (!_parser.Utilities.CompareTokenType(TokenType.OpSimpleAssignment))
            //    {
            //        throw new Exception("An assignment symbol was expected");
            //    }

            //    OptionalInitOfArray(isInMultiDeclaration);
            //}
            ////Cuando hay una multideclaracion de variables que lleva arreglos en ese conjunto
            //else if (_parser.Utilities.CompareTokenType(TokenType.Comma))
            //{
            //    _parser.OptionalExpression();

            //    if (!_parser.Utilities.CompareTokenType(TokenType.EndOfSentence))
            //    {
            //        throw new Exception("An End of sentence ; symbol was expected");
            //    }

            //    _parser.Utilities.NextToken();
            //}
            //else
            //{
            //    throw new Exception("An End of sentence ; symbol was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);       
            //}

            if (!_parser.Utilities.CompareTokenType(TokenType.OpenSquareBracket))
                throw new Exception("An openning bracket [ symbol was expected");

            _parser.Utilities.NextToken();

            bool hasSize;
            bool isUnidimensional = true;

            SizeForArray(out hasSize);

            if (!_parser.Utilities.CompareTokenType(TokenType.CloseSquareBracket))
                throw new Exception("An closing bracket ] symbol was expected");

            _parser.Utilities.NextToken();

            if (_parser.Utilities.CompareTokenType(TokenType.OpenSquareBracket))
            {
                BidArray(out isUnidimensional);
            }

            InitOfArray(true);
            //OptionalInitOfArray(true);
          
            if (_parser.Utilities.CompareTokenType(TokenType.Comma))
            {
                // _parser.TypeOfDeclaration();
                //_parser.Utilities.NextToken();
                _parser.Functions.OptionalId();
            }

            if (_parser.Utilities.CompareTokenType(TokenType.OpSimpleAssignment))
            {
                _parser.Utilities.NextToken();
                InitOfArray(true);
            }
            else
            {

            }
            //if (_parser.Utilities.CompareTokenType(TokenType.EndOfSentence))
            //{
            //    _parser.Utilities.NextToken();
            //}
            //else
            //{
            //    throw new Exception("An End of sentence ; symbol was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            //}

            //if (_TokenActual.Tipo == TokenTipos.LlaveIzquierdo)
            //{
            //    _TokenActual = lexico.ObtenerSiguienteToken();
            //    SizeForArray();
            //    if (_TokenActual.Tipo != TokenTipos.LlaveDerecho)
            //    {
            //        throw new SintanticoException("Se esperaba  ]");
            //    }
            //    _TokenActual = lexico.ObtenerSiguienteToken();
            //    BidArray();
            //    OptionalInitOfArray();
            //    if (_TokenActual.Tipo != TokenTipos.FinalDeSentencia)
            //    {
            //        throw new SintanticoException("Se esperaba  ;");
            //    }
            //    _TokenActual = lexico.ObtenerSiguienteToken();
            //}

        }

        //public void ArrayMultiDeclaration(bool isInMultiDeclaration)
        //{
        //    if (!_parser.Utilities.CompareTokenType(TokenType.OpenSquareBracket))
        //        throw new Exception("An openning bracket [ symbol was expected");

        //    _parser.Utilities.NextToken();

        //    bool hasSize;
        //    bool isUnidimensional = true;

        //    SizeForArray(out hasSize);

        //    if (!_parser.Utilities.CompareTokenType(TokenType.CloseSquareBracket))
        //        throw new Exception("An closing bracket ] symbol was expected");

        //    _parser.Utilities.NextToken();

        //    if (_parser.Utilities.CompareTokenType(TokenType.OpenSquareBracket))
        //    {
        //        BidArray(out isUnidimensional);
        //    }
        //    if ((_parser.Utilities.CompareTokenType(TokenType.EndOfSentence) && hasSize && isUnidimensional))
        //    {
        //        _parser.Utilities.NextToken();
        //    }
        //    else if (_parser.Utilities.CompareTokenType(TokenType.EndOfSentence) && !isUnidimensional)
        //    {
        //        _parser.Utilities.NextToken();
        //    }
        //    //Cuando hay una multideclaracion de variables que lleva arreglos en ese conjunto
        //    else if (_parser.Utilities.CompareTokenType(TokenType.Comma) 
        //        || _parser.Utilities.CompareTokenType(TokenType.OpSimpleAssignment))
        //    {
        //        _parser.TypeOfDeclaration();
        //    }
        //}

        public void OptionalInitOfArray(bool isInMultiDeclaration)
        {
            _parser.Utilities.NextToken();
            if (_parser.Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
            {
                _parser.Utilities.NextToken();
                _parser.ListOfExpressions();
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

        public void InitOfArray(bool isInMultiDeclaration)
        {
            //_parser.Utilities.NextToken();
            if (_parser.Utilities.CompareTokenType(TokenType.OpenCurlyBracket))
            {
                _parser.Utilities.NextToken();
                _parser.ListOfExpressions();
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

        public void BidArray(out bool isUnidimensional)
        {
            if (!_parser.Utilities.CompareTokenType(TokenType.OpenSquareBracket))
                throw new Exception("An openning bracket [ symbol was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);

            _parser.Utilities.NextToken();

            SizeForBidArray();

            if (_parser.Utilities.CompareTokenType(TokenType.CloseSquareBracket))
            {
                _parser.Utilities.NextToken();
            }
            else
            {
                throw new Exception("An closing bracket ] symbol was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }

            isUnidimensional = false;
        }

        public void SizeForBidArray()
        {
            if (_parser.Utilities.CompareTokenType(TokenType.LiteralNumber) 
                ||_parser.Utilities.CompareTokenType(TokenType.LiteralOctal)
                || _parser.Utilities.CompareTokenType(TokenType.LiteralHexadecimal) 
                ||_parser.Utilities.CompareTokenType(TokenType.Identifier))
            {
                //Para casos como  sum += arr[i++];   
                if (_parser.Utilities.CompareTokenType(TokenType.Identifier)    )
                {
                    _parser.Expressions.Expression();
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
        }

        private void SizeForArray(out bool hasSize)
        {
            if (_parser.Utilities.CompareTokenType(TokenType.LiteralNumber) 
                || _parser.Utilities.CompareTokenType(TokenType.LiteralOctal)
                || _parser.Utilities.CompareTokenType(TokenType.LiteralHexadecimal) 
                || _parser.Utilities.CompareTokenType(TokenType.Identifier))
            {
                _parser.Utilities.NextToken();
                hasSize = true;
            }
            else
            {
                hasSize = false;
            }
        }

        public void ArrayIdentifier()
        {
            SizeForArray();

            if (!_parser.Utilities.CompareTokenType(TokenType.CloseSquareBracket))
            {
                throw new Exception("An closing bracket ] symbol was expected at row: " + _parser.CurrentToken.Row + " , column: " + _parser.CurrentToken.Column);
            }
            else
            {
                
            }
        }

        private void SizeForArray()
        {
            if (_parser.Utilities.CompareTokenType(TokenType.LiteralNumber)
                || _parser.Utilities.CompareTokenType(TokenType.LiteralOctal)
                || _parser.Utilities.CompareTokenType(TokenType.LiteralHexadecimal) 
                || _parser.Utilities.CompareTokenType(TokenType.Identifier))
            {
                _parser.Utilities.NextToken();
            }
            else
            {
            }
        }
    }
}