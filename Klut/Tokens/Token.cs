namespace Klut.Tokens
{
    class Token
    {
        public TokenType Type { get; set; }

        public string Lexeme { get; set; }

        public Token( TokenType type, string lexeme )
        {
            Type = type;
            Lexeme = lexeme;
        }

        public override string ToString()
        {
            return "( " + Type + ", `" + Lexeme + "` )";
        }
    }
}
