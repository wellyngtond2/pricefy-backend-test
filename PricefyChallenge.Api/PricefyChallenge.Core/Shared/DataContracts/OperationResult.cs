namespace PricefyChallenge.Core.Shared.DataContracts
{
    public class OperationResult<T> : OperationResult
    {
        public OperationResult(bool isSuccess, string message, T data) : base(isSuccess, message)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }

        public bool IsSuccess { get; }
        public string Message { get; }
        public T Data { get; }
    }
    public class OperationResult
    {
        public OperationResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public bool IsSuccess { get; }
        public string Message { get; }

        public static OperationResult<Tdata> Success<Tdata>(Tdata data) => new(true, null, data);
        public static OperationResult Success() => new(true, null);
        public static OperationResult<Tdata> Failure<Tdata>(Tdata data) => new(false, null, data);
        public static OperationResult Failure() => new(false, null);
        public static OperationResult Failure(string message) => new(false, message);
    }
}
