using Springly.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Springly
{
    public static class CommandExtensions
    {
        public static IEnumerable<ICommand> GetCommands() => typeof(ICommand).Assembly.GetTypes()
                .Where(x => !x.IsAbstract && x.IsClass && typeof(ICommand).IsAssignableFrom(x))
                .Select(x => (ICommand)Activator.CreateInstance(x))
                .OrderBy(x => x.Order)
                .ToArray();
    }
}
