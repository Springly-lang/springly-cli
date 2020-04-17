namespace SpringlyLang
{
    public enum TokenType
    {
        [TokenDefinition("^\\\\.+\n", false)]
        Comment = 1,

        [TokenDefinition("^,", false)]
        Colon,

        [TokenDefinition("^(\"(?<value>[^\"]+)\"|'(?<value>[^']+)')", false)]
        StringLiteral,

        [TokenDefinition("^(?<value>\\d+[^\\w+])", false)]
        NumericLiteral,

        [TokenDefinition("^@(?<value>[^\\s,]+)", false)]
        ElementIdentifier,

        [TokenDefinition("^browser", true)]
        Browser,

        [TokenDefinition("^use", true)]
        Use,

        [TokenDefinition("^test(\\s+)case", true)]
        TestCase,

        [TokenDefinition("^open", true)]
        Open,

        [TokenDefinition("^appears", true)]
        Appears,

        [TokenDefinition("^disappears", true)]
        Disappears,

        [TokenDefinition("^navigate", true)]
        Navigate,

        [TokenDefinition("^maximize", true)]
        Maximize,

        [TokenDefinition("^minimize", true)]
        Minimize,

        [TokenDefinition("^from", true)]
        From,

        [TokenDefinition("^select", true)]
        Select,

        [TokenDefinition("^check", true)]
        Check,

        [TokenDefinition("^click", true)]
        Click,

        [TokenDefinition("^right(\\s+)click", true)]
        RightClick,

        [TokenDefinition("^double(\\s+)click", true)]
        DoubleClick,

        [TokenDefinition("^type", true)]
        Type,

        [TokenDefinition("^wait(\\s+)until", true)]
        WaitUntil,

        [TokenDefinition("^wait(\\s+)for", true)]
        WaitFor,

        [TokenDefinition("^number", true)]
        Number,

        [TokenDefinition("^scroll", true)]
        ScrollTo,

        [TokenDefinition("^resize", true)]
        Resize,

        [TokenDefinition("^close", true)]
        Close,

        [TokenDefinition("^((?<value>1)st|(?<value>2)nd|(?<value>3)rd|(?<value>\\d+)th)", false)]
        OrdinalNumber,

        [TokenDefinition("^in", true)]
        In,

        [TokenDefinition("^to", true)]
        To,

        [TokenDefinition("^on", true)]
        On,

        [TokenDefinition("^of", true)]
        Of,

        [TokenDefinition("^be", true)]
        Be,

        [TokenDefinition("^(seconds|second)", true)]
        Seconds,

        [TokenDefinition("^(minutes|minute)", true)]
        Minutes,

        [TokenDefinition("^(hours|hour)", true)]
        Hours,

        [TokenDefinition("^(equals|equal)", true)]
        Equal,

        [TokenDefinition("^(contains|contain)", true)]
        Contain,

        [TokenDefinition("^not", true)]
        Not,

        [TokenDefinition("^(expects|expect)", true)]
        Expect,

        //[TokenDefinition("^([a-zA-Z][a-zA-Z0-9_\\-]*)")]
        //Identifier,

        [TokenDefinition("^(\\r\\n|\\n)", false)]
        NewLine,

        [TokenDefinition("^\\s+", false)]
        WhiteSpace
    }
}