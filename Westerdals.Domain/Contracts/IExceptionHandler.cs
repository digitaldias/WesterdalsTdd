using System;

namespace Westerdals.Domain.Contracts
{
    public interface IExceptionHandler
    {
        void RunUnsafeMethod(Action unsafeAction);

        T GetFromUnsafeMethod<T>(Func<T> unsafeFunction);
    }
}
