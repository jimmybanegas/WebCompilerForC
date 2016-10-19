namespace Lexer
{
    public enum TokenType
    {
        EndOfFile,
        Identifier,
        OperatorEquals,
        LiteralNumber,
        RwPrint,  //Rw stands for reserved word
        EndOfSentence,

        //Keywords
        RwAuto,
        RwBreak,
        RwCase,
        RwChar,
        RwContinue,
        RwDo,
        RwDefault,
        RwConst,
        RwDouble,
        RwElse,
        RwEnum,
        RwExtern,
        RwFor,
        RwIf,
        RwGoto,
        RwFloat,
        RwInt,
        RwLong,
        RwRegister,
        RwReturn,
        RwSigned,
        RwStatic,
        RwSizeOf,
        RwShort,
        RwStruct,
        RwSwitch,
        RwTypedef,
        RwUnion,
        RwVoid,
        RwWhile,
        RwVolatile,
        RwUnsigned,

        //Searators
        OpenParenthesis,
        CloseParenthesis,
        OpenSquareBracket,
        CloseSquareBracket,
        OpenCurlyBracket,
        CloseCurlyBracket,
        Comma,
        Dot,
        Assignation
    }
}