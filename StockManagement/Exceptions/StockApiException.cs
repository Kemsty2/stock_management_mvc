#nullable enable

using System;

namespace StockManagement.Exceptions
{
    public class StockApiException : Exception
    {
        public StockApiException(string? message) : base(message)
        {
        }
    }
}