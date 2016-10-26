namespace Lexer
{
    public enum TokenType
    {
        EndOfFile,
        Identifier,
        OperatorEquals,
        LiteralNumber,  
        EndOfSentence,
        LiteralString,
        LiteralChar,
        LineComment,
        BlockComment,
        
        //Keywords
        RwAuto, //Rw stands for reserved word
        RwBreak,
        RwCase,
        RwChar,
        RwString,
        RwContinue,
        RwDo,
        RwDefault,
        RwConst,
        RwDouble,
        RwElse,
        RwEnum,
        RwExtern,
        RwFor,
        RwForEach,
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
        RwDate,
        RwInclude,
        RwBool,
        RwTrue,
        RwFalse,

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
        OpPointerStructs,
        
        //Logical Operators
        OpAnd,
        OpLogicalOr,
        OpNot,
        OpAssingment,
        OpIncrement,
        OpDecrement,

        //Bitwise Operators
        OpBitAnd,
        OpBitOr,
        OpBitXor,
        OpBitShiftLeft,
        OpBitShiftRight,

        //Other operators
        OpAppend,
        OpUnAappend,
        LiteralHexadecimal,
        LiteralOctal,
        LiteralDate,
        LiteralFloat,
        LiteralDecimal
    }
}