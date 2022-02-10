namespace Project.WebApi.Models.Common;

public class ErrorModel
{
    public ErrorModel(int statusCode, string msg)
    {
        StatusCode = statusCode;
        Message = msg;
    }

    public int StatusCode { get; set; }
    public string Message { get; set; }
}
