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
        private string temporaryPath;
        bool disposed = false;

        public FileWriter(string path)
        {
            temporaryPath = Guid.NewGuid().ToString();
            streamWriter = new StreamWriter(temporaryPath);
            this.path = path;
        }

        public void WriteTemporary(string line)
        {
            streamWriter.WriteLine(line);
        }

        public void Close()
        {
            Dispose();
            File.Replace(temporaryPath, path, null);
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
