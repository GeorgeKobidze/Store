using Domain.Infrastructure.Extension;
using System;

namespace Domain.ExceptionHandler
{
    internal class ExceptionResult
    {
        private int _code;
        private Guid _uId;
        private DateTime _requestDate;
        private string _errorMessage;

        public ExceptionResult(int code, Guid uId, DateTime requestDate, string errorMessage)
        {
            _code = code;
            _uId = uId;
            _requestDate = requestDate;
            _errorMessage = errorMessage;
        }

        public override string ToString()
        {
            return new
            {
                code = _code,
                operationId = _uId,
                requestDateTime = _requestDate,
                errorMessage = _errorMessage
            }.ToJson();
        }

    }
}