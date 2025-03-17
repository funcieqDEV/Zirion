using Src.Frontend.Parser.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lang.Src.Frontend.AST
{
    public class VariableDeclaration : Node
    {
        String Name;
        string Type;
        Expr Value;
        public VariableDeclaration(string n, string t,Expr init) { }
    }
}
