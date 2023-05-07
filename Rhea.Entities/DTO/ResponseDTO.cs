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

        public ResponseDTO<T> UpdateResponse(ResponseDTO<T> response, T data, ushort statusCode, bool succeed, string error, string message)
        { 
            response.Data = data;
            response.Message = message;
            response.StatusCode = statusCode;
            response.Succeed = succeed;
            response.Errors.Add(error);

            return response;
        }
    }
}
