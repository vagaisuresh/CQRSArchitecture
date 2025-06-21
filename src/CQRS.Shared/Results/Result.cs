namespace MyApp.Shared.Results;

public class Result<T>
{
    public bool Succeeded { get; set; }
    public string[] Errors { get; set; } = [];
    public T? Data { get; set; }

    public static Result<T> Success(T data) => new() { Succeeded = true, Data = data };
    public static Result<T> Failure(params string[] errors) => new() { Succeeded = false, Errors = errors };
}