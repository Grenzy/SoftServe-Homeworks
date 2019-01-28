using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_4_FileParser.BL.Interfaces;

namespace Task_4_FileParser.BL
{
    public class FileReader : IFileReader, IDisposable
    {
        private StreamReader streamReader;
        bool disposed = false;

        public FileReader(string path)
        {
            streamReader = new StreamReader(path);
        }

        public string ReadLine()
        {
            return streamReader.ReadLine();
        }
        public void Close()
        {
            Dispose();
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
                streamReader.Close();
            }
            disposed = true;
        }
        ~FileReader()
        {
            Dispose(false);
        }
    }
}
