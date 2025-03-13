namespace Application.Models
{
    public class ResponseModel
    {
        public string Code { get; set; }
        public string Message { get; set; }

        public static ResponseModel InternalError() => new ResponseModel
        {
            Code = "500",
            Message = "An internal error has occurred. Please try again later or try contacting support."
        };
    }
}
