using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using SpringlyLang.Language.Ast;

namespace SpringlyLang.Language
{
    public class CustomNumericLiteral : Terminal
    {
        public CustomNumericLiteral(string name) : base(name, TokenCategory.Content, TermFlags.IsLiteral)
        {
            AstConfig.NodeType = typeof(NumericLiteralNode);
            EditorInfo = new TokenEditorInfo(TokenType.Literal, TokenColor.Number, TokenTriggers.None);
        }

        public override Token TryMatch(ParsingContext context, ISourceStream source)
        {
            const int MaxPossibleNumberLength = 29;
            var builder = new StringBuilder(MaxPossibleNumberLength);

            //source.CreateToken(this, "");

            if (!char.IsDigit(source.PreviewChar) && source.PreviewChar != '+' && source.PreviewChar != '-')
            {
                return null;
            }

            var i = source.Location.Position;

            while (i < source.Text.Length)
            {
                var currentChar = source.Text[i];
                if (char.IsDigit(currentChar) || currentChar == '.')
                {
                    builder.Append(currentChar);
                    i++;
                }
                else
                {
                    break;
                }
            }

            var strValue = builder.ToString();
            if (!decimal.TryParse(strValue, out decimal d))
            {
                return null;
            }

            return new Token(this, source.Location, strValue, strValue);
        }

        public override IList<string> GetFirsts()
        {
            return new List<string> { "+", "-", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        }
    }
}
