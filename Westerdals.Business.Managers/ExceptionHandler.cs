using System;
using Westerdals.Domain.Contracts;

namespace Westerdals.Business.Managers
{
    public class ExceptionHandler : IExceptionHandler
    {
        private readonly ILogger _logger;

        public ExceptionHandler(ILogger logger)
        {
            _logger = logger;
        }
        public T GetFromUnsafeMethod<T>(Func<T> unsafeFunction)
        {
            try
            {
                return unsafeFunction.Invoke();
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }
            return default(T);
        }

        public void RunUnsafeMethod(Action unsafeAction)
        {
            try
            {
                unsafeAction.Invoke();
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
            }
        }
    }
}
