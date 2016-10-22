using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lexer
{
    public class ReserverdWords
    {
        public readonly Dictionary<string, TokenType> _keywords;
        public Dictionary<string, TokenType> _operators;
        public Dictionary<string, TokenType> _separators;

        //This one, the especial is used for the operators which are composed by two operators
        public List<char> _specialSymbols;

        public ReserverdWords()
        {
            _keywords = new Dictionary<string, TokenType>();
            _operators = new Dictionary<string, TokenType>();
            _separators = new Dictionary<string,TokenType>();
            _specialSymbols = new List<char>();

            InitializeKeywords();
            InitializeOperators();
            InitializeSeparators();
            InitializeSpecial();
        }

        private void InitializeSpecial()
        {
            _specialSymbols.Add('<');
            _specialSymbols.Add('>');
            _specialSymbols.Add('=');
            _specialSymbols.Add('&');
            _specialSymbols.Add('|');
            _specialSymbols.Add('+');
            _specialSymbols.Add('-');
            _specialSymbols.Add('/');
            _specialSymbols.Add('*');
        }

        private void InitializeSeparators()
        {
           //      
            _separators.Add("(", TokenType.OpenParenthesis);
            _separators.Add(")", TokenType.CloseParenthesis);
            _separators.Add("[", TokenType.OpenSquareBracket);
            _separators.Add("]", TokenType.CloseSquareBracket);
            _separators.Add("{", TokenType.OpenCurlyBracket);
            _separators.Add("}", TokenType.CloseCurlyBracket);
            _separators.Add(";", TokenType.EndOfSentence);
            _separators.Add(",", TokenType.Comma);
            _separators.Add(".", TokenType.Dot);
            _separators.Add(":", TokenType.Colon);
        }

        private void InitializeOperators()
        {
            //Arithmetic Operators
            _operators.Add("+", TokenType.OpAdd);
            _operators.Add("-", TokenType.OpSubstraction);
            _operators.Add("*", TokenType.OpMultiplication);
            _operators.Add("/", TokenType.OpDivision);
            _operators.Add("%", TokenType.OpModule);

            //Relational Operators
            _operators.Add("<", TokenType.OpLessThan);
            _operators.Add("<=", TokenType.OpLessThanOrEqualTo);
            _operators.Add(">", TokenType.OpGreaterThan);
            _operators.Add(">=", TokenType.OpGreaterThanOrEqualTo);
            _operators.Add("==", TokenType.OpEqualTo);
            _operators.Add("!=", TokenType.OpNotEqualTo);

            //Logical Operators
            _operators.Add("&&", TokenType.OpAnd);
            _operators.Add("||", TokenType.OpOr);
            _operators.Add("!", TokenType.OpNot);

            //Asignament Operators
            _operators.Add("=", TokenType.OpAssingment);
            _operators.Add("+=", TokenType.OpAppend);
            _operators.Add("-=", TokenType.OpUnAappend);

            //Increment and decrement operators
            _operators.Add("++", TokenType.OpIncrement);
            _operators.Add("--", TokenType.OpDecrement);

            /* Conditional Operator
            The operator pair “?” and “:” is known as conditional operator. These pair of operators are ternary operators. 
            The general syntax of conditional operator is: expression1 ? expression2 : expression3 ; */

            //Bitwise Operators
            _operators.Add("&", TokenType.OpBitAnd);
           // _operators.Add("!", TokenType.OpBitOr);
            _operators.Add("^", TokenType.OpBitXor);
            _operators.Add("<<", TokenType.OpBitShiftLeft);
            _operators.Add(">>", TokenType.OpBitShiftRight);

            //Special for comments
            _operators.Add("//", TokenType.LineComment);
            _operators.Add("/*", TokenType.BlockComment);

        }

        private void InitializeKeywords()
        {
            //_keywords.Add("print", TokenType.RwPrint);

            //C language reserved words
            _keywords.Add("auto",TokenType.RwAuto);
            _keywords.Add("break", TokenType.RwBreak);
            _keywords.Add("case", TokenType.RwCase);
            _keywords.Add("char", TokenType.RwChar);
            _keywords.Add("continue", TokenType.RwContinue);
            _keywords.Add("do", TokenType.RwDo);
            _keywords.Add("default", TokenType.RwDefault);
            _keywords.Add("const", TokenType.RwConst);
            _keywords.Add("double", TokenType.RwDouble);
            _keywords.Add("else", TokenType.RwElse);
            _keywords.Add("enum", TokenType.RwEnum);
            _keywords.Add("extern", TokenType.RwExtern);
            _keywords.Add("for", TokenType.RwFor);
            _keywords.Add("if", TokenType.RwIf);
            _keywords.Add("goto", TokenType.RwGoto);
            _keywords.Add("float", TokenType.RwFloat);
            _keywords.Add("int", TokenType.RwInt);
            _keywords.Add("long", TokenType.RwLong);
            _keywords.Add("register", TokenType.RwRegister);
            _keywords.Add("return", TokenType.RwReturn);
            _keywords.Add("signed", TokenType.RwSigned);
            _keywords.Add("static", TokenType.RwStatic);
            _keywords.Add("sizeof", TokenType.RwSizeOf);
            _keywords.Add("short", TokenType.RwShort);
            _keywords.Add("struct", TokenType.RwStruct);
            _keywords.Add("switch",TokenType.RwSwitch);
            _keywords.Add("typedef", TokenType.RwTypedef);
            _keywords.Add("union", TokenType.RwUnion);
            _keywords.Add("void", TokenType.RwVoid);
            _keywords.Add("while", TokenType.RwWhile);
            _keywords.Add("volatile", TokenType.RwVolatile);
            _keywords.Add("unsigned", TokenType.RwUnsigned);
        }
    }
}
