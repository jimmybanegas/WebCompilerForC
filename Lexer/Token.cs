namespace Lexer
{
    public class Token
    {
        public string Lexeme { get; set; }
        public TokenType TokenType { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public override string ToString()
        {
           return $"| {Lexeme,55} | {TokenType,30} | {Row,5} | {Column,5} |\n";
        }
    }
}
