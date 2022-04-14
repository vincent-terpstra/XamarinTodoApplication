using System;

namespace TODO.Objects;

public class Result
{

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;

    public string Message { get; }

    public Result()
    {
        IsSuccess = true;
    }

    public Result(string message)
    {
        IsSuccess = false;
        Message = message;
    }
}

public class Result<T> : Result
{
    private readonly T _value;

    public T Value
    {
        get
        {
            if (IsSuccess)
                return _value;
            throw new InvalidOperationException();
        }
    }

    public Result(T value) : base()
    {
        this._value = value;
    }

    public Result(string message) : base(message)
    {
    }
}