using System.IO;
using System.Linq;

namespace SpringlyLangCliIntegrationTests
{
    public abstract class TestCaseBase
    {
        protected string[] SetupFiles(string assetsFolderName, params string[] scriptFileNames)
        {
            var baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), assetsFolderName);
            var args = scriptFileNames.Select(scriptFileName => Path.Combine(baseDirectory, scriptFileName)).ToArray();

            var indexFileName = Path.Combine(baseDirectory, "index.html");
            indexFileName = "file:///" + indexFileName.Replace(@"\", "/");
            foreach (var file in args)
            {
                var content = File.ReadAllText(file);
                content = content.Replace("$INDEX_FILE_PATH$", indexFileName);
                File.WriteAllText(file, content);
            }

            return args;
        }
    }
}
