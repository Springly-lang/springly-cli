using System.IO;

namespace SpringlyLang.Common
{
    public class SourceFile
    {
        public SourceFile(string filename, string content)
        {
            FileName = filename;
            Content = content;
        }

        public static bool TryCreate(string fileName, out SourceFile sourceFile)
        {
            if (File.Exists(fileName))
            {
                var content = File.ReadAllText(fileName);
                sourceFile = new SourceFile(fileName, content);
                return true;
            }
            else
            {
                sourceFile = null;
                return false;
            }
        }

        public string FileName { get; }
        public string Content { get; }
    }
}
