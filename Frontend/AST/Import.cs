namespace Src.Frontend.Parser.AST{
    public class Import : Node{
        public string Namespace;
        public string Name;
        public Import(string n, string ns)
        {
            this.Namespace = ns;
            this.Name = n;
        }
    }
}