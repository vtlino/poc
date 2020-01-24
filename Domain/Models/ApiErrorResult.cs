using System.Collections.Generic;

namespace OpenBanking.POC.Domain.Models
{
    public class Error
    {
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public string Path { get; set; }
        public string Url { get; set; }
    }

    public class ApiErrorResult 
    {
        public string Code { get; set; }
        public string Id { get; set; }
        public string Message { get; set; }
        public IList<Error> Errors { get; set; }
    }
}