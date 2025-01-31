﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic.CompilerLog.UnitTests;

internal sealed class TempDir : IDisposable
{
    internal string DirectoryPath { get; }

    public TempDir(string? name = null)
    {
        DirectoryPath = Path.Combine(Path.GetTempPath(), "Basic.CompilerLog", Guid.NewGuid().ToString());
        if (name != null)
        {
            DirectoryPath = Path.Combine(DirectoryPath, name);
        }

        Directory.CreateDirectory(DirectoryPath);
    }

    public void Dispose()
    {
        Directory.Delete(DirectoryPath, recursive: true);
    }

    public void EmptyDirectory()
    {
        var d = new DirectoryInfo(DirectoryPath);
        foreach(System.IO.FileInfo file in d.GetFiles()) file.Delete();
        foreach(System.IO.DirectoryInfo subDirectory in d.GetDirectories()) subDirectory.Delete(true);
    }
}
