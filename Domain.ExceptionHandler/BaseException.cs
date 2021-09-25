using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ExceptionHandler
{
    public class BaseException : Exception
    {
        public Guid UId { get; set; }
        public int Code { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public string ErrorMessage { get; set; }

        public BaseException()
        {
        }

        public BaseException(string message) : base(message)
        {
        }

        public BaseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
