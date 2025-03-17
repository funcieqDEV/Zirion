using Src.Frontend.Parser.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lang.Src.Frontend.AST
{
    public class BinaryOperation : Expr
    {
        public Expr Left;
        public Expr Right;
        public string Operation;
        public BinaryOperation(Expr l, Expr r, string o)
        {
            this.Left = l;
            this.Right = r;
            this.Operation = o;
        }
    }
}
