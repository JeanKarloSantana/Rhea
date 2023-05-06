using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rhea.Entities.DTO
{
    public class ResponseDTO<T>
    {
        public T Data { get; set; }
        public bool Succeed { get; set; }
        public List<string> Errors { get; set; }
        public string Message { get; set; }
        public ushort StatusCode { get; set; }

        public ResponseDTO()
        {
            Errors = new List<string>();
        }
    }
}
