using System;
using System.Collections.Generic;
using Syntax.Semantic.Types;
using Syntax.Tree.LoopsAndConditions.Functions;

namespace Syntax.Semantic
{
    public class StackContext
    {
        private static StackContext _context;
        public Stack<TypesTable> Stack = new Stack<TypesTable>();
        public Dictionary<string, BaseType> TableOfTypes;

        public Dictionary<string, FunctionDeclarationNode> FunctionsNodes;


        public Dictionary<Guid, TypesTable> PastContexts;

        public bool CanDeclareBreak = false;
        public bool CanDeclareContinue = false;
        public bool CanDeclareReturn = false;
        private StackContext()
        {
            Stack.Push(new TypesTable());

            TableOfTypes = new Dictionary<string, BaseType>
            {
                {"int", new IntType()},
                {"string", new StringType()},
                {"float", new FloatType()},
                {"date", new DateType()},
                {"char", new CharType()},
                {"bool", new BooleanType()},
                {"double", new FloatType()},
                {"decimal", new FloatType()},
                {"void", new VoidType()},
                {"long", new IntType()},
            };

            PastContexts = new Dictionary<Guid, TypesTable>();
            FunctionsNodes = new Dictionary<string, FunctionDeclarationNode>();
        }

        public static StackContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new StackContext();
                }
                return _context;
            }
        }

        public BaseType GetGeneralType(string name)
        {
            return TableOfTypes[name];
        }

    }
}