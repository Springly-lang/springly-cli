using System.Collections.Generic;
using CommandLine;

namespace SpringlyLang.Cli
{
    [Verb("run", HelpText = "Runs the test script files.")]
    public class RunOptions
    {
        [Option('i', "in", Separator = ' ', Required = false, Default = null, HelpText = "Specifies the list of test script files. If no file is specified, the whole directoy and sub-directories will be searched.")]
        public IEnumerable<string> FileNames { get; set; }

        [Option('h', "headless", Required = false, Default = true, HelpText = "Specifies whether the browsers should run in headless mode or not. Default value is true.")]
        public bool Headless { get; set; }
    }
}
