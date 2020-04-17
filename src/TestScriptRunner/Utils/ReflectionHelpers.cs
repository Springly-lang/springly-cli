using System;
using System.Collections.Generic;
using System.Linq;

namespace SpringlyLang.Utils
{
    internal static class ReflectionHelpers
    {
        public static string GetTokenTypePattern(TokenType tokenType)
        {
            var enumMember = typeof(TokenType).GetMember(tokenType.ToString())[0];
            var enumAttr = enumMember.GetCustomAttributes(typeof(TokenDefinitionAttribute), false)
                            .Select(x => x as TokenDefinitionAttribute)
                            .FirstOrDefault();
            return enumAttr?.Pattern;
        }


        private static readonly List<TokenType> CachedKeywordTokenTypes = new List<TokenType>();
        public static TokenType[] GetTokenTypeKeywords()
        {
            if (!CachedKeywordTokenTypes.Any())
            {
                lock (CachedKeywordTokenTypes)
                {
                    if (!CachedKeywordTokenTypes.Any())
                    {
                        foreach (TokenType tokenType in Enum.GetValues(typeof(TokenType)))
                        {
                            var enumMember = typeof(TokenType).GetMember(tokenType.ToString())[0];
                            var enumAttr = enumMember.GetCustomAttributes(typeof(TokenDefinitionAttribute), false)
                                            .Select(x => x as TokenDefinitionAttribute)
                                            .FirstOrDefault();

                            if (enumAttr.IsKeyword)
                            {
                                CachedKeywordTokenTypes.Add(tokenType);
                            }
                        }
                    }
                }
            }

            return CachedKeywordTokenTypes.ToArray();
        }
    }
}
