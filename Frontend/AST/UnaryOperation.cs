using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lang.Src.Frontend.AST
{
    public class UnaryOperation : Expr
    {
        string Op;
        Expr Value;

        public UnaryOperation(string op, Expr value)
        {
            this.Op = op;
            this.Value = value;
        }
    }
}
