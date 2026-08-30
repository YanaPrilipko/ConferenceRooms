namespace ConferenceRooms.Services.Results;

public enum OperationErrorCode
{
    None = 0,
    ValidationFailed,
    NotFound,
    Conflict,
    Unexpected
}

public class OperationResult
{
    public bool Success { get; init; }
    public string? Error { get; init; }
    public OperationErrorCode ErrorCode { get; init; } = OperationErrorCode.None;

    public static OperationResult Ok() => new() { Success = true };

    public static OperationResult Fail(
        string error,
        OperationErrorCode errorCode = OperationErrorCode.ValidationFailed) =>
        new() { Success = false, Error = error, ErrorCode = errorCode };
}

public class OperationResult<T> : OperationResult
{
    public T? Value { get; init; }

    public static OperationResult<T> Ok(T value) => new() { Success = true, Value = value };

    public static new OperationResult<T> Fail(
        string error,
        OperationErrorCode errorCode = OperationErrorCode.ValidationFailed) =>
        new() { Success = false, Error = error, ErrorCode = errorCode };
}
