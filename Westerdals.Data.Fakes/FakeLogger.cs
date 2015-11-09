using System;
using Westerdals.Domain.Contracts;

namespace Westerdals.Data.Fakes
{
    public class FakeLogger : ILogger
    {
        public void LogException(Exception ex)
        {
            // For a good time, call Pedro
        }
    }
}
