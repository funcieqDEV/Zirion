using Src.Frontend.Parser.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lang.Src.Frontend.AST
{
    public class Return : Node
    {
        public Expr Value;
        public Return(Expr v)
        {
            this.Value = v;
        }
    }
}
