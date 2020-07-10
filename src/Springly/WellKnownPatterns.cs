namespace Springly
{
    public static class WellKnownPatterns
    {
        public const string Id = "#(?<id>[A-Za-z][A-Za-z0-9_:\\.-]*)";
        public const string CssSelector = "'(?<selector>.+)'";
        public const string Coordinate = "(?<x>\\d+)\\s*,\\s*(?<y>\\d+)\\s*\\)";
        public const string CompareOp = "(?<op>equal|not\\s+equal|contain|not\\s+contain|greater\\s+than\\s+or\\s+equal|greater\\s+than|smaller\\s+than\\s+or\\s+equal|smaller\\s+than)";
        public const string BrowserName = "(?<name>[_\\w]*\\w+[_\\w\\d]*)";
        public const string DriverName = "(?<browser>(\\w+))";
    }
}
