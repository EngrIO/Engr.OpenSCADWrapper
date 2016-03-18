using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engr.OpenSCADWrapper
{
    public class OpenSCAD
    {
        private string _processFileName;
        public OpenSCAD(string processFileName = @"C:\Program Files\OpenSCAD\openscad.com")
        {
            _processFileName = processFileName;
        }

        public void Run(string args, bool wait = true)
        {
            var process = new Process
            {
                StartInfo =
              {
                  FileName = _processFileName,
                  Arguments = args
              }
            };
            process.Start();
            if (wait)
            {
                process.WaitForExit();
            }
        }


        public Stream Generate(string code, OutputType type = OutputType.STL)
        {
            using (var input = new TempFile("cad"))
            using (var output = new TempFile(type))
            {
                return new MemoryStream( File.ReadAllBytes(output.FilePath));
            }
        }
    }

    public enum OutputType { STL, OFF, DXF, CSG }
    internal class TempFile : IDisposable
    {
        public readonly string FilePath;

        public TempFile(OutputType type): this (type.ToString())
        {
        }

        public TempFile(string ext)
        {
            FilePath = String.Format("{0}{1}.{2}", Path.GetTempPath(), Guid.NewGuid(), ext.ToLower());
            File.Create(FilePath);
        }

        public void Dispose()
        {
            File.Delete(FilePath);
        }
    }
}
