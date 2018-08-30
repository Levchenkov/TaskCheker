using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public interface IFile
    {
        void Open();
        string Read();
        void Close();
    }

    public class File : IFile
    {
        public void Open()
        {
        }

        public void Close()
        {
        }

        public string Read()
        {
            throw new Exception("Bad symbol.");
        }
    }

    public interface IFileReader
    {
        string Read();

        string ReadSafe();
    }
}
