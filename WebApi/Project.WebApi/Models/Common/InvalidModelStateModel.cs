namespace Project.WebApi.Models.Common;

public class InvalidModelStateModel : ErrorModel
{
    public InvalidModelStateModel(int statusCode, string msg, List<InvalidPoperty> errors) : base(statusCode, msg)
    {
        Errors = errors;
    }

    public List<InvalidPoperty> Errors { get; set; }
}

public class InvalidPoperty
{

    public InvalidPoperty(string property, List<string> errors)
    {
        Name = property;
        Errors = errors;
    }

    public string Name { get; set; }
    public List<string> Errors { get; set; }
}
