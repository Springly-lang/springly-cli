namespace TestScriptRunner
{
    public enum TokenType
    {
        [TokenDefinition("^\\\\.+\n")]
        Comment = 1,

        [TokenDefinition("^,")]
        Colon,

        [TokenDefinition("^(\"(?<value>[^\"]+)\"|'(?<value>[^']+)')")]
        StringValue,

        [TokenDefinition("^(?<value>\\d+[^\\w+])")]
        NumericValue,

        [TokenDefinition("^@(?<value>[^\\s]+)")]
        ElementIdentifier,

        [TokenDefinition("^browser")]
        Browser,

        [TokenDefinition("^use")]
        Use,

        [TokenDefinition("^test(\\s+)case")]
        TestCase,

        [TokenDefinition("^open")]
        Open,

        [TokenDefinition("^appears")]
        Appears,

        [TokenDefinition("^disappears")]
        Disappears,

        [TokenDefinition("^navigate")]
        Navigate,

        [TokenDefinition("^maximize")]
        Maximize,

        [TokenDefinition("^minimize")]
        Minimize,

        [TokenDefinition("^from")]
        From,

        [TokenDefinition("^select")]
        Select,

        [TokenDefinition("^check")]
        Check,

        [TokenDefinition("^click")]
        Click,

        [TokenDefinition("^right(\\s+)click")]
        RightClick,

        [TokenDefinition("^double(\\s+)click")]
        DoubleClick,

        [TokenDefinition("^type")]
        Type,

        [TokenDefinition("^wait(\\s+)until")]
        WaitUntil,

        [TokenDefinition("^wait(\\s+)for")]
        WaitFor,

        [TokenDefinition("^number")]
        Number,

        [TokenDefinition("^scroll")]
        ScrollTo,

        [TokenDefinition("^resize")]
        Resize,

        [TokenDefinition("^close")]
        Close,

        [TokenDefinition("^((?<value>1)st|(?<value>2)nd|(?<value>3)rd|(?<value>\\d+)th)")]
        OrdinalNumber,

        [TokenDefinition("^in")]
        In,

        [TokenDefinition("^to")]
        To,

        [TokenDefinition("^on")]
        On,

        [TokenDefinition("^of")]
        Of,

        [TokenDefinition("^be")]
        Be,

        [TokenDefinition("^(seconds|second)")]
        Seconds,

        [TokenDefinition("^(minutes|minute)")]
        Minutes,

        [TokenDefinition("^(hours|hour)")]
        Hours,

        [TokenDefinition("^(equals|equal)")]
        Equal,

        [TokenDefinition("^(contains|contain)")]
        Contain,

        [TokenDefinition("^not")]
        Not,

        [TokenDefinition("^(expects|expect)")]
        Expect,

        [TokenDefinition("^(\\r\\n|\\n)")]
        NewLine,

        [TokenDefinition("^\\s+")]
        WhiteSpace
    }
}