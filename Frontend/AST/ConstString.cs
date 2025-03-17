using Src.Frontend.Parser.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lang.Src.Frontend.AST
{
    public class ConstString :Expr
    {
        public string Value;
        public ConstString(string v)
        {
            this.Value = v;
        }
    }
}
