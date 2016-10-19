namespace Lexer
{
    public enum TokenType
    {
        EndOfFile,
        Identifier,
        OperatorEquals,
        LiteralNumber,  
        EndOfSentence,

        //Keywords
        RwAuto, //Rw stands for reserved word
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

        //Separators
        OpenParenthesis,
        CloseParenthesis,
        OpenSquareBracket,
        CloseSquareBracket,
        OpenCurlyBracket,
        CloseCurlyBracket,
        Comma,
        Dot,
        Colon,
        
        //Arithmetic Operators
        OpAdd,
        OpSubstraction,
        OpMultiplication,
        OpDivision,
        OpModule,

        //Relational Operators
        OpLessThan,
        OpLessThanOrEqualTo,
        OpGreaterThan,
        OpGreaterThanOrEqualTo,
        OpEqualTo,
        OpNotEqualTo,
        
        //Logical Operators
        OpAnd,
        OpOr,
        OpNot,
        OpAssingment,
        OpIncrement,
        OpDecrement,

        //Bitwise Operators
        OpBitAnd,
        OpBitOr,
        OpBitXor,
        OpBitShiftLeft,
        OpBitShiftRight
    }
}