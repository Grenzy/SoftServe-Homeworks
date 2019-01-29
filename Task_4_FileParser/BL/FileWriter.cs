using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_4_FileParser.BL.Interfaces;

namespace Task_4_FileParser.BL
{
    public class FileWriter : IFileWriter, IDisposable
    {
        private StreamWriter streamWriter;
        private string path;
        private string tempPath;
        bool disposed = false;

        public FileWriter(string path)
        {
            tempPath = Path.Combine(Path.GetTempPath(),
                Path.GetRandomFileName());
            streamWriter = new StreamWriter(tempPath);
            this.path = path;
        }

        public void WriteTemporary(string line)
        {
            streamWriter.WriteLine(line);
        }

        public void Close()
        {
            Dispose();
            File.Replace(tempPath, path, null);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                streamWriter.Close();
            }
            disposed = true;
        }
        ~FileWriter()
        {
            Dispose(false);
        }
    }
}
