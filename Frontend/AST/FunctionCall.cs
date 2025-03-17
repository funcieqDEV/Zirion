using Src.Frontend.Parser.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lang.Src.Frontend.AST
{
    public class FunctionCall : Node
    {
        String name;
        List<Expr> args;

        public FunctionCall(String n, List<Expr> a)
        {
            name = n;
            args = a;
        }
    }
}
