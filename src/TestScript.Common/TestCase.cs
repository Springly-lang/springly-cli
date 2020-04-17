using System.Collections.Generic;
using SpringlyLang.Common.Instructions;

namespace SpringlyLang.Common
{
    public class TestCase
    {
        public TestCase(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public List<InstructionBase> Instructions { get; } = new List<InstructionBase>();
    }
}
