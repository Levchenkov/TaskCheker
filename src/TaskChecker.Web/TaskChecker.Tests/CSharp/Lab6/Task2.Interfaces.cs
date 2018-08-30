using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public interface IRemoteClient
    {
        IRemoteResult SendData(string[] data);
    }

    public interface IRemoteResult
    {
        IEnumerable<Exception> Exceptions
        {
            get;
        }

        void Add(Exception exception);

        bool IsSuccess
        {
            get;
        }
    }

    public interface IRemoteService
    {
        void SendData(string data);
    }

    public class RemoteService : IRemoteService
    {
        public void SendData(string data)
        {
            throw new Exception(data);
        }
    }
}
