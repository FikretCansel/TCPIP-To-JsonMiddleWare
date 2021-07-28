using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.TcpServer.DTO
{
    public class GenericDTO<T> where T : IEntity
    {
        public T Data { get; set; }
        public int Status { get; set; }
    }
}
