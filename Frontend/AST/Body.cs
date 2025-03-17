using Src.Frontend.Parser.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lang.Src.Frontend.AST
{
    public class Body : Node
    {
        public List<Node> Childrens = new();
        public Body(List<Node> ch)
        {
            this.Childrens = ch;
        }
    }
}
