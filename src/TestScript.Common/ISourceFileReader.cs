﻿using System.Collections.Generic;

namespace TestScript.Common
{
    public interface ISourceFileReader
    {
        IEnumerable<SourceFile> Transform(string[] files);
    }

    public class SourceFileReader : ISourceFileReader
    {
        public IEnumerable<SourceFile> Transform(string[] files)
        {
            var sourceFiles = new List<SourceFile>();

            foreach (var arg in files)
            {
                if (SourceFile.TryCreate(arg, out SourceFile sourceFile))
                    sourceFiles.Add(sourceFile);
            }

            return sourceFiles;
        }
    }
}
