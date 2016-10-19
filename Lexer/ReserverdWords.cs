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

        public ReserverdWords()
        {
            _keywords = new Dictionary<string, TokenType>();
            _operators = new Dictionary<string, TokenType>();
            _separators = new Dictionary<string,TokenType>();

            InitializeReservedWords();
            InitializeOperators();
            InitializeSeparators();
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
            _separators.Add(":", TokenType.Assignation);
        }

        private void InitializeOperators()
        {
           // _operators.Add(";",TokenType.EndOfSentence);
        }

        private void InitializeReservedWords()
        {
            _keywords.Add("print", TokenType.RwPrint);

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
