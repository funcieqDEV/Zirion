using Src.Frontend.Parser.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lang.Src.Frontend.AST
{
    public class Arg : Node
    {
        public string Name;
        public string Type;
        public Arg(string n, string t)
        {
            this.Name = n;
            this.Type = t;
        }
    }
}
