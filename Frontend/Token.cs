using System;

namespace Global{

    public enum TokenType {
        ConstInt,
        ConstString,
        ConstFloat,
        ConstChar,
        Operator,
        Symbol,
        K_int,
        K_float,
        K_string,
        K_void,
        K_char,
        k_bool,
        k_fn,
        k_return,
        k_import,
        k_true,
        k_false,
        k_call,
        LP,
        RP,
        LB,
        RB,
        Semi,
        Colon,
        DoubleColon,
        Comma,
        Id,
        Equal,
        Ap,
        EOF
    }
    public class Token {
        public uint Row;
        public uint Col;
        public TokenType Type;
        public String Value;
        public Token(uint r,uint c, TokenType t, string v){
            this.Row = r;
            this.Col = c;
            this.Type = t;
            this.Value = v;
        }

        public override string ToString()
        {
            return "{type: "+Type+", value: '"+Value+"'} <"+Row+", "+Col+">";
        }
    }
}