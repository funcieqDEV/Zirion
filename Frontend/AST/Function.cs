using Src.Frontend.Parser.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lang.Src.Frontend.AST
{
    public class Function : Node
    {
        string ReturnType;
        string Name;
        List<Arg> Args;
        Body Body;
        public Function(string n, string rt, List<Arg> a, Body b)
        {
            this.Name = n;
            this.ReturnType = rt;
            this.Args = a;
            this.Body = b;
        }
    }
}
