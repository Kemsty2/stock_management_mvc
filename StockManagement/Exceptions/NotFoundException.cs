using System;

namespace StockManagement.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string msg) : base(msg) { }
    }
}