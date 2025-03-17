using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Global;

namespace Src.Frontend.Lexer
{
    public class Lexer
    {
        private List<Token> tokens;
        string Input;
        private uint row;
        private uint col;
        int i = 0;

        private static readonly Dictionary<string, TokenType> keywords = new()
        {
            {"int", TokenType.K_int},
            {"string", TokenType.K_string},
            {"float", TokenType.K_float},
            {"fn", TokenType.k_fn},
            {"void", TokenType.K_void},
            {"char", TokenType.K_char},
            {"return", TokenType.k_return},
            {"import", TokenType.k_import},
            {"call", TokenType.k_call }
        };

        public Lexer()
        {
            row = 1;
            col = 1;
            tokens = new List<Token>();
            this.Input = "";
        }

        public List<Token> Tokenize(string input)
        {
            this.Input = input;

            while (i < Input.Length)
            {
                if (Input[i] == '\n')
                {
                    row++;
                    col = 1;
                    i++;  
                }
                else if (isOperator(Input[i]))
                {
                    tokens.Add(new Token(row, col, TokenType.Operator, Input[i].ToString()));
                    col++;
                    i++;  
                }
                else if (Input[i] == ':')
                {
                    if (LookAhead() == ':')
                    {
                        tokens.Add(new Token(row, col, TokenType.DoubleColon, "::"));
                        col += 2;
                        i += 2;
                    }
                    else
                    {
                        tokens.Add(new Token(row, col, TokenType.Colon, ":"));
                        col++;
                        i++;
                    }
                }
                else if (Input[i] == ';')
                {
                    tokens.Add(new Token(row, col, TokenType.Semi, ";"));
                    col++;
                    i++; 
                }
                else if (Input[i] == ',')
                {
                    tokens.Add(new Token(row, col, TokenType.Comma, ","));
                    col++;
                    i++;
                }
                else if (Input[i] == '=')
                {
                    tokens.Add(new Token(row, col, TokenType.Equal, "="));
                    col++;
                    i++;  
                }
                else if (Input[i] == '(')
                {
                    tokens.Add(new Token(row, col, TokenType.LP, "("));
                    col++;
                    i++;
                }
                else if (Input[i] == ')')
                {
                    tokens.Add(new Token(row, col, TokenType.RP, ")"));
                    col++;
                    i++;
                }
                else if (Input[i] == '{')
                {
                    tokens.Add(new Token(row, col, TokenType.LB, "{"));
                    col++;
                    i++;
                }
                else if (Input[i] == '}')
                {
                    tokens.Add(new Token(row, col, TokenType.RB, "}"));
                    col++;
                    i++;
                }
                else if (Input[i] == '\'')  
                {
                    tokens.Add(ReadChar());
                }
                else if (Input[i] == '#')  
                {
                    SkipComment();
                }
                else if (Input[i] == '"')  
                {
                    tokens.Add(ReadString());
                }
                else if (char.IsDigit(Input[i]))
                {
                    tokens.Add(ReadNumber());
                }
                else if (char.IsWhiteSpace(Input[i]))
                {
                    col++;
                    i++;  
                }
                else if (Char.IsLetter(Input[i]))
                {
                    tokens.Add(IdOrKeyword());
                }
                else
                {
                    throw new Exception($"Undefined character '{Input[i]}' at row {row}, column {col}");
                }
            }

            tokens.Add(new Token(row, col, TokenType.EOF, "EOF"));
            return tokens;
        }

        private void SkipComment()
        {
            while (i < Input.Length && Input[i] != '\n') 
            {
                col++;
                i++;
            }
        }

        private Token ReadString()
        {
            uint startRow = row;
            uint startColumn = col;
            uint start = (uint)i;
            bool escape = false;
            string value = "";

            i++;
            col++;

            while (i < Input.Length)
            {
                if (Input[i] == '"' && !escape) 
                {
                    i++;
                    col++;
                    break;
                }

                if (Input[i] == '\\' && !escape) 
                {
                    escape = true;
                    i++;
                    col++;
                    continue;
                }

                if (escape)
                {
                    if (Input[i] == 'n')
                    {
                        value += '\n';
                    }
               
                    else if (Input[i] == 't')
                    {
                        value += '\t';
                    }
                    else if (Input[i] == 'r')
                    {
                        value += '\r';
                    }
                    else if (Input[i] == '\\')
                    {
                        value += '\\';
                    }
                    else if (Input[i] == '"')
                    {
                        value += '"';
                    }
                   
                    else
                    {
                        throw new Exception($"Invalid escape sequence '\\{Input[i]}' in string at row {row}, column {col}");
                    }

                    escape = false;
                }
                else
                {
                    value += Input[i];
                }

                col++;
                i++;
            }

            if (Input[i - 1] != '"')
            {
                throw new Exception($"Unterminated string literal at row {row}, column {col}");
            }

            return new Token(startRow, startColumn, TokenType.ConstString, value);
        }

        private Token ReadChar()
        {
            uint startRow = row;
            uint startColumn = col;
            uint start = (uint)i;
            bool escape = false;
            string value = "";

            i++; 
            col++;

            if (i < Input.Length)
            {
                if (Input[i] == '\\' && !escape) 
                {
                    escape = true;
                    i++;
                    col++;
                }

                if (escape)
                {
                    if (Input[i] == 'n')
                    {
                        value += '\n';
                    }
                    else if (Input[i] == 't')
                    {
                        value += '\t';
                    }
                    else if (Input[i] == 'r')
                    {
                        value += '\r';
                    }
                    else if (Input[i] == '\\')
                    {
                        value += '\\';
                    }
                    else if (Input[i] == '\'')
                    {
                        value += '\'';
                    }
                    else
                    {
                        throw new Exception($"Invalid escape sequence '\\{Input[i]}' in character at row {row}, column {col}");
                    }

                    escape = false;
                    i++;
                    col++;
                }
                else
                {
                    value = Input[i].ToString();
                    i++;
                    col++;
                }
            }

            if (i < Input.Length && Input[i] == '\'') 
            {
                i++;
                col++;
                return new Token(startRow, startColumn, TokenType.ConstChar, value);
            }

            throw new Exception($"Invalid character literal at row {row}, column {col}");
        }

        private Token IdOrKeyword()
        {
            uint startRow = row;
            uint startColumn = col;
            uint start = (uint)i;

            while (i < Input.Length && (Char.IsLetterOrDigit(Input[i]) || Input[i] == '.'))
            {
                col++;
                i++;
            }

            string value = Input.Substring((int)start, i - (int)start);
            if (keywords.ContainsKey(value))
            {
                return new Token(startRow, startColumn, keywords[value], value);
            }
            return new Token(startRow, startColumn, TokenType.Id, value);
        }

        public bool isOperator(char c)
        {
            return c == '-' || c == '+' || c == '/' || c == '*' || c == '%';
        }
        private char LookAhead()
        {
            if (i + 1 < Input.Length)
            {
                return Input[i + 1];
            }
            return '\0';
        }
        private Token ReadNumber()
        {
            uint startRow = row;
            uint startColumn = col;
            uint start = (uint)i;
            bool isFloat = false;

            while (i < Input.Length && (char.IsDigit(Input[i]) || Input[i] == '.'))
            {
                if (Input[i] == '.')
                {
                    if (isFloat)
                    {
                        throw new Exception("Invalid number format: multiple decimal points");
                    }
                    isFloat = true;
                }

                col++;
                i++;
            }

            string value = Input.Substring((int)start, i - (int)start);
            return isFloat 
                ? new Token(startRow, startColumn, TokenType.ConstFloat, value) 
                : new Token(startRow, startColumn, TokenType.ConstInt, value);
        }
    }
}
