using Src.Frontend.Parser.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lang.Src.Frontend.AST
{
    public class ConstInt : Expr
    {
        public int Value;
        public ConstInt(int v)
        {
            this.Value = v;
        }
    }
}
