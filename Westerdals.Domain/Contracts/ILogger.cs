using System;

namespace Westerdals.Domain.Contracts
{
    public interface ILogger
    {
        void LogException(Exception ex);
    }
}
