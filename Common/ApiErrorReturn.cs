using OpenBanking.POC.Domain.Models;

namespace Common
{
    public static class ApiErrorReturn
    {
        public static ApiErrorResult InvalidDate()
        {
            return new ApiErrorResult
            {
                Code = "004",
                Id = "004",
                Message = "Invalid Date Format (yyyy-MM-ddTHH:mm:ss.fffZ)."
            };
        }

        public static ApiErrorResult InvalidInitialDate()
        {
            return new ApiErrorResult
            {
                Code = "005",
                Id = "005",
                Message = "Initial date has to be greater than end date."
            };
        }

        public static ApiErrorResult InternalError()
        {
            return new ApiErrorResult
            {
                Code = "500",
                Id = "500",
                Message = "Internal error, please contact Bs2."
            };
        }
    }
}
