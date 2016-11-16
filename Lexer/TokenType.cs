﻿namespace Lexer
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
        HTMLContent,
        
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
        OpIncrement,
        OpDecrement,

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
        OpSimpleAssignment,
        OpMultiplyAndAssignment,

        //Bitwise Operators
        OpBitAnd,
        OpBitOr,
        OpBitXor,
        OpBitShiftLeft,
        OpBitShiftRight,
        OpComplement,

        //Other operators
        OpAddAndAssignment,
        OpSusbtractAndAssignment,
        LiteralHexadecimal,
        LiteralOctal,
        LiteralDate,
        LiteralFloat,
        LiteralDecimal,
        OpDivideAssignment,
        OpModulusAssignment,
        OpBitShiftLeftAndAssignment,
        OpBitShiftRightAndAssignment,
        OpBitwiseAndAssignment,
        OpBitwiseXorAndAssignment,
        OpBitwiseInclusiveOrAndAssignment,
        ConditionalExpression,
        OpenCCode,
        CloseCCode
    }
}