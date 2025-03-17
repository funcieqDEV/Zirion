using Src.Frontend.Parser.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lang.Src.Frontend.AST
{
    public class ConstBool : Expr
    {
        public bool Value;
        public ConstBool(bool v)
        {
            this.Value = v;
        }
    }
}
